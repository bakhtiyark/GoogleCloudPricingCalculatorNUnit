namespace GoogleCloudPricingCalculatorNUnit.Core
{
    public class TestData
    {
        public const string SearchQuery = "Google Cloud Pricing Calculator"; 
        public string DeveloperMail { get; set; } = "https://www.developermail.com/";
        public string Tempail { get; set; } = "https://tempail.com/";
        public string TempMail { get; set; } = "https://temp-mail.org/en/";
        public string TenMinuteEmail { get; set; } = "https://10minutemail.com/";

        public Dictionary<string, string> Datalayer = new()
        {
            {"quantity", "4"},
            {"os", "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)"},
            {"class", "Regular"},
            {"series", "N1"},
            {"instance","n1-standard-8 (vCPUs: 8, RAM: 30GB)"},
            {"ssd", "2x375 GB"},
            {"location", "Netherlands (europe-west4)"},
            {"gpuType", "NVIDIA Tesla V100"},
            {"gpuCount", "2"},
            {"cud", "1 Year"},
            {"estimatedCost", "10,314.90"}

        };

        public string Access(string entry)
        {
            return Datalayer[entry];
        }
    }
}