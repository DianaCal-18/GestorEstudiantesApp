﻿using Application.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
         static EstudianteService estudianteService = new EstudianteService();

    }

}
