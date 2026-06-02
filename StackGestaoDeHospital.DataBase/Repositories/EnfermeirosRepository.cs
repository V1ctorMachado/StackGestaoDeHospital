using Microsoft.EntityFrameworkCore;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.DataBase.Repositories
{
    public class EnfermeirosRepository : RepositoryBase<Enfermeiro>
    {
        public EnfermeirosRepository(HospitalDbContext context) : base(context) { }

        public IList<Enfermeiro> ListarDisponiveis(int idDepartamento)
        {
            return _dbSet
                .Where(e => e.Departamento.Id == idDepartamento && e.Disponivel)
                .ToList();
        }
    }
}
