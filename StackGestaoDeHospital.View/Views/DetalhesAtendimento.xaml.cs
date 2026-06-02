using System;
using System.Collections.ObjectModel;
using System.Windows;
using StackGestaoDeHospital.Controller;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.View
{
    public partial class DetalhesAtendimento : Window
    {
        public Atendimento Atendimento { get; set; }

        public AtendimentoComando AtendimentoComando { get; set; }

        public ObservableCollection<Especialidade> Especialidades { get; set; } = new();

        public bool IsEspecialidadeEditavel { get; set; }

        public bool IsDiagnosticoReadOnly { get; set; }

        public bool IsQueixaReadOnly { get; set; }

        private readonly EspecialidadesController especialidadesController;

        private readonly AtendimentosController atendimentosController;

        public DetalhesAtendimento(Atendimento atendimento)
        {
            InitializeComponent();

            Atendimento = atendimento ?? throw new ArgumentNullException(nameof(atendimento));

            AtendimentoComando = new AtendimentoComando
            {
                Queixa = atendimento.Queixa,
                Diagnostico = atendimento.Diagnostico,
                Especialidade = atendimento.Especialidade
            };

            especialidadesController = new EspecialidadesController(App.DBContext);
            atendimentosController = new AtendimentosController(App.DBContext);

            CarregarEspecialidades();
            ConfigurarEditabilidade();

            DataContext = this;
        }

        private void CarregarEspecialidades()
        {
            var especialidades = especialidadesController.GetAllEspecialidades();

            Especialidades.Clear();

            foreach (var especialidade in especialidades)
            {
                Especialidades.Add(especialidade);
            }
        }

        private void ConfigurarEditabilidade()
        {
            IsEspecialidadeEditavel = Atendimento.Status == StatusAtendimentoEnum.EmTriagem;

            IsDiagnosticoReadOnly = Atendimento.Status != StatusAtendimentoEnum.EmAtendimento;

            IsQueixaReadOnly = Atendimento.Status == StatusAtendimentoEnum.Concluido;
        }

        private void SalvarAtendimento(object sender, RoutedEventArgs e)
        {
            atendimentosController.EditarAtendimento(
                Atendimento,
                AtendimentoComando.Queixa,
                AtendimentoComando.Diagnostico,
                AtendimentoComando.Especialidade
            );

            DialogResult = true;
            Close();
        }
    }
}