using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveSelectionServer
{
    /// <summary>
    /// Model to bind the data from Datatable 
    /// </summary>
    public class CurveDataModel
    {
        public Dictionary<string, string> ColumnValues = new Dictionary<string, string>
        {
            {"index", ""}
        };
    }
}
