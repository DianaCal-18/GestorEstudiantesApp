using Domain.Entities;
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
    /// Interaction logic for EstadisticasWindow.xaml
    /// </summary>
    public partial class EstadisticasWindow : Window
    {
        public EstadisticasWindow()
        {
            InitializeComponent();
        }
        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            var grupo = cmbGrupos.SelectedItem as Grupo;
            var porcentaje = App.EstudianteService.CalcularPorcentajeAprobados(grupo.nombreGrupo);
            lblResultado.Text = $"Aprobados: {porcentaje:F2}%";
        }

    }
}
