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
  public partial class CreateTemplate_Form: Form
    {
    private Template_Class newTemplate_Variable;
    private string templatesPath_Variable;

    public CreateTemplate_Form()
      {
      InitializeComponent();
      newTemplate_Variable = new Template_Class();
      templatesPath_Variable = Path.Combine(
          AppDomain.CurrentDomain.BaseDirectory,
          "..", "..", "Templates"
      );
      }

    public CreateTemplate_Form( string templatesPath_Parameter ) : this()
      {
      templatesPath_Variable = templatesPath_Parameter;
      }

    private void button1_Click( object sender_Variable, EventArgs e_Variable )
      {
      try
        {
        CollectPoints();

        SaveFileDialog saveDialog_Variable = new SaveFileDialog
          {
          InitialDirectory = templatesPath_Variable,
          Filter = "Text files (*.txt)|*.txt",
          DefaultExt = "txt"
          };

        if ( saveDialog_Variable.ShowDialog() == DialogResult.OK )
          {
          newTemplate_Variable.SaveTemplate( saveDialog_Variable.FileName );
          this.DialogResult = DialogResult.OK;
          this.Close();
          }
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
        newTemplate_Variable.KompetenzPunkte_Property.Clear();
        newTemplate_Variable.DokumentationPunkte_Property.Clear();
        newTemplate_Variable.PraesentationPunkte_Property.Clear();

        // Sammle Pflichtkriterien (A1-A11)
        for ( int i_Variable = 1; i_Variable <= 11; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxObligatoryCriteriaA{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            newTemplate_Variable.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Pflichtwahlkriterium
        var textBoxObligatorySelected_Variable = Controls.Find( "textBoxObligatorySelectedCriteria1", true ).FirstOrDefault() as TextBox;
        if ( textBoxObligatorySelected_Variable != null && !string.IsNullOrEmpty( textBoxObligatorySelected_Variable.Text ) )
          {
          double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBoxObligatorySelected_Variable.Text ) ) );
          newTemplate_Variable.KompetenzPunkte_Property.Add( punkt_Variable );
          }

        // Sammle Wahlkriterien direkt aus dem Katalog
        for ( int i_Variable = 1; i_Variable <= 2; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxSelectedCatalogueCriteria{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            newTemplate_Variable.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle individuelle Wahlkriterien
        for ( int i_Variable = 1; i_Variable <= 8; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxIndividualCriteria{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            newTemplate_Variable.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Dokumentationspunkte
        for ( int i_Variable = 1; i_Variable <= 8; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxDocumentation{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            newTemplate_Variable.DokumentationPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Präsentationspunkte
        for ( int i_Variable = 1; i_Variable <= 10; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxPresentationAndConversation{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            newTemplate_Variable.PraesentationPunkte_Property.Add( punkt_Variable );
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