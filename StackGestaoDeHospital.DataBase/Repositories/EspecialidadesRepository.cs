using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.DataBase.Repositories
{
    public class EspecialidadesRepository : RepositoryBase<Especialidade>
    {
        public EspecialidadesRepository(HospitalDbContext context) : base(context) { }
    }
}
