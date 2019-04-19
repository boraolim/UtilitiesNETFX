// Ejemplo de generación de un archivo JSON por medio de la librería Utilities.dll (NETFX40/NETFX45).
// Autor: Olimpo Bonilla Ramirez.
// Fecha: 2019-04-18.
// Correo electrónico: boraolim@hotmail.com

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
  class Program
  {
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

      var ArchivoJSON = Directory.GetCurrentDirectory() + @"\temp\" + Tool.RandomString(25) + ".json";

      try
      {
        // Generando un archivo JSON de la lista.
        JSONSerializacion<List<Equipo>>.WriteToJsonFile(ArchivoJSON, _oLstEquipos, true);
        Console.WriteLine("Se ha generado correctamente el archivo JSON {0}.", ArchivoJSON);

        // Cargamos el mismo archivo JSON a una lista generica para ostrar su numero total de registros.
        var _NuevaLista = JSONSerializacion<List<Equipo>>.ReadFromJsonFile(ArchivoJSON);
        Console.WriteLine("Total de registros cargados desde el archivo {0}: {1}.", ArchivoJSON, _NuevaLista.Count);

        // La lista generica la convierto en JSON string.
        Console.WriteLine("Contenido JSON: {0}.", JSONSerializacion<List<Equipo>>.JSONSerialize(_oLstEquipos));

        // Recupero el JSON string anterior a un objeto nuevo.
        Console.WriteLine("Total de registros recuperados: {0}.", JSONSerializacion<List<Equipo>>.JSONDeserialize(JSONSerializacion<List<Equipo>>.JSONSerialize(_oLstEquipos), true).Count);
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
