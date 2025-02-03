using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  public class NotenRechner_Class
    {
    // Gewichtungen
    private const double KOMPETENZ_GEWICHT = 0.5;
    private const double DOKUMENTATION_GEWICHT = 0.2;
    private const double PRAESENTATION_GEWICHT = 0.3;

    // Berechnet die Teilnote (Raw-Note) für eine Kategorie.
    // Dabei gilt: 0 Punkte → 1, volle Punkte → maxPossible + 1.
    public static double BerechneTeilnote( List<double> punkte, double maxPossible )
      {
      if ( punkte == null || punkte.Count == 0 )
        return 1.0;

      double summe = 0;
      foreach ( double p in punkte )
        {
        // Jeder Punkt wird in den erlaubten Bereich [0, maxPossible] geclamped
        summe += Math.Max( 0, Math.Min( maxPossible, p ) );
        }
      double durchschnitt = summe / punkte.Count;
      // Basis 1 addieren: 0 Punkte → 1, volle Punkte → maxPossible+1
      return Math.Round( durchschnitt + 1, 2 );
      }

    // Skaliert eine Teilnote aus dem Bereich [1, maxNote] (maxNote = maxPossible+1)
    // auf den Bereich [1, 6].
    public static double SkaliereTeilnote( double teilnote, double maxNote )
      {
      double scaled = 1 + ( ( teilnote - 1 ) / ( maxNote - 1 ) ) * 5;
      return Math.Round( scaled, 2 );
      }

    // Berechnet die Gesamtnote als gewichtetes Mittel der skalierten Teilnoten.
    // maxPossible-Werte: Kompetenz: 3, Dokumentation: 1.2, Präsentation: 1.8.
    public static double BerechneGesamtnote( Template_Class template )
      {
      double kompetenzRaw = BerechneTeilnote( template.KompetenzPunkte_Property, 3 );
      double dokumentationRaw = BerechneTeilnote( template.DokumentationPunkte_Property, 1.2 );
      double praesentationRaw = BerechneTeilnote( template.PraesentationPunkte_Property, 1.8 );

      // maxNote = maxPossible + 1
      double kompetenzScaled = SkaliereTeilnote( kompetenzRaw, 3 + 1 );
      double dokumentationScaled = SkaliereTeilnote( dokumentationRaw, 1.2 + 1 );
      double praesentationScaled = SkaliereTeilnote( praesentationRaw, 1.8 + 1 );

      double gesamtNote = kompetenzScaled * KOMPETENZ_GEWICHT +
                            dokumentationScaled * DOKUMENTATION_GEWICHT +
                            praesentationScaled * PRAESENTATION_GEWICHT;
      return Math.Round( gesamtNote, 2 );
      }
    }
  }
