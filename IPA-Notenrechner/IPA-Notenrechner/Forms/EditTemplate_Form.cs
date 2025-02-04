using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IPA_Notenrechner.Forms
  {
  public partial class EditTemplate_Form: Form
    {
    private Template_Class template_Field;
    private readonly DatabaseManager_Class dbManager_Field;
    private string templatesPath_Field;

    public EditTemplate_Form( string templateName_Parameter, string templatesPath_Parameter = null, bool useDatabase_Parameter = false )
      {
      InitializeComponent();
      dbManager_Field = new DatabaseManager_Class( useDatabase_Parameter );
      templatesPath_Field = templatesPath_Parameter ?? Path.Combine(
          AppDomain.CurrentDomain.BaseDirectory,
          "..", "..", "Templates"
      );

      LoadTemplate( templateName_Parameter, useDatabase_Parameter );
      }

    private void LoadTemplate( string templateName_Parameter, bool useDatabase_Parameter )
      {
      try
        {
        // Versuch zuerst das Template aus der gewählten Quelle zu laden
        if ( useDatabase_Parameter )
          {
          template_Field = dbManager_Field.LoadTemplate( templateName_Parameter );
          }
        else
          {
          string templatePath_Variable = Path.Combine( templatesPath_Field, templateName_Parameter + ".txt" );
          if ( File.Exists( templatePath_Variable ) )
            {
            template_Field = Template_Class.LoadTemplate( templatePath_Variable );
            }
          else
            {
            MessageBox.Show( $"Template-Datei nicht gefunden: {templatePath_Variable}",
                "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return;
            }
          }

        // Wenn das Template erfolgreich geladen wurde, fülle das Formular
        if ( template_Field != null )
          {
          PopulateFormWithTemplateData();
          }
        else
          {
          MessageBox.Show( "Template konnte nicht geladen werden.",
              "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Laden des Templates: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }

    private void PopulateFormWithTemplateData()
      {
      try
        {
        // Pflichtkriterien (A1-A11)
        for ( int i_Variable = 0; i_Variable < Math.Min( template_Field.KompetenzPunkte_Property.Count, 11 ); i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxObligatoryCriteriaA{i_Variable + 1}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Field.KompetenzPunkte_Property[ i_Variable ].ToString();
            }
          }

        // Pflichtwahlkriterium
        if ( template_Field.KompetenzPunkte_Property.Count > 11 )
          {
          var textBox_Variable = Controls.Find( "textBoxObligatorySelectedCriteria1", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Field.KompetenzPunkte_Property[ 11 ].ToString();
            }
          }

        // Wahlkriterien aus dem Katalog
        for ( int i_Variable = 0; i_Variable < 2 && ( i_Variable + 12 ) < template_Field.KompetenzPunkte_Property.Count; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxSelectedCatalogueCriteria{i_Variable + 1}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Field.KompetenzPunkte_Property[ i_Variable + 12 ].ToString();
            }
          }

        // Individuelle Wahlkriterien
        for ( int i_Variable = 0; i_Variable < 8 && ( i_Variable + 14 ) < template_Field.KompetenzPunkte_Property.Count; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxIndividualCriteria{i_Variable + 1}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Field.KompetenzPunkte_Property[ i_Variable + 14 ].ToString();
            }
          }

        // Dokumentationspunkte
        for ( int i_Variable = 0; i_Variable < template_Field.DokumentationPunkte_Property.Count && i_Variable < 8; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxDocumentation{i_Variable + 1}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Field.DokumentationPunkte_Property[ i_Variable ].ToString();
            }
          }

        // Präsentations- und Fachgesprächspunkte
        for ( int i_Variable = 0; i_Variable < template_Field.PraesentationPunkte_Property.Count && i_Variable < 10; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxPresentationAndConversation{i_Variable + 1}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Field.PraesentationPunkte_Property[ i_Variable ].ToString();
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Befüllen der Formularfelder: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }

    private void buttonSaveTemplate_Click( object sender_Parameter, EventArgs e_Parameter )
      {
      try
        {
        CollectPoints();
        template_Field.SaveTemplate( Path.Combine( templatesPath_Field, template_Field.Name_Property + ".txt" ) );
        MessageBox.Show( "Template wurde erfolgreich aktualisiert!",
            "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information );
        this.DialogResult = DialogResult.OK;
        this.Close();
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Speichern des Templates: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }

    private void CollectPoints()
      {
      try
        {
        template_Field.KompetenzPunkte_Property.Clear();
        template_Field.DokumentationPunkte_Property.Clear();
        template_Field.PraesentationPunkte_Property.Clear();

        // Sammle Pflichtkriterien (A1-A11)
        for ( int i_Variable = 1; i_Variable <= 11; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxObligatoryCriteriaA{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            template_Field.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Pflichtwahlkriterium
        var textBoxObligatorySelected_Variable = Controls.Find( "textBoxObligatorySelectedCriteria1", true ).FirstOrDefault() as TextBox;
        if ( textBoxObligatorySelected_Variable != null && !string.IsNullOrEmpty( textBoxObligatorySelected_Variable.Text ) )
          {
          double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBoxObligatorySelected_Variable.Text ) ) );
          template_Field.KompetenzPunkte_Property.Add( punkt_Variable );
          }

        // Sammle Wahlkriterien direkt aus dem Katalog
        for ( int i_Variable = 1; i_Variable <= 2; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxSelectedCatalogueCriteria{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            template_Field.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle individuelle Wahlkriterien
        for ( int i_Variable = 1; i_Variable <= 8; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxIndividualCriteria{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            template_Field.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Dokumentationspunkte
        for ( int i_Variable = 1; i_Variable <= 8; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxDocumentation{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            template_Field.DokumentationPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Präsentationspunkte
        for ( int i_Variable = 1; i_Variable <= 10; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxPresentationAndConversation{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            template_Field.PraesentationPunkte_Property.Add( punkt_Variable );
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Sammeln der Punkte: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        throw;
        }
      }
    }
  }