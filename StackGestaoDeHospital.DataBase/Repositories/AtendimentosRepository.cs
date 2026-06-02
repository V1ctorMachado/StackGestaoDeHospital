using Microsoft.EntityFrameworkCore;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.DataBase.Repositories
{
    public class AtendimentosRepository : RepositoryBase<Atendimento>
    {
        public AtendimentosRepository(HospitalDbContext context) : base(context) { }

        public IList<Atendimento> GetAtendimentos(int idDepartamento, StatusAtendimentoEnum status)
        {
            return _dbSet
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .Include(a => a.Enfermeiro)
                .Include(a => a.Especialidade)
                .Include(a => a.Departamento)
                .Where(a => a.Departamento.Id == idDepartamento && a.Status == status)
                .OrderByDescending(a => a.Data)
                .ToList();
        }
    }
}
