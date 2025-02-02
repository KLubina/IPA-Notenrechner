using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace IPA_Notenrechner
  {
  internal static class Program_Class
    {
    [STAThread]
    static void Main()
      {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );

      // Verbindung testen
      string connString = ConfigurationManager
          .ConnectionStrings[ "NotenrechnerDb" ]
          .ConnectionString;

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
        return; // App wird beendet, wenn’s nicht klappt
        }

      // Hauptform starten
      Application.Run( new Main_Form() );
      }
    }
  }
