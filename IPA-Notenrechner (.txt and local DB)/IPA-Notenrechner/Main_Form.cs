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
        // Liste für txt Templates leeren
        checkedListBoxChooseTxtTemplate.Items.Clear();

        // Liste für DB Templates leeren
        checkedListBoxChooseDBTemplate.Items.Clear();

        // Prüfe ob der Ordner für txt Templates existiert
        if ( !Directory.Exists( templatesPath_Variable ) )
          {
          throw new DirectoryNotFoundException( $"Der Template-Ordner wurde nicht gefunden: {templatesPath_Variable}" );
          }

        // Alle .txt Dateien im Ordner finden
        string[] templates_Variable = Directory.GetFiles( templatesPath_Variable, "*.txt" );

        // Templates zur txt Liste hinzufügen
        foreach ( string template_Variable in templates_Variable )
          {
          string templateName_Variable = Path.GetFileNameWithoutExtension( template_Variable );
          checkedListBoxChooseTxtTemplate.Items.Add( templateName_Variable );
          }

        // Datenbank Templates laden
        DatabaseManager_Class dbManager_Object = new DatabaseManager_Class();
        List<string> dbTemplates_Variable = dbManager_Object.GetTemplateNames();

        // Templates zur DB Liste hinzufügen
        foreach ( string templateName_Variable in dbTemplates_Variable )
          {
          checkedListBoxChooseDBTemplate.Items.Add( templateName_Variable );
          }

        // Aktualisiere die Anzeige
        checkedListBoxChooseTxtTemplate.Refresh();
        checkedListBoxChooseDBTemplate.Refresh();
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Laden der Templates: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
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
        // Prüfe, ob ein txt Template ausgewählt wurde
        if ( checkedListBoxChooseTxtTemplate.SelectedItem != null )
          {
          string templateName_Variable = checkedListBoxChooseTxtTemplate.SelectedItem.ToString();
          string templatePath_Variable = Path.Combine( templatesPath_Variable, templateName_Variable + ".txt" );

          if ( File.Exists( templatePath_Variable ) )
            {
            currentTemplate_Variable = Template_Class.LoadTemplate( templatePath_Variable );
            }
          }
        // Prüfe, ob ein DB Template ausgewählt wurde
        else if ( checkedListBoxChooseDBTemplate.SelectedItem != null )
          {
          string templateName_Variable = checkedListBoxChooseDBTemplate.SelectedItem.ToString();
          DatabaseManager_Class dbManager_Object = new DatabaseManager_Class();
          currentTemplate_Variable = dbManager_Object.LoadTemplate( templateName_Variable );
          }
        else
          {
          MessageBox.Show( "Bitte wählen Sie ein Template aus.", "Information",
              MessageBoxButtons.OK, MessageBoxIcon.Information );
          return;
          }

        // Berechne die Teilnoten
        double kompetenzNote_Variable = NotenRechner_Class.BerechneTeilnote(
            currentTemplate_Variable.KompetenzPunkte_Property );
        double dokumentationNote_Variable = NotenRechner_Class.BerechneTeilnote(
            currentTemplate_Variable.DokumentationPunkte_Property );
        double praesentationNote_Variable = NotenRechner_Class.BerechneTeilnote(
            currentTemplate_Variable.PraesentationPunkte_Property );

        // Berechne die Gesamtnote (1–6)
        double gesamtnote_Variable = NotenRechner_Class.BerechneGesamtnote( currentTemplate_Variable );

        // Skaliere die Teilnoten
        double kompetenzScaled_Variable = NotenRechner_Class.SkaliereTeilnote( kompetenzNote_Variable );
        double dokumentationScaled_Variable = NotenRechner_Class.SkaliereTeilnote( dokumentationNote_Variable );
        double praesentationScaled_Variable = NotenRechner_Class.SkaliereTeilnote( praesentationNote_Variable );

        // Zeige die (unskalierten) Teilnoten
        richTextBoxGradeCompetence.Text = kompetenzNote_Variable.ToString( "F2" );
        richTextBoxGradeDocumentation.Text = dokumentationNote_Variable.ToString( "F2" );
        richTextBoxGradePresentationAndConversation.Text = praesentationNote_Variable.ToString( "F2" );

        // Zeige die skalierten Teilnoten
        richTextBoxGradeCompetenceScaled.Text = kompetenzScaled_Variable.ToString( "F2" );
        richTextBoxGradeDocumentationScaled.Text = dokumentationScaled_Variable.ToString( "F2" );
        richTextBoxGradePresentationAndConversationScaled.Text =
            praesentationScaled_Variable.ToString( "F2" );

        // Zeige die Gesamtnote (1–6)
        richTextBoxEndNote.Text = gesamtnote_Variable.ToString( "F2" );
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Anzeigen des Templates: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }
    }
  }