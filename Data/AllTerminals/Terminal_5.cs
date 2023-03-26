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
    class Terminal_5 : ITerminal
    {
        public bool IsFree { get; set; } = true;
        public static ITerminal Init { get; } = new Terminal_5();
        private Terminal_5() { }
        public void NextTerminal(Flight currentFlight, AirplaneDB data)
        {
            Console.WriteLine(GetType().Name);
            if (Terminal_6.Init.IsFree)
            {
                currentFlight.Ter = (Terminal)Terminal_6.Init;
            }
            else if (Terminal_7.Init.IsFree )
            {
                currentFlight.Ter = (Terminal)Terminal_7.Init;
            }
        }
    }
}