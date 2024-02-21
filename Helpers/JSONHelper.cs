using Newtonsoft.Json;
using System.IO;

namespace Inventory_managment.Helpers
{
    public static class JsonHelper
    {
        public static void ExportMapJSON(MapJSON mapJSON)
        {
            string json = JsonConvert.SerializeObject(mapJSON, Newtonsoft.Json.Formatting.Indented);

            string filename = $"{mapJSON.Gtin}_result_file_{DateTime.Now:yyMMdd_HHmm}.json";

            string directory = AppDomain.CurrentDomain.BaseDirectory;

            string filePath = Path.Combine(directory, filename);

            FileHelper.WriteAllText(filePath, json);
        }
    }
}
