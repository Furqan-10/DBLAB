using ProjectDLL.DL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.BL
{
    public class ShoeBL : ProductBL
    {
        private readonly ProductDB productDB;
        private string type;
        private string name;
        private int Size;

        public ShoeBL(ProductDB productDB) : base(productDB)
        {
            this.productDB = productDB;
        }
        public ShoeBL(string type, string name, int size, string color, int quantity, decimal price):base(color, quantity, price)
        {
            this.type=type;
            this.name=name;
            this.Size=size;
        }

        public string getType() {
         return this.type;
        }
        public void setType(string type)
        {
            this.type = type;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string name) { 
            this.name = name;
        }

        public int getSize()
        {
            return this.Size;
        }

        public void setSize(int size)
        {
            this.Size = size;
        }
    }

}
