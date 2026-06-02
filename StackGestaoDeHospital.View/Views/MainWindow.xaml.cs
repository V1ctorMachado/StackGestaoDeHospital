using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackGestaoDeHospital.Controller;
using StackGestaoDeHospital.DataBase;
using StackGestaoDeHospital.Model;
using StackGestaoDeHospital.View.Utils;

namespace StackGestaoDeHospital.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Observable Collections
        public ObservableCollection<Atendimento> AtendimentosAguardando { get; set; } = new();
        public ObservableCollection<Atendimento> AtendimentosTriagem { get; set; } = new();
        public ObservableCollection<Atendimento> AtendimentosEmAtendimento { get; set; } = new();
        public ObservableCollection<Atendimento> AtendimentosFinalizados { get; set; } = new();
        public ObservableCollection<Departamento> Departamentos { get; set; } = new();

        // Variaveis de estado
        public Departamento? DepartamentoSelecionado { get; set; }

        // Controllers
        private DepartamentosController departamentosController { get; set; }
        private AtendimentosController atendimentosController { get; set; }
        private MedicosController medicosController { get; set; }
        private EnfermeirosController enfermeirosController { get; set; }
        private EspecialidadesController especialidadesController { get; set; }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            departamentosController = new DepartamentosController(App.DBContext);
            atendimentosController = new AtendimentosController(App.DBContext);
            medicosController = new MedicosController(App.DBContext);
            enfermeirosController = new EnfermeirosController(App.DBContext);
            especialidadesController = new EspecialidadesController(App.DBContext);
            Inicializar();
        }

        public void Inicializar()
        {
            var departamentos = departamentosController.GetAllDepartamentos();
            Departamentos.Replace(departamentos);
            var primeiro = departamentos.FirstOrDefault();
            DepartamentoSelecionado = primeiro;
            ComboDepartamento.SelectedItem = primeiro;
        }

        private void ChangeDepartamento(object sender, SelectionChangedEventArgs e)
        {
            if (ComboDepartamento.SelectedItem is not Departamento departamento)
                return;

            DepartamentoSelecionado = departamento;

            ListarAtendimentos();
        }

        private void ListarAtendimentos()
        {
            if (DepartamentoSelecionado == null)
            {
                AtendimentosAguardando.Clear();
                AtendimentosEmAtendimento.Clear();
                AtendimentosTriagem.Clear();
                AtendimentosFinalizados.Clear();
                return;
            }

            AtendimentosAguardando.Replace(atendimentosController.GetAtendimentos(DepartamentoSelecionado.Id, StatusAtendimentoEnum.Aberto));
            AtendimentosEmAtendimento.Replace(atendimentosController.GetAtendimentos(DepartamentoSelecionado.Id, StatusAtendimentoEnum.EmAtendimento));
            AtendimentosTriagem.Replace(atendimentosController.GetAtendimentos(DepartamentoSelecionado.Id, StatusAtendimentoEnum.EmTriagem));
            AtendimentosFinalizados.Replace(atendimentosController.GetAtendimentos(DepartamentoSelecionado.Id, StatusAtendimentoEnum.Concluido));
        }

        private void ProsseguirAtendimento(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button)
                return;

            Atendimento atendimento = button.DataContext as Atendimento;

            switch (atendimento.Status)
            {
                case StatusAtendimentoEnum.Aberto:

                    if (DepartamentoSelecionado == null)
                    {
                        MessageBox.Show("Selecione um departamento antes de prosseguir.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    var enfermeiros = enfermeirosController.ListarDisponiveis(DepartamentoSelecionado.Id);
                    var modalEnfermeiros = new ModalSelecao("Selecionar enfermeiro", enfermeiros, "NomeCompletoMatricula");
                    modalEnfermeiros.ShowDialog();
                    Enfermeiro enfermeiro = modalEnfermeiros.ItemSelecionado as Enfermeiro;

                    atendimentosController.ProsseguirParaTriagem(atendimento, enfermeiro);
                    break;

                case StatusAtendimentoEnum.EmTriagem:

                    if(atendimento.Especialidade == null)
                    {
                        throw new Exception("Atendimento sem especialidade definida.");
                    }

                    var medicos = medicosController.ListarDisponiveis(DepartamentoSelecionado.Id, atendimento.Especialidade.Id);
                    var modalMedicos = new ModalSelecao("Selecionar médico", medicos, "NomeCompletoMatriculaEspecialidades");
                    modalMedicos.ShowDialog();
                    Medico medico = modalMedicos.ItemSelecionado as Medico;

                    atendimentosController.ProsseguirParaEmAtendimento(atendimento, medico);
                    break;

                case StatusAtendimentoEnum.EmAtendimento:
                    atendimentosController.ProsseguirParaEmConcluido(atendimento);
                    break;

                default:
                    MessageBox.Show("Atendimento já finalizado.");
                    break;
            }

            ListarAtendimentos();
        }

        private void VisualizarAtendimento(object sender, RoutedEventArgs e)
        {
            Atendimento atendimento = (sender as Button).DataContext as Atendimento;



            var modalAtendimento = new DetalhesAtendimento(atendimento);
            modalAtendimento.ShowDialog();

            ListarAtendimentos();
        }
    }
}