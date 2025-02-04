using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IPA_Notenrechner.Forms
  {
  public partial class EditTemplate_Form: Form
    {
    private Template_Class template_Variable;
    private readonly DatabaseManager_Class dbManager_Object;
    private string templatesPath_Variable;

    public EditTemplate_Form( string templateName_Parameter, string templatesPath_Parameter = null, bool useDatabase = false )
      {
      InitializeComponent();
      dbManager_Object = new DatabaseManager_Class( useDatabase );
      templatesPath_Variable = templatesPath_Parameter ?? Path.Combine(
          AppDomain.CurrentDomain.BaseDirectory,
          "..", "..", "Templates"
      );

      LoadTemplate( templateName_Parameter, useDatabase );
      }

    private void LoadTemplate( string templateName_Parameter, bool useDatabase )
      {
      try
        {
        if ( useDatabase )
          {
          template_Variable = dbManager_Object.LoadTemplate( templateName_Parameter );
          }
        else
          {
          string templatePath_Variable = Path.Combine( templatesPath_Variable, templateName_Parameter + ".txt" );
          template_Variable = Template_Class.LoadTemplate( templatePath_Variable );
          }

        PopulateFormWithTemplateData();
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
        for ( int i_Variable = 0; i_Variable < Math.Min( template_Variable.KompetenzPunkte_Property.Count, 11 ); i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxObligatoryCriteriaA{i_Variable + 1}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Variable.KompetenzPunkte_Property[ i_Variable ].ToString();
            }
          }

        // Pflichtwahlkriterium
        if ( template_Variable.KompetenzPunkte_Property.Count > 11 )
          {
          var textBox_Variable = Controls.Find( "textBoxObligatorySelectedCriteria1", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Variable.KompetenzPunkte_Property[ 11 ].ToString();
            }
          }

        // Wahlkriterien aus dem Katalog
        for ( int i_Variable = 0; i_Variable < 2 && ( i_Variable + 12 ) < template_Variable.KompetenzPunkte_Property.Count; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxSelectedCatalogueCriteria{i_Variable + 1}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Variable.KompetenzPunkte_Property[ i_Variable + 12 ].ToString();
            }
          }

        // Individuelle Wahlkriterien
        for ( int i_Variable = 0; i_Variable < 8 && ( i_Variable + 14 ) < template_Variable.KompetenzPunkte_Property.Count; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxIndividualCriteria{i_Variable + 1}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Variable.KompetenzPunkte_Property[ i_Variable + 14 ].ToString();
            }
          }

        // Dokumentationspunkte
        for ( int i_Variable = 0; i_Variable < template_Variable.DokumentationPunkte_Property.Count && i_Variable < 8; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxDocumentation{i_Variable + 1}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Variable.DokumentationPunkte_Property[ i_Variable ].ToString();
            }
          }

        // Präsentations- und Fachgesprächspunkte
        for ( int i_Variable = 0; i_Variable < template_Variable.PraesentationPunkte_Property.Count && i_Variable < 10; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxPresentationAndConversation{i_Variable + 1}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null )
            {
            textBox_Variable.Text = template_Variable.PraesentationPunkte_Property[ i_Variable ].ToString();
            }
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Befüllen der Formularfelder: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }

    private void buttonSaveTemplate_Click( object sender_Variable, EventArgs e_Variable )
      {
      try
        {
        CollectPoints();
        template_Variable.SaveTemplate( Path.Combine( templatesPath_Variable, template_Variable.Name_Property + ".txt" ) );
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
        template_Variable.KompetenzPunkte_Property.Clear();
        template_Variable.DokumentationPunkte_Property.Clear();
        template_Variable.PraesentationPunkte_Property.Clear();

        // Sammle Pflichtkriterien (A1-A11)
        for ( int i_Variable = 1; i_Variable <= 11; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxObligatoryCriteriaA{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            template_Variable.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Pflichtwahlkriterium
        var textBoxObligatorySelected_Variable = Controls.Find( "textBoxObligatorySelectedCriteria1", true ).FirstOrDefault() as TextBox;
        if ( textBoxObligatorySelected_Variable != null && !string.IsNullOrEmpty( textBoxObligatorySelected_Variable.Text ) )
          {
          double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBoxObligatorySelected_Variable.Text ) ) );
          template_Variable.KompetenzPunkte_Property.Add( punkt_Variable );
          }

        // Sammle Wahlkriterien direkt aus dem Katalog
        for ( int i_Variable = 1; i_Variable <= 2; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxSelectedCatalogueCriteria{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            template_Variable.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle individuelle Wahlkriterien
        for ( int i_Variable = 1; i_Variable <= 8; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxIndividualCriteria{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            template_Variable.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Dokumentationspunkte
        for ( int i_Variable = 1; i_Variable <= 8; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxDocumentation{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            template_Variable.DokumentationPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Präsentationspunkte
        for ( int i_Variable = 1; i_Variable <= 10; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxPresentationAndConversation{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            template_Variable.PraesentationPunkte_Property.Add( punkt_Variable );
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