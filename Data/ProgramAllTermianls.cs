using System.Linq;
using Airplane_Project_2023;
using Data.Contexts;
using Data.Models;
using Terminals.AllTerminals;

namespace Terminals
{
    internal class ProgramAllTermianls
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var data = new AirplaneDB())
            {
                var t1 = new Terminal_1 { IsFree = true };
                var t2 = new Terminal_2 { IsFree = true };

                data.Flights.Add(new Flight { Ter = t1 });
                data.Terminals.Add(t1);
                data.Terminals.Add(t2);
                data.SaveChanges();
            }

            using (var data = new AirplaneDB())
            {
                var flight = data.Flights.First();
                flight.NextTerminal(data);
                flight.NextTerminal(data);
                flight.NextTerminal(data);
                flight.NextTerminal(data);
                flight.NextTerminal(data);
                flight.NextTerminal(data);
                flight.NextTerminal(data);
                flight.NextTerminal(data);
            }
        }
    }
}