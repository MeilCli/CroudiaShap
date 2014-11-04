using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.Extensions {
    internal static class IEnumerableExtensions {

        internal static void ForEach<T>(this IEnumerable<T> source,Action<T> action) { 
            foreach(T t in source){
                action(t);
            }
        }

        internal static string JoinString<T>(this IEnumerable<T> source,string separator) {
            return string.Join(separator,source.Select(x => x.ToString()).ToArray());
        }
    }
}
