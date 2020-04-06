using System;
using System.Linq;
using System.IO;
using EcoU.Models;

namespace EcoU.SampleData
{
    public class SampleLocationData
    {
        public static void InitializeTowns(ProjectContext context)
        {
            if (!context.Locations.Any())
            {
                StreamReader streamReader = new StreamReader("SampleData/towns.txt");
                while(!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    var data = line.Split('|');
                    if (data.Length > 1)
                    {
                        Location location = new Location() { Town = data[0], Region = data[1] };
                        context.Locations.Add(location);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
