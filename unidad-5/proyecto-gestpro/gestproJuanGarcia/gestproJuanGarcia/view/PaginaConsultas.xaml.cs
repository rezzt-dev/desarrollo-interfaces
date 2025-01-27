﻿using gestproJuanGarcia.domain;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gestproJuanGarcia.view
{
  /// <summary>
  /// Lógica de interacción para PaginaConsultas.xaml
  /// </summary>
  public partial class PaginaConsultas : Page
  {
    private List<Proyecto> listProyectos;
    private Proyecto proyecto;

    public PaginaConsultas(List<Proyecto> inputListaProyectos)
    {
      InitializeComponent();
      this.listProyectos = inputListaProyectos;
      proyecto = new Proyecto();

      dataProyectos.ItemsSource = listProyectos;
    }
  }
}
