using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  public class DatabaseManager_Class
    {
    private readonly string connectionString_Field;
    private readonly bool useDatabase_Field;
    private readonly string textFilePath_Field;
    private static bool errorMessageShown_Field = false;

    public DatabaseManager_Class( bool useDatabase_Parameter )
      {
      this.useDatabase_Field = useDatabase_Parameter;
      this.textFilePath_Field = Path.Combine(
          Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ),
          "IPA_Notenrechner",
          "templates.json" );

      if ( useDatabase_Parameter )
        {
        string computerName_Variable = Environment.MachineName.ToLower();
        if ( computerName_Variable == "desktop-o9bmbcb" )
          {
          connectionString_Field = ConfigurationManager.ConnectionStrings[ "NotenrechnerDbPC" ].ConnectionString;
          }
        else if ( computerName_Variable == "laptop-6hk14r0a" )
          {
          connectionString_Field = ConfigurationManager.ConnectionStrings[ "NotenrechnerDbLaptop" ].ConnectionString;
          }

        if ( !EnsureTemplateTableExists() && !errorMessageShown_Field )
          {
          errorMessageShown_Field = true;
          MessageBox.Show(
              "Keine lokale Datenbank erkannt. Die Anwendung wird im Offline-Modus gestartet.",
              "Hinweis",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information );
          this.useDatabase_Field = false;
          }
        }

      Directory.CreateDirectory( Path.GetDirectoryName( textFilePath_Field ) );
      }

    public bool TestConnection()
      {
      if ( !useDatabase_Field ) return true;

      try
        {
        using ( SqlConnection connection_Variable = new SqlConnection( connectionString_Field ) )
          {
          connection_Variable.Open();

          if ( EnsureTemplateTableExists() )
            {
            if ( !errorMessageShown_Field )
              {
              MessageBox.Show( "Verbindung zur Datenbank erfolgreich!" );
              }
            return true;
            }
          return false;
          }
        }
      catch ( Exception )
        {
        if ( !errorMessageShown_Field )
          {
          errorMessageShown_Field = true;
          MessageBox.Show(
              "Keine lokale Datenbank erkannt. Die Anwendung wird im Offline-Modus gestartet.",
              "Hinweis",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information );
          }
        return false;
        }
      }

    public bool SaveTemplate( Template_Class template_Parameter )
      {
      if ( useDatabase_Field )
        {
        return SaveTemplateToDatabase( template_Parameter );
        }
      else
        {
        return SaveTemplateToFile( template_Parameter );
        }
      }

    private bool SaveTemplateToDatabase( Template_Class template_Parameter )
      {
      try
        {
        using ( SqlConnection connection_Variable = new SqlConnection( connectionString_Field ) )
          {
          connection_Variable.Open();
          string query_Variable = @"
                        INSERT INTO Templates (Name, KompetenzPunkte, DokumentationPunkte, PraesentationPunkte)
                        VALUES (@Name, @KompetenzPunkte, @DokumentationPunkte, @PraesentationPunkte)";

          using ( SqlCommand command_Variable = new SqlCommand( query_Variable, connection_Variable ) )
            {
            command_Variable.Parameters.AddWithValue( "@Name", template_Parameter.Name_Property );
            command_Variable.Parameters.AddWithValue( "@KompetenzPunkte", string.Join( ",", template_Parameter.KompetenzPunkte_Property ) );
            command_Variable.Parameters.AddWithValue( "@DokumentationPunkte", string.Join( ",", template_Parameter.DokumentationPunkte_Property ) );
            command_Variable.Parameters.AddWithValue( "@PraesentationPunkte", string.Join( ",", template_Parameter.PraesentationPunkte_Property ) );

            command_Variable.ExecuteNonQuery();
            return true;
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Speichern des Templates: {ex_Variable.Message}" );
        return false;
        }
      }

    private bool SaveTemplateToFile( Template_Class template_Parameter )
      {
      try
        {
        List<Template_Class> templates_Variable = LoadAllTemplatesFromFile();

        templates_Variable.RemoveAll( t_Parameter => t_Parameter.Name_Property == template_Parameter.Name_Property );
        templates_Variable.Add( template_Parameter );

        string jsonString_Variable = JsonSerializer.Serialize( templates_Variable, new JsonSerializerOptions
          {
          WriteIndented = true
          } );
        File.WriteAllText( textFilePath_Field, jsonString_Variable );
        return true;
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Speichern des Templates in Datei: {ex_Variable.Message}" );
        return false;
        }
      }

    public List<string> GetTemplateNames()
      {
      if ( useDatabase_Field )
        {
        return GetTemplateNamesFromDatabase();
        }
      else
        {
        return GetTemplateNamesFromFile();
        }
      }

    private List<string> GetTemplateNamesFromDatabase()
      {
      List<string> templateNames_Variable = new List<string>();
      try
        {
        using ( SqlConnection connection_Variable = new SqlConnection( connectionString_Field ) )
          {
          connection_Variable.Open();
          string query_Variable = "SELECT Name FROM Templates ORDER BY Name";

          using ( SqlCommand command_Variable = new SqlCommand( query_Variable, connection_Variable ) )
          using ( SqlDataReader reader_Variable = command_Variable.ExecuteReader() )
            {
            while ( reader_Variable.Read() )
              {
              templateNames_Variable.Add( reader_Variable[ "Name" ].ToString() );
              }
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        if ( !errorMessageShown_Field )
          {
          MessageBox.Show( $"Fehler beim Laden der Template-Namen: {ex_Variable.Message}" );
          }
        }
      return templateNames_Variable;
      }

    private List<string> GetTemplateNamesFromFile()
      {
      try
        {
        var templates_Variable = LoadAllTemplatesFromFile();
        return templates_Variable.Select( t_Parameter => t_Parameter.Name_Property ).OrderBy( n_Parameter => n_Parameter ).ToList();
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Laden der Template-Namen aus Datei: {ex_Variable.Message}" );
        return new List<string>();
        }
      }

    public Template_Class LoadTemplate( string name_Parameter )
      {
      if ( useDatabase_Field )
        {
        return LoadTemplateFromDatabase( name_Parameter );
        }
      else
        {
        return LoadTemplateFromFile( name_Parameter );
        }
      }

    private Template_Class LoadTemplateFromDatabase( string name_Parameter )
      {
      Template_Class template_Variable = new Template_Class();
      try
        {
        using ( SqlConnection connection_Variable = new SqlConnection( connectionString_Field ) )
          {
          connection_Variable.Open();
          string query_Variable = "SELECT * FROM Templates WHERE Name = @Name";

          using ( SqlCommand command_Variable = new SqlCommand( query_Variable, connection_Variable ) )
            {
            command_Variable.Parameters.AddWithValue( "@Name", name_Parameter );
            using ( SqlDataReader reader_Variable = command_Variable.ExecuteReader() )
              {
              if ( reader_Variable.Read() )
                {
                template_Variable.Name_Property = reader_Variable[ "Name" ].ToString();

                string[] kompetenzArray_Variable = reader_Variable[ "KompetenzPunkte" ].ToString().Split( ',' );
                string[] dokumentationArray_Variable = reader_Variable[ "DokumentationPunkte" ].ToString().Split( ',' );
                string[] praesentationArray_Variable = reader_Variable[ "PraesentationPunkte" ].ToString().Split( ',' );

                template_Variable.KompetenzPunkte_Property = Array.ConvertAll( kompetenzArray_Variable, Double.Parse ).ToList();
                template_Variable.DokumentationPunkte_Property = Array.ConvertAll( dokumentationArray_Variable, Double.Parse ).ToList();
                template_Variable.PraesentationPunkte_Property = Array.ConvertAll( praesentationArray_Variable, Double.Parse ).ToList();
                }
              }
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        if ( !errorMessageShown_Field )
          {
          MessageBox.Show( $"Fehler beim Laden des Templates: {ex_Variable.Message}" );
          }
        }
      return template_Variable;
      }

    private Template_Class LoadTemplateFromFile( string name_Parameter )
      {
      try
        {
        var templates_Variable = LoadAllTemplatesFromFile();
        return templates_Variable.FirstOrDefault( t_Parameter => t_Parameter.Name_Property == name_Parameter ) ?? new Template_Class();
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Laden des Templates aus Datei: {ex_Variable.Message}" );
        return new Template_Class();
        }
      }

    private List<Template_Class> LoadAllTemplatesFromFile()
      {
      if ( !File.Exists( textFilePath_Field ) )
        {
        return new List<Template_Class>();
        }

      try
        {
        string jsonString_Variable = File.ReadAllText( textFilePath_Field );
        return JsonSerializer.Deserialize<List<Template_Class>>( jsonString_Variable ) ?? new List<Template_Class>();
        }
      catch
        {
        return new List<Template_Class>();
        }
      }

    private bool EnsureTemplateTableExists()
      {
      if ( !useDatabase_Field ) return true;

      try
        {
        using ( SqlConnection connection_Variable = new SqlConnection( connectionString_Field ) )
          {
          connection_Variable.Open();

          string checkTableQuery_Variable = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Templates')
                        BEGIN
                            CREATE TABLE Templates (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                Name NVARCHAR(255) NOT NULL,
                                KompetenzPunkte NVARCHAR(MAX),
                                DokumentationPunkte NVARCHAR(MAX),
                                PraesentationPunkte NVARCHAR(MAX),
                                CreatedAt DATETIME DEFAULT GETDATE(),
                                UpdatedAt DATETIME DEFAULT GETDATE()
                            )
                        END";

          using ( SqlCommand command_Variable = new SqlCommand( checkTableQuery_Variable, connection_Variable ) )
            {
            command_Variable.ExecuteNonQuery();
            }
          return true;
          }
        }
      catch ( Exception )
        {
        if ( !errorMessageShown_Field )
          {
          errorMessageShown_Field = true;
          MessageBox.Show(
              "Keine lokale Datenbank erkannt. Die Anwendung wird im Offline-Modus gestartet.",
              "Hinweis",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information );
          }
        return false;
        }
      }
    }
  }