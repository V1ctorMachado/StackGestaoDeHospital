using StackGestaoDeHospital.DataBase;
using StackGestaoDeHospital.DataBase.Repositories;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.Controller
{
    public class AtendimentosController(HospitalDbContext hospitalDbContext)
    {
        private AtendimentosRepository atendimentosRepository { get; set; } = new AtendimentosRepository(hospitalDbContext);
        private MedicosController medicosController { get; set; } = new MedicosController(hospitalDbContext);
        private EnfermeirosController enfermeirosController { get; set; } = new EnfermeirosController(hospitalDbContext);

        public IEnumerable<Atendimento> GetAllAtendimentos()
        {
            return atendimentosRepository.GetAll();
        }

        public Atendimento GetAtendimentoById(int id)
        {
            return atendimentosRepository.GetById(id);
        }

        public IEnumerable<Atendimento> GetAtendimentos(int idDepartamento, StatusAtendimentoEnum status)
        {
            return atendimentosRepository.GetAtendimentos(idDepartamento, status);
        }

        public void ProsseguirParaEmConcluido(Atendimento atendimento)
        {
            atendimento.SetStatus(StatusAtendimentoEnum.Concluido);
            medicosController.AtualizarStatus(atendimento.Medico, true);
            atendimentosRepository.Update(atendimento);

            hospitalDbContext.SaveChanges();
        }

        public void ProsseguirParaEmAtendimento(Atendimento atendimento, Medico medico)
        {
            if (medico == null)
                return;

            atendimento.SetStatus(StatusAtendimentoEnum.EmAtendimento);
            atendimento.SetMedico(medico);
            medicosController.AtualizarStatus(atendimento.Medico, false);
            enfermeirosController.AtualizarStatus(atendimento.Enfermeiro, true);
            atendimentosRepository.Update(atendimento);

            hospitalDbContext.SaveChanges();
        }

        public void ProsseguirParaTriagem(Atendimento atendimento, Enfermeiro enfermeiro)
        {
            if (enfermeiro == null)
                return;

            atendimento.SetStatus(StatusAtendimentoEnum.EmTriagem);
            atendimento.SetEnfermeiro(enfermeiro);
            enfermeirosController.AtualizarStatus(atendimento.Enfermeiro, false);
            atendimentosRepository.Update(atendimento);

            hospitalDbContext.SaveChanges();
        }

        public void Update(Atendimento atendimento)
        {
            atendimentosRepository.Update(atendimento);
            hospitalDbContext.SaveChanges();
        }

        public void EditarAtendimento(Atendimento atendimento, string? queixa, string? diagnostico, Especialidade? especialidade)
        {
            if(atendimento.Status != StatusAtendimentoEnum.Concluido)
                atendimento.SetQueixa(queixa);

            if(atendimento.Status == StatusAtendimentoEnum.EmTriagem)
            {
                atendimento.SetEspecialidade(especialidade);
            }

            if (atendimento.Status == StatusAtendimentoEnum.EmAtendimento)
            {
                atendimento.SetDiagnostico(diagnostico);
            }

            atendimentosRepository.Update(atendimento);
            hospitalDbContext.SaveChanges();
        }
    }
}
