using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Reflection;
using System.IO;

namespace czechCovid19APIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            foreach (var arg in args) {
                if (arg == "tests") {
                    await DisplayAndSaveData("tests");
                }

                if (arg == "infected") {
                    await DisplayAndSaveData("infected");
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

        private static async Task DisplayAndSaveData(string dataToGet)
        {
            dynamic data = null;

            switch (dataToGet)
            {
                case "tests":
                    data = await returnData("tests");
                    saveDataToJson("testsData.json", data);
                    break;
                
                case "infected":
                    data = await returnData("infected");
                    saveDataToJson("infectedData.json", data);
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

        private static async Task saveDataToJson(string filename, dynamic data)
        {
            using (FileStream fs = File.Create(filename))
            {
                await JsonSerializer.SerializeAsync(fs, data);
            }
        }
    }
}
