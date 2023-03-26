using Airplane_Project_2023;
using Airplane_Project_2023.Interfaces;
using Data.Contexts;
using Data.Models;
using LogicAndConnectionToDb.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Terminals_Sim.Interfaces;
using Terminals_Sim.Repositories;

namespace AIRPLANE.Controllers
{
    [Route("logger")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly AirplaneDB _context;
        private readonly IFlightRepository _flightIRepository;
        private readonly ILoggerRepository _loggerRepository;
        private readonly ITerminalIRepository _terminalIRepository;

        public LoggerController(AirplaneDB context, IFlightRepository IflightRepo, ILoggerRepository loggerIRepository, ITerminalIRepository terminalIRepository)
        {
            _context = context;
            _flightIRepository = IflightRepo;
            _loggerRepository = loggerIRepository;
            _terminalIRepository = terminalIRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _loggerRepository.GetPlanes();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Logger l = await _loggerRepository.GetOnePlane(id);
            if (id <= 0)
            {
                return NotFound("Logger does not found.");
            }
            else
            {
                return Ok(l);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Logger log)
        {
            await _loggerRepository.AddPlane(log);
            return Ok(log);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Logger log)
        {
            await _loggerRepository.EditPlane(log);
            return Ok(log);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Logger l = await _loggerRepository.GetOnePlane(id);
            await _loggerRepository.DeletePlane(l);
            return Ok(l);
        }
    }
}
