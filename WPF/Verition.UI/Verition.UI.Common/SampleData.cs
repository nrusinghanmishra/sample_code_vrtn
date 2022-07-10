using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verition.UI.Common
{
    public class SampleData
    {

        static object SyncRoot = new object();
        static List<string> customerNames = new List<string>();
        //static List<CategoryData> categoryData = new List<CategoryData>();
        //static List<ProductData> productData = new List<ProductData>();
        //static List<string> vehicleOrderTrademarks = new List<string>();





        public static List<VehicleOrder> GenerateVehicleOrders(int generateCount)
        {
            var rnd = new Random();
            var orders = new List<VehicleOrder>();

            //var model = models[rnd.Next(0, models.Count - 1)];
            orders.Add(new VehicleOrder(
                orderID: 1,
                discount: Math.Round(0.05 * rnd.Next(4), 2),
                salesDate: DateTime.Now.AddDays(-rnd.Next(400)),
                modelPrice: new Decimal(12390909.23),
                modelTrademarkName: "RAM",
                modelName: "3500 Regular",
                modelModification: "ST LBW 5.7 L",
                modelMPGCity: 13,
                modelMPGHighway: 18,
                modelCylinders: 4));
            orders.Add(new VehicleOrder(
               orderID: 2,
               discount: Math.Round(0.05 * rnd.Next(4), 2),
               salesDate: DateTime.Now.AddDays(-rnd.Next(400)),
               modelPrice: new Decimal(456788.00),
               modelTrademarkName: "Toyota",
               modelName: "Camry",
               modelModification: "XLE 3.5L V6",
               modelMPGCity: 13,
               modelMPGHighway: 18,
               modelCylinders: 4));

            return orders;
        }

        static List<string> vehicleOrderTrademarks = new List<string>();
        public static List<string> VehicleOrderTrademarks
        {
            get
            {
                if (vehicleOrderTrademarks.Count == 0)
                {
                    vehicleOrderTrademarks.Add("Ram");
                    vehicleOrderTrademarks.Add("Toyota");
                }
                return vehicleOrderTrademarks;
            }
        }
    }


    public class VehicleOrder
    {
        public VehicleOrder(int orderID, double discount, DateTime salesDate, decimal modelPrice, string modelTrademarkName, string modelName, string modelModification, int? modelMPGCity, int? modelMPGHighway, int modelCylinders)
        {
            OrderID = orderID;
            Discount = discount;
            SalesDate = salesDate;
            ModelPrice = modelPrice;
            ModelTrademarkName = modelTrademarkName;
            ModelName = modelName;
            ModelModification = modelModification;
            ModelMPGCity = modelMPGCity;
            ModelMPGHighway = modelMPGHighway;
            ModelCylinders = modelCylinders;
        }

        public int OrderID { get; set; }
        public double Discount { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal ModelPrice { get; set; }
        public string ModelTrademarkName { get; set; }
        public string ModelName { get; set; }
        public string ModelModification { get; set; }
        public int? ModelMPGCity { get; set; }
        public int? ModelMPGHighway { get; set; }
        public int ModelCylinders { get; set; }
    }
}

