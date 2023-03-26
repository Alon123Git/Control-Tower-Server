using Airplane_Project_2023;
using Airplane_Project_2023.Interfaces;
using Data.Contexts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Airplane_Project_2023.Repositories
{
    public class TerminalRepository : ITerminalIRepository
    {
        private readonly AirplaneDB _context;

        // ctor:
        public TerminalRepository(AirplaneDB context)
        {
            _context = context;
        }

        // get all planes:
        public async Task<List<Terminal>> GetPlanes()
        {
            var data = await _context.Terminals.ToListAsync();
            return data;
        }

        // get one plane:
        public async Task<Terminal> GetOnePlane(int id)
        {
            var data = await _context.Terminals.FirstOrDefaultAsync(x => x.TerId == id);
            return data;
        }

        // add new plane: 
        public async Task<EntityEntry<Terminal>> AddPlane(Terminal t)
        {
            var data = await _context.Terminals.AddAsync(t);
            _context.SaveChanges();
            return data;
        }

        // edit plane:
        public async Task<EntityEntry<Terminal>> EditPlane(Terminal t)
        {
            var data = _context.Terminals.Update(t);
            await _context.SaveChangesAsync();
            return data;
        }

        // delete plane:
        public async Task<Terminal> DeletePlane(Terminal t)
        {
            Terminal b = await GetOnePlane(t.TerId);
            _context.Terminals.Remove(b);
            await _context.SaveChangesAsync();
            return t;
        }
    }
}