using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  public class Template_Class
    {
    // Properties für die Punktelisten
    public List<double> KompetenzPunkte_Property { get; set; }
    public List<double> DokumentationPunkte_Property { get; set; }
    public List<double> PraesentationPunkte_Property { get; set; }
    public string Name_Property { get; set; }

    // Konstanten für maximale Punktzahlen
    private const double MAX_KOMPETENZ = 66.0;
    private const double MAX_DOKUMENTATION = 24.0;
    private const double MAX_PRAESENTATION = 30.0;

    // Properties für die Maximalpunkte
    public double FullCompetence { get; set; }
    public double FullDocumentation { get; set; }
    public double FullPresentation { get; set; }

    public Template_Class()
      {
      // Initialisierung der Listen
      KompetenzPunkte_Property = new List<double>();
      DokumentationPunkte_Property = new List<double>();
      PraesentationPunkte_Property = new List<double>();

      // Setzen der Standardwerte für Maximalpunkte
      FullCompetence = MAX_KOMPETENZ;
      FullDocumentation = MAX_DOKUMENTATION;
      FullPresentation = MAX_PRAESENTATION;
      }

    public double BerechneGesamtpunkteKompetenz()
      {
      double summe_Variable = 0;
      foreach ( double punkt_Variable in KompetenzPunkte_Property )
        {
        summe_Variable += Math.Max( 0, punkt_Variable );
        }
      return summe_Variable;
      }

    public double BerechneGesamtpunkteDokumentation()
      {
      double summe_Variable = 0;
      foreach ( double punkt_Variable in DokumentationPunkte_Property )
        {
        summe_Variable += Math.Max( 0, punkt_Variable );
        }
      return summe_Variable;
      }

    public double BerechneGesamtpunktePraesentation()
      {
      double summe_Variable = 0;
      foreach ( double punkt_Variable in PraesentationPunkte_Property )
        {
        summe_Variable += Math.Max( 0, punkt_Variable );
        }
      return summe_Variable;
      }

    public void SaveTemplate( string path_Parameter )
      {
      try
        {
        using ( StreamWriter writer = new StreamWriter( path_Parameter ) )
          {
          writer.WriteLine( $"FC:{FullCompetence}" );
          writer.WriteLine( $"FD:{FullDocumentation}" );
          writer.WriteLine( $"FP:{FullPresentation}" );

          if ( !string.IsNullOrEmpty( Name_Property ) )
            writer.WriteLine( $"N:{Name_Property}" );

          foreach ( double punkt in KompetenzPunkte_Property )
            writer.WriteLine( $"K:{punkt}" );

          foreach ( double punkt in DokumentationPunkte_Property )
            writer.WriteLine( $"D:{punkt}" );

          foreach ( double punkt in PraesentationPunkte_Property )
            writer.WriteLine( $"P:{punkt}" );
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Speichern: {ex_Variable.Message}" );
        }
      }

    public static Template_Class LoadTemplate( string path_Parameter )
      {
      Template_Class template_Object = new Template_Class();
      try
        {
        string[] lines = File.ReadAllLines( path_Parameter );
        foreach ( string line in lines )
          {
          string[] parts = line.Split( ':' );
          if ( parts.Length == 2 )
            {
            string key = parts[ 0 ];
            string valueStr = parts[ 1 ];
            switch ( key )
              {
              case "FC":
                template_Object.FullCompetence = Convert.ToDouble( valueStr );
                break;
              case "FD":
                template_Object.FullDocumentation = Convert.ToDouble( valueStr );
                break;
              case "FP":
                template_Object.FullPresentation = Convert.ToDouble( valueStr );
                break;
              case "N":
                template_Object.Name_Property = valueStr;
                break;
              case "K":
                double kompetenzPunkt_Variable = Math.Max( 0, Convert.ToDouble( valueStr ) );
                template_Object.KompetenzPunkte_Property.Add( kompetenzPunkt_Variable );
                break;
              case "D":
                double dokumentationPunkt_Variable = Math.Max( 0, Convert.ToDouble( valueStr ) );
                template_Object.DokumentationPunkte_Property.Add( dokumentationPunkt_Variable );
                break;
              case "P":
                double praesentationPunkt_Variable = Math.Max( 0, Convert.ToDouble( valueStr ) );
                template_Object.PraesentationPunkte_Property.Add( praesentationPunkt_Variable );
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