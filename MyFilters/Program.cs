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
                int[] filters = { 3, 10, 9 };


                List<Filter> Filters = new List<Filter>();
                foreach (int id in filters) //Шукаємо всі продукти з заданими id
                {
                    foreach (Filter filter in context.Filters)
                    {
                        if (id == filter.FilterValueId)
                        {
                            Filters.Add(filter);
                        }
                    }
                }



                //foreach(Filter a in Filters)
                //    Console.WriteLine(a.ProductId);

                //foreach(var a in res)
                //    Console.WriteLine(a);
                //var result = FiltringProducts.Where(FindingObjects => (FiltringProducts.Count(obj => obj == FindingObjects)) >= filters.Count()).Distinct();
                //foreach (Product pr in result)
                //{
                //    Console.WriteLine(pr.Name);
                //}



                //.FirstOrDefault().Key

                // Console.WriteLine(a.Count());

                //foreach (Product a in FiltringProducts)
                //{
                //    Console.WriteLine(a.Name);
                //}

            }
        }
    }
}
