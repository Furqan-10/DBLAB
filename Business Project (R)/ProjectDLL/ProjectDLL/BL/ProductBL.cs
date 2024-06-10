using ProjectDLL.DL.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.BL
{
    public class ProductBL
    {
        private readonly ProductDB productDB;

        public ProductBL(ProductDB productDB)
        {
            this.productDB = productDB;
        }
        private int ProductId;
        private string Color ;
        private int Quantity ;
        private decimal Price;

   
        public ProductBL(string color,int quantity,decimal price)
        {
            this.Color = color;
            this.Quantity = quantity;
            this.Price = price;
        }

        public void setColor(string Color)
        {
            this.Color = Color;
        }

        public string getColor()
        {
            return this.Color;
        }

        public void setQuantity(int Quantity)
        {
            this.Quantity = Quantity;
        }

        public int getQuantity()
        {
            return this.Quantity;
        }

        public void setPrice(decimal price)
        {
            this.Price = price;
        }

        public decimal getPrice()
        {
            return this.Price ;
        }


      

    }
}
