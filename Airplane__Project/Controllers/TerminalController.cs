using Airplane_Project_2023;
using Airplane_Project_2023.Interfaces;
using Data.Contexts;
using Airplane_Project_2023.Repositories;
using LogicAndConnectionToDb.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Terminals_Sim.Interfaces;
using Terminals_Sim.Repositories;
using Data.Models;

namespace AIRPLANE.Controllers
{
    [Route("terminal")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly AirplaneDB _context;
        private readonly IFlightRepository _flightIRepository;
        private readonly ILoggerRepository _loggerIRepository;
        private readonly ITerminalIRepository _terminalIRepository;

        public TerminalController(AirplaneDB context, IFlightRepository IflightRepo, ILoggerRepository loggerIRepository, ITerminalIRepository terminalIRepository)
        {
            _context = context;
            _flightIRepository = IflightRepo;
            _loggerIRepository = loggerIRepository;
            _terminalIRepository = terminalIRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _terminalIRepository.GetPlanes();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Terminal data = await _terminalIRepository.GetOnePlane(id);  
            if (id <= 0)
            {
                return NotFound("Logger does not found.");
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Terminal t)
        {
            await _terminalIRepository.AddPlane(t);
            return Ok(t);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Terminal t)
        {
            await _terminalIRepository.EditPlane(t);
            return Ok(t);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await _terminalIRepository.GetOnePlane(id);
            await _terminalIRepository.DeletePlane(t);
            return Ok(t);
        }
    }
}