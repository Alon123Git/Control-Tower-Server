using Airplane_Project_2023;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminals_Sim.Interfaces
{
    public interface ILoggerRepository
    {
        Task<List<Logger>> GetPlanes();

        // get one plane:
        Task<Logger> GetOnePlane(int id);

        // add new plane: 
        Task<EntityEntry<Logger>> AddPlane(Logger l);

        // edit plane:
        Task<EntityEntry<Logger>> EditPlane(Logger l);

        // delete plane:
        Task<Logger> DeletePlane(Logger l);
    }
}