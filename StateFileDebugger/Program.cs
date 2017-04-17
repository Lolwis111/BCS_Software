using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateFileDebugger
{
    [Obsolete("The state system got dropped. Simply enter name and points into BCS Software.")]
    class Program
    {
        static void Main(string[] args)
        {
            string data = System.IO.File.ReadAllText(args[0]);
            string[] states = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string state in states)
            {
                string s = state.Replace("&auml;", "ä");
                s = s.Replace("&ouml;", "ö");
                s = s.Replace("&uuml;", "ü");

                s = s.Replace("&Ouml;", "Ö");
                s = s.Replace("&Uuml;", "Ü");
                s = s.Replace("&Auml;", "Ä");

                s = s.Replace("&szlig;", "ß");

                string[] segments = s.Split(';');

                int points = int.Parse(segments[segments.Length - 1].Substring(2));
                string dataString = "";

                for (int i = 0; i < (segments.Length - 1); i++)
                {
                    dataString += segments[i];

                    if (i != segments.Length - 2)
                        dataString += ";";
                }

                Console.WriteLine("{0}: {1} Punkte", dataString, points);
            }

            Console.ReadLine();
        }
    }
}
