namespace GraphQL_Api.ViewModels
{
    public class PacienteViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal Imc => Peso / (Altura * Altura);
        public long ClinicaId { get; set; }
    }
}
