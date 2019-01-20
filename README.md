<h1>UtilitiesNETFX - Librería de funciones del programador para .NET.</h1>
Librería genérica para las funciones del programador exclusiva para la plataforma de Microsoft .NET Framework 4.0/4.5/4.6/4.7 y Xamarin Mono 4.4.0 en adelante.

<h2>Detalle de la versión 1.0.7.8941 (20/01/2019)</h2>
<ul type="square">
  <li>Ajuste a las clases <strong>SQLConnectionDB</strong> y <strong>MySQLConnectionDB</strong> para aceptar par&aacute;metros de manera din&aacute;mica para las consultas a SQL Server y MySQL/MariaDB Server.</li>
  <li>Clase <strong>PDFHelper</strong> y <strong>CompatiblePDF</strong> para la generaci&oacute; de documentos PDF. Se pueden guardar archivos de imagenes o PDF para unirlos en un solo archivo PDF final. Tambi&eacute;n permite insertar texto en formato HTML5/CSS3 para la generaci&oacute;n de archivos PDF.</li>
  <li>Otros ajustes adicionales.</li>
</ul>

<h2>Detalle de la versión 1.0.6.2391 (19/05/2018)</h2>
<ul type="square">
  <li>Clase <strong>SQLConnectionDB</strong> para conexiones y consultas a Microsoft SQL Server.</li>
  <li>Clase <strong>MySQLConnectionDB</strong> para conexiones y consultas a MySQL/MariaDB Server.</li>
  <li>Clase <strong>PostgreSQLConnectionDB</strong> para conexiones y consultas a PostgreSQL Server.</li>
</ul>

<h2>Detalle de la versión 1.0.5.5678 (10/05/2018)</h2>
<ul type="square">
  <li>Optimizaci&oacute;n de c&oacute;digo fuente.</li>
</ul>

<h2>Detalle de la versión 1.0.5.5678 (27/01/2018)</h2>
<ul type="square">
  <li>Incorporación de la clase <strong>CSVReader</strong> para realizar funciones de lectura y escritura de archivos del tipo CSV.</li>
</ul>

<h2>Detalle de la versión 1.0.5.3491 (26/10/2017)</h2>
<ul type="square">
  <li>Adecuación de la clase 'DataAccess' a la versión reciente de EntityFramework 6.2.0.</li>
</ul>

<h2>Detalle de la versión 1.0.4.6973 (29/08/2017)</h2>
<ul type="square">
  <li>Correcciones adicionales para optimización de funciones.</li>
</ul>

<h2>Detalle de la versión 1.0.3.7951 (28/07/2017)</h2>
<ul type="square">
  <li>Adici&oacute;n del m&eacute;todo 'RandomRoulette' para la generación de números aleatorios en la clase 'Tool'.</li>
</ul>

<h2>Detalle de la versión 1.0.3.7951 (17/05/2017)</h2>
<ul type="square">
  <li>Adición de la clase 'BaseHandler' para el manejo de controladores genericos ASHX de ASP.NET 4.0/4.5, emulando el patrón Modelo-Vista-Controlador.</li>
</ul>

<h2>Detalle de la versión 1.0.3.2730 (17/05/2017)</h2>
<ul type="square">
  <li>Adición del m&eacute;todo 'ToCollection<T>' en la clase 'Tool' para la conversión explicita de listas genéricas a colecciones genéricas.</li>
  <li>Adición de la clase 'ContainsSwith' para la emulación de la sentencia clave 'switch(x)... case' en C# para cadenas de carácteres.</li>
  <li>Correcciones en la clase 'Utilities.CustomSessionProviderSQLServer' para el proveedor genérico de estado de sesión para Microsoft SQL Server.</li>
  <li>Correcciones en la clase 'Tool', función 'ListToCSV' al momento de exportar listas genericas a formato de archivo de texto plano CSV.</li>
  <li>Correccion y optimización del proceso de exportación de listas genéricas a Microsoft Excel.</li>
</ul>


<h2>Requisitos de compilación y ejecución.</h2>
<ul type="square">
  <li>El ensamblado para la versión de Microsoft .NET Framework 4.0 solo puede ejecutarse en equipos que tengan instalado Microsoft .NET Framework 4.0 en el equipo local con Windows (Windows XP SP3/Vista/Seven/Windows 8/Windows 10 en adelante, Windows Server 2003/Windows Server 2008/Windows Server 2012 en adelante) y en Visual Studio 2010 en todas sus ediciones.</li>
  <li>El ensamblado para la versión de Microsoft .NET Framework 4.5 solo puede ejecutarse en equipos que tengan instalado Microsoft .NET Framework 4.5/4.6 en el equipo local con Windows (Windows Vista/Seven/Windows 8/Windows 10 en adelante, Windows Server 2008/Windows Server 2012 en adelante) y en Visual Studio 2012/2013/2015 en todas sus ediciones.</li>
  <li>Ambos ensamblados se ejecutan sin problemas en el compilador Mono 4.2.3 en adelante.</li>
  <li>Funciona al 100% para los servidores web Internet Information Services (Windows Server) y Apache Web Server (Linux Ubuntu Server con Mono ya configurado).</li>
</ul>

<p>Para su correcta ejecución en Microsoft Visual Studio y en ambiente de Producci&oacute;n/Pruebas, es necesario que se tenga con los siguientes paquetes Nuget para su correcta ejecución (se pueden bajar por medio de la <strong>Consola de Administración de Paquetes</strong> de Visual Studio o bien desde la opci&oacute;n <strong>Administrar los paquetes Nuget para la soluci&oacute;n</strong> de la opci&oacute;n <strong>Administrador de Paquetes Nuget</strong>, del men&uacute; <strong>Herramientas</strong> del mismo Visual Studio):</p>

<ul type="square">
  <li>Entity Framework 6.2.0.</li>
  <li>DotNet Zip 1.13.0.</li>
  <li>Iesi Collections 4.0.4.</li>
  <li>Document OpenXML SDK 2.5.</li>
  <li>SpreadSheetLight 3.4.9.</li>
  <li>NewtonSoft 12.0.1.</li>
  <li>PDFsharp 1.32.3057.0.</li>
  <li>iTextSharp 5.5.13.</li>
  <li>iTextsharp.XMLWorker 5.5.13.</li>
  <li>NgSQL 4.0.3. (Para la versión de la librería en NETFX 4.5)</li>
  <li>NgSQL 2.2.7. (Para la versión de la librería en NETFX 4.0)</li>
  <li>MySQL.Data 6.9.12.0. (Para la versión de la librería en NETFX 4.0/NETFX 4.5)</li>
  <li>System.Runtime.CompilerServices.Unsafe 4.5.2. (Para la versión de la librería en NETFX 4.5)</li>
  <li>System.Threading.Tasks.Extensions 4.5.2. (Para la versión de la librería en NETFX 4.5)</li>
  <li>System.ValueTuple 4.5.0. (Para la versión de la librería en NETFX 4.5)</li>
</ul>  

<h2>Información adicional</h2>
<strong>Autor:</strong> OLIMPO BONILLA RAMIREZ.<br/>
<strong>Versión:</strong> 1.0.7.8941<br/>
<strong>Correo electronico:</strong> boraolim@hotmail.com <br />
<strong>Ultima actualización:</strong> 20 de enero de 2019. Ciudad de M&eacute;xico.