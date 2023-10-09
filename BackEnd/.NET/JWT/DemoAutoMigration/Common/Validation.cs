namespace DemoAutoMigration.Common
{
    public static class Validation
    {
        public static bool checkString(string? input)
        {
            try
            {
                input = input.Trim();
                return string.IsNullOrEmpty(input) && string.IsNullOrWhiteSpace(input);
            }
            catch
            {
                return false;
            }
        }
    }
}
