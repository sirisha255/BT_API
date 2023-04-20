using MySql.Data.MySqlClient;

namespace BT_API.Models
{
    public class ProductContext : IProductContext
    {
        public ProductResponse Add(Product item)
        {
            ProductResponse response = new ProductResponse();
            SqlManager sql = new SqlManager();
            if (!sql.Connect("server=gsw.dnsalias.net;uid=brandtransparency;" +
                             "pwd=db23/M3rm2EA;database=brandtransparency"))
            {
                Console.WriteLine("Failed to connect to the database!");
            }
            Console.WriteLine("Connect to the database was successful.\n");
            int i = sql.ExecuteQuery("INSERT INTO product(Barcode,Marking,Description,Origin,Manufacturer,ProductName,CO2,Id) values ('" + item.Barcode + "','" + item.Marking + "','" + item.Description + "','" + item.Origin + "','" + item.Manufacturer + "','" + item.Productname + "','" + item.Co2 + "','"+ item.Id +"' )");
            if (i < 0)
            {
                response.Status = false;
                response.Error = new Error { ErrorMessage = "Unable to save the record. Please try again." };
            }
            else
            {
                response.Status = true;
            }
            return response;
        }

        public ProductResponse GetById(int id)
        {
            ProductResponse response = new ProductResponse();
            Product product = new Product();
            SqlManager sql = new SqlManager();
            if (!sql.Connect("server=gsw.dnsalias.net;uid=brandtransparency;" +
                             "pwd=db23/M3rm2EA;database=brandtransparency"))
            {
                Console.WriteLine("Failed to connect to the database!");
            }
            Console.WriteLine("Connect to the database was successful.\n");
            response.Product = new Product();
            try
            {
                MySqlCommand cmd = sql.GetSqlCommand("SELECT * FROM product where id = " + id);

                sql.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product = new Product();
                        product.Barcode = reader.GetString("BarCode");
                        product.Marking = reader.GetInt32("Marking");
                        product.Description = reader.GetString("Description");
                        product.Origin = reader.GetString("Origin");
                        product.Manufacturer = reader.GetString("Manufacturer");
                        product.Productname = reader.GetString("Productname");
                        product.Co2 = reader.GetString("Co2");
                        product.Id = reader.GetInt32("Id");
                    }
                }
                response.Product = product;
                response.Status = true;         
            }
            catch (Exception ex)
            {
                response.Status = false; response.Error = new Error { ErrorMessage = "Unable to retrieve the records." + ex.Message };
            }

            return response;
        }

        public ProductResponse GetAll()
        {
            ProductResponse response = new ProductResponse();
            Product product = new Product();
            List<Product> products = new List<Product>();
            SqlManager sql = new SqlManager();
            if (!sql.Connect("server=gsw.dnsalias.net;uid=brandtransparency;" +
                             "pwd=db23/M3rm2EA;database=brandtransparency"))
            {
                Console.WriteLine("Failed to connect to the database!");
            }
            Console.WriteLine("Connect to the database was successful.\n");
            response.Products = new List<Product>();
            try
            {
                MySqlCommand cmd = sql.GetSqlCommand("SELECT * FROM product");

                sql.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product = new Product();
                        product.Barcode = reader.GetString("Barcode");
                        product.Marking = reader.GetInt32("Marking");
                        product.Description = reader.GetString("Description");
                        product.Origin = reader.GetString("Origin");
                        product.Manufacturer = reader.GetString("Manufacturer");
                        product.Productname = reader.GetString("Productname");
                        product.Co2 = reader.GetString("CO2");
                        product.Id = reader.GetInt32("Id");
                        products.Add(product);
                    }
                }
                response.Products = products;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false; response.Error = new Error { ErrorMessage = "Unable to retrieve the records." + ex.Message };
            }

            return response;
        }

        public ProductResponse Delete(int id)
        {
            ProductResponse response = new ProductResponse();
            SqlManager sql = new SqlManager();
            if (!sql.Connect("server=gsw.dnsalias.net;uid=brandtransparency;" +
                             "pwd=db23/M3rm2EA;database=brandtransparency"))
            {
                Console.WriteLine("Failed to connect to the database!");
            }
            Console.WriteLine("Connect to the database was successful.\n");
            int i = sql.ExecuteQuery("DELETE FROM product where Id=" + id);
            if (i < 0)
            {
                response.Status = false;
                response.Error = new Error { ErrorMessage = "Unable to delete the record. Please try again." };
            }
            else
            {
                response.Status = true;
            }
            return response;
        }

        public ProductResponse Update(Product item)
        {
            ProductResponse response = new ProductResponse();
            SqlManager sql = new SqlManager();
            if (!sql.Connect("server=gsw.dnsalias.net;uid=brandtransparency;" +
                             "pwd=db23/M3rm2EA;database=brandtransparency"))
            {
                Console.WriteLine("Failed to connect to the database!");
            }
            Console.WriteLine("Connect to the database was successful.\n");
            int i = sql.ExecuteQuery("UPDATE product set productname='" + item.Productname + "',manufacturer='" + item.Manufacturer + "',barcode='" + item.Barcode + "',description='" + item.Description + "',co2 = '" + item.Co2 + "',marking='" + item.Marking + "',origin='" + item.Origin + "' where id= '" + item.Id + "';");
            if (i < 0)
            {
                response.Status = false;
                response.Error = new Error { ErrorMessage = "Unable to update the record. Please try again." };
            }
            else
            {
                response.Status = true;
            }
            return response;
        }

    }
}
