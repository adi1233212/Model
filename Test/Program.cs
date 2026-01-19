using Model;
using ViewModel;
namespace Test

{
    internal class Program
    {
        static void Main(string[] args)
        {
            CityDB cdb = new();
            CityList cList = cdb.SelectAll();
            foreach(City c in cList)
                Console.WriteLine(c.CityName);

        }
    }
}
