using Space.Language;
using Space.Models;
using System.Text;

namespace Space.FileIO;

public class FileWriter
{
    public static string WriteSCVFile(List<Spaceport> spaceports, string fileFolderPath)
    {
        string fullFilePath = Path.Combine(fileFolderPath, @"Analysis\LaunchAnalysisReport.csv");
        string analysisFolderPath = Path.Combine(fileFolderPath, "Analysis");

        string separator = ",";
        string[] headings = [LangHelper.GetString("SpaceportLocation")!, LangHelper.GetString("BestDayLaunching")!];

        StringBuilder sb = new();
        sb.AppendLine(string.Join(separator, headings));

        foreach (Spaceport spaceport in spaceports)
        {
            string location = $"\"{spaceport.Location}\""; // keep the spaceport location as a pair despite it is comma separated
            string newLine = string.Format("{0}, {1}", location, spaceport.LaunchBestDate);
            sb.AppendLine(newLine);
        }

        try
        {
            if (!Directory.Exists(analysisFolderPath))
                Directory.CreateDirectory(analysisFolderPath);

            if (File.Exists(fullFilePath))
                File.Delete(fullFilePath);

            File.AppendAllText(fullFilePath, sb.ToString());
        }
        catch
        {
            Console.WriteLine($"\n{LangHelper.GetString("ReportNotSaved")}");
            return string.Empty;
        }

        Console.WriteLine($"\n{LangHelper.GetString("ReportSaved")}");

        return fullFilePath;
    }
}
