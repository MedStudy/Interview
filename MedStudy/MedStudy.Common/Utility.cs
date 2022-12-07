using System.Data;
using Newtonsoft.Json;

namespace MedStudy.Common
{
    public class Utility
    {
        public static string JSonConverter(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
    }
}
