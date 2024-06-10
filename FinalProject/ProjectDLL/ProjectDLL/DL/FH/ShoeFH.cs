using ProjectDLL.BL;
using ProjectDLL.DLInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DL.FH
{
    public class ShoeFH : IProducts
    {
        public void AddShoes(string type, string name, int size, string color, int quantity, decimal price)
        {
            string filePath = "Shoes.txt";

            string shoeData = $"{type},{name},{size},{color},{quantity},{price}";

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(shoeData);
            }

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
        public void AddShoe(string type, string name, int size, string color, int quantity, decimal price)
        {


            string filePath = "Shoes.txt"; 
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{type},{name},{size},{color},{quantity},{price}");
            }

            Console.WriteLine("Product added successfully");

        }

        public List<ShoeBL> getAllShoes()
        {


            List<ShoeBL> shoes = new List<ShoeBL>();

            try
            {
                using (StreamReader reader = new StreamReader("Shoes.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 6)
                        {
                            string type = parts[0];
                            string name = parts[1];
                            int size = int.Parse(parts[2]);
                            string color = parts[3];
                            int quantity = int.Parse(parts[4]);
                            decimal price = decimal.Parse(parts[5]);

                            ShoeBL shoe = new ShoeBL(type, name, size, color, quantity, price);
                            shoes.Add(shoe);
                        }
                        else
                        {
                            Console.WriteLine("Invalid data format in file");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading file: {ex.Message}");
            }

            return shoes;
        }



        public void DeleteShoe(string name)
        {
            List<ShoeBL> shoes = getAllShoes();
            if (shoes.Count == 1 && shoes[0].getName() == name)
            {
                shoes.Clear();
                writeshoes(shoes);
            }
            else
            {
                for (int i = 0; i < shoes.Count; i++)
                {
                    if (shoes[i].getName() == name)
                    {
                        shoes.RemoveAt(i);
                        writeshoes(shoes);
                        Console.WriteLine("Shoe has been removed");
                        break;
                    }
                }

            }

        }

        public bool UpdateShoe(string name, int quantity, decimal price)
        {
            List<ShoeBL> shoes = getAllShoes();
            foreach (ShoeBL sho in shoes)
            {
                if (name == sho.getName())
                {
                    sho.setQuantity(quantity);
                    sho.setPrice(price);
                }
            }
            writeshoes(shoes);

            return true;
        }

        public void writeshoes(List<ShoeBL> shoelist)
        {
            


            string filePath = "Shoes.txt"; 
            if(shoelist.Count < 1)
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.Write("");
                }
            }
            else
            {

            foreach (ShoeBL sho in shoelist)
            {

                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine($"{sho.getType()},{sho.getName()},{sho.getSize()},{sho.getColor()},{sho.getQuantity()},{sho.getPrice()}");
                }
            }
            }
        




        }
    }
}
