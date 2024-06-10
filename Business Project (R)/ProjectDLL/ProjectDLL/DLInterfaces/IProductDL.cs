using ProjectDLL.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DLInterfaces
{
    public interface IProductDL
    {
        int giveMeshoes();

        bool DecreaseShoeQuantity(int productId, int quantityToDecrease);

        int giveMeshirts();

        bool DecreaseShirtQuantity(int productId, int quantityToDecrease);

        DataTable GetFeedback();

        bool AddFeedback(string customerName, string email, string feedbackText, int rating);

        bool EmptyCartTables();

        decimal CalculateTotalPayableAmount();

        bool DeleteFromShirtCart(int shirtID);

        bool DeleteFromShoeCart(int shoeID);

        DataTable GetShirtCart();

        decimal GetShirtPrice(int shirtID);

        decimal GetShoePrice(int shoeID);

        bool AddToShirtCart(int shirtID, int quantity, decimal price);

        bool AddToShoeCart(int shoeID, int quantity, decimal price);


        void AddShirt(string material, string sleeve, string size, string color, int quantity, decimal price);


        DataTable ShowAllShirts();
        DataTable GetShoeCart();

        bool UpdateShirt(int shirtID, int quantity, decimal price);


        void DeleteShirt(int shirtID);



        int getCustomerId(string name);





        bool IsValidShirtColor(string color);

        bool IsValidShirtSize(string size);

        bool IsValidShirtMaterial(string material);

        bool IsValidShirtSleeve(string sleeve);

        bool IsValidShoeColor(string color);

        bool IsValidShoeSize(int size);

        bool IsValidShoeType(string type);

        bool getAllnames(string nameToCheck);
    }
}
