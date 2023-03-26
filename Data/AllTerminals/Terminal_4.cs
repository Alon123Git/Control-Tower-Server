using Airplane_Project_2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminals.Interfaces;
using Data.Contexts;
using Data.Models;

namespace Terminals.AllTerminals
{
    public class Terminal_4 : ITerminal
    {
        public bool IsFree { get; set; } = true;
        public static ITerminal Init { get; } = new Terminal_4();
        private Terminal_4() { }
        public void NextTerminal(Flight currentFlight, AirplaneDB data)
        {
            Console.WriteLine(GetType().Name);

            if (currentFlight.IsDeparture)
            {
                Console.WriteLine("Finish");
            }
            else if (Terminal_5.Init.IsFree)
            {
                currentFlight.Ter = (Terminal)Terminal_5.Init;
            }
        }
    }
}
