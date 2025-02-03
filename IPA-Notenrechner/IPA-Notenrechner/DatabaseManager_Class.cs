using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace IPA_Notenrechner
  {
  public class DatabaseManager_Class
    {
    private readonly string connectionString_Variable;

    public DatabaseManager_Class()
      {
      // Verbindungsstring aus der App.config
      string computerName_Variable = Environment.MachineName.ToLower();
      if ( computerName_Variable == "desktop-o9bmbcb" )
        {
        connectionString_Variable = ConfigurationManager.ConnectionStrings[ "NotenrechnerDbPC" ].ConnectionString;
        }
      else if ( computerName_Variable == "laptop-6hk14r0a" )
        {
        connectionString_Variable = ConfigurationManager.ConnectionStrings[ "NotenrechnerDbLaptop" ].ConnectionString;
        }
      else
        {
        throw new Exception( "Unbekannter Computer" );
        }
      }

    public bool TestConnection()
      {
      try
        {
        using ( SqlConnection connection_Object = new SqlConnection( connectionString_Variable ) )
          {
          connection_Object.Open();
          MessageBox.Show( "Verbindung zur Datenbank erfolgreich!" );
          return true;
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler bei der Datenbankverbindung: {ex_Variable.Message}" );
        return false;
        }
      }

    public bool SaveTemplate( Template_Class template_Parameter )
      {
      try
        {
        using ( SqlConnection connection_Object = new SqlConnection( connectionString_Variable ) )
          {
          connection_Object.Open();
          string query_Variable = @"
                        INSERT INTO Templates (Name, KompetenzPunkte, DokumentationPunkte, PraesentationPunkte)
                        VALUES (@Name, @KompetenzPunkte, @DokumentationPunkte, @PraesentationPunkte)";

          using ( SqlCommand command_Object = new SqlCommand( query_Variable, connection_Object ) )
            {
            command_Object.Parameters.AddWithValue( "@Name", template_Parameter.Name_Property );
            command_Object.Parameters.AddWithValue( "@KompetenzPunkte",
                string.Join( ",", template_Parameter.KompetenzPunkte_Property ) );
            command_Object.Parameters.AddWithValue( "@DokumentationPunkte",
                string.Join( ",", template_Parameter.DokumentationPunkte_Property ) );
            command_Object.Parameters.AddWithValue( "@PraesentationPunkte",
                string.Join( ",", template_Parameter.PraesentationPunkte_Property ) );

            command_Object.ExecuteNonQuery();
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

    public List<string> GetTemplateNames()
      {
      List<string> templateNames_Variable = new List<string>();
      try
        {
        using ( SqlConnection connection_Object = new SqlConnection( connectionString_Variable ) )
          {
          connection_Object.Open();
          string query_Variable = "SELECT Name FROM Templates ORDER BY Name";

          using ( SqlCommand command_Object = new SqlCommand( query_Variable, connection_Object ) )
          using ( SqlDataReader reader_Object = command_Object.ExecuteReader() )
            {
            while ( reader_Object.Read() )
              {
              templateNames_Variable.Add( reader_Object[ "Name" ].ToString() );
              }
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Laden der Template-Namen: {ex_Variable.Message}" );
        }
      return templateNames_Variable;
      }

    public Template_Class LoadTemplate( string name_Parameter )
      {
      Template_Class template_Object = new Template_Class();
      try
        {
        using ( SqlConnection connection_Object = new SqlConnection( connectionString_Variable ) )
          {
          connection_Object.Open();
          string query_Variable = "SELECT * FROM Templates WHERE Name = @Name";

          using ( SqlCommand command_Object = new SqlCommand( query_Variable, connection_Object ) )
            {
            command_Object.Parameters.AddWithValue( "@Name", name_Parameter );
            using ( SqlDataReader reader_Object = command_Object.ExecuteReader() )
              {
              if ( reader_Object.Read() )
                {
                template_Object.Name_Property = reader_Object[ "Name" ].ToString();

                // Konvertiere die gespeicherten Strings zurück in Listen
                string[] kompetenzArray_Variable = reader_Object[ "KompetenzPunkte" ].ToString().Split( ',' );
                string[] dokumentationArray_Variable = reader_Object[ "DokumentationPunkte" ].ToString().Split( ',' );
                string[] praesentationArray_Variable = reader_Object[ "PraesentationPunkte" ].ToString().Split( ',' );

                template_Object.KompetenzPunkte_Property = Array.ConvertAll( kompetenzArray_Variable, Double.Parse ).ToList();
                template_Object.DokumentationPunkte_Property = Array.ConvertAll( dokumentationArray_Variable, Double.Parse ).ToList();
                template_Object.PraesentationPunkte_Property = Array.ConvertAll( praesentationArray_Variable, Double.Parse ).ToList();
                }
              }
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Laden des Templates: {ex_Variable.Message}" );
        }
      return template_Object;
      }
    }
  }