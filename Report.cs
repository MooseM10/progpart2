using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityApp
{ 
    public class Report
{
    public string Location { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string MediaFilePath { get; set; } // Optional field for media attachment

    public Report(string location, string category, string description, string mediaFilePath)
    {
        Location = location;
        Category = category;
        Description = description;
        MediaFilePath = mediaFilePath;
    }
 }
}