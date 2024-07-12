using HttpClientDemo.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HttpClientDemo
{
    internal class Program
    {
        const string API_URL = "http://localhost:5000/api/";

        static async Task Main(string[] args)
        {
            int orderId = 11081;

            using (var client = new HttpClient())
            {
                var continueProgram = true;
                while (continueProgram)
                {
                    try
                    {
                        string? option = SelectAction(orderId);
                        switch (option)
                        {
                            case "1":
                                await GetOrders(client);
                                break;
                            case "2":
                                await GetOrdersByID(client, orderId);
                                break;
                            case "3":
                                orderId = await PostOrder(client);
                                break;
                            case "4":
                                await UpdateOrder(client, orderId);
                                break;
                            case "5":
                                await DeleteOrder(client, orderId);
                                break;
                            default:
                                continueProgram = false;
                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nException Caught!");
                        Console.WriteLine("Message :{0} ", e.Message);
                    }
                }
            }

            Console.WriteLine("Press any key to quit ...");
            Console.ReadLine();
        }

        private static string? SelectAction(int orderId)
        {
            Console.WriteLine($@"Select an option:
    1. Get Orders
    2. Get Orders by Id {orderId}
    3. Post new Order
    4. Update existing Order by Id {orderId}
    5. Delete Order by Id {orderId}

    0. Exit");

            var option = Console.ReadLine();
            return option;
        }

        private static async Task DeleteOrder(HttpClient client, int orderId)
        {
            var response = await client.DeleteAsync(API_URL + $"orders/{orderId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to delete order: {response.StatusCode} {response.ReasonPhrase}");
            }
        }

        private static async Task UpdateOrder(HttpClient client, int orderId)
        {
            var updateOrder = new Order
            {
                CustomerID = "ANTON",
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                ShipperID = 2,
                Freight = 100,
                ShipName = "Updated",
                ShipCountry = "Germany"
            };
            var json = JsonConvert.SerializeObject(updateOrder);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync(API_URL + $"orders/{orderId}", content);

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to update order: {response.StatusCode}\n {responseContent}");
            }
        }

        private static async Task<int> PostOrder(HttpClient client)
        {
            var newOrder = new Order
            {
                CustomerID = "ANTON",
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                ShipperID = 2,
                Freight = 100,
                ShipName = "ShipName",
                ShipCountry = "New Zealand"
            };
            var json = JsonConvert.SerializeObject(newOrder);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(API_URL + "orders", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<Order>(responseContent);

                Console.WriteLine($"Order {order.OrderID} created successfully");
                return order.OrderID;
            } 
            else
            {
                Console.WriteLine($"Failed to create order: {response.StatusCode}");
                return 0;
            }
        }

        private static async Task GetOrdersByID(HttpClient client, int orderId)
        {
            var response = await client.GetAsync(API_URL + $"orders/{orderId}");

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get order: {response.StatusCode} {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync();

            var order = JsonConvert.DeserializeObject<Order>(content);
            Console.WriteLine(order);
        }

        private static async Task GetOrders(HttpClient client)
        {
            var response = await client.GetAsync(API_URL + "orders?customerid=ANTON");
            var content = await response.Content.ReadAsStringAsync();

            var orders = JsonConvert.DeserializeObject<Order[]>(content) ?? [];
            Console.WriteLine(string.Join('\n', orders.Select(o => o.ToString())));
        }
    }
}
