using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveSelectionClient
{
    /// <summary>
    /// Properties used for exporting XML
    /// </summary>
    public class ExportData
    {
        public List<Dictionary<string, string>> ExportList { get; set; }
        public Dictionary<string, string> MinCurve { get; set; }
        public Dictionary<string, string> MaxCurve { get; set; }
    }
}
