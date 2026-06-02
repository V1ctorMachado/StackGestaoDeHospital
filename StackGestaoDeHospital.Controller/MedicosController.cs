using StackGestaoDeHospital.DataBase;
using StackGestaoDeHospital.DataBase.Repositories;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.Controller
{
    public class MedicosController(HospitalDbContext hospitalDbContext)
    {
        private MedicosRepository medicosRepository { get; set; } = new MedicosRepository(hospitalDbContext);

        public IEnumerable<Medico> ListarDisponiveis(int idDepartamento, int idEspecialidade)
        {
            var medicos = medicosRepository.ListarDisponiveis(idDepartamento, idEspecialidade);

            if(medicos == null || medicos.Count == 0)
            {
                throw new Exception("Nenhum médico disponível encontrado para o departamento e especialidade especificados.");
            }

            return medicos;
        }

        public void AtualizarStatus(Medico medico, bool disponivel)
        {
            medico.SetDisponivel(disponivel);
            medicosRepository.Update(medico);
        }
    }
}
