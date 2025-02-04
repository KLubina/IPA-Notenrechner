using System;
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

      DatabaseManager_Class dbManager_Variable = new DatabaseManager_Class( true );
      bool useDatabase_Variable = dbManager_Variable.TestConnection();

      Application.Run( new Main_Form( useDatabase_Variable ) );
      }
    }
  }