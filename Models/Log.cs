using System;
using System.IO;

namespace Capstone.Models
{
    public class Log // Log doesn't write correctly, the third field when depositing should list the amount deposited, but ours lists the balance before deposit
    {
        //string directory = Environment.CurrentDirectory;
        //string path = Path.Combine(directory, "log.txt");

        string filename = "log.txt";

        public void WriteToLog(string v)
        {
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                // 01/01/2016 12:00:00 PM
                sw.WriteLine($"{DateTime.Now} {v}");
            }
        }


    }
}
