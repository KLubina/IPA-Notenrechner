using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  internal static class Program_Class
    {
    [STAThread]
    static void Main()
      {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );

      // Rechnernamen abrufen
      string computerName = Environment.MachineName.ToLower();
      string connString;

      // Abhängig vom Rechnernamen den passenden Connection String wählen
      if ( computerName == "desktop-o9bmbcb" )
        {
        connString = ConfigurationManager.ConnectionStrings[ "NotenrechnerDbPC" ].ConnectionString;
        }
      else if ( computerName == "laptop-6hk14r0a" )
        {
        connString = ConfigurationManager.ConnectionStrings[ "NotenrechnerDbLaptop" ].ConnectionString;
        }
      else
        {
        MessageBox.Show( "Unbekannter Computer. Keine passende Verbindung gefunden!" );
        return;
        }

      // Verbindung testen
      try
        {
        using ( SqlConnection conn = new SqlConnection( connString ) )
          {
          conn.Open();
          MessageBox.Show( "Verbindung zur Datenbank erfolgreich!" );
          }
        }
      catch ( Exception ex )
        {
        MessageBox.Show( "Konnte nicht verbinden: " + ex.Message );
        return; // App abbrechen, wenn’s nicht klappt
        }

      // Hauptformular starten
      Application.Run( new Main_Form() );
      }
    }
  }
