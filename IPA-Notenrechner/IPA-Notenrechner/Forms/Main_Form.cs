using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  public partial class Main_Form: Form
    {
    private Template_Class currentTemplate_Variable;
    private string templatesPath_Variable;
    private readonly DatabaseManager_Class dbManager_Object;
    private readonly bool useDatabase;

    public Main_Form( bool useDatabase = false )
      {
      InitializeComponent();
      this.useDatabase = useDatabase;
      currentTemplate_Variable = new Template_Class();
      dbManager_Object = new DatabaseManager_Class( useDatabase );

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

      try
        {
        if ( !Directory.Exists( templatesPath_Variable ) )
          {
          Directory.CreateDirectory( templatesPath_Variable );
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
        if ( !Directory.Exists( templatesPath_Variable ) )
          {
          throw new DirectoryNotFoundException( $"Der Template-Ordner wurde nicht gefunden: {templatesPath_Variable}" );
          }

        string[] templates_Variable = Directory.GetFiles( templatesPath_Variable, "*.txt" );
        foreach ( string template_Variable in templates_Variable )
          {
          string templateName_Variable = Path.GetFileNameWithoutExtension( template_Variable );
          checkedListBoxChooseTxtTemplate.Items.Add( templateName_Variable );
          }

        // Lade DB-Templates nur wenn Datenbank aktiviert ist
        if ( useDatabase )
          {
          List<string> dbTemplates_Variable = dbManager_Object.GetTemplateNames();
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

    private void buttonShowTemplate_Click( object sender_Variable, EventArgs e_Variable )
      {
      try
        {
        if ( LoadSelectedTemplate() )
          {
          // Berechne rohe Teilnoten
          double rohKompetenz_Variable = NotenRechner_Class.BerechneRoheTeilnote(
              currentTemplate_Variable.BerechneGesamtpunkteKompetenz(),
              currentTemplate_Variable.FullCompetence,
              2.5 );

          double rohDokumentation_Variable = NotenRechner_Class.BerechneRoheTeilnote(
              currentTemplate_Variable.BerechneGesamtpunkteDokumentation(),
              currentTemplate_Variable.FullDocumentation,
              1.0 );

          double rohPraesentation_Variable = NotenRechner_Class.BerechneRoheTeilnote(
              currentTemplate_Variable.BerechneGesamtpunktePraesentation(),
              currentTemplate_Variable.FullPresentation,
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
              currentTemplate_Variable.BerechneGesamtpunkteKompetenz(),
              currentTemplate_Variable.BerechneGesamtpunkteDokumentation(),
              currentTemplate_Variable.BerechneGesamtpunktePraesentation() );

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
      bool txtTemplateSelected_LocalVariable = false;
      bool dbTemplateSelected_LocalVariable = false;

      for ( int i_LocalVariable = 0; i_LocalVariable < checkedListBoxChooseTxtTemplate.Items.Count; i_LocalVariable++ )
        {
        if ( checkedListBoxChooseTxtTemplate.GetItemChecked( i_LocalVariable ) )
          {
          txtTemplateSelected_LocalVariable = true;
          break;
          }
        }

      if ( useDatabase )
        {
        for ( int i_LocalVariable = 0; i_LocalVariable < checkedListBoxChooseDBTemplate.Items.Count; i_LocalVariable++ )
          {
          if ( checkedListBoxChooseDBTemplate.GetItemChecked( i_LocalVariable ) )
            {
            dbTemplateSelected_LocalVariable = true;
            break;
            }
          }
        }

      if ( !txtTemplateSelected_LocalVariable && !dbTemplateSelected_LocalVariable )
        {
        MessageBox.Show( "Bitte wählen Sie zuerst ein Template aus und aktivieren Sie die Checkbox.",
            "Keine Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Warning );
        return false;
        }

      if ( checkedListBoxChooseTxtTemplate.SelectedItem != null && txtTemplateSelected_LocalVariable )
        {
        string templateName_Variable = checkedListBoxChooseTxtTemplate.SelectedItem.ToString();
        string templatePath_Variable = Path.Combine( templatesPath_Variable, templateName_Variable + ".txt" );

        if ( File.Exists( templatePath_Variable ) )
          {
          currentTemplate_Variable = Template_Class.LoadTemplate( templatePath_Variable );
          return true;
          }
        }
      else if ( useDatabase && checkedListBoxChooseDBTemplate.SelectedItem != null && dbTemplateSelected_LocalVariable )
        {
        string templateName_Variable = checkedListBoxChooseDBTemplate.SelectedItem.ToString();
        currentTemplate_Variable = dbManager_Object.LoadTemplate( templateName_Variable );
        return true;
        }

      MessageBox.Show( "Bitte wählen Sie ein Template aus.", "Information",
          MessageBoxButtons.OK, MessageBoxIcon.Information );
      return false;
      }

    private void buttonCreateTemplate_Click( object sender_Variable, EventArgs e_Variable )
      {
      CreateTemplate_Form createTemplateForm_Object = new CreateTemplate_Form( templatesPath_Variable );
      if ( createTemplateForm_Object.ShowDialog() == DialogResult.OK )
        {
        LoadTemplateList();
        }
      }

    private void checkedListBoxChooseTxtTemplate_ItemCheck( object sender_Variable, ItemCheckEventArgs e_Variable )
      {
      for ( int i_LocalVariable = 0; i_LocalVariable < checkedListBoxChooseTxtTemplate.Items.Count; i_LocalVariable++ )
        {
        if ( i_LocalVariable != e_Variable.Index )
          {
          checkedListBoxChooseTxtTemplate.SetItemChecked( i_LocalVariable, false );
          }
        }

      if ( useDatabase )
        {
        for ( int i_LocalVariable = 0; i_LocalVariable < checkedListBoxChooseDBTemplate.Items.Count; i_LocalVariable++ )
          {
          checkedListBoxChooseDBTemplate.SetItemChecked( i_LocalVariable, false );
          }
        }
      }

    private void checkedListBoxChooseDBTemplate_ItemCheck( object sender_Variable, ItemCheckEventArgs e_Variable )
      {
      if ( !useDatabase ) return;

      for ( int i_LocalVariable = 0; i_LocalVariable < checkedListBoxChooseDBTemplate.Items.Count; i_LocalVariable++ )
        {
        if ( i_LocalVariable != e_Variable.Index )
          {
          checkedListBoxChooseDBTemplate.SetItemChecked( i_LocalVariable, false );
          }
        }

      for ( int i_LocalVariable = 0; i_LocalVariable < checkedListBoxChooseTxtTemplate.Items.Count; i_LocalVariable++ )
        {
        checkedListBoxChooseTxtTemplate.SetItemChecked( i_LocalVariable, false );
        }
      }
    }
  }