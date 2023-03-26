using Airplane_Project_2023;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminals_Sim.Interfaces;
using Data.Models;

namespace Terminals_Sim.Repositories
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly AirplaneDB _context;

        // ctor:
        public LoggerRepository(AirplaneDB context)
        {
            _context = context;
        }

        // get all planes:
        public async Task<List<Logger>> GetPlanes()
        {
            var data = await _context.Loggers.ToListAsync();
            return data;
        }

        // get one plane:
        public async Task<Logger> GetOnePlane(int id)
        {
            var log = await _context.Loggers.FirstOrDefaultAsync(x => x.Id == id);
            return log;
        }

        // add new plane: 
        public async Task<EntityEntry<Logger>> AddPlane(Logger l)
        {
            var data = await _context.Loggers.AddAsync(l);
            await _context.SaveChangesAsync();
            return data;
        }

        // edit plane:
        public async Task<EntityEntry<Logger>> EditPlane(Logger l)
        {
            var data = _context.Loggers.Update(l);
            await _context.SaveChangesAsync();
            return data;
        }

        // delete plane:
        public async Task<Logger> DeletePlane(Logger l)
        {
            Logger b = await GetOnePlane(l.Id);
            _context.Loggers.Remove(b);
            await _context.SaveChangesAsync();
            return l;
        }
    }
}