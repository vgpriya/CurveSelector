using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveSelectionServer
{
    /// <summary>
    /// To add extended features
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// To convert KeyValuePair to Dictionary
        /// </summary>
        public static Dictionary<T1, T2> ToDictionary<T1, T2>(this KeyValuePair<T1, T2> kvp)
        {
            var dict = new Dictionary<T1, T2>();
            dict.Add(kvp.Key, kvp.Value);
            return dict;
        }
    }
}
