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

        private static async Task<dynamic> returnData(string dataToGet)
        {
            dynamic streamTask;
            dynamic data;

            switch (dataToGet)
            {
                case "tests":
                    streamTask = client.GetStreamAsync(Tests.resource);
                    data = await JsonSerializer.DeserializeAsync<Tests>(await streamTask);
                    return data;
                case "infected":
                    streamTask = client.GetStreamAsync(Infected.resource);
                    data = await JsonSerializer.DeserializeAsync<Infected>(await streamTask);
                    return data;
            }

            return new object();
        }

        private static async Task DisplayData(string dataToGet)
        {
            dynamic data = null;

            switch (dataToGet)
            {
                case "tests":
                    data = await returnData("tests");
                    break;
                
                case "infected":
                    data = await returnData("infected");
                    break;
            }

            var dataset = data.Dataset;

            foreach (var item in dataset)
            {
                PropertyInfo[] props = item.GetType().GetProperties();

                foreach (PropertyInfo prop in props)
                {
                    Console.WriteLine($"{prop.Name}: {prop.GetValue(item)}");
                }
                Console.WriteLine("");
            }
        }
    }
}
