using StackGestaoDeHospital.DataBase;
using StackGestaoDeHospital.DataBase.Repositories;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.Controller
{
    public class DepartamentosController(HospitalDbContext hospitalDbContext)
    {
        private DepartamentosRepository departamentosRepository { get; set; } = new DepartamentosRepository(hospitalDbContext);

        public IEnumerable<Departamento> GetAllDepartamentos()
        {
            return departamentosRepository.GetAll();
        }
    }
}
