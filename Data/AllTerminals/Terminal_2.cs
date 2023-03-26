using Airplane_Project_2023;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Contexts;
using Data.Models;

namespace Terminals.AllTerminals
{
    public class Terminal_2 : Terminal
    {
        public override void NextTerminal(Flight currentFlight, AirplaneDB data)
        {
            Console.WriteLine(GetType().Name);
            var ter = data.Terminals.First(t => t.TerId == 3);
            if (ter.IsFree)
            {
                currentFlight.Ter = ter;
            }
        }
    }
}