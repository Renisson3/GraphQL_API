using GraphQL_Api.ViewModels;
using GraphQL_API.ContextAcess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IContextAcess _context;

        public PacientesController(IContextAcess context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<PacienteViewModel>> GetAll()
        {
            return await _context.Pacientes.Select(paciente => new PacienteViewModel
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Altura = paciente.Altura,
                Idade = paciente.Idade,
                Peso = paciente.Peso,
                ClinicaId = paciente.ClinicaId
            }).ToListAsync();
        }
    }
}
