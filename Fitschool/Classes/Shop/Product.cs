using MySql.Data.MySqlClient;

namespace Fitschool.Classes.Shop
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Stock { get; private set; }
        public string ImageUrl { get; private set; }

        public Product(int id)
        {
            this.Id = id + 1; // +1 because the database starts at 1 instead of 0

            DataManagement dataManagement = new();
            string productData = dataManagement.ExecuteQuery("SELECT product_naam, product_prijs, product_voorraad, product_afbeelding FROM producten WHERE product_id = @id", new MySqlParameter("@id", Id));
            string[] productDataSplit = productData.Split(',');
            Name = productDataSplit[0];
            Price = Convert.ToInt32(productDataSplit[1]);
            Stock = Convert.ToInt32(productDataSplit[2]);
            ImageUrl = productDataSplit[3];
        }

        public bool InStock()
        {
            if (Stock > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveFromStock(int amount)
        {
            new DataManagement().ExecuteQuery("UPDATE producten SET product_voorraad = product_voorraad - @amount WHERE product_id = @id", new MySqlParameter("@id", Id), new MySqlParameter("@amount", amount));
        }
    }
}
