// Ejemplo de generación de un archivo LOG por medio de la librería Utilities.dll (NETFX40/NETFX45).
// Autor: Olimpo Bonilla Ramirez.
// Fecha: 2019-04-18.
// Correo electrónico: boraolim@hotmail.com

using System;
using System.Collections.Generic;
using System.IO;
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
    private static DateTime _oScheduledTime = DateTime.Now;                                                    // Fecha actual.
    private static DateTime _oTime0;                                                                           // Tiempo inicial para escribir el log.
    private static DateTime _oTime1;                                                                           // Tiempo final para escribir el log.
    private static TimeSpan _oTimeTotal;                                                                       // La diferencia entre el tiempo inicial y el tiempo final.
    private static StringBuilder _oSb = null;                                                                  // Objeto StringBuilder.

    static void Main(string[] args)
    {
      // Nuestra lista de ejemplo.
      var _oLstEquipos = new List<Equipo>()
      {
        new Equipo() { IdEquipo = 1, Nombre = "Cruz Azul", Valor = 20.50M, Estatus = true, FechaAlta = DateTime.Now },
        new Equipo() { IdEquipo = 2, Nombre = "America", Valor = 200.50M, Estatus = true, FechaAlta = DateTime.Now },
        new Equipo() { IdEquipo = 3, Nombre = "Chivas", Valor = 2010.50M, Estatus = true, FechaAlta = DateTime.Now },
        new Equipo() { IdEquipo = 4, Nombre = "Barcelona", Valor = 2400.50M, Estatus = true, FechaAlta = DateTime.Now },
        new Equipo() { IdEquipo = 5, Nombre = "Real Mandril", Valor = 1200.50M, Estatus = true, FechaAlta = DateTime.Now }
      };

      // Inicializamos el objeto StringBuilder.
      _oSb = new StringBuilder(); var ArchivoJSON = Directory.GetCurrentDirectory() + @"\temp\" + Tool.RandomString(25) + ".json";

      try
      {
        // Aqui creamos las lineas del archivo LOG que se guardar al final de la ejecucion de este programa.
        GlobalApp.oLog = new LOGFiles(GlobalApp.FolderLog.Trim(), "TestPDF", "Program.cs", "Main", "TestPDF", AssemblyInfo.Company.Trim());
        GlobalApp.DetailLog = new List<DetailLOG>(); GlobalApp.iCount = 1; GlobalApp.Numero = 0; GlobalApp.Mensaje = string.Empty; GlobalApp.FechaActual = DateTime.Now; _oTime0 = DateTime.Now;
        if (Directory.Exists(GlobalApp.FolderLog.Trim()) == false) { Directory.CreateDirectory(GlobalApp.FolderLog.Trim()); }                  // Carpeta de los archivos LOG de la aplicación.
        if (Directory.Exists(GlobalApp.FolderRpt.Trim()) == false) { Directory.CreateDirectory(GlobalApp.FolderRpt.Trim()); }                  // Carpeta de archivo de reportes finales.
        if (Directory.Exists(GlobalApp.FolderLayOut.Trim()) == false) { Directory.CreateDirectory(GlobalApp.FolderLayOut.Trim()); }            // Carpeta de archivo de layout.
        if (Directory.Exists(GlobalApp.FolderLayOutEnd.Trim()) == false) { Directory.CreateDirectory(GlobalApp.FolderLayOutEnd.Trim()); }      // Carpeta de archivo de layoutEnd.

        Console.WriteLine("Fecha de inicio: " + _oTime0.ToString());

        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.Informacion,
          Numero = 0,
          Comentario = _oSb.Clear().AppendFormat("Fecha de inicio: {0}.", _oTime0.ToString()).ToString()
        });

        // Generando un archivo JSON de la lista.
        JSONSerializacion<List<Equipo>>.WriteToJsonFile(ArchivoJSON, _oLstEquipos, true);
        Console.WriteLine("Se ha generado correctamente el archivo JSON {0}.", ArchivoJSON);

        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.Informacion,
          Numero = 0,
          Comentario = _oSb.Clear().AppendFormat("Se ha generado correctamente el archivo JSON {0}.", ArchivoJSON).ToString()
        });

        // Cargamos el mismo archivo JSON a una lista generica para ostrar su numero total de registros.
        var _NuevaLista = JSONSerializacion<List<Equipo>>.ReadFromJsonFile(ArchivoJSON);
        Console.WriteLine("Total de registros cargados desde el archivo {0}: {1}.", ArchivoJSON, _NuevaLista.Count);

        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.Informacion,
          Numero = 0,
          Comentario = _oSb.Clear().AppendFormat("Total de registros cargados desde el archivo {0}: {1}.", ArchivoJSON, _NuevaLista.Count).ToString()
        });

        // La lista generica la convierto en JSON string.
        Console.WriteLine("Contenido JSON: {0}.", JSONSerializacion<List<Equipo>>.JSONSerialize(_oLstEquipos));
        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.Informacion,
          Numero = 0,
          Comentario = _oSb.Clear().AppendFormat("Se ha generado la cadena JSON correctamente.").ToString(),
          Valor = JSONSerializacion<List<Equipo>>.JSONSerialize(_oLstEquipos)
        });

        // Recupero el JSON string anterior a un objeto nuevo.
        Console.WriteLine("Total de registros recuperados: {0}.", JSONSerializacion<List<Equipo>>.JSONDeserialize(JSONSerializacion<List<Equipo>>.JSONSerialize(_oLstEquipos), true).Count);
        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.Informacion,
          Numero = 0,
          Comentario = _oSb.Clear().AppendFormat("Total de registros recuperados: {0}.", JSONSerializacion<List<Equipo>>.JSONDeserialize(JSONSerializacion<List<Equipo>>.JSONSerialize(_oLstEquipos), true).Count).ToString()
        });
      }
      catch (Exception oEx)
      {

        // Cuando ocurre una excepcion, tambien guardamos el detalle del mismo.
        GlobalApp.Numero = 100; GlobalApp.Mensaje = string.Concat(((oEx.InnerException == null) ? oEx.Message.Trim() : oEx.InnerException.Message.ToString()));
        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.ErrorProceso,
          Numero = GlobalApp.Numero,
          Comentario = GlobalApp.Mensaje
        });
        Console.WriteLine("Ocurrió un error: {0}", oEx.Message.Trim());
      }
      finally
      {
        // Limpiamos variables.
        _oTime1 = DateTime.Now; _oTimeTotal = new TimeSpan(_oTime1.Ticks - _oTime0.Ticks); _oSb = null;

        // Obtengo la fecha de termino.
        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.Informacion,
          Numero = 0,
          Comentario = "Fecha de termino: " + _oTime1.ToString()
        });
        Console.WriteLine("Fecha de termino: " + _oTime1.ToString());

        // Obtengo el tiempo transcurrido.
        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.Informacion,
          Numero = 0,
          Comentario = "Tiempo transcurrido en ejecutarse este proceso: " + _oTimeTotal.ToString()
        });
        Console.WriteLine("Tiempo transcurrido en ejecutarse este proceso: " + _oTimeTotal.ToString());

        // Guardamos los mensajes en el log y limpiamos las variables.
        GlobalApp.oLog.ListEvents = GlobalApp.DetailLog;
        XMLSerializacion<LOGFiles>.WriteToXmlFile(GlobalApp.FolderLog + @"\LOGTestPDF_" + DateTime.Now.ToString("yyyy''MM''dd''hh''mm''ss''fff") + ".xml", GlobalApp.oLog, false);
        GlobalApp.DetailLog = null; GlobalApp.oLog = null;

        Console.WriteLine("Presione cualquier tecla para salir..."); Console.ReadKey();
      }
    }
  }
}

// NOTAS: Siempre se necesita el archivo GlobalApp.cs para tener la carpeta raiz de la aplicacion y el objeto DetailLog para guardar informacion en el
// archivo LOG final. Cuando se haya terminado de guardar el LOG, se procede a guardar fisicamente el LOG en un archivo XML de la carpeta de la aplicacion.
