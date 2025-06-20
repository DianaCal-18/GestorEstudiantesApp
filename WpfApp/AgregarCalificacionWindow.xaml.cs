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
    /// Interaction logic for AgregarCalificacionWindow.xaml
    /// </summary>
    public partial class AgregarCalificacionWindow : Window
    {
        public AgregarCalificacionWindow()
        {
            InitializeComponent();
        }

        private void BtnAgregarCalificacion_Click(object sender, RoutedEventArgs e)
        {
            var estudiante = App.EstudianteService.BuscarPorMatricula(txtMatricula.Text);
            if (estudiante == null)
            {
                MessageBox.Show("No se encontró el estudiante.");
                return;
            }

            estudiante.calificaciones.Add(new Calificacion
            {
                tipo = ((ComboBoxItem)cmbTipo.SelectedItem).Content.ToString(),
                valor = decimal.Parse(txtValor.Text)
            });

            MessageBox.Show("Calificación agregada.");
        }

    }
}
