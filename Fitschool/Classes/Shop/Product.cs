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
            Name = DataManagement.ExecuteQuery("SELECT product_naam FROM producten WHERE product_id = @id", new MySqlParameter("@id", Id));
            Price = Convert.ToInt32(DataManagement.ExecuteQuery("SELECT product_prijs FROM producten WHERE product_id = @id", new MySqlParameter("@id", Id)));
            Stock = Convert.ToInt32(DataManagement.ExecuteQuery("SELECT product_voorraad FROM producten WHERE product_id = @id", new MySqlParameter("@id", Id)));
            ImageUrl = DataManagement.ExecuteQuery("SELECT product_afbeelding FROM producten WHERE product_id = @id", new MySqlParameter("@id", Id));
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
            DataManagement.ExecuteQuery("UPDATE producten SET product_voorraad = product_voorraad - @amount WHERE product_id = @id", new MySqlParameter("@id", Id), new MySqlParameter("@amount", amount));
        }
    }
}
