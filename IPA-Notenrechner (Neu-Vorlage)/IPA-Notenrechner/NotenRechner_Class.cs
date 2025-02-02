using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  public class NotenRechner_Class
    {
    // Konstanten für die Gewichtung
    private const double KOMPETENZ_GEWICHT_Constant = 0.5;    // 50%
    private const double DOKUMENTATION_GEWICHT_Constant = 0.2; // 20%
    private const double PRAESENTATION_GEWICHT_Constant = 0.3; // 30%

    // Methode zur Berechnung der Gesamtnote (skaliert auf 6)
    public static double BerechneGesamtnote( Template_Class template_Parameter )
      {
      try
        {
        double kompetenzNote_Variable = BerechneTeilnote( template_Parameter.KompetenzPunkte_Property );
        double dokumentationNote_Variable = BerechneTeilnote( template_Parameter.DokumentationPunkte_Property );
        double praesentationNote_Variable = BerechneTeilnote( template_Parameter.PraesentationPunkte_Property );

        // Hier erst die gewichtete Summe (max. 3) ermitteln
        double gesamtnote_Variable = ( kompetenzNote_Variable * KOMPETENZ_GEWICHT_Constant ) +
                                     ( dokumentationNote_Variable * DOKUMENTATION_GEWICHT_Constant ) +
                                     ( praesentationNote_Variable * PRAESENTATION_GEWICHT_Constant );

        // Dann skalieren wir von 0–3 auf 0–6
        double scaledGesamtnote_Variable = gesamtnote_Variable * 2.0;

        return Math.Round( scaledGesamtnote_Variable, 2 );
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler bei der Notenberechnung: {ex_Variable.Message}",
            "Berechnungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        return 0;
        }
      }

    // Hilfsmethode zur Berechnung einer Teilnote (0–3)
    public static double BerechneTeilnote( List<double> punkte_Parameter )
      {
      if ( punkte_Parameter == null || punkte_Parameter.Count == 0 )
        {
        return 0;
        }

      double summe_Variable = 0;
      foreach ( double punkt_Variable in punkte_Parameter )
        {
        double validierterPunkt_Variable = Math.Max( 0, Math.Min( 3, punkt_Variable ) );
        summe_Variable += validierterPunkt_Variable;
        }

      double durchschnitt_Variable = summe_Variable / punkte_Parameter.Count;
      return Math.Round( durchschnitt_Variable, 2 );
      }

    // Falls du die einzelnen Teilnoten separat auf 0–6 skalieren möchtest,
    // kannst du diese Methode verwenden:
    public static double SkaliereTeilnote( double teilnote_Variable )
      {
      // teilnote_Variable kommt von BerechneTeilnote (0–3) und wird nun mal 2 genommen
      return Math.Round( teilnote_Variable * 2.0, 2 );
      }
    }
  }
