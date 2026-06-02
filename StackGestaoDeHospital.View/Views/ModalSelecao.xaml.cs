using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StackGestaoDeHospital.View
{
    /// <summary>
    /// Lógica interna para ModalSelecao.xaml
    /// </summary>
    public partial class ModalSelecao : Window
    {

        public object? ItemSelecionado { get; private set; }

        public ModalSelecao(string titulo, IEnumerable itens, string? propriedadeExibicao = "Descricao")
        {
            InitializeComponent();

            Title = titulo;
            TituloTextBlock.Text = titulo;

            ComboSeletor.ItemsSource = itens;
            ComboSeletor.DisplayMemberPath = propriedadeExibicao;
        }

        private void Confirmar_Click(object sender, RoutedEventArgs e)
        {
            if (ComboSeletor.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecione um item para continuar.",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            ItemSelecionado = ComboSeletor.SelectedItem;

            DialogResult = true;
            Close();
        }
    }
}
