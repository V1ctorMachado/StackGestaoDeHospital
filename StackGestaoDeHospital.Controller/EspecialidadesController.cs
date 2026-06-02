using StackGestaoDeHospital.DataBase;
using StackGestaoDeHospital.DataBase.Repositories;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.Controller
{
    public class EspecialidadesController(HospitalDbContext hospitalDbContext)
    {
        private EspecialidadesRepository especialidadesRepository { get; set; } = new EspecialidadesRepository(hospitalDbContext);

        public IEnumerable<Especialidade> GetAllEspecialidades()
        {
            return especialidadesRepository.GetAll();
        }
    }
}
