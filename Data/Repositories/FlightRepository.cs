using Airplane_Project_2023;
using LogicAndConnectionToDb.Interfaces;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Terminals_Sim.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AirplaneDB _context;

        // ctor:
        public FlightRepository(AirplaneDB context)
        {
            _context = context;
        }

        // get all planes:
        public async Task<List<Flight>> GetPlanes()
        {
            var data = await _context.Flights.ToListAsync();
            return data;
        }

        // get one plane:
        public async Task<Flight> GetOnePlane(int id)
        {
            var data = await _context.Flights.FirstOrDefaultAsync(x => x.FlId == id);
            return data;
        }

        // add new plane: 
        public async Task<Flight> AddPlane(Flight a)
        {
            await _context.Flights.AddAsync(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<Flight> UpdatePlane(Flight a)
        {
            _context.Flights.Update(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<Flight> GetOldestPlane()
        {
            var oldestPlane = await _context.Flights.OrderBy(p => p.FlId).FirstOrDefaultAsync();
            return oldestPlane;
        }

        // delete plane:
        public async Task<Flight> DeletePlane(int id)
        {
            var plane = await _context.Flights.FirstOrDefaultAsync(x => x.FlId == id);
            if (plane != null)
            {
                _context.Flights.Remove(plane);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Error 404");
            }
            return plane;
        }
    }
}