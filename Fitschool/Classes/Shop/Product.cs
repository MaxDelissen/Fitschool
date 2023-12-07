using MySql.Data.MySqlClient;

namespace Fitschool.Classes.Shop
{
    public class Product
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public int price { get; private set; }
        public int stock { get; private set; }

        public Product(int id)
        {
            this.id = id;
            name = DataManagement.ExecuteQuery("SELECT product_naam FROM producten WHERE product_id = @id", new MySqlParameter("@id", id));
            price = Convert.ToInt32(DataManagement.ExecuteQuery("SELECT product_prijs FROM producten WHERE product_id = @id", new MySqlParameter("@id", id)));
            stock = Convert.ToInt32(DataManagement.ExecuteQuery("SELECT product_voorraad FROM producten WHERE product_id = @id", new MySqlParameter("@id", id)));
        }

        public bool InStock()
        {
            if (stock > 0)
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
            DataManagement.ExecuteQuery("UPDATE producten SET product_voorraad = product_voorraad - @amount WHERE product_id = @id", new MySqlParameter("@id", id), new MySqlParameter("@amount", amount));
        }
    }
}
