using Space.DataFilters;
using Space.Email;
using Space.FileIO;
using Space.Language;
using Space.Models;

namespace SpaceSolution;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"{LangHelper.GetString("Hello")}");

        Console.WriteLine("To change language to German enter 'de'. To continue in English press Enter.");
        string? language = Console.ReadLine();

        if (language is "de")
            LangHelper.ChangeLanguage(language);

        SpaceportsResponse response = FileReader.ReadFileData();

        List<Spaceport> spaceports = response.SpaceportsData.Keys.ToList();

        string filePath = FileWriter.WriteSCVFile(spaceports, response.FolderPath);

        if (string.IsNullOrEmpty(filePath))
            return;

        Spaceport spaceport = LocationSelector.GetBestLocationSpaceport(response.SpaceportsData);

        EmailSender.SendEmail(spaceport, filePath);

        Console.WriteLine($"\n{LangHelper.GetString("Thanks")}");
    }
}