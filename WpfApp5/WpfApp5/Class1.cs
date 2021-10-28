using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WpfApp5
{
    static class Class1
    {
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int mdk = 0; mdk < arr.Length; mdk++)
            {
                res.Columns.Add("col" + (mdk + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int mdk = 0; mdk < arr.Length; mdk++)
            {
                row[mdk] = arr[mdk];
            }
            res.Rows.Add(row);
            return res;
        }
    }
}
