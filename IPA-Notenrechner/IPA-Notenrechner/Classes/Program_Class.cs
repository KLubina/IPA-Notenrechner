using System;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  internal static class Program_Class
    {
    [STAThread]
    static void Main()
      {
      try
        {
        // Initialisiere den Logger (loggt automatisch den Programmstart)
        Logger_Class.GetInstance();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault( false );

        DatabaseManager_Class dbManager_Variable = new DatabaseManager_Class( true );
        bool useDatabase_Variable = dbManager_Variable.TestConnection();

        Application.Run( new Main_Form( useDatabase_Variable ) );
        }
      catch ( Exception ex_Variable )
        {
        // Logge unerwartete Fehler
        Logger_Class.GetInstance().LogError( "Unerwarteter Fehler in der Hauptanwendung", ex_Variable );
        throw;
        }
      finally
        {
        // Logge das Programmende
        Logger_Class.GetInstance().LogApplicationExit();
        }
      }
    }
  }