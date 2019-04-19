using System;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;

using Utilities;

namespace TestPDF
{
  public static class GlobalApp
  {
    /// <summary>
    /// Aqui definimos la variable que va a guardar exactamente el archivo log generado desde el servicio de Windows ya que 
    /// si definimos la carpeta en donde se ejecuta el servicio, normalmente se generan los logs en %systemdrive%\system32 y no
    /// es aconsejable colocarlos ahí.
    /// </summary>
    public static string FolderApp = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

    /// <summary>
    /// Carpeta LOG de la aplicación.
    /// </summary>
    public static string FolderLog = string.Concat(FolderApp, @"\log");

    /// <summary>
    /// Carpeta RPT de la aplicación.
    /// </summary>
    public static string FolderRpt = string.Concat(FolderApp, @"\rpt");

    /// <summary>
    /// Carpeta LAYOUT de la aplicación.
    /// </summary>
    public static string FolderLayOut = string.Concat(FolderApp, @"\layout");

    /// <summary>
    /// Carpeta LAYOUT de la aplicación.
    /// </summary>
    public static string FolderLayOutEnd = string.Concat(FolderApp, @"\layoutEnd");

    /// <summary>
    /// Numero de error.
    /// </summary>
    public static uint Numero = 0;

    /// <summary>
    /// Descripción del mensaje de error.
    /// </summary>
    public static string Mensaje = string.Empty;

    /// <summary>
    /// Lista de detalles de error.
    /// </summary>
    public static List<DetailLOG> DetailLog = null;

    /// <summary>
    /// El objeto 'LOGFiles' para almacenar los mensajes de error.
    /// </summary>
    public static LOGFiles oLog = null;

    /// <summary>
    /// Contador generico para el ordenamiento de los mensajes de error.
    /// </summary>
    public static int iCount = 0;

    /// <summary>
    /// Fecha actual.
    /// </summary>
    public static DateTime FechaActual;

    /// <summary>
    /// Variable global que guarda las cadenas de conexión del archivo de configuración de la aplicacion (ConnectionStrings).
    /// </summary>
    public static ConnectionStringSettingsCollection ConnectionDB = ConfigurationManager.ConnectionStrings;

    /// <summary>
    /// Variable global que guarda las claves de la seccion de valores de la aplicación (AppSettings).
    /// </summary>
    public static NameValueCollection ValoresApp = ConfigurationManager.AppSettings;
  }
}