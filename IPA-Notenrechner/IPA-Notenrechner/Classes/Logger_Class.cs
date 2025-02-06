using System;
using System.IO;

namespace IPA_Notenrechner
  {
  public class Logger_Class
    {
    private readonly string logFilePath_Field;
    private readonly string actionLogFilePath_Field;
    private static Logger_Class instance_Field;

    private Logger_Class()
      {
      // Definiere den Log-Pfad mit dem aktuellen Laufwerk
      string logPath_Variable = Path.Combine(
          Directory.GetCurrentDirectory().Substring( 0, 3 ), // Gibt z.B. "C:\" oder "R:\" zurück
          "IPA-Notenrechner Logs"
      );

      // Erstelle den Ordner falls er nicht existiert
      if ( !Directory.Exists( logPath_Variable ) )
        {
        Directory.CreateDirectory( logPath_Variable );
        }

      // Definiere die Pfade für Error- und Action-Logs
      logFilePath_Field = Path.Combine( logPath_Variable, $"errorlog_{DateTime.Now:yyyy-MM-dd}.txt" );
      actionLogFilePath_Field = Path.Combine( logPath_Variable, $"actionlog_{DateTime.Now:yyyy-MM-dd}.txt" );

      // Logge den Programmstart
      LogAction( "Applikation wurde gestartet" );
      }

    public static Logger_Class GetInstance()
      {
      if ( instance_Field == null )
        {
        instance_Field = new Logger_Class();
        }
      return instance_Field;
      }

    public void LogError( string message_Parameter, Exception exception_Parameter = null )
      {
      try
        {
        string logMessage_Variable = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message_Parameter}";

        if ( exception_Parameter != null )
          {
          logMessage_Variable += $"\nException: {exception_Parameter.Message}";
          logMessage_Variable += $"\nStackTrace: {exception_Parameter.StackTrace}";
          }

        logMessage_Variable += "\n----------------------------------------\n";

        File.AppendAllText( logFilePath_Field, logMessage_Variable );
        }
      catch
        {
        // Hier bewusst keine Exception werfen, da dies zu einer Endlosschleife führen könnte
        }
      }

    public void LogInfo( string message_Parameter )
      {
      try
        {
        string logMessage_Variable = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO: {message_Parameter}\n";
        File.AppendAllText( logFilePath_Field, logMessage_Variable );
        }
      catch
        {
        // Hier bewusst keine Exception werfen, da dies zu einer Endlosschleife führen könnte
        }
      }

    public void LogAction( string action_Parameter )
      {
      try
        {
        string actionMessage_Variable = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ACTION: {action_Parameter}";
        actionMessage_Variable += $"\nBenutzer: {Environment.UserName}";
        actionMessage_Variable += $"\nComputer: {Environment.MachineName}";
        actionMessage_Variable += "\n----------------------------------------\n";

        File.AppendAllText( actionLogFilePath_Field, actionMessage_Variable );
        }
      catch
        {
        // Hier bewusst keine Exception werfen, da dies zu einer Endlosschleife führen könnte
        }
      }

    public void LogApplicationExit()
      {
      LogAction( "Applikation wurde beendet" );
      }
    }
  }