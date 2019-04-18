// Ejemplo de generación y carga de un archivo CSV por medio de la librería Utilities.dll (NETFX40/NETFX45).
// Autor: Olimpo Bonilla Ramirez.
// Fecha: 2019-04-18.
// Correo electrónico: boraolim@hotmail.com

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Utilities;

namespace TestPDF
{
  public class Equipo
  {
    public int IdEquipo { get; set; }
    public string Nombre { get; set; }
    public decimal Valor { get; set; }
    public bool Estatus { get; set; }
    public DateTime FechaAlta { get; set; }
  }

  /// <summary>
  /// Clase para la carga de archivos de pagos realizados en formato CSV.
  /// </summary>
  [Serializable]
  public class EquiposCSV
  {
    [Column(Name = "IdEquipo", DataType = typeof(int))]
    public int IdEquipo { get; set; }

    [Column(Name = "Nombre", DataType = typeof(string))]
    public string Nombre { get; set; }

    [Column(Name = "Valor", DataType = typeof(decimal))]
    public decimal Valor { get; set; }

    [Column(Name = "Estatus", DataType = typeof(bool))]
    public bool Estatus { get; set; }

    [Column(Name = "FechaAlta", DataType = typeof(DateTime))]
    public DateTime FechaAlta { get; set; }
  }
  class Program
  {
    private static StringBuilder _oSb = new StringBuilder();

    static void Main(string[] args)
    {
      var _oLstEquipos = new List<Equipo>()
      {
        new Equipo() { IdEquipo = 1, Nombre = "Cruz Azul", Valor = 20.50M, Estatus = true, FechaAlta = DateTime.Now },
        new Equipo() { IdEquipo = 2, Nombre = "America", Valor = 200.50M, Estatus = true, FechaAlta = DateTime.Now },
        new Equipo() { IdEquipo = 3, Nombre = "Chivas", Valor = 2010.50M, Estatus = true, FechaAlta = DateTime.Now },
        new Equipo() { IdEquipo = 4, Nombre = "Barcelona", Valor = 2400.50M, Estatus = true, FechaAlta = DateTime.Now },
        new Equipo() { IdEquipo = 5, Nombre = "Real Mandril", Valor = 1200.50M, Estatus = true, FechaAlta = DateTime.Now }
      };

      var ArchivoCSV = Directory.GetCurrentDirectory() + @"\temp\" + Tool.RandomString(25) + ".csv";

      try
      {
        // Generando un archivo CSV de la lista.
        Tool.ListToCSV(_oLstEquipos, ArchivoCSV);
        Console.WriteLine("Se ha generado correctamente el archivo CSV {0}.", ArchivoCSV);

        // Cargamos el mismo archivo a una lista generica para ostrar su numero total de registros.
        var _NuevaLista = new TextFileReader<EquiposCSV>(ArchivoCSV.Trim(), ",").ToList();
        Console.WriteLine("Total de registros cargados desde el archivo {0}: {1}.", ArchivoCSV, _NuevaLista.Count);
      }
      catch (Exception oEx)
      {
        Console.WriteLine("Ocurrió un error: {0}", oEx.Message.Trim());
      }
      finally
      {
        Console.WriteLine("Presione cualquier tecla para salir..."); Console.ReadKey();
      }
    }
  }
}
