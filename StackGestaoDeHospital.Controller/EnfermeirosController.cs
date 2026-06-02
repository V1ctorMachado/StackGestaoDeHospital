using Microsoft.EntityFrameworkCore;
using StackGestaoDeHospital.DataBase;
using StackGestaoDeHospital.DataBase.Repositories;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.Controller
{
    public class EnfermeirosController(HospitalDbContext hospitalDbContext)
    {
        private EnfermeirosRepository enfermeirosRepository { get; set; } = new EnfermeirosRepository(hospitalDbContext);

        public IList<Enfermeiro> ListarDisponiveis(int idDepartamento)
        {
            var enfermeiros = enfermeirosRepository.ListarDisponiveis(idDepartamento);
             
            if(enfermeiros == null || enfermeiros.Count == 0)
            {
                throw new Exception("Nenhum enfermeiro disponível encontrado para o departamento especificado.");
            }

            return enfermeiros;
        }

        public void AtualizarStatus(Enfermeiro enfermeiro, bool disponivel)
        {
            enfermeiro.SetDisponivel(disponivel);
            enfermeirosRepository.Update(enfermeiro);
        }
    }
}
