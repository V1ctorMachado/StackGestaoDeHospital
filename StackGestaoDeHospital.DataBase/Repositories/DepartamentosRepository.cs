using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.DataBase.Repositories
{
    public class DepartamentosRepository : RepositoryBase<Departamento>
    {
        public DepartamentosRepository(HospitalDbContext context) : base(context) { }
    }
}
