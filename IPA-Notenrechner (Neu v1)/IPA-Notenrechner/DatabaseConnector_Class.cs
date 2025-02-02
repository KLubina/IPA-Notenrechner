using System;
using System.Collections.Generic;
using Npgsql;

namespace IPA_Notenrechner
  {
  public class DatabaseConnector_Class
    {
    private string connectionString_Variable;

    public DatabaseConnector_Class( string connectionString_Parameter )
      {
      connectionString_Variable = connectionString_Parameter;
      }

    public void SpeichereTemplate( Template_Class template_Parameter )
      {
      using ( var connection_Object = new NpgsqlConnection( connectionString_Variable ) )
        {
        connection_Object.Open();

        string sqlQuery_Variable = @"
          INSERT INTO templates (name, kompetenz_punkte, dokumentation_punkte, praesentation_punkte) 
          VALUES (@name, @kompetenz_punkte, @dokumentation_punkte, @praesentation_punkte);";

        using ( var command_Object = new NpgsqlCommand( sqlQuery_Variable, connection_Object ) )
          {
          command_Object.Parameters.AddWithValue( "@name", template_Parameter.Name_Property );
          command_Object.Parameters.AddWithValue( "@kompetenz_punkte", template_Parameter.KompetenzPunkte_Property.ToArray() );
          command_Object.Parameters.AddWithValue( "@dokumentation_punkte", template_Parameter.DokumentationPunkte_Property.ToArray() );
          command_Object.Parameters.AddWithValue( "@praesentation_punkte", template_Parameter.PraesentationPunkte_Property.ToArray() );

          command_Object.ExecuteNonQuery();
          }
        }
      }
    }
  }
