namespace StackGestaoDeHospital.Model
{
    public class Paciente : Pessoa
    {
        public Paciente(int id, string nome, string sobrenome, string cPF, DateTime dataNascimento, string numeroCarteirinha, string planoSaude) : base(id, nome, sobrenome, cPF, dataNascimento)
        {
            NumeroCarteirinha = numeroCarteirinha;
            PlanoSaude = planoSaude;
        }

        public string NumeroCarteirinha { get; set; } = string.Empty;
        public string PlanoSaude { get; set; } = string.Empty;

    }
}
