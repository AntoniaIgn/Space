using Space.Functions;

namespace SpaceSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, dear user!\n" +
                                "In order to do our job, you have to give us some information. So in which language do you prefer to communicate?\n" +
                                "English/German (you can answer with the first letter only)");

            Dictionary<string, string> languageOptions = new() { { "e", "e" }, { "english", "e" }, { "g", "g" }, { "german", "g" } };
            string language;

            while (true)
            {
                language = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(language) || !languageOptions.ContainsKey(language))
                {
                    Console.WriteLine("Sorry, but this is invalid input. You can write just an 'e' for english and 'g' for german.");
                }
                else
                    break;
            }

            if (language == "e")
            {
                Console.WriteLine("Please, enter the path to or the name of the folder where you are storing the CSV files!");

                while (true)
                {
                    string folderPath = Console.ReadLine();

                    if (!string.IsNullOrEmpty(folderPath) || Directory.GetFiles(folderPath, "*.csv").Length > 0)
                        FileReader.ReadingCSVFile(folderPath);
                    else
                        Console.WriteLine("Sorry, but it looks like there is no csv files in this folder");
                }
            }
            else
            {
                Console.WriteLine("We can't speak German right now :)");
            }
        }
    }
}
