using Airplane_Project_2023;
using System;
using Terminals.AllTerminals;
using Terminals.Interfaces;
using Data.Contexts;
using Data.Models;

namespace Terminals.AllTerminals
{
    class Terminal_8 : ITerminal
    {
        public bool IsFree { get; set; } = true;
        public static ITerminal Init { get; } = new Terminal_8();
        private Terminal_8() { }
        public void NextTerminal(Flight currentFlight, AirplaneDB data)
        {
            currentFlight.IsDeparture = true;
            Console.WriteLine(GetType().Name);
            if (Terminal_4.Init.IsFree)
            {
                currentFlight.Ter = (Terminal)Terminal_4.Init;
            }
        }
    }
}