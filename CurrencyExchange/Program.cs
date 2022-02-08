using CurrencyExchange.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            string from, to = "";
            int amount = 0;
            DateTime? date = null;

            Console.WriteLine("Insert Currency FROM:");
            from = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Insert Currency TO:");
            to = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Insert amount({0}):", from);
            amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            Console.WriteLine("Insert Date:");
            date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("\n");

            var t = CallExchangeApi(from, to, date, amount);
            t.Wait();

            Console.WriteLine(t.Result);

            Console.ReadLine();
        }

        private static async Task<string> CallExchangeApi(string from, string to, DateTime? date, decimal amount)
        {
            var result = await GetExchangeRate(from, to, date);

            if (result.Success)
            {
                var finalAmount = result.Rates[to.ToString()] * amount;
                return $"{from} to {to} for amount {amount} = {finalAmount}";
            }
            else
                return "Unsuccessful";
        }

        private static async Task<ConvertResponse> GetExchangeRate(string from, string to, DateTime? date)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                                        Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "admin", "Pa$$WoRd"))));

            var url = $"https://currencyrateapi.azurewebsites.net/api/ExchangeRate/latest?from={from}&to={to}";

            if (date != null)
            {
                url += $"&date={date.Value.ToString("yyyy-MM-dd")}";
            }

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var repo = JsonConvert.DeserializeObject<ConvertResponse>(result);

                return repo;
            }

            throw new Exception($"Request failed ({response.StatusCode})");

        }
    }
}
