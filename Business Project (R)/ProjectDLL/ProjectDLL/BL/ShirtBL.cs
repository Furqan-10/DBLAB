using ProjectDLL.DL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.BL
{
    public class ShirtBL : ProductBL
    {
        private readonly ProductDB productDB;

        public ShirtBL(ProductDB productDB) : base(productDB)
        {
            this.productDB = productDB;
        }
    }
}
