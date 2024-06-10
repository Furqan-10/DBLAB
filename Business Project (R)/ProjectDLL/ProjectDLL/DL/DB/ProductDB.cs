using ProjectDLL.BL;
using ProjectDLL.DLInterfaces;
using ProjectDLL.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectDLL.DL.DB
{
    public class ProductDB : IProductDL,IProducts
    {
        private string connectionString;

        public ProductDB(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool IsValidShoeType(string type)
        {

            string[] validTypes = { "sneakers", "grippers", "slides", "studs" };
            return Array.Exists(validTypes, t => t.Equals(type, StringComparison.OrdinalIgnoreCase));
        }

        public bool IsValidShoeSize(int size)
        {
            return size >= 32 && size <= 47;
        }

        public bool IsValidShoeColor(string color)
        {
            string[] validColors = { "red", "green", "blue" };
            return Array.Exists(validColors, c => c.Equals(color, StringComparison.OrdinalIgnoreCase));
        }
        public bool IsValidShirtSleeve(string sleeve)
        {
      
            string[] validSleeve = { "Half", "Full" };
            return Array.Exists(validSleeve, c => c.Equals(sleeve, StringComparison.OrdinalIgnoreCase));
        }
        public bool IsValidShirtMaterial(string material)
        {
        
            string[] validMaterial = { "fabric", "silk", "cotton" };
            return Array.Exists(validMaterial, c => c.Equals(material, StringComparison.OrdinalIgnoreCase));
        }
        private bool IsValidPrice(decimal price)
        {
            return price > 0;
        }
        private bool IsValidquantity(int quantity)
        {
            return quantity > 0;
        }

        public bool IsValidShirtSize(string size)
        {
            string[] validSize = { "S", "M", "L", "XL" };
            return Array.Exists(validSize, t => t.Equals(size, StringComparison.OrdinalIgnoreCase));
        }

        public bool IsValidShirtColor(string color)
        {
            string[] validColors = { "red", "green", "blue" };
            return Array.Exists(validColors, c => c.Equals(color, StringComparison.OrdinalIgnoreCase));
        }
        public void AddShirt(string material, string sleeve, string size, string color, int quantity, decimal price)
        {
           
            if (!IsValidShirtMaterial(material))
            {
                throw new ArgumentException("Invalid shirt Material (fabric,silk,cotton).");
            }
            if (!IsValidShirtSize(size))
            {
                throw new ArgumentException("Invalid shirt size (Only S,M,L,XL).");
            }

            if (!IsValidShirtSleeve(sleeve))
            {
                throw new ArgumentException("Invalid shirt sleeve (Only half and full).");
            }
            if (!IsValidPrice(price))
            {
                throw new ArgumentException("Invalid Price (Enter positive value");

            }
            if (!IsValidquantity(quantity))
            {
                throw new ArgumentException("Invalid quantity (Enter positive value");
            }

            if (!IsValidShirtColor(color))
            {
                throw new ArgumentException("Invalid shirt color (Only red, green, blue.");
            }
            string query = "INSERT INTO Shirts (Material, Sleeve, Size, Color, Quantity, Price) VALUES (@Material, @Sleeve, @Size, @Color, @Quantity, @Price)";

          
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

     
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Material", material);
                    command.Parameters.AddWithValue("@Sleeve", sleeve);
                    command.Parameters.AddWithValue("@Size", size);
                    command.Parameters.AddWithValue("@Color", color);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);                
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AddShoe(string type, string name, int size, string color, int quantity, decimal price)
        {
         
            if (!IsValidShoeType(type))
            {
                throw new ArgumentException("Invalid shoe type (sneakers, grippers, slides, studs).");
            }

            if (!IsValidShoeSize(size))
            {
                throw new ArgumentException("Invalid shoe size (only from 32-47.");
            }

            if (!IsValidShoeColor(color))
            {
                throw new ArgumentException("Invalid shoe color (Only red, green, blue.");
            }
            if (!IsValidPrice(price))
            {
                throw new ArgumentException("Invalid Price (Enter positive value");

            }
            if (!IsValidquantity(quantity))
            {
                throw new ArgumentException("Invalid quantity (Enter positive value");
            }

            string query = "INSERT INTO Shoes (Type, Name, Size, Color, Quantity, Price) VALUES (@Type, @Name, @Size, @Color, @Quantity, @Price)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Size", size);
                    command.Parameters.AddWithValue("@Color", color);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    command.ExecuteNonQuery();
                }
            }


        }
        public  List<ShoeBL> getAllShoes()
        {
            List<ShoeBL> shoelist=new List<ShoeBL>();


                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Type,Name,Size,Color,Quantity,Price FROM Shoes";
                    SqlCommand command = new SqlCommand(query, connection);


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string type = reader["Type"].ToString();
                        string name = reader["Name"].ToString();
                        int Size = int.Parse(reader["Size"].ToString());
                        string color = reader["Color"].ToString();
                        int quantity = int.Parse(reader["Quantity"].ToString());
                        decimal price = decimal.Parse(reader["Price"].ToString());
                        ShoeBL shoe = new ShoeBL(type,name,Size,color,quantity,price);
                        shoelist.Add(shoe);
                       
                    }
                }
           
           
            return shoelist;
        }
        public DataTable ShowAllShirts()
        {
            DataTable shirtData = new DataTable();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Shirts";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(shirtData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return shirtData;
        }
        public bool UpdateShoe(string name, int quantity, decimal price)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Shoes SET Quantity = @Quantity, Price = @Price WHERE Name = @name";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public bool UpdateShirt(int shirtID, int quantity, decimal price)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Shirts SET Quantity = @Quantity, Price = @Price WHERE ShirtID = @ShirtID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ShirtID", shirtID);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public void DeleteShoe(string name)
        {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Shoes WHERE Name = @name";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", name);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception($"No shoe found with ID {name}.");
                    }
                }
            
        }
        public void DeleteShirt(int shirtID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Shirts WHERE ShirtID = @ShirtID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ShirtID", shirtID);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception($"No shirt found with ID {shirtID}.");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to delete shirt.", ex);
            }
        }
        public bool AddToShoeCart(int shoeid, int quantity, decimal price)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Shoes WHERE ShoeID = @Name";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Name", shoeid );
                    int shoeExists = (int)checkCommand.ExecuteScalar();

                    if (shoeExists == 0)
                    {
                        throw new Exception("The shoe with the provided name does not exist.");
                    }
                    string insertQuery = "INSERT INTO ShoeCart (ShoeID, Quantity, Price) VALUES (@ShoeID, @Quantity, @Price)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@ShoeID", shoeid);
                    insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                    insertCommand.Parameters.AddWithValue("@Price", quantity*price);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    bool result=DecreaseShoeQuantity(shoeid, quantity);
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public bool AddToShirtCart(int shirtID, int quantity, decimal price)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Shirts WHERE ShirtID = @ShirtID";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@ShirtID", shirtID);
                    int shirtExists = (int)checkCommand.ExecuteScalar();

                    if (shirtExists == 0)
                    {
                        throw new Exception("The shirt with the provided ID does not exist.");
                    }


                    string insertQuery = "INSERT INTO ShirtCart (ShirtID, Quantity, Price) VALUES (@ShirtID, @Quantity, @Price)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@ShirtID", shirtID);
                    insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                    insertCommand.Parameters.AddWithValue("@Price", price*quantity);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    bool result = DecreaseShirtQuantity(shirtID, quantity);
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }


        }



        public decimal GetShoePrice(int shoeID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Price FROM Shoes WHERE ShoeID = @ShoeID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ShoeID", shoeID);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1;
            }
        }

        public decimal GetShirtPrice(int shirtID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Price FROM Shirts WHERE ShirtID = @ShirtID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ShirtID", shirtID);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
   
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1;
            }
        }


        public DataTable GetShoeCart()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM ShoeCart";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable shoeCartTable = new DataTable();
                    adapter.Fill(shoeCartTable);

                    return shoeCartTable;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public DataTable GetShirtCart()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();              
                    string query = "SELECT * FROM ShirtCart";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable shirtCartTable = new DataTable();
                    adapter.Fill(shirtCartTable);

                    return shirtCartTable;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public bool DeleteFromShoeCart(int shoeID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM ShoeCart WHERE ShoeID = @ShoeID";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@ShoeID", shoeID);
                    int shoeExists = (int)checkCommand.ExecuteScalar();

                    if (shoeExists == 0)
                    {
                        throw new Exception("The shoe with the provided ID does not exist in the cart.");
                    }

                    string deleteQuery = "DELETE FROM ShoeCart WHERE ShoeID = @ShoeID";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@ShoeID", shoeID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public bool DeleteFromShirtCart(int shirtID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM ShirtCart WHERE ShirtID = @ShirtID";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@ShirtID", shirtID);
                    int shirtExists = (int)checkCommand.ExecuteScalar();

                    if (shirtExists == 0)
                    {
                        throw new Exception("The shirt with the provided ID does not exist in the cart.");
                    }
                    string deleteQuery = "DELETE FROM ShirtCart WHERE ShirtID = @ShirtID";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@ShirtID", shirtID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public decimal CalculateTotalPayableAmount()
        {
            decimal totalAmount = 0;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string shoeCartQuery = "SELECT SUM(Price) FROM ShoeCart";
                    SqlCommand shoeCartCommand = new SqlCommand(shoeCartQuery, connection);
                    object shoeCartTotal = shoeCartCommand.ExecuteScalar();
                    if (shoeCartTotal != null && shoeCartTotal != DBNull.Value)
                    {
                        totalAmount += Convert.ToDecimal(shoeCartTotal);
                    }

                    string shirtCartQuery = "SELECT SUM(Price) FROM ShirtCart";
                    SqlCommand shirtCartCommand = new SqlCommand(shirtCartQuery, connection);
                    object shirtCartTotal = shirtCartCommand.ExecuteScalar();
                    if (shirtCartTotal != null && shirtCartTotal != DBNull.Value)
                    {
                        totalAmount += Convert.ToDecimal(shirtCartTotal);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return totalAmount;
        }

        public bool EmptyCartTables()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

   
                    string emptyShoeCartQuery = "DELETE FROM ShoeCart";
                    SqlCommand emptyShoeCartCommand = new SqlCommand(emptyShoeCartQuery, connection);
                    emptyShoeCartCommand.ExecuteNonQuery();
                    string emptyShirtCartQuery = "DELETE FROM ShirtCart";
                    SqlCommand emptyShirtCartCommand = new SqlCommand(emptyShirtCartQuery, connection);
                    emptyShirtCartCommand.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public bool AddFeedback(string customerName, string email, string feedbackText, int rating)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Feedback (CustomerName, Email, FeedbackText, Rating, DateSubmitted) " +
                                         "VALUES (@CustomerName, @Email, @FeedbackText, @Rating, GETDATE())";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@CustomerName", customerName);
                    insertCommand.Parameters.AddWithValue("@Email", email);
                    insertCommand.Parameters.AddWithValue("@FeedbackText", feedbackText);
                    insertCommand.Parameters.AddWithValue("@Rating", rating);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public DataTable GetFeedback()
        {
            DataTable feedbackTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Feedback";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(feedbackTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving feedback: {ex.Message}");
            }

            return feedbackTable;
        }


        public bool DecreaseShirtQuantity(int productId, int quantityToDecrease)
        {
            
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE Shirts  SET Quantity = Quantity - @QuantityToDecrease WHERE ShirtID = @ProductID";      
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@QuantityToDecrease", quantityToDecrease);
                    command.Parameters.AddWithValue("@ProductID", productId);                 
                    int rowsAffected = command.ExecuteNonQuery();                 
                    return rowsAffected > 0;
                }
            
        
        }
        public int giveMeshirts()
        {
            int result = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = $"SELECT Quantity FROM Shirts";
                SqlCommand command = new SqlCommand(selectQuery, connection);
                object scalarResult = command.ExecuteScalar();
                if (scalarResult != null && scalarResult != DBNull.Value)
                {
                    result = Convert.ToInt32(scalarResult);
                    return result;
                }
                return result;
            }
        }
        public bool DecreaseShoeQuantity(int productId, int quantityToDecrease)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Shoes  SET Quantity = Quantity - @QuantityToDecrease WHERE ShoeID = @ProductID";
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@QuantityToDecrease", quantityToDecrease);
                command.Parameters.AddWithValue("@ProductID", productId);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }


        }

        

        public int giveMeshoes()
        {
            int result = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = $"SELECT Quantity FROM Shoes";
                SqlCommand command = new SqlCommand(selectQuery, connection);
                object scalarResult = command.ExecuteScalar();
                if (scalarResult != null && scalarResult != DBNull.Value)
                {
                    result = Convert.ToInt32(scalarResult);
                    return result;
                }
                return result;
            }
        }

        public bool getAllnames(string nameToCheck)
        {
            List<string> shoelist = new List<string>();


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Name FROM Shoes";
                SqlCommand command = new SqlCommand(query, connection);

                
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    string name = reader["Name"].ToString();
            
                    shoelist.Add(name);

                }
            }

            if (shoelist.Contains(nameToCheck))
            {
                return false;
            }
            return true;
        }

        public int getCustomerId(string name)
        {

            string idQuery = "SELECT ShoeId FROM Shoes WHERE Name = @name;";

            int userId = -1;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand idCommand = new SqlCommand(idQuery, connection);
            idCommand.Parameters.AddWithValue("@name", name);
            object idResult = idCommand.ExecuteScalar();
            if (idResult != null && int.TryParse(idResult.ToString(), out userId))
            {
                connection.Close();
                return userId;
            }
            else
            {
                connection.Close();
                return 0;
            }
        }
    }
}
