using Domain.Base;
using Domain.Entities;
using Application;
using System.Collections.Generic;
using System.Windows;
using Application.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AgregarEstudianteWindow.xaml
    /// </summary>
    public partial class AgregarEstudianteWindow : Window
    {
        private List<Grupo> grupos;
        private List<Asignatura> asignaturas;

        public AgregarEstudianteWindow()
        {
            InitializeComponent();

            grupos = new List<Grupo>()
            {
                new Grupo { nombreGrupo = "Grupo A" },
                new Grupo { nombreGrupo = "Grupo B" }
            };

            asignaturas = new List<Asignatura>()
            {
                new Asignatura { nombreAsignatura = "Matemáticas" },
                new Asignatura { nombreAsignatura = "Historia" }
            };

            // Asignar listas a los ComboBoxes
            cmbGrupo.ItemsSource = grupos;
            cmbGrupo.DisplayMemberPath = "nombreGrupo";

            cmbAsignatura.ItemsSource = asignaturas;
            cmbAsignatura.DisplayMemberPath = "nombreAsignatura";
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var nombre = txtNombre.Text.Trim();
            var matricula = txtMatricula.Text.Trim();

            var grupo = (Grupo)cmbGrupo.SelectedItem;
            var asignatura = (Asignatura)cmbAsignatura.SelectedItem;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingresa el nombre del estudiante.");
                return;
            }
            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("Ingresa la matrícula del estudiante.");
                return;
            }
            if (grupo == null)
            {
                MessageBox.Show("Selecciona un grupo.");
                return;
            }
            if (asignatura == null)
            {
                MessageBox.Show("Selecciona una asignatura.");
                return;
            }

            Estudiante estudiante = cmbTipoEstudiante.SelectedIndex == 0
                ? new EstudiantePresencial()
                : new EstudianteADistancia();

            estudiante.nombre = nombre;
            estudiante.matricula = matricula;
            estudiante.grupo = grupo;
            estudiante.asignatura = asignatura;

            App.EstudianteService.AgregarEstudiante(estudiante, grupo, asignatura);
            MessageBox.Show("Estudiante agregado.");
            this.Close();
        }
    }
}
