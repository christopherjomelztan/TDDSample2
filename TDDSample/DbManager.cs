using System;
using TDDSample.PoCo;

namespace TDDSample
{
    public class DbManager : IDbManager
    {
        public void SaveToDb(Item i)
        {
            Console.WriteLine($"{i.Name} - {i.Description} saved to database.");
        }
    }
}
