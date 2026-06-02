using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace StackGestaoDeHospital.View.Views.Handlers
{
    class ExceptionHandler
    {
        public static void Show(Exception ex)
        {
            MessageBox.Show(
                ex.InnerException?.Message ?? ex.Message,
                "Erro",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }
}
