using Airplane_Project_2023;
using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminals.Interfaces
{
    public interface ITerminal
    {
        public bool IsFree { get; set; }
        void NextTerminal(Flight currentFlight, AirplaneDB data);
    }
}