using primer_informe.reports;
using SAPBusinessObjects.WPF.Viewer;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace primer_informe
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  
  public partial class MainWindow : Window
  {
    DataTable tabla1;
    private static readonly Random random = new Random();

    public MainWindow()
    {
      InitializeComponent();;
      tabla1 = new DataTable("DataTable1");

      tabla1.Columns.Add("Name");
      tabla1.Columns.Add("Age");
      tabla1.Columns.Add("Address");
      tabla1.Columns.Add("Phone");

      for (int i = 0; i < 10; i++)
      {
        DataRow row = tabla1.NewRow();
        row["Name"] = "Juan";
        row["Age"] = random.Next(10, 100);
        row["Address"] = "direccion-ejemplo";
        row["Phone"] = "676830394";
        tabla1.Rows.Add(row);
      }

      CrystalReport1 report = new CrystalReport1();
      report.Database.Tables["DataTable1"].SetDataSource((DataTable) tabla1);
      reportViewer.ViewerCore.ReportSource = report;
    }
  }
}
