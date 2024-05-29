namespace MyApiClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Enter a word to get its definition:");
            string word = Console.ReadLine();

            ApiClient client = new ApiClient();
            var getResponse = await client.GetWordDefinitionAsync(word);
            Console.WriteLine(getResponse.Message);
            if (getResponse.Data != null)
            {
                foreach (var definition in getResponse.Data)
                {
                    Console.WriteLine($"{definition.PartOfSpeech}: {definition.Text}");
                }
            }
        }
    }
}
