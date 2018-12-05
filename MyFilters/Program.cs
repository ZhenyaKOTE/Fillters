using MyFilters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilters
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EFContext context = new EFContext())
            {
                int[] filters = { 5, 6, 3, 4 };

                
                Filter f = new Filter { FilterValueId = 3 };

                foreach (var a in context.Filters)
                {
                    if (a.FilterValueId == f.FilterValueId)
                    {
                        Console.WriteLine(a.FilterNameOf.Name + " : " + a.FilterValueOf.Name + "   Ноутбук: " + a.ProductOf.Name);
                    }
                }

            }
        }
    }
}
