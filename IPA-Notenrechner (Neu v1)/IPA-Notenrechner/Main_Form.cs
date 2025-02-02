using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  public partial class Main_Form: Form
    {
    private Template_Class currentTemplate_Variable;
    private string templatesPath_Variable;

    public Main_Form()
      {
      InitializeComponent();
      currentTemplate_Variable = new Template_Class();

      // Setze den Pfad zum Templates-Ordner
      string gitPath_Variable = @"C:\GitHubDesktop\IPA-Notenrechner\IPA-Notenrechner\Templates";

      if ( Directory.Exists( gitPath_Variable ) )
        {
        templatesPath_Variable = gitPath_Variable;
        }
      else
        {
        templatesPath_Variable = Path.Combine(
            Application.StartupPath,
            "..", "..", "Templates"
        );
        }

      // Stelle sicher, dass der Templates-Ordner existiert
      try
        {
        if ( !Directory.Exists( templatesPath_Variable ) )
          {
          Directory.CreateDirectory( templatesPath_Variable );
          }

        // Debug-Ausgabe
        MessageBox.Show( $"Templates Pfad: {templatesPath_Variable}\nOrdner existiert: {Directory.Exists( templatesPath_Variable )}", "Debug Info" );

        LoadTemplateList();
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Initialisieren des Template-Ordners: {ex_Variable.Message}", "Fehler",
            MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }

    private void LoadTemplateList()
      {
      try
        {
        // Liste leeren
        checkedListBoxChooseTemplate.Items.Clear();

        // Prüfe ob der Ordner existiert
        if ( !Directory.Exists( templatesPath_Variable ) )
          {
          throw new DirectoryNotFoundException( $"Der Template-Ordner wurde nicht gefunden: {templatesPath_Variable}" );
          }

        // Alle .txt Dateien im Ordner finden
        string[] templates_Variable = Directory.GetFiles( templatesPath_Variable, "*.txt" );

        // Debug-Ausgabe
        string templateList_Variable = string.Join( "\n", templates_Variable );
        MessageBox.Show( $"Gefundene Templates:\n{templateList_Variable}", "Debug Info" );

        // Templates zur Liste hinzufügen
        foreach ( string template_Variable in templates_Variable )
          {
          string templateName_Variable = Path.GetFileNameWithoutExtension( template_Variable );
          checkedListBoxChooseTemplate.Items.Add( templateName_Variable );
          }

        // Aktualisiere die Anzeige
        checkedListBoxChooseTemplate.Refresh();
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Laden der Templates: {ex_Variable.Message}", "Fehler",
            MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }

    private void buttonCreateTemplate_Click( object sender_Variable, EventArgs e_Variable )
      {
      CreateTemplate_Form createTemplateForm_Object = new CreateTemplate_Form( templatesPath_Variable );
      if ( createTemplateForm_Object.ShowDialog() == DialogResult.OK )
        {
        LoadTemplateList();
        }
      }

    private void buttonShowTemplate_Click( object sender_Variable, EventArgs e_Variable )
      {
      try
        {
        if ( checkedListBoxChooseTemplate.SelectedItem != null )
          {
          string templateName_Variable = checkedListBoxChooseTemplate.SelectedItem.ToString();
          string templatePath_Variable = Path.Combine( templatesPath_Variable, templateName_Variable + ".txt" );

          if ( File.Exists( templatePath_Variable ) )
            {
            currentTemplate_Variable = Template_Class.LoadTemplate( templatePath_Variable );

            // Berechne die Teilnoten (0–3)
            double kompetenzNote_Variable = NotenRechner_Class.BerechneTeilnote( currentTemplate_Variable.KompetenzPunkte_Property );
            double dokumentationNote_Variable = NotenRechner_Class.BerechneTeilnote( currentTemplate_Variable.DokumentationPunkte_Property );
            double praesentationNote_Variable = NotenRechner_Class.BerechneTeilnote( currentTemplate_Variable.PraesentationPunkte_Property );

            // Berechne die Gesamtnote (0–6)
            double gesamtnote_Variable = NotenRechner_Class.BerechneGesamtnote( currentTemplate_Variable );

            // Skaliere die Teilnoten von 0–3 auf 0–6
            double kompetenzScaled_Variable = NotenRechner_Class.SkaliereTeilnote( kompetenzNote_Variable );
            double dokumentationScaled_Variable = NotenRechner_Class.SkaliereTeilnote( dokumentationNote_Variable );
            double praesentationScaled_Variable = NotenRechner_Class.SkaliereTeilnote( praesentationNote_Variable );

            // Zeige die (unskalierten) Teilnoten
            richTextBoxGradeCompetence.Text = kompetenzNote_Variable.ToString( "F2" );
            richTextBoxGradeDocumentation.Text = dokumentationNote_Variable.ToString( "F2" );
            richTextBoxGradePresentationAndConversation.Text = praesentationNote_Variable.ToString( "F2" );

            // Zeige die **skalierten** Teilnoten
            richTextBoxGradeCompetenceScaled.Text = kompetenzScaled_Variable.ToString( "F2" );
            richTextBoxGradeDocumentationScaled.Text = dokumentationScaled_Variable.ToString( "F2" );
            richTextBoxGradePresentationAndConversationScaled.Text
                                                                = praesentationScaled_Variable.ToString( "F2" );

            // Zeige die Gesamtnote (0–6)
            richTextBoxEndNote.Text = gesamtnote_Variable.ToString( "F2" );
            }
          else
            {
            MessageBox.Show( $"Template-Datei nicht gefunden: {templatePath_Variable}", "Fehler",
                MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Anzeigen des Templates: {ex_Variable.Message}", "Fehler",
            MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }
    }
  }