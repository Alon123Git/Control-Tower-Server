using Airplane_Project_2023;
using Airplane_Project_2023.Interfaces;
using Airplane_Project_2023.Repositories;
using Data.Contexts;
using Data.Models;
using LogicAndConnectionToDb.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Terminals_Sim.Interfaces;
using Terminals_Sim.Repositories;

namespace AIRPLANE.Controllers
{
    //[EnableCors(origin: "*", headers: "*", methods: "*")]
    [Route("control-tower")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly AirplaneDB _context;
        private readonly IFlightRepository _flightIRepository;
        private readonly ITerminalIRepository _terminalIRepository;

        public FlightController(AirplaneDB context, IFlightRepository IflightRepo, ITerminalIRepository terminalIRepository)
        {
            _context = context;
            _flightIRepository = IflightRepo;
            _terminalIRepository = terminalIRepository;
        }

        [Route("/flight")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _flightIRepository.GetPlanes();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getbyid(int id)
        {
            Flight a = await _flightIRepository.GetOnePlane(id);
            if (id <= 0)
            {
                return NotFound("the plane is not found");
            }
            else
            {
                return Ok(a);
            }
        }

        [Route("/flight")]
        [HttpPost]
        public async Task<IActionResult> Post(Flight a)
        {
            //try
            //{
                // Get oldest plane: 
                Flight oldestPlane = await _flightIRepository.GetOldestPlane();
                if (oldestPlane != null)
                {
                // Delete oldest plane: 
                //await _flightIRepository.DeletePlane(oldestPlane.FlId);
            }
                Random r = new Random();
                a.PassengersCount = r.Next(100, 700);

                a.IsDeparture = true;
                Terminal? t = _terminalIRepository.GetPlanes().Result.FirstOrDefault(terminal => terminal.Number == 1);
                a.Ter = t;
                // Add new plane: 
                await _flightIRepository.AddPlane(a);
                await _flightIRepository.UpdatePlane(a);
                return Ok(a);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //return Ok(a);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Flight a)
        {
            try
            {
                await _flightIRepository.UpdatePlane(a);
                return Ok(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(a);
        }
    }
}