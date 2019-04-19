// Ejemplo de generación de conexión a Base de Datos por medio de la librería Utilities.dll (NETFX40/NETFX45).
// Autor: Olimpo Bonilla Ramirez.
// Fecha: 2019-04-18.
// Correo electrónico: boraolim@hotmail.com

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using System.Data.SqlClient;
using System.Data.SqlTypes;

using Utilities;
using System.Linq;

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
      // Inicializamos el objeto StringBuilder.
      _oSb = new StringBuilder();

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

        // Creamos una sentencia SQL con un array de parametros.
        var Valor1 = "America";
        var Valor2 = 1;
        var _oParam = new List<SqlParameter>();
        _oParam.Add(new SqlParameter("@P1", System.Data.SqlDbType.VarChar, 255, Valor1));
        _oParam.Add(new SqlParameter("@P2", System.Data.SqlDbType.Int, Valor2));

        _oSb.Clear().AppendFormat("SELECT * FROM mtEquipos t1 Where (t1.Nombre = @P1) and (t1.IdEquipo = @P2);");

        // Aqui establezco:
        // * Nombre de la cadena de conexión a Base de Datos.
        // * La sentencia SQL con los parametros de entrada.
        // * El array de parametros para SQL Server (Para MySQL, seria el objeto MySQLParameter.
        // * Tiempo de respuesta de Base de Datos.
        // * Numero de intentos.
        // Si la salida del set de datos es correcta, convierte el resultado de la consulta en un List<T>. De lo contrario, lanzará una excepción.
        // Si solo se desean ver X número de columnas, los atributos de la clase deben ser iguales a los nombres de las columnas de la sentencia SQL
        // que se va a mandar a Base de Datos.
        var _Ret = SQLServerConnectionDB.GetData<Equipo>("Cadena_Conexion_Base_Datos", _oSb.ToString(), _oParam, 60, 5).ToList();
        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.Informacion,
          Numero = 0,
          Comentario = _oSb.Clear().AppendFormat("Total de registros cargados: {0}.", _Ret.Count).ToString()
        });

        // Teniendo aqui el set de datos, se puede manipular al gusto del desarrollador.

        // Se aplica del mismo modo los mismos parametros para la funcion 'SQLServerConnectionDB.ExecuteQuery()' para ejecutar 
        // otras operaciones del tipo INSERT, UPDATE, DELETE o bien un stored procedure sin retorno de datos.
        // De la misma manera tambien las funciones antes mencionadas existen en las clases 'MySQLConnectionDB' y 'PostgreSQLConnectionDB'.

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
