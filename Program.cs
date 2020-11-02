using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Reflection;

namespace czechCovid19APIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            foreach (var arg in args) {
                if (arg == "tests") {
                    await DisplayData("tests");
                }

                if (arg == "infected") {
                    await DisplayData("infected");
                }
                
            }
         }

        private static async Task<Tests> returnTestsData()
        {     
            var streamTask = client.GetStreamAsync(Tests.resource);
            var data = await JsonSerializer.DeserializeAsync<Tests>(await streamTask);
            return data;

        }
        private static async Task<Infected> returnInfectedData()
        {     
            var streamTask = client.GetStreamAsync(Infected.resource);
            var data = await JsonSerializer.DeserializeAsync<Infected>(await streamTask);
            return data;
            
        }

        private static async Task DisplayData(string dataToGet)
        {
            dynamic data = null;

            switch (dataToGet)
            {
                case "tests":
                    data = await returnTestsData();
                    break;
                
                case "infected":
                    data = await returnInfectedData();
                    break;
            }

            var dataset = data.Dataset;

            foreach (var item in dataset)
            {
                PropertyInfo[] props = item.GetType().GetProperties();

                foreach (PropertyInfo prop in props)
                {
                    Console.WriteLine(prop.GetValue(item));
                }
                Console.WriteLine("");
            }
        }
    }
}
