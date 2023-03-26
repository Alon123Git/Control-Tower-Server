using Airplane_Project_2023;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAndConnectionToDb.Interfaces
{
    public interface IFlightRepository
    {
        // List of planes
        Task<List<Flight>> GetPlanes();


        // get one plane:
        Task<Flight> GetOnePlane(int id);


        // add new plane: 
        Task<Flight> AddPlane(Flight c);

        // update plane:
        Task<Flight> UpdatePlane(Flight a);

        // get oldest plane:
        Task<Flight> GetOldestPlane();


        // delete plane:
        Task<Flight> DeletePlane(int id);
    }
}