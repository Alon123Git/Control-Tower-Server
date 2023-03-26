using Airplane_Project_2023;
using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminals.Interfaces;

namespace Terminals.AllTerminals
{
    class Terminal_6 : ITerminal
    {
        public bool IsFree { get; set; } = true;
        public static ITerminal Init { get; } = new Terminal_6();
        private Terminal_6() { }
        public void NextTerminal(Flight currentFlight, AirplaneDB data)
        {
            Console.WriteLine(GetType().Name);
            if (Terminal_8.Init.IsFree)
            {
                currentFlight.Ter = (Terminal)(Terminal)Terminal_8.Init;
            }
        }
    }
}