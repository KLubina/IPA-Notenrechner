using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace IPA_Notenrechner
  {
  internal static class Program_Class
    {
    private static IConfigurationRoot config_Object;

    [STAThread]
    static void Main()
      {
      // Konfigurationsdatei laden
      var configBuilder_Object = new ConfigurationBuilder()
          .SetBasePath( Directory.GetCurrentDirectory() )
          .AddJsonFile( "appsettings.json", optional: false, reloadOnChange: true );
      config_Object = configBuilder_Object.Build();

      string connectionString_Variable = config_Object.GetConnectionString( "DefaultConnection" );

      // Verbindung testen
      try
        {
        using ( var connection_Object = new NpgsqlConnection( connectionString_Variable ) )
          {
          connection_Object.Open();
          MessageBox.Show( "✅ Verbindung erfolgreich!", "Datenbanktest", MessageBoxButtons.OK, MessageBoxIcon.Information );
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"❌ Fehler bei der Verbindung: {ex_Variable.Message}", "Datenbanktest", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }

      // Startet die Windows Forms Anwendung
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );
      Application.Run( new Main_Form() );
      }
    }
  }
