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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnAgregarEstudiante_Click(object sender, RoutedEventArgs e)
        {
            new AgregarEstudianteWindow().ShowDialog();
        }

        private void BtnAgregarCalificacion_Click(object sender, RoutedEventArgs e)
        {
            // Abre la ventana AgregarCalificacionWindow (crea la ventana si no existe)
            new AgregarCalificacionWindow().ShowDialog();
        }

        private void BtnVerEstudiantes_Click(object sender, RoutedEventArgs e)
        {
            // Abre la ventana VerEstudiantesWindow (crea la ventana si no existe)
            new VerEstudiantesWindow().ShowDialog();
        }

        private void BtnVerEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            // Abre la ventana EstadisticasWindow (crea la ventana si no existe)
            new EstadisticasWindow().ShowDialog();
        }

    }
}