using System;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestApi
{
    class Program
    {
        private static HttpClient _client;
        private static string _server_url = "https://sandbox3.payture.com/api/Pay?";

        static async Task Main(string[] args)
        {
            var orderId = Guid.NewGuid().ToString();
            var amount = 1599;
            var payInfo = new PayInfo().SetPan("4011111111111112")
                .SetEMonth(10)
                .SetEYear(2021)
                .SetOrderId(orderId)
                .SetAmount(amount)
                .SetSecureCode(222)
                .SetCardHolder("Oleg Ivanov")
                .Create();
            var payReq = new PayRequest()
                .SetKey("Merchant")
                .SetOrderId(orderId)
                .SetAmount(amount)
                .SetPayInfo(payInfo)
                .Create();
            _client = new HttpClient();

            Console.WriteLine($"[{DateTime.Now:O}] Send request\n");

            try
            {
                var response = (await _client.GetAsync(_server_url + payReq)).Content.ReadAsStringAsync().Result;
                var serializer = new XmlSerializer(typeof(PayResponseXml));
                using TextReader reader = new StringReader(response);
                var result = serializer.Deserialize(reader);
                Console.WriteLine(result?.ToString());
                Console.WriteLine($"\n[{DateTime.Now:O}] Done");
            }
            catch (Exception e)
            {
                Console.WriteLine($"[{DateTime.Now}]" + e.Message);
            }

            Console.ReadKey();
        }
    }
}
