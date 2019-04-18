// Ejemplo de generación de un documento PDF por medio de la librería Utilities.dll (NETFX40/NETFX45).
// Autor: Olimpo Bonilla Ramirez.
// Fecha: 2019-04-18.
// Correo electrónico: boraolim@hotmail.com

using System;
using System.IO;
using System.Text;

using Utilities;

namespace TestPDF
{
  class Program
  {
    private static string _strPDFArchivoFinal = string.Empty;                                      // Nombre del archivo final PDF.
    private static string _strFolderDestino = string.Empty;                                        // Nombre de la carpeta final donde se va a generar el documento PDF.
    private static string _strArchivoTmp = string.Empty;                                           // Nombre del archivo que se va a pasar desde el origen hasta el final.
    private static string _strFolderTmp = string.Empty;                                            // Nombre de la carpeta temporal donde se guarda el archivo temporalmente.

    private static StringBuilder _oSb = new StringBuilder();

    static void Main(string[] args)
    {
      try
      {
        // Genero un HTMLString para convertir a PDF.
        var _strHTML = new StringBuilder();

        // Genero un CSSString para aplicarlo a un texto HTML.
        var _strCSS3 = string.Empty;

        // Genero un estilo CSS3:
        _strCSS3 = "body { font-size: 0.665em; font-family: Georgia, serif; text-align:justify; } ";
        _strCSS3 += "h1 { color: #661400; }";
        _strCSS3 += "h2 { color: #0066ff; font-size: 1.265em; font-weight: bold; } ";

        // Un parrafo.
        var _strParrafo1 = @"El cálculo diferencial es una parte del análisis matemático que consiste en el estudio de cómo cambian las funciones cuando sus variables cambian. " +
                           @"El principal objeto de estudio en el cálculo diferencial es la derivada. Una noción estrechamente relacionada es la de diferencial de una función.";

        // Defino la plantilla HTML.
        _strHTML.Clear().AppendFormat("<!DOCTYPE html><html><head><meta charset = \"utf-8\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
        _strHTML.AppendFormat("<meta name=\"description\" content=\"website description\" />");
        _strHTML.AppendFormat("<meta name=\"keywords\" content=\"website keywords, website keywords\" />");
        _strHTML.AppendFormat("<meta http-equiv=\"Content-Script-Type\" content=\"text/javascript\" />");
        _strHTML.AppendFormat("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,chrome=1\" />");
        _strHTML.AppendFormat("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\" />");
        _strHTML.AppendFormat("<title>Conceptos de Cálculo Diferencial</title>");
        _strHTML.AppendFormat("</head><body><h2>Calculo Diferencial</h2><p>{0}</p><p style=\"page-break-after: always;\">&nbsp;</p><p>Hola. Esta es una nueva pagina.</p></body></html>", _strParrafo1);

        // Realizo la conversión de HTML a PDF, firmado y protegido.
        // Parametros: objeto 'InformacionArchivoPDF', el string que contenga HTML embebido, el string que contenga el formato CSS3 embebido y el nombre del archivo PDF final.
        GenerarPDF.HTMLToPDF(new InformacionArchivoPDF()
        {
          Titulo = "Documento digitalizado generado por la librería Utilities.Dll.",
          Asunto = "Documento digitalizado generado por la librería Utilities.Dll",
          Autor = "Olimpo Bonilla Ramirez",
          Contrasenia = Tool.RandomString(25),
          Creador = "Empresa S.A. de C.V.",
          PalabraClave = "Digitalizacion, Credito"
        }, _strHTML.ToString(), _strCSS3.ToString(), Path.Combine(Directory.GetCurrentDirectory(), "UrlToPdf.pdf"));

        Console.WriteLine("El documento PDF generado desde HTML se ha generado correctamente.");

        // Para el armado de expresiones HTML, consulte esta liga:
        // https://www.rapidtables.com/web/html/html-codes.html

        // En ambiente Windows, uso la función "OpenFileByProcess" para mostrar en pantalla el documento PDF generado.
        // Tool.OpenFileByProcess(Path.Combine(Directory.GetCurrentDirectory(), "UrlToPdf.pdf"));

        // Ahora aqui sigue la generación de un documento PDF.
        // Coloque aquí en la linea siguiente la carpeta donde se encuentran los archivos que se van 
        // a exportar a formato PDF.
        var ListArchivos = Tool.SelectFilesByFolderFullPaths(Directory.GetCurrentDirectory() + @"\temp", "*.*");

        // Ejecutamos la función 
        GenerarPDF.GeneratePDFFromFiles(new InformacionArchivoPDF()
        {
          Titulo = "Documento digitalizado generado por la librería Utilities.Dll.",
          Asunto = "Documento digitalizado generado por la librería Utilities.Dll",
          Autor = "Olimpo Bonilla Ramirez",
          Contrasenia = Tool.RandomString(25),
          Creador = "Empresa S.A. de C.V.",
          PalabraClave = "Digitalizacion, Credito"
        }, ListArchivos, Path.Combine(Directory.GetCurrentDirectory(), "UrlToPdfImg.pdf"), true);

        Console.WriteLine("El documento PDF generado por archivos se ha generado correctamente.");

        // En ambiente Windows, uso la función "OpenFileByProcess" para mostrar en pantalla el documento PDF generado.
        // Tool.OpenFileByProcess(Path.Combine(Directory.GetCurrentDirectory(), "UrlToPdfImg.pdf"));

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