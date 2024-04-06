using System.Text;

namespace Space.DataAccess
{
    internal class FileWriter
    {
        public static void WritingSCVFile(List<Spaceport> spaceports, string folderPath)
        {
            string fullFilePath = Path.Combine(
               folderPath,
               @"Analysis\LaunchAnalysisReport.csv"
           );

            string separator = ",";
            string[] headings = ["Spaceport Location", "Best date for launching"];
            StringBuilder sb = new();

            sb.AppendLine(string.Join(separator, headings));

            foreach (Spaceport spaceport in spaceports)
            {
                string location = $"\"{spaceport.Location}\"";
                string newLine = string.Format("{0}, {1}", location, spaceport.LaunchBestDate);
                sb.AppendLine(newLine);
            }

            try
            {
                if (File.Exists(fullFilePath))
                    File.Delete(fullFilePath);

                File.AppendAllText(fullFilePath, sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nCreating analysis report failed!"); 
                return;
            }

            Console.WriteLine("\nThe analysis report has been successfully saved to 'LaunchAnalysisReport.csv'.");
        }
    }
}
