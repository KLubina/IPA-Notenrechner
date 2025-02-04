using IPA_Notenrechner.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  public partial class Main_Form: Form
    {
    private Template_Class currentTemplate_Field;
    private string templatesPath_Field;
    private readonly DatabaseManager_Class dbManager_Field;
    private readonly bool useDatabase_Field;

    public Main_Form( bool useDatabase_Parameter = false )
      {
      InitializeComponent();
      this.useDatabase_Field = useDatabase_Parameter;
      currentTemplate_Field = new Template_Class();
      dbManager_Field = new DatabaseManager_Class( useDatabase_Parameter );

      string gitPath_Variable = @"C:\GitHubDesktop\IPA-Notenrechner\IPA-Notenrechner\Templates";

      if ( Directory.Exists( gitPath_Variable ) )
        {
        templatesPath_Field = gitPath_Variable;
        }
      else
        {
        templatesPath_Field = Path.Combine(
            Application.StartupPath,
            "..", "..", "Templates"
        );
        }

      try
        {
        if ( !Directory.Exists( templatesPath_Field ) )
          {
          Directory.CreateDirectory( templatesPath_Field );
          }
        LoadTemplateList();
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Initialisieren des Template-Ordners: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }

    private void LoadTemplateList()
      {
      try
        {
        checkedListBoxChooseTxtTemplate.Items.Clear();
        checkedListBoxChooseDBTemplate.Items.Clear();

        // Lade Text-Templates
        if ( !Directory.Exists( templatesPath_Field ) )
          {
          throw new DirectoryNotFoundException( $"Der Template-Ordner wurde nicht gefunden: {templatesPath_Field}" );
          }

        string[] templates_Variable = Directory.GetFiles( templatesPath_Field, "*.txt" );
        foreach ( string template_Variable in templates_Variable )
          {
          string templateName_Variable = Path.GetFileNameWithoutExtension( template_Variable );
          checkedListBoxChooseTxtTemplate.Items.Add( templateName_Variable );
          }

        // Lade DB-Templates nur wenn Datenbank aktiviert ist
        if ( useDatabase_Field )
          {
          List<string> dbTemplates_Variable = dbManager_Field.GetTemplateNames();
          foreach ( string templateName_Variable in dbTemplates_Variable )
            {
            checkedListBoxChooseDBTemplate.Items.Add( templateName_Variable );
            }
          }
        else
          {
          checkedListBoxChooseDBTemplate.Enabled = false;
          }

        checkedListBoxChooseTxtTemplate.Refresh();
        checkedListBoxChooseDBTemplate.Refresh();
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Laden der Templates: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }

    private void buttonShowTemplate_Click( object sender_Parameter, EventArgs e_Parameter )
      {
      try
        {
        if ( LoadSelectedTemplate() )
          {
          // Berechne rohe Teilnoten
          double rohKompetenz_Variable = NotenRechner_Class.BerechneRoheTeilnote(
              currentTemplate_Field.BerechneGesamtpunkteKompetenz(),
              currentTemplate_Field.FullCompetence_Property,
              2.5 );

          double rohDokumentation_Variable = NotenRechner_Class.BerechneRoheTeilnote(
              currentTemplate_Field.BerechneGesamtpunkteDokumentation(),
              currentTemplate_Field.FullDocumentation_Property,
              1.0 );

          double rohPraesentation_Variable = NotenRechner_Class.BerechneRoheTeilnote(
              currentTemplate_Field.BerechneGesamtpunktePraesentation(),
              currentTemplate_Field.FullPresentation_Property,
              1.5 );

          // Berechne skalierte Noten
          double skaliertKompetenz_Variable = NotenRechner_Class.BerechneSkalierteNote( rohKompetenz_Variable, 2.5 );
          double skaliertDokumentation_Variable = NotenRechner_Class.BerechneSkalierteNote( rohDokumentation_Variable, 1.0 );
          double skaliertPraesentation_Variable = NotenRechner_Class.BerechneSkalierteNote( rohPraesentation_Variable, 1.5 );

          // Zeige die rohen Teilnoten
          richTextBoxRawPartGradeCompetence.Text = rohKompetenz_Variable.ToString( "F2" );
          richTextBoxRawPartGradeDocumentation.Text = rohDokumentation_Variable.ToString( "F2" );
          richTextBoxRawPartGradePresentationAndConversation.Text = rohPraesentation_Variable.ToString( "F2" );

          // Zeige die skalierten Teilnoten
          richTextBoxPartGradeCompetenceScaled.Text = skaliertKompetenz_Variable.ToString( "F2" );
          richTextBoxPartGradeDocumentationScaled.Text = skaliertDokumentation_Variable.ToString( "F2" );
          richTextBoxPartGradePresentationAndConversationScaled.Text = skaliertPraesentation_Variable.ToString( "F2" );

          // Berechne Gesamtnote
          double gesamtNote_Variable = NotenRechner_Class.BerechneGesamtnote(
              currentTemplate_Field.BerechneGesamtpunkteKompetenz(),
              currentTemplate_Field.BerechneGesamtpunkteDokumentation(),
              currentTemplate_Field.BerechneGesamtpunktePraesentation() );

          richTextBoxEndNote.Text = gesamtNote_Variable.ToString( "F2" );
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Anzeigen des Templates: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }

    private bool LoadSelectedTemplate()
      {
      bool txtTemplateSelected_Variable = false;
      bool dbTemplateSelected_Variable = false;

      for ( int i_Variable = 0; i_Variable < checkedListBoxChooseTxtTemplate.Items.Count; i_Variable++ )
        {
        if ( checkedListBoxChooseTxtTemplate.GetItemChecked( i_Variable ) )
          {
          txtTemplateSelected_Variable = true;
          break;
          }
        }

      if ( useDatabase_Field )
        {
        for ( int i_Variable = 0; i_Variable < checkedListBoxChooseDBTemplate.Items.Count; i_Variable++ )
          {
          if ( checkedListBoxChooseDBTemplate.GetItemChecked( i_Variable ) )
            {
            dbTemplateSelected_Variable = true;
            break;
            }
          }
        }

      if ( !txtTemplateSelected_Variable && !dbTemplateSelected_Variable )
        {
        MessageBox.Show( "Bitte wählen Sie zuerst ein Template aus und aktivieren Sie die Checkbox.",
            "Keine Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Warning );
        return false;
        }

      if ( checkedListBoxChooseTxtTemplate.SelectedItem != null && txtTemplateSelected_Variable )
        {
        string templateName_Variable = checkedListBoxChooseTxtTemplate.SelectedItem.ToString();
        string templatePath_Variable = Path.Combine( templatesPath_Field, templateName_Variable + ".txt" );

        if ( File.Exists( templatePath_Variable ) )
          {
          currentTemplate_Field = Template_Class.LoadTemplate( templatePath_Variable );
          return true;
          }
        }
      else if ( useDatabase_Field && checkedListBoxChooseDBTemplate.SelectedItem != null && dbTemplateSelected_Variable )
        {
        string templateName_Variable = checkedListBoxChooseDBTemplate.SelectedItem.ToString();
        currentTemplate_Field = dbManager_Field.LoadTemplate( templateName_Variable );
        return true;
        }

      MessageBox.Show( "Bitte wählen Sie ein Template aus.", "Information",
          MessageBoxButtons.OK, MessageBoxIcon.Information );
      return false;
      }

    private void buttonCreateTemplate_Click( object sender_Parameter, EventArgs e_Parameter )
      {
      CreateTemplate_Form createTemplateForm_Variable = new CreateTemplate_Form( templatesPath_Field );
      if ( createTemplateForm_Variable.ShowDialog() == DialogResult.OK )
        {
        LoadTemplateList();
        }
      }

    private void checkedListBoxChooseTxtTemplate_ItemCheck( object sender_Parameter, ItemCheckEventArgs e_Parameter )
      {
      for ( int i_Variable = 0; i_Variable < checkedListBoxChooseTxtTemplate.Items.Count; i_Variable++ )
        {
        if ( i_Variable != e_Parameter.Index )
          {
          checkedListBoxChooseTxtTemplate.SetItemChecked( i_Variable, false );
          }
        }

      if ( useDatabase_Field )
        {
        for ( int i_Variable = 0; i_Variable < checkedListBoxChooseDBTemplate.Items.Count; i_Variable++ )
          {
          checkedListBoxChooseDBTemplate.SetItemChecked( i_Variable, false );
          }
        }
      }

    private void checkedListBoxChooseDBTemplate_ItemCheck( object sender_Parameter, ItemCheckEventArgs e_Parameter )
      {
      if ( !useDatabase_Field ) return;

      for ( int i_Variable = 0; i_Variable < checkedListBoxChooseDBTemplate.Items.Count; i_Variable++ )
        {
        if ( i_Variable != e_Parameter.Index )
          {
          checkedListBoxChooseDBTemplate.SetItemChecked( i_Variable, false );
          }
        }

      for ( int i_Variable = 0; i_Variable < checkedListBoxChooseTxtTemplate.Items.Count; i_Variable++ )
        {
        checkedListBoxChooseTxtTemplate.SetItemChecked( i_Variable, false );
        }
      }

    private void buttonEditTemplate_Click( object sender_Variable, EventArgs e_Variable )
      {
      string selectedTemplate_Variable = null;

      if ( checkedListBoxChooseTxtTemplate.SelectedItem != null &&
          checkedListBoxChooseTxtTemplate.GetItemChecked( checkedListBoxChooseTxtTemplate.SelectedIndex ) )
        {
        selectedTemplate_Variable = checkedListBoxChooseTxtTemplate.SelectedItem.ToString();
        }
      else if ( useDatabase_Field && checkedListBoxChooseDBTemplate.SelectedItem != null &&
               checkedListBoxChooseDBTemplate.GetItemChecked( checkedListBoxChooseDBTemplate.SelectedIndex ) )
        {
        selectedTemplate_Variable = checkedListBoxChooseDBTemplate.SelectedItem.ToString();
        }

      if ( selectedTemplate_Variable != null )
        {
        EditTemplate_Form editTemplate_Variable = new EditTemplate_Form( selectedTemplate_Variable, templatesPath_Field, useDatabase_Field );
        if ( editTemplate_Variable.ShowDialog() == DialogResult.OK )
          {
          LoadTemplateList(); // Liste nach Bearbeitung aktualisieren
          }
        }
      else
        {
        MessageBox.Show( "Bitte wählen Sie zuerst ein Template aus.",
            "Keine Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Warning );
        }
      }
    }
  }