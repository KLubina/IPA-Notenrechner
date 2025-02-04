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
    private const double MAX_KOMPETENZ_Constant = 66.0;
    private const double MAX_DOKUMENTATION_Constant = 24.0;
    private const double MAX_PRAESENTATION_Constant = 30.0;

    // Properties für die Maximalpunkte
    public double FullCompetence_Property { get; set; }
    public double FullDocumentation_Property { get; set; }
    public double FullPresentation_Property { get; set; }

    public Template_Class()
      {
      // Initialisierung der Listen
      KompetenzPunkte_Property = new List<double>();
      DokumentationPunkte_Property = new List<double>();
      PraesentationPunkte_Property = new List<double>();

      // Setzen der Standardwerte für Maximalpunkte
      FullCompetence_Property = MAX_KOMPETENZ_Constant;
      FullDocumentation_Property = MAX_DOKUMENTATION_Constant;
      FullPresentation_Property = MAX_PRAESENTATION_Constant;
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
        using ( StreamWriter writer_Variable = new StreamWriter( path_Parameter ) )
          {
          writer_Variable.WriteLine( $"FC:{FullCompetence_Property}" );
          writer_Variable.WriteLine( $"FD:{FullDocumentation_Property}" );
          writer_Variable.WriteLine( $"FP:{FullPresentation_Property}" );

          if ( !string.IsNullOrEmpty( Name_Property ) )
            writer_Variable.WriteLine( $"N:{Name_Property}" );

          foreach ( double punkt_Variable in KompetenzPunkte_Property )
            writer_Variable.WriteLine( $"K:{punkt_Variable}" );

          foreach ( double punkt_Variable in DokumentationPunkte_Property )
            writer_Variable.WriteLine( $"D:{punkt_Variable}" );

          foreach ( double punkt_Variable in PraesentationPunkte_Property )
            writer_Variable.WriteLine( $"P:{punkt_Variable}" );
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Speichern: {ex_Variable.Message}" );
        }
      }

    public static Template_Class LoadTemplate( string path_Parameter )
      {
      Template_Class template_Variable = new Template_Class();
      try
        {
        string[] lines_Variable = File.ReadAllLines( path_Parameter );
        foreach ( string line_Variable in lines_Variable )
          {
          string[] parts_Variable = line_Variable.Split( ':' );
          if ( parts_Variable.Length == 2 )
            {
            string key_Variable = parts_Variable[ 0 ];
            string valueStr_Variable = parts_Variable[ 1 ];
            switch ( key_Variable )
              {
              case "FC":
                template_Variable.FullCompetence_Property = Convert.ToDouble( valueStr_Variable );
                break;
              case "FD":
                template_Variable.FullDocumentation_Property = Convert.ToDouble( valueStr_Variable );
                break;
              case "FP":
                template_Variable.FullPresentation_Property = Convert.ToDouble( valueStr_Variable );
                break;
              case "N":
                template_Variable.Name_Property = valueStr_Variable;
                break;
              case "K":
                double kompetenzPunkt_Variable = Math.Max( 0, Convert.ToDouble( valueStr_Variable ) );
                template_Variable.KompetenzPunkte_Property.Add( kompetenzPunkt_Variable );
                break;
              case "D":
                double dokumentationPunkt_Variable = Math.Max( 0, Convert.ToDouble( valueStr_Variable ) );
                template_Variable.DokumentationPunkte_Property.Add( dokumentationPunkt_Variable );
                break;
              case "P":
                double praesentationPunkt_Variable = Math.Max( 0, Convert.ToDouble( valueStr_Variable ) );
                template_Variable.PraesentationPunkte_Property.Add( praesentationPunkt_Variable );
                break;
              }
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Laden: {ex_Variable.Message}" );
        }
      return template_Variable;
      }
    }
  }