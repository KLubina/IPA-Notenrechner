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

      bool useDatabase_Variable = false;
      // Rechnernamen abrufen
      string computerName_Variable = Environment.MachineName.ToLower();
      string connString_Variable = null;

      // Abhängig vom Rechnernamen den passenden Connection String wählen
      if ( computerName_Variable == "desktop-o9bmbcb" )
        {
        connString_Variable = ConfigurationManager.ConnectionStrings[ "NotenrechnerDbPC" ].ConnectionString;
        }
      else if ( computerName_Variable == "laptop-6hk14r0a" )
        {
        connString_Variable = ConfigurationManager.ConnectionStrings[ "NotenrechnerDbLaptop" ].ConnectionString;
        }

      // Wenn ein Connection String gefunden wurde, Verbindung testen
      if ( connString_Variable != null )
        {
        try
          {
          using ( SqlConnection conn_Variable = new SqlConnection( connString_Variable ) )
            {
            conn_Variable.Open();
            useDatabase_Variable = true;
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
      Application.Run( new Main_Form( useDatabase_Variable ) );
      }
    }
  }