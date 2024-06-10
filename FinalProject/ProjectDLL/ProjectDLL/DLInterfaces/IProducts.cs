using ProjectDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DLInterfaces
{
    public interface IProducts
    {
        List<ShoeBL> getAllShoes();

        void DeleteShoe(string name);

        bool UpdateShoe(string name, int quantity, decimal price);

        void AddShoe(string type, string name, int size, string color, int quantity, decimal price);
    }
}
