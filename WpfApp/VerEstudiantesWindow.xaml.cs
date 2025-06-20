using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for VerEstudiantesWindow.xaml
    /// </summary>
    public partial class VerEstudiantesWindow : Window
    {
        public VerEstudiantesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var estudiantes = App.EstudianteService.ObtenerTodos();
            foreach (var est in estudiantes)
                lstEstudiantes.Items.Add(est.MostrarInfo());
        }


    }
}
