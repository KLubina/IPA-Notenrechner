using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  public class Template_Class
    {
    public List<double> KompetenzPunkte_Property { get; set; }
    public List<double> DokumentationPunkte_Property { get; set; }
    public List<double> PraesentationPunkte_Property { get; set; }
    public string Name_Property { get; set; }

    // Konstruktor
    public Template_Class()
      {
      KompetenzPunkte_Property = new List<double>();
      DokumentationPunkte_Property = new List<double>();
      PraesentationPunkte_Property = new List<double>();
      }

    // Template als .txt Datei speichern
    public void SaveTemplate( string path_Parameter )
      {
      try
        {
        using ( StreamWriter writer_Variable = new StreamWriter( path_Parameter ) )
          {
          // Speichere Kompetenzpunkte
          foreach ( double punkt_Variable in KompetenzPunkte_Property )
            {
            writer_Variable.WriteLine( $"K:{punkt_Variable}" );
            }

          // Speichere Dokumentationspunkte
          foreach ( double punkt_Variable in DokumentationPunkte_Property )
            {
            writer_Variable.WriteLine( $"D:{punkt_Variable}" );
            }

          // Speichere Präsentationspunkte
          foreach ( double punkt_Variable in PraesentationPunkte_Property )
            {
            writer_Variable.WriteLine( $"P:{punkt_Variable}" );
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Speichern: {ex_Variable.Message}" );
        }
      }

    // Template aus .txt Datei laden
    public static Template_Class LoadTemplate( string path_Parameter )
      {
      Template_Class template_Object = new Template_Class();

      try
        {
        string[] lines_Variable = File.ReadAllLines( path_Parameter );

        foreach ( string line_Variable in lines_Variable )
          {
          string[] parts_Variable = line_Variable.Split( ':' );
          if ( parts_Variable.Length == 2 )
            {
            double punkt_Variable = Convert.ToDouble( parts_Variable[ 1 ] );
            punkt_Variable = Math.Max( 0, Math.Min( 3, punkt_Variable ) ); // Begrenze Werte auf 0-3

            switch ( parts_Variable[ 0 ] )
              {
              case "K":
                template_Object.KompetenzPunkte_Property.Add( punkt_Variable );
                break;
              case "D":
                template_Object.DokumentationPunkte_Property.Add( punkt_Variable );
                break;
              case "P":
                template_Object.PraesentationPunkte_Property.Add( punkt_Variable );
                break;
              }
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Laden: {ex_Variable.Message}" );
        }

      return template_Object;
      }
    }
  }