using System.Collections.Generic;

namespace GraphQL_Domain
{
    public class Clinica
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
        public ICollection<Medico> Medicos { get; set; }
    }
}
