using Airplane_Project_2023;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Airplane_Project_2023.Interfaces
{
    public interface ITerminalIRepository
    {
        Task<List<Terminal>> GetPlanes();

        // get one plane:
        Task<Terminal> GetOnePlane(int id);

        // add new plane: 
        Task<EntityEntry<Terminal>> AddPlane(Terminal t);

        // edit plane:
        Task<EntityEntry<Terminal>> EditPlane(Terminal t);

        // delete plane:
        Task<Terminal> DeletePlane(Terminal t);
    }
}
