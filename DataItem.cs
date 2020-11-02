using System.Text.Json.Serialization;

namespace czechCovid19APIClient
{
    public class DataItemTests
    {
        [JsonPropertyName("datum")]
        public string Datum {get; set;}

        [JsonPropertyName("prirustkovy_pocet_testu")]
        public int PrirustkovyPocetTestu { get; set; }

        [JsonPropertyName("kumulativni_pocet_testu")]
        public int KumulativniPocetTestu { get; set; }
    }
    public class DataItemInfected
    {
        [JsonPropertyName("datum")]
        public string Datum {get; set;}

        [JsonPropertyName("prirustkovy_pocet_nakazenych")]
        public int PrirustkovyPocetNakazenych { get; set; }

        [JsonPropertyName("kumulativni_pocet_nakazenych")]
        public int KumulativniPocetNakazenych { get; set; }
    }
}