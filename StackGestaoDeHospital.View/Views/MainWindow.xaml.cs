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
        public ObservableCollection<Atendimento> AtendimentosAguardando { get; set; } = new();
        public ObservableCollection<Atendimento> AtendimentosTriagem { get; set; } = new();
        public ObservableCollection<Atendimento> AtendimentosEmAtendimento { get; set; } = new();
        public ObservableCollection<Atendimento> AtendimentosFinalizados { get; set; } = new();

        public ObservableCollection<Departamento> Departamentos { get; set; } = new();
        public Departamento? DepartamentoSelecionado { get; set; }

        public ICommand ProsseguirCommand { get; set; }

        // Controllers
        private DepartamentosController departamentosController { get; set; }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            departamentosController = new DepartamentosController(App.DBContext);
            Inicializar();
        }

        public void Inicializar()
        {
            var departamentos = departamentosController.GetAllDepartamentos();
            TrazerAtendimentosFalsos();
            Departamentos.Replace(departamentos);
        }

        private void TrazerAtendimentosFalsos()
        {
            Paciente pacienteFalso = new Paciente(1, "Victor", "Machado", "12345678900", new DateTime(2005, 01, 01), "123456789", "Plano X");


            var atendimentoFalso = new Atendimento("Reprovou 7 vezes", pacienteFalso);

            AtendimentosAguardando.Add(atendimentoFalso);
        }
    }
}