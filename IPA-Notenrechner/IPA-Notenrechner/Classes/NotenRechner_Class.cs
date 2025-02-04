using System;

namespace IPA_Notenrechner
  {
  public class NotenRechner_Class
    {
    // Konstanten für die maximalen Punkte
    private const double MAX_KOMPETENZ_PUNKTE_Constant = 66.0;
    private const double MAX_DOKUMENTATION_PUNKTE_Constant = 24.0;
    private const double MAX_PRAESENTATION_PUNKTE_Constant = 30.0;

    // Konstanten für die rohen Maximalwerte 
    private const double MAX_KOMPETENZ_RAW_Constant = 2.5;
    private const double MAX_DOKUMENTATION_RAW_Constant = 1.0;
    private const double MAX_PRAESENTATION_RAW_Constant = 1.5;

    public static double BerechneRoheTeilnote( double erzieltePunkte_Parameter, double maxPunkte_Parameter, double maxRaw_Parameter )
      {
      if ( maxPunkte_Parameter <= 0 )
        {
        return 0;
        }
      double rohNote_Variable = ( erzieltePunkte_Parameter / maxPunkte_Parameter ) * maxRaw_Parameter;
      return Math.Round( rohNote_Variable, 2 );
      }

    public static double BerechneSkalierteNote( double rohNote_Parameter, double maxRaw_Parameter )
      {
      double skalierteNote_Variable = 1 + ( rohNote_Parameter / maxRaw_Parameter ) * 5;
      skalierteNote_Variable = Math.Max( 1, Math.Min( 6, skalierteNote_Variable ) );
      return Math.Round( skalierteNote_Variable, 2 );
      }

    public static double BerechneGesamtnote( double kompetenzPunkte_Parameter,
                                          double dokumentationPunkte_Parameter,
                                          double praesentationPunkte_Parameter )
      {
      double rohKompetenz_Variable = BerechneRoheTeilnote( kompetenzPunkte_Parameter,
                                                         MAX_KOMPETENZ_PUNKTE_Constant,
                                                         MAX_KOMPETENZ_RAW_Constant );

      double rohDokumentation_Variable = BerechneRoheTeilnote( dokumentationPunkte_Parameter,
                                                            MAX_DOKUMENTATION_PUNKTE_Constant,
                                                            MAX_DOKUMENTATION_RAW_Constant );

      double rohPraesentation_Variable = BerechneRoheTeilnote( praesentationPunkte_Parameter,
                                                            MAX_PRAESENTATION_PUNKTE_Constant,
                                                            MAX_PRAESENTATION_RAW_Constant );

      double endNote_Variable = rohKompetenz_Variable + rohDokumentation_Variable + rohPraesentation_Variable + 1;
      endNote_Variable = Math.Max( 1, Math.Min( 6, endNote_Variable ) );

      return Math.Round( endNote_Variable, 2 );
      }
    }
  }