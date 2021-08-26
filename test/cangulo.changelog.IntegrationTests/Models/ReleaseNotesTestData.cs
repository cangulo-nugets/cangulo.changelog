namespace cangulo.changelog.IntegrationTests.Models
{
    public class TestDataBaseModel
    {
        public string Scenario { get; set; }
    }

    public static class PlaceholderConstants
    {
        public static string[] PLACEHOLDER_LIST = new string[] { DATE };
        public const string DATE = "{DATE}";
    }
}