namespace TestUtilities
{
  using System;
  using System.IO;
  using System.Text;

  using Utilities;
  
public class mtClases
  {
    public int Id_clase;
    public int Id_tipoact;
    public string Descripcion;
    public bool IsDeleted;
    public DateTime Fech_alt;
    public DateTime? Fech_act;
  }

  public class ListaBD
  {
    [DataNames("Database", "Database")]
    public string Database { get; set;}
  }

  [Serializable]
  public class Person
  {
    [DataNames("first_name", "firstName")]
    public string FirstName { get; set; }

    [DataNames("last_name", "lastName")]
    public string LastName { get; set; }

    [DataNames("dob", "dateOfBirth")]
    public DateTime DateOfBirth { get; set; }

    [DataNames("job_title", "jobTitle")]
    public string JobTitle { get; set; }

    [DataNames("taken_name", "nickName")]
    public string TakenName { get; set; }

    [DataNames("is_american", "isAmerican")]
    public bool IsAmerican { get; set; }
  }
  

  public class Program
  {
    [STAThread()]
    static void Main(string[] args)
    {
      try
      {
        GlobalApp.oLog = new LOGFiles(GlobalApp.FolderLog.Trim(), "TestConsole", "Program.cs", "Main", "TestConsole", AssemblyInfo.Company.Trim());
        GlobalApp.DetailLog = new List<DetailLOG>(); GlobalApp.iCount = 1; GlobalApp.Numero = 0; GlobalApp.Mensaje = string.Empty; GlobalApp.FechaActual = DateTime.Now; _oTime0 = DateTime.Now;
        if (Directory.Exists(GlobalApp.FolderLog.Trim()) == false) { Directory.CreateDirectory(GlobalApp.FolderLog.Trim()); }                  // Carpeta de los archivos LOG de la aplicación.
        if (Directory.Exists(GlobalApp.FolderTemporal.Trim()) == false) { Directory.CreateDirectory(GlobalApp.FolderTemporal.Trim()); }        // Carpeta de archivo de reportes finales.
        if (Directory.Exists(GlobalApp.FolderLayOut.Trim()) == false) { Directory.CreateDirectory(GlobalApp.FolderLayOut.Trim()); }            // Carpeta de archivo de layout.

        Console.WriteLine("Consola de aplicación en .NET Core.\nVersión " + AssemblyInfo.Version.ToString());
        Console.WriteLine("México " + DateTime.Now.Year.ToString() + ".\n");

        Console.WriteLine("Fecha de inicio: " + _oTime0.ToString());

        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.Informacion,
          Numero = 0,
          Comentario = "Fecha de inicio: " + _oTime0.ToString()
        });

        // Inicializamos las variables.
        InitVars();

        Console.WriteLine("Fecha universal: {0}", Tool.ToDateUniversal(DateTime.Now));

        var _ValoraCifrar = "Que_Chingue_A_Su_Mother_AMLO_Y_EL_AMERICA";
        var _strNewGUID = Guid.NewGuid().ToString();
        Console.WriteLine("Valor a cifrar: {0}. Valor cifrado: {1}.", _ValoraCifrar, RijndaelManagedEncryption.EncryptRijndael(_ValoraCifrar, _strNewGUID));
        Console.WriteLine("Valor desencriptado: {0}.", RijndaelManagedEncryption.DecryptRijndael(RijndaelManagedEncryption.EncryptRijndael(_ValoraCifrar, _strNewGUID), _strNewGUID));

        // Mapeo de DataTables.
        var priestsDataSet = DataSetGenerator.Priests();
        DataNamesMapper<Person> mapper = new DataNamesMapper<Person>();
        List<Person> persons = mapper.Map(priestsDataSet.Tables[0]).ToList();

        var ranchersDataSet = DataSetGenerator.Ranchers();
        persons.AddRange(mapper.Map(ranchersDataSet.Tables[0]));

        foreach (var person in persons)
        {
          Console.WriteLine("First Name: " + person.FirstName + ", Last Name: " + person.LastName
                            + ", Date of Birth: " + person.DateOfBirth.ToShortDateString()
                            + ", Job Title: " + person.JobTitle + ", Nickname: " + person.TakenName
                            + ", Is American: " + person.IsAmerican);
        }

        Console.WriteLine("Fecha universal: {0}", Tool.ToDateUniversal(DateTime.Now));

        var strDato = "CapMax = ((DepositoConceptoJubilacionPension - CargosDomiciliados - CargosConceptoCreditos) * 0.4);nnCapMax=n((DepositoConceptoJubilacionPension - CargosDomiciliados - CargosConceptoCreditos) - CapMax) n> (NúmeroCasasComerciales < 2 ? 400 : 800)? CapMax : (NúmeroCasasComerciales < 2 ? 400 : 800);nnCapMax = CapMax > 0 ? CapMax : 0;tnnCapMax = NúmeroCasasComerciales >= 3 ? 0 : CapMax;";
        Console.WriteLine("Dato anterior: {0}", strDato);
        strDato = Regex.Replace(strDato, Patrones.PatronAlphaLatino.Trim(), string.Empty);
        Console.WriteLine("Dato nuevo: {0}", strDato);		  
		  	  
        var _oSb = new StringBuilder();

        // _oSb.Clear().AppendFormat("SELECT trim(t1.userguid) as Id, trim(t1.username) as UserName, ");
        // _oSb.AppendFormat("trim(t1.descusuario) as Usuario, trim(t1.Email) as Email, trim(t1.hash) as Hash, trim(t1.keyrol) as KeyRol, ");
        // _oSb.AppendFormat("trim(t1.descrol) as DescRol, TRIM(t1.keysucursal) as KeySucursal, TRIM(t1.keyclas) as KeyClas, t1.fechaalta, (1::int) as Status ");
        // _oSb.AppendFormat("FROM public.\"schema-identityusers-keops\" t1 WHERE (t1.userguid = '{0}');", id);

        // Si se desea restringir cuentas de usuario que tengan asignados reportes personalizados solamente, entonces descomentar las siguientes lineas.
        _oSb.Clear().AppendFormat("SELECT trim(t1.userguid) as Id, trim(t1.username) as UserName, trim(t1.descusuario) as Usuario, trim(t1.Email) as Email,  ");
        _oSb.AppendFormat("trim(t1.hash) as Hash, trim(t1.keyrol) as KeyRol, trim(t1.descrol) as DescRol, ");
        _oSb.AppendFormat("TRIM(t1.keysucursal) as KeySucursal, TRIM(t1.keyclas) as KeyClas, t1.fechaalta, (1::int) as Status ");
        _oSb.AppendFormat("FROM public.\"schema-identityusers-keops\" t1 ");
        _oSb.AppendFormat("INNER JOIN public.\"schema-relacionusuarioreporte-keops\" t2 ON (t2.keyusuario = t1.username) AND (t2.keyrol = t1.keyrol) ");
        _oSb.AppendFormat("WHERE (t1.username = 'OBONILLA') ");
        _oSb.AppendFormat("GROUP BY t1.userguid, t1.username, t1.descusuario,t1.Email, t1.hash, t1.keyrol, t1.descrol, t1.keysucursal, t1.keyclas, t1.fechaalta;");

        // Uso de DbManager.
        using (var oDb = new DBManager("Nombre_Cadena_Conexión_desde_archivo_Configuracion"))
        {
          var strJSONTemplate = oDb.GetDataTojqGridJSONTakeToCount("Prueba", 100, _oSb.ToString(), System.Data.CommandType.Text, null);

          Console.WriteLine("Consulta ejecutada correctamente: {0}.", strJSONTemplate.Trim());

          // Carpeta de archivo de reportes finales.
          if (Directory.Exists(GlobalApp.FolderTemp.Trim()) == false) { Directory.CreateDirectory(GlobalApp.FolderTemp.Trim()); }

          // Si la carpeta no existe, la creamos.
          var _strArchivoExcel = Path.Combine(GlobalApp.FolderTemp.Trim(), string.Format("{0}.csv", Guid.NewGuid().ToString()));
          var UrlSourceDrive = string.Empty; var IdKeyGoogleDrive = string.Empty;

          oDb.ExportDataToGoogleSheetsInFolderWithPermissions(_strArchivoExcel, ",", "ClientId", "SecretId", GlobalApp.FolderPersonal.Trim(), "AplicacionGoogleAPI", "Identificador_Google_Drive", "correo@gmail.com", 
                                                              GoogleDrivePermissions.Reader, GoogleDriveGroups.User, false, false, true, out UrlSourceDrive, out IdKeyGoogleDrive, _oSb.ToString(), System.Data.CommandType.Text, null);

          Console.WriteLine("Identificadores de Google Drive: {0} y {1}", UrlSourceDrive, IdKeyGoogleDrive);
        } // Fin del objeto DbManager.
      }
      catch(Exception oEx)
      {
        GlobalApp.Numero = 100; GlobalApp.Mensaje = string.Concat(((oEx.InnerException == null) ? oEx.Message.Trim() : oEx.InnerException.Message.ToString()));
        GlobalApp.DetailLog.Add(new DetailLOG()
        {
          Id = GlobalApp.iCount++,
          Fecha = DateTime.Now.ToString("yyyy'/'MM'/'dd' 'hh':'mm':'ss'.'fff' 'tt"),
          TipoEvento = TipoInformacion.ErrorProceso,
          Numero = GlobalApp.Numero,
          Comentario = GlobalApp.Mensaje
        });
        Console.WriteLine("Ocurrieron errores al ejecutar este proceso: " + GlobalApp.Mensaje.Trim() + ". Seguimiento de pila: " + oEx.StackTrace.Trim());
      }
      finally
      {
        // Limpiamos variables.
        _oTime1 = DateTime.Now; _oTimeTotal = new TimeSpan(_oTime1.Ticks - _oTime0.Ticks); DestroyVars();

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
        GlobalApp.oLog.ListEvents = GlobalApp.DetailLog; XMLSerializacion<LOGFiles>.WriteToXmlFile(Path.Combine(GlobalApp.FolderLog, string.Concat("LOGTestConsole_", DateTime.Now.ToString("yyyy''MM''dd''hh''mm''ss''fff"), ".xml")), GlobalApp.oLog, false);
        GlobalApp.DetailLog = null; GlobalApp.oLog = null;

        Console.WriteLine("Pulse cualquier tecla para salir..."); Console.ReadLine();
      }
    }

    /// <summary>
    /// Inicialización de variables.
    /// </summary>
    private static void InitVars()
    {
      _oSb = new StringBuilder(); _oSb.Clear();
    }

    /// <summary>
    /// Destrucción de variables.
    /// </summary>
    private static void DestroyVars()
    {
      _oSb = null;
    }
  }
}
