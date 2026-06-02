using Microsoft.EntityFrameworkCore;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.DataBase.Repositories
{
    public class MedicosRepository : RepositoryBase<Medico>
    {
        public MedicosRepository(HospitalDbContext context) : base(context) { }

        public IList<Medico> ListarDisponiveis(int idDepartamento, int idEspecialidade)
        {
            return _dbSet
                .Where(m => m.Departamento.Id == idDepartamento && m.Especialidades.Select(e => e.Id).Contains(idEspecialidade))
                .ToList();
        }
    }
}
