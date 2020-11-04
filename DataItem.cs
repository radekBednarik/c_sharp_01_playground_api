using System.Text.Json.Serialization;

namespace czechCovid19APIClient
{
    public class commonDataItem
    {
        [JsonPropertyName("datum")]
        public string Datum {get; set;}
    }
    public class DataItemTests : commonDataItem
    {
        [JsonPropertyName("prirustkovy_pocet_testu")]
        public int PrirustkovyPocetTestu { get; set; }

        [JsonPropertyName("kumulativni_pocet_testu")]
        public int KumulativniPocetTestu { get; set; }
    }
    public class DataItemInfected : commonDataItem
    {
        [JsonPropertyName("prirustkovy_pocet_nakazenych")]
        public int PrirustkovyPocetNakazenych { get; set; }

        [JsonPropertyName("kumulativni_pocet_nakazenych")]
        public int KumulativniPocetNakazenych { get; set; }
    }
}