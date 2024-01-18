using Fitschool.Forms;
using QRCoder;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace Fitschool.Classes
{
    public class Card
    {
        public User User { get; set; }

        public enum CardDesigns
        {
            panda,
            poes,
            giraffe,
            eekhoorn,
            miereneter,
            rodePanda,
            schatkaart
        }

        public Card(User User)
        {
            this.User = User;
        }

        public Bitmap GenerateCard(CardDesigns design)
        {
            Bitmap card = new Bitmap(getPath(design));

            int CoordsX = 21; int CoordsY = 60;
            if (design == CardDesigns.schatkaart)
            {
                CoordsX = 225; CoordsY = 23;
            }

            Bitmap qr = GenerateQR();

            try
            {
                using (Graphics graphics = Graphics.FromImage(card))
                {
                    graphics.CompositingMode = CompositingMode.SourceOver;
                    graphics.DrawImage(qr, new Point(CoordsX, CoordsY));

                    // Define text properties (font, brush, etc.)
                    Font textFont = new("Arial", 18, FontStyle.Bold);
                    Brush textBrush = Brushes.White;

                    // Create StringFormat for center alignment
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;

                    int textWidth = card.Width - 20; // Width of the text area (20px padding on each side)
                    int textHeight = 50; // Height of the text area (50 is enough for 2 lines of text)
                    int textX = (card.Width - textWidth) / 2; // X coordinate of the text area (centered horizontally)
                    int textY = 150; // Y coordinate of the text area (below image)

                    if (design == CardDesigns.schatkaart)
                    {
                        textX = 12; textY = 12;
                        stringFormat.Alignment = StringAlignment.Near;
                        stringFormat.LineAlignment = StringAlignment.Near;
                        textBrush = Brushes.Black;
                        textFont = new Font("", 18, FontStyle.Bold);
                    }

                    RectangleF textRect = new RectangleF(textX, textY, textWidth, textHeight);


                    // Draw the 'name' text onto the card
                    graphics.DrawString(User.Name, textFont, textBrush, textRect, stringFormat);
                }
                DataManagement.Log("Card generated successfully");
            }
            catch (Exception ex)
            {
                DataManagement.Log($"Error generating card: {ex.Message}");
                new FormMessageBox("Er ging iets mis met het maken van de pas. Er is geen pas gemaakt", "Fout");
            }
            finally
            {
                qr?.Dispose(); // Dispose the QR code image
            }
            return card;
        }

        private Bitmap GenerateQR()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(User.Id.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5, Color.Black, Color.White, true);
            DataManagement.Log("QR code generated");
            return qrCodeImage;
        }

        private string getPath(CardDesigns design) //kan online?!
        {
            string path;
            path = design switch
            {
                CardDesigns.panda => "panda.png",
                CardDesigns.poes => "kat.png",
                CardDesigns.giraffe => "giraffe.png",
                CardDesigns.eekhoorn => "eekhoorn.png",
                CardDesigns.miereneter => "miereneter.png",
                CardDesigns.rodePanda => "rodePanda.png",
                CardDesigns.schatkaart => "schatkaart.png",
                _ => "default.png"
            };

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string templateFilePath = Path.Combine(appDirectory, "Templates", path);

            return templateFilePath;
        }

        public void SaveCard(Bitmap card)
        {
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "PNG Image|*.png";
            saveFileDialog.Title = "Waar wil je de pas opslaan?";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = $"Pas {User.Name}";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                DataManagement.Log("Saving card");
                string fileName = saveFileDialog.FileName;

                if (fileName != "")
                {
                    try
                    {
                        card.Save(fileName, ImageFormat.Png);
                        DataManagement.Log("Card saved successfully");
                    }
                    catch (Exception ex)
                    {
                        DataManagement.Log($"Error saving card: {ex.Message}");
                        new FormMessageBox("Er is een fout opgetreden tijdens het opslaan van de pas.", "Fout");
                    }
                }
            }
        }


        public void PrintCard(Bitmap card)
        {
            DataManagement.Log("Printing card");
            PrintDocument printDocument = new();
            printDocument.PrintPage += (sender, e) =>
            {
                if (e == null)
                {
                    return;
                }
                RectangleF printArea = e.MarginBounds;

                // Calculate the position to maintain the original aspect ratio
                float imageWidth = card.Width;
                float imageHeight = card.Height;

                float maxWidth = printArea.Width;
                float maxHeight = printArea.Height;

                float aspectRatio = imageWidth / imageHeight;
                float adjustedWidth = maxWidth;
                float adjustedHeight = adjustedWidth / aspectRatio;

                if (adjustedHeight > maxHeight)
                {
                    adjustedHeight = maxHeight;
                    adjustedWidth = adjustedHeight * aspectRatio;
                }

                float x = (maxWidth - adjustedWidth) / 2;
                float y = (maxHeight - adjustedHeight) / 2;

                RectangleF destinationRect = new RectangleF(x, y, adjustedWidth, adjustedHeight);
                RectangleF sourceRect = new RectangleF(0, 0, imageWidth, imageHeight);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                e.Graphics.DrawImage(card, destinationRect, sourceRect, GraphicsUnit.Pixel);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    // Start the printing process
                    printDocument.Print();
                    DataManagement.Log("Card send to printer successfully");
                }
                catch (Exception ex)
                {
                    DataManagement.Log("Printing failed: " + ex.Message);
                }
            }
        }
    }
}
