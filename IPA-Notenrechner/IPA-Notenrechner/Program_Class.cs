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

      bool useDatabase = false;
      // Rechnernamen abrufen
      string computerName = Environment.MachineName.ToLower();
      string connString = null;

      // Abhängig vom Rechnernamen den passenden Connection String wählen
      if ( computerName == "desktop-o9bmbcb" )
        {
        connString = ConfigurationManager.ConnectionStrings[ "NotenrechnerDbPC" ].ConnectionString;
        }
      else if ( computerName == "laptop-6hk14r0a" )
        {
        connString = ConfigurationManager.ConnectionStrings[ "NotenrechnerDbLaptop" ].ConnectionString;
        }

      // Wenn ein Connection String gefunden wurde, Verbindung testen
      if ( connString != null )
        {
        try
          {
          using ( SqlConnection conn = new SqlConnection( connString ) )
            {
            conn.Open();
            useDatabase = true;
            MessageBox.Show( "Verbindung zur Datenbank erfolgreich! Die Anwendung wird mit Datenbankunterstützung gestartet." );
            }
          }
        catch ( Exception )
          {
          MessageBox.Show( "Keine Datenbankverbindung möglich. Die Anwendung wird nur mit Textdateien arbeiten." );
          }
        }
      else
        {
        MessageBox.Show( "Kein Datenbankzugang für diesen Computer konfiguriert. Die Anwendung wird nur mit Textdateien arbeiten." );
        }

      // Hauptformular mit dem entsprechenden Modus starten
      Application.Run( new Main_Form( useDatabase ) );
      }
    }
  }