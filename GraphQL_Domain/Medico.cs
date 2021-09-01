namespace GraphQL_Domain
{
    public class Medico
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public long ClinicaId { get; set; }
        public Clinica Clinica { get; set; }
    }
}
