using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IPA_Notenrechner
  {
  public partial class CreateTemplate_Form: Form
    {
    private Template_Class newTemplate_Field;
    private string templatesPath_Field;
    private DatabaseManager_Class dbManager_Field;
    private readonly bool useDatabase_Field;

    public CreateTemplate_Form( bool useDatabase_Parameter = false )
      {
      InitializeComponent();
      this.useDatabase_Field = useDatabase_Parameter;
      newTemplate_Field = new Template_Class();
      dbManager_Field = new DatabaseManager_Class( useDatabase_Parameter );

      // Definiere den Templates-Pfad mit dem aktuellen Laufwerk
      templatesPath_Field = Path.Combine(
          Directory.GetCurrentDirectory().Substring( 0, 3 ), // Gibt z.B. "C:\" oder "R:\" zurück
          "IPA-Notenrechner .txt Vorlagen"
      );

      try
        {
        // Erstelle den Ordner falls er nicht existiert
        if ( !Directory.Exists( templatesPath_Field ) )
          {
          Directory.CreateDirectory( templatesPath_Field );
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Erstellen des Template-Ordners: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }

      // Setze .txt als Standardauswahl
      radioButtonTxt_Field.Checked = true;

      // Deaktiviere DB-Option wenn keine DB verfügbar
      if ( !useDatabase_Parameter )
        {
        radioButtonDB_Field.Enabled = false;
        radioButtonDB_Field.Visible = false;
        }
      }

    public CreateTemplate_Form( string templatesPath_Parameter, bool useDatabase = false ) : this( useDatabase )
      {
      templatesPath_Field = templatesPath_Parameter;
      }

    private void SaveAsTextFile()
      {
      SaveFileDialog saveDialog_Variable = new SaveFileDialog
        {
        InitialDirectory = templatesPath_Field,
        Filter = "Text files (*.txt)|*.txt",
        DefaultExt = "txt"
        };

      if ( saveDialog_Variable.ShowDialog() == DialogResult.OK )
        {
        newTemplate_Field.SaveTemplate( saveDialog_Variable.FileName );
        MessageBox.Show( "Template wurde erfolgreich als Textdatei gespeichert!",
            "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information );
        this.DialogResult = DialogResult.OK;
        this.Close();
        }
      }

    private void SaveToDatabase()
      {
      try
        {
        // Prüfe DB-Verbindung
        if ( !dbManager_Field.TestConnection() )
          {
          MessageBox.Show( "Keine Verbindung zur Datenbank möglich.",
              "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
          return;
          }

        // Template Namen aus dem ersten Eingabefeld generieren
        string templateName_Variable = $"Template_{DateTime.Now:yyyyMMdd_HHmmss}";
        newTemplate_Field.Name_Property = templateName_Variable;

        if ( dbManager_Field.SaveTemplate( newTemplate_Field ) )
          {
          MessageBox.Show( "Template wurde erfolgreich in der Datenbank gespeichert!",
              "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information );
          this.DialogResult = DialogResult.OK;
          this.Close();
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Speichern in der Datenbank: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }

    private void CollectPoints()
      {
      try
        {
        newTemplate_Field.KompetenzPunkte_Property.Clear();
        newTemplate_Field.DokumentationPunkte_Property.Clear();
        newTemplate_Field.PraesentationPunkte_Property.Clear();

        // Sammle Pflichtkriterien (A1-A11)
        for ( int i_Variable = 1; i_Variable <= 11; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxObligatoryCriteriaA{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            newTemplate_Field.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Pflichtwahlkriterium
        var textBoxObligatorySelected_Variable = Controls.Find( "textBoxObligatorySelectedCriteria1", true ).FirstOrDefault() as TextBox;
        if ( textBoxObligatorySelected_Variable != null && !string.IsNullOrEmpty( textBoxObligatorySelected_Variable.Text ) )
          {
          double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBoxObligatorySelected_Variable.Text ) ) );
          newTemplate_Field.KompetenzPunkte_Property.Add( punkt_Variable );
          }

        // Sammle Wahlkriterien direkt aus dem Katalog
        for ( int i_Variable = 1; i_Variable <= 2; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxSelectedCatalogueCriteria{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            newTemplate_Field.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle individuelle Wahlkriterien
        for ( int i_Variable = 1; i_Variable <= 8; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxIndividualCriteria{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            newTemplate_Field.KompetenzPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Dokumentationspunkte
        for ( int i_Variable = 1; i_Variable <= 8; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxDocumentation{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            newTemplate_Field.DokumentationPunkte_Property.Add( punkt_Variable );
            }
          }

        // Sammle Präsentationspunkte
        for ( int i_Variable = 1; i_Variable <= 10; i_Variable++ )
          {
          var textBox_Variable = Controls.Find( $"textBoxPresentationAndConversation{i_Variable}", true ).FirstOrDefault() as TextBox;
          if ( textBox_Variable != null && !string.IsNullOrEmpty( textBox_Variable.Text ) )
            {
            double punkt_Variable = Math.Max( 0, Math.Min( 3, Convert.ToDouble( textBox_Variable.Text ) ) );
            newTemplate_Field.PraesentationPunkte_Property.Add( punkt_Variable );
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

    private void buttonSaveTemplate_Click( object sender_Parameter, EventArgs e_Parameter )
      {
      try
        {
        CollectPoints();

        if ( radioButtonTxt_Field.Checked )
          {
          SaveAsTextFile();
          }
        else if ( radioButtonDB_Field.Checked && useDatabase_Field )
          {
          SaveToDatabase();
          }
        else
          {
          MessageBox.Show( "Bitte wählen Sie eine Speicheroption aus.",
              "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning );
          }
        }
      catch ( Exception ex_Variable )
        {
        MessageBox.Show( $"Fehler beim Speichern des Templates: {ex_Variable.Message}",
            "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }
    }
  }