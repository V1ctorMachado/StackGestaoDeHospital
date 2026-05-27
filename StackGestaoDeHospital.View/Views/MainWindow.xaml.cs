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
        public ObservableCollection<Departamento> ListaDepartamentos { get; set; } = new();
        public Departamento DepartamentoSelecionado { get; set; }

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
            ListaDepartamentos.Replace(departamentos);
        }
    }
}