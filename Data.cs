using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace czechCovid19APIClient
{
    public class commonData
    {
        
        [JsonPropertyName("modified")]
        public string Modified { get; set;}
                
        [JsonPropertyName("source")]
        public string Source { get; set; }
    }
    public class Tests : commonData
    {
        public static Uri resource = new Uri("https://onemocneni-aktualne.mzcr.cz/api/v2/covid-19/testy.json");

        [JsonPropertyName("data")]
        public List<DataItemTests> Dataset { get; set; }

    }

    public class Infected : commonData
    {
        public static Uri resource = new Uri("https://onemocneni-aktualne.mzcr.cz/api/v2/covid-19/nakaza.json");

        [JsonPropertyName("data")]
        public List<DataItemInfected> Dataset { get; set; }

    }
    
}
