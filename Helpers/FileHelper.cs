using System.IO;

namespace Inventory_managment.Helpers
{
    public class FileHelper
    {
        public static List<string> ReadCodesFromFile(string filePath)
        {
            List<string> codes = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string? line = reader.ReadLine();

                        if (line != null)
                            codes.Add(line.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading codes from file: {ex.Message}");
            }

            return codes;
        }

        public static void WriteAllText(string filePath, string json)
        {
            File.WriteAllText(filePath, json);
        }
    }
}