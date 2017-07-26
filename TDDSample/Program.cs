using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDSample.PoCo;

namespace TDDSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var item = new Item { Name = "Item1", Description = "Item1 Desc" };
            var item2 = new Item { Name = "Item2", Description = "Item2 Desc" };

            var service = new MyService(new DbManager(), new WebServiceClientWrapper());
            service.Save(item);
            service.Save(item2);
        }
    }
}
