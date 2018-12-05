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
                Console.WriteLine("dsfsd");
                int[] filters = { 3, 10 };

                List<Product> FiltringProducts = new List<Product>();
                foreach (int id in filters)
                {
                    foreach (Filter filter in context.Filters)
                    {
                        if (id == filter.FilterValueId)
                        {
                            FiltringProducts.Add(filter.ProductOf);
                        }
                    }
                }

                var result = FiltringProducts.Where(FindingObjects => (FiltringProducts.Count(obj => obj == FindingObjects)) == filters.Count()).Distinct();
                foreach (Product pr in result)
                {
                    Console.WriteLine(pr.Name);
                }

                

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
