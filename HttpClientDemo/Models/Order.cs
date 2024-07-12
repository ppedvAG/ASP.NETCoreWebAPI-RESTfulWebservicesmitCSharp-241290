namespace HttpClientDemo.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShipperID { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }

        public override string ToString()
        {
            return $"OrderID: {OrderID}\nCustomerID: {CustomerID}\nEmployeeID: {EmployeeID}\nOrderDate: {OrderDate}\nShipperID: {ShipperID}\nFreight: {Freight}\nShipName: {ShipName}\nShipCountry: {ShipCountry}";
        }
    }
}
