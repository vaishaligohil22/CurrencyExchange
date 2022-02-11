using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CurrencyExchangeTF
{
    public static class CurrencyExchange
    {
        // {second=0} {minute=1} {hour=10} {day} {month} {day-of-week=(2=Tuesday)}
        private const string TimerSchedule = "0 30 10 * * *";
        private static HttpClient _client = new HttpClient();

        [FunctionName("CurrencyExchange")]
        public static async Task RunAsync([TimerTrigger(TimerSchedule)]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Tiggering Blog rebuild at: {DateTime.Now}");
            
            var latestRate = new ExhangeRateRequest
            {
                From = Environment.GetEnvironmentVariable("FromCurrency"),
                To = Environment.GetEnvironmentVariable("ToCurrency"),
                Date = DateTime.Now
            };

            var itemJson = new StringContent(JsonSerializer.Serialize(latestRate), Encoding.UTF8, "application/json");

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                                        Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "admin", "Pa$$WoRd"))));

            var result = await _client.PostAsync(Environment.GetEnvironmentVariable("ApiUrl"), itemJson);
            var response = await result.Content.ReadAsStringAsync();

            log.LogInformation($"Result from api call is:" + response);

            log.LogInformation($"Blog rebuild triggered successfully at: {DateTime.Now}");
        }
    }

    public class ExhangeRateRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
    }
}
