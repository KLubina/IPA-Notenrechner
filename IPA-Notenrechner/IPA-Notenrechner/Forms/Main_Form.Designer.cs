namespace IPA_Notenrechner
  {
  partial class Main_Form
    {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
      {
      if ( disposing && ( components != null ) )
        {
        components.Dispose();
        }
      base.Dispose( disposing );
      }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
      {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
      this.labelEndnote = new System.Windows.Forms.Label();
      this.checkedListBoxChooseTxtTemplate = new System.Windows.Forms.CheckedListBox();
      this.buttonCreateTemplate = new System.Windows.Forms.Button();
      this.buttonShowTemplate = new System.Windows.Forms.Button();
      this.richTextBoxEndNote = new System.Windows.Forms.RichTextBox();
      this.richTextBoxRawPartGradeCompetence = new System.Windows.Forms.RichTextBox();
      this.labelGradeCompetence = new System.Windows.Forms.Label();
      this.richTextBoxRawPartGradeDocumentation = new System.Windows.Forms.RichTextBox();
      this.labelGradeDocumentation = new System.Windows.Forms.Label();
      this.richTextBoxRawPartGradePresentationAndConversation = new System.Windows.Forms.RichTextBox();
      this.labelGradePresentationAndConversation = new System.Windows.Forms.Label();
      this.richTextBoxPartGradePresentationAndConversationScaled = new System.Windows.Forms.RichTextBox();
      this.richTextBoxPartGradeDocumentationScaled = new System.Windows.Forms.RichTextBox();
      this.richTextBoxPartGradeCompetenceScaled = new System.Windows.Forms.RichTextBox();
      this.labelChooseTxtTemplate = new System.Windows.Forms.Label();
      this.labelChooseDBTemplate = new System.Windows.Forms.Label();
      this.checkedListBoxChooseDBTemplate = new System.Windows.Forms.CheckedListBox();
      this.labelRawPartGrade = new System.Windows.Forms.Label();
      this.labelGradeScaled = new System.Windows.Forms.Label();
      this.labelNoteProPunktKompetenz = new System.Windows.Forms.Label();
      this.labelNoteProPunktDokumentation = new System.Windows.Forms.Label();
      this.labelNoteProPunktPrasentationUndFachgesprach = new System.Windows.Forms.Label();
      this.buttonEditTemplate = new System.Windows.Forms.Button();
      this.richTextBoxTxtDesciption = new System.Windows.Forms.RichTextBox();
      this.richTextBoxDBDescption = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // labelEndnote
      // 
      this.labelEndnote.AutoSize = true;
      this.labelEndnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.labelEndnote.Location = new System.Drawing.Point(12, 36);
      this.labelEndnote.Name = "labelEndnote";
      this.labelEndnote.Size = new System.Drawing.Size(114, 29);
      this.labelEndnote.TabIndex = 0;
      this.labelEndnote.Text = "Endnote:";
      // 
      // checkedListBoxChooseTxtTemplate
      // 
      this.checkedListBoxChooseTxtTemplate.FormattingEnabled = true;
      this.checkedListBoxChooseTxtTemplate.HorizontalScrollbar = true;
      this.checkedListBoxChooseTxtTemplate.Location = new System.Drawing.Point(957, 80);
      this.checkedListBoxChooseTxtTemplate.Name = "checkedListBoxChooseTxtTemplate";
      this.checkedListBoxChooseTxtTemplate.ScrollAlwaysVisible = true;
      this.checkedListBoxChooseTxtTemplate.Size = new System.Drawing.Size(187, 259);
      this.checkedListBoxChooseTxtTemplate.TabIndex = 1;
      this.checkedListBoxChooseTxtTemplate.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxChooseTxtTemplate_ItemCheck);
      // 
      // buttonCreateTemplate
      // 
      this.buttonCreateTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.buttonCreateTemplate.Location = new System.Drawing.Point(764, 356);
      this.buttonCreateTemplate.Name = "buttonCreateTemplate";
      this.buttonCreateTemplate.Size = new System.Drawing.Size(380, 32);
      this.buttonCreateTemplate.TabIndex = 2;
      this.buttonCreateTemplate.Text = "Erstelle eine Vorlage";
      this.buttonCreateTemplate.UseVisualStyleBackColor = true;
      this.buttonCreateTemplate.Click += new System.EventHandler(this.buttonCreateTemplate_Click);
      // 
      // buttonShowTemplate
      // 
      this.buttonShowTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.buttonShowTemplate.Location = new System.Drawing.Point(764, 393);
      this.buttonShowTemplate.Name = "buttonShowTemplate";
      this.buttonShowTemplate.Size = new System.Drawing.Size(380, 32);
      this.buttonShowTemplate.TabIndex = 3;
      this.buttonShowTemplate.Text = "Vorlage anzeigen lassen";
      this.buttonShowTemplate.UseVisualStyleBackColor = true;
      this.buttonShowTemplate.Click += new System.EventHandler(this.buttonShowTemplate_Click);
      // 
      // richTextBoxEndNote
      // 
      this.richTextBoxEndNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
      this.richTextBoxEndNote.Location = new System.Drawing.Point(433, 6);
      this.richTextBoxEndNote.Name = "richTextBoxEndNote";
      this.richTextBoxEndNote.ReadOnly = true;
      this.richTextBoxEndNote.Size = new System.Drawing.Size(318, 133);
      this.richTextBoxEndNote.TabIndex = 4;
      this.richTextBoxEndNote.Text = "";
      // 
      // richTextBoxRawPartGradeCompetence
      // 
      this.richTextBoxRawPartGradeCompetence.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxRawPartGradeCompetence.Location = new System.Drawing.Point(529, 172);
      this.richTextBoxRawPartGradeCompetence.Name = "richTextBoxRawPartGradeCompetence";
      this.richTextBoxRawPartGradeCompetence.ReadOnly = true;
      this.richTextBoxRawPartGradeCompetence.Size = new System.Drawing.Size(92, 78);
      this.richTextBoxRawPartGradeCompetence.TabIndex = 6;
      this.richTextBoxRawPartGradeCompetence.Text = "";
      // 
      // labelGradeCompetence
      // 
      this.labelGradeCompetence.AutoSize = true;
      this.labelGradeCompetence.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.labelGradeCompetence.Location = new System.Drawing.Point(12, 206);
      this.labelGradeCompetence.Name = "labelGradeCompetence";
      this.labelGradeCompetence.Size = new System.Drawing.Size(282, 29);
      this.labelGradeCompetence.TabIndex = 5;
      this.labelGradeCompetence.Text = "Note Kompetenz (50%):";
      // 
      // richTextBoxRawPartGradeDocumentation
      // 
      this.richTextBoxRawPartGradeDocumentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxRawPartGradeDocumentation.Location = new System.Drawing.Point(529, 256);
      this.richTextBoxRawPartGradeDocumentation.Name = "richTextBoxRawPartGradeDocumentation";
      this.richTextBoxRawPartGradeDocumentation.ReadOnly = true;
      this.richTextBoxRawPartGradeDocumentation.Size = new System.Drawing.Size(92, 78);
      this.richTextBoxRawPartGradeDocumentation.TabIndex = 8;
      this.richTextBoxRawPartGradeDocumentation.Text = "";
      // 
      // labelGradeDocumentation
      // 
      this.labelGradeDocumentation.AutoSize = true;
      this.labelGradeDocumentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.labelGradeDocumentation.Location = new System.Drawing.Point(12, 290);
      this.labelGradeDocumentation.Name = "labelGradeDocumentation";
      this.labelGradeDocumentation.Size = new System.Drawing.Size(324, 29);
      this.labelGradeDocumentation.TabIndex = 7;
      this.labelGradeDocumentation.Text = "Note Dokumentation (20%):";
      // 
      // richTextBoxRawPartGradePresentationAndConversation
      // 
      this.richTextBoxRawPartGradePresentationAndConversation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxRawPartGradePresentationAndConversation.Location = new System.Drawing.Point(529, 340);
      this.richTextBoxRawPartGradePresentationAndConversation.Name = "richTextBoxRawPartGradePresentationAndConversation";
      this.richTextBoxRawPartGradePresentationAndConversation.ReadOnly = true;
      this.richTextBoxRawPartGradePresentationAndConversation.Size = new System.Drawing.Size(92, 78);
      this.richTextBoxRawPartGradePresentationAndConversation.TabIndex = 10;
      this.richTextBoxRawPartGradePresentationAndConversation.Text = "";
      // 
      // labelGradePresentationAndConversation
      // 
      this.labelGradePresentationAndConversation.AutoSize = true;
      this.labelGradePresentationAndConversation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.labelGradePresentationAndConversation.Location = new System.Drawing.Point(12, 374);
      this.labelGradePresentationAndConversation.Name = "labelGradePresentationAndConversation";
      this.labelGradePresentationAndConversation.Size = new System.Drawing.Size(511, 29);
      this.labelGradePresentationAndConversation.TabIndex = 9;
      this.labelGradePresentationAndConversation.Text = "Note Präsentation und Fachgespräch (30%):";
      // 
      // richTextBoxPartGradePresentationAndConversationScaled
      // 
      this.richTextBoxPartGradePresentationAndConversationScaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxPartGradePresentationAndConversationScaled.Location = new System.Drawing.Point(635, 340);
      this.richTextBoxPartGradePresentationAndConversationScaled.Name = "richTextBoxPartGradePresentationAndConversationScaled";
      this.richTextBoxPartGradePresentationAndConversationScaled.ReadOnly = true;
      this.richTextBoxPartGradePresentationAndConversationScaled.Size = new System.Drawing.Size(119, 78);
      this.richTextBoxPartGradePresentationAndConversationScaled.TabIndex = 13;
      this.richTextBoxPartGradePresentationAndConversationScaled.Text = "";
      // 
      // richTextBoxPartGradeDocumentationScaled
      // 
      this.richTextBoxPartGradeDocumentationScaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxPartGradeDocumentationScaled.Location = new System.Drawing.Point(635, 256);
      this.richTextBoxPartGradeDocumentationScaled.Name = "richTextBoxPartGradeDocumentationScaled";
      this.richTextBoxPartGradeDocumentationScaled.ReadOnly = true;
      this.richTextBoxPartGradeDocumentationScaled.Size = new System.Drawing.Size(119, 78);
      this.richTextBoxPartGradeDocumentationScaled.TabIndex = 12;
      this.richTextBoxPartGradeDocumentationScaled.Text = "";
      // 
      // richTextBoxPartGradeCompetenceScaled
      // 
      this.richTextBoxPartGradeCompetenceScaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxPartGradeCompetenceScaled.Location = new System.Drawing.Point(635, 172);
      this.richTextBoxPartGradeCompetenceScaled.Name = "richTextBoxPartGradeCompetenceScaled";
      this.richTextBoxPartGradeCompetenceScaled.ReadOnly = true;
      this.richTextBoxPartGradeCompetenceScaled.Size = new System.Drawing.Size(119, 78);
      this.richTextBoxPartGradeCompetenceScaled.TabIndex = 11;
      this.richTextBoxPartGradeCompetenceScaled.Text = "";
      // 
      // labelChooseTxtTemplate
      // 
      this.labelChooseTxtTemplate.AutoSize = true;
      this.labelChooseTxtTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
      this.labelChooseTxtTemplate.Location = new System.Drawing.Point(950, 6);
      this.labelChooseTxtTemplate.Name = "labelChooseTxtTemplate";
      this.labelChooseTxtTemplate.Size = new System.Drawing.Size(182, 17);
      this.labelChooseTxtTemplate.TabIndex = 14;
      this.labelChooseTxtTemplate.Text = "Wähle eine .txt-Vorlage aus";
      // 
      // labelChooseDBTemplate
      // 
      this.labelChooseDBTemplate.AutoSize = true;
      this.labelChooseDBTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
      this.labelChooseDBTemplate.Location = new System.Drawing.Point(757, 6);
      this.labelChooseDBTemplate.Name = "labelChooseDBTemplate";
      this.labelChooseDBTemplate.Size = new System.Drawing.Size(183, 17);
      this.labelChooseDBTemplate.TabIndex = 16;
      this.labelChooseDBTemplate.Text = "Wähle eine DB-Vorlage aus";
      // 
      // checkedListBoxChooseDBTemplate
      // 
      this.checkedListBoxChooseDBTemplate.FormattingEnabled = true;
      this.checkedListBoxChooseDBTemplate.HorizontalScrollbar = true;
      this.checkedListBoxChooseDBTemplate.Location = new System.Drawing.Point(764, 80);
      this.checkedListBoxChooseDBTemplate.Name = "checkedListBoxChooseDBTemplate";
      this.checkedListBoxChooseDBTemplate.ScrollAlwaysVisible = true;
      this.checkedListBoxChooseDBTemplate.Size = new System.Drawing.Size(187, 259);
      this.checkedListBoxChooseDBTemplate.TabIndex = 15;
      this.checkedListBoxChooseDBTemplate.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxChooseDBTemplate_ItemCheck);
      // 
      // labelRawPartGrade
      // 
      this.labelRawPartGrade.AutoSize = true;
      this.labelRawPartGrade.Location = new System.Drawing.Point(529, 153);
      this.labelRawPartGrade.Name = "labelRawPartGrade";
      this.labelRawPartGrade.Size = new System.Drawing.Size(69, 13);
      this.labelRawPartGrade.TabIndex = 17;
      this.labelRawPartGrade.Text = "rohe Teilnote";
      // 
      // labelGradeScaled
      // 
      this.labelGradeScaled.AutoSize = true;
      this.labelGradeScaled.Location = new System.Drawing.Point(632, 153);
      this.labelGradeScaled.Name = "labelGradeScaled";
      this.labelGradeScaled.Size = new System.Drawing.Size(122, 13);
      this.labelGradeScaled.TabIndex = 18;
      this.labelGradeScaled.Text = "Teilnote als eigene Note";
      // 
      // labelNoteProPunktKompetenz
      // 
      this.labelNoteProPunktKompetenz.AutoSize = true;
      this.labelNoteProPunktKompetenz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
      this.labelNoteProPunktKompetenz.Location = new System.Drawing.Point(17, 239);
      this.labelNoteProPunktKompetenz.Name = "labelNoteProPunktKompetenz";
      this.labelNoteProPunktKompetenz.Size = new System.Drawing.Size(204, 20);
      this.labelNoteProPunktKompetenz.TabIndex = 19;
      this.labelNoteProPunktKompetenz.Text = "0.037379... Note pro Punkt";
      // 
      // labelNoteProPunktDokumentation
      // 
      this.labelNoteProPunktDokumentation.AutoSize = true;
      this.labelNoteProPunktDokumentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
      this.labelNoteProPunktDokumentation.Location = new System.Drawing.Point(17, 322);
      this.labelNoteProPunktDokumentation.Name = "labelNoteProPunktDokumentation";
      this.labelNoteProPunktDokumentation.Size = new System.Drawing.Size(195, 20);
      this.labelNoteProPunktDokumentation.TabIndex = 20;
      this.labelNoteProPunktDokumentation.Text = "0.04167... Note pro Punkt";
      // 
      // labelNoteProPunktPrasentationUndFachgesprach
      // 
      this.labelNoteProPunktPrasentationUndFachgesprach.AutoSize = true;
      this.labelNoteProPunktPrasentationUndFachgesprach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
      this.labelNoteProPunktPrasentationUndFachgesprach.Location = new System.Drawing.Point(17, 405);
      this.labelNoteProPunktPrasentationUndFachgesprach.Name = "labelNoteProPunktPrasentationUndFachgesprach";
      this.labelNoteProPunktPrasentationUndFachgesprach.Size = new System.Drawing.Size(156, 20);
      this.labelNoteProPunktPrasentationUndFachgesprach.TabIndex = 21;
      this.labelNoteProPunktPrasentationUndFachgesprach.Text = "0.05 Note pro Punkt";
      // 
      // buttonEditTemplate
      // 
      this.buttonEditTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.buttonEditTemplate.Location = new System.Drawing.Point(764, 430);
      this.buttonEditTemplate.Name = "buttonEditTemplate";
      this.buttonEditTemplate.Size = new System.Drawing.Size(380, 32);
      this.buttonEditTemplate.TabIndex = 22;
      this.buttonEditTemplate.Text = "Vorlage bearbeiten";
      this.buttonEditTemplate.UseVisualStyleBackColor = true;
      this.buttonEditTemplate.Click += new System.EventHandler(this.buttonEditTemplate_Click);
      // 
      // richTextBoxTxtDesciption
      // 
      this.richTextBoxTxtDesciption.Location = new System.Drawing.Point(953, 27);
      this.richTextBoxTxtDesciption.Name = "richTextBoxTxtDesciption";
      this.richTextBoxTxtDesciption.Size = new System.Drawing.Size(191, 47);
      this.richTextBoxTxtDesciption.TabIndex = 23;
      this.richTextBoxTxtDesciption.Text = "müssen alle in \"Laufwerk:\\IPA-Notenrechner .txt Vorlagen\" gespeichert werden";
      // 
      // richTextBoxDBDescption
      // 
      this.richTextBoxDBDescption.Location = new System.Drawing.Point(760, 27);
      this.richTextBoxDBDescption.Name = "richTextBoxDBDescption";
      this.richTextBoxDBDescption.Size = new System.Drawing.Size(191, 47);
      this.richTextBoxDBDescption.TabIndex = 24;
      this.richTextBoxDBDescption.Text = "werden in einer Datenbank namens \"IPA-Notenrechner\" gespeichert, falls bereits vo" +
    "rhanden und eingerichtet";
      // 
      // Main_Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1156, 474);
      this.Controls.Add(this.richTextBoxDBDescption);
      this.Controls.Add(this.richTextBoxTxtDesciption);
      this.Controls.Add(this.buttonEditTemplate);
      this.Controls.Add(this.labelNoteProPunktPrasentationUndFachgesprach);
      this.Controls.Add(this.labelNoteProPunktDokumentation);
      this.Controls.Add(this.labelNoteProPunktKompetenz);
      this.Controls.Add(this.labelGradeScaled);
      this.Controls.Add(this.labelRawPartGrade);
      this.Controls.Add(this.labelChooseDBTemplate);
      this.Controls.Add(this.checkedListBoxChooseDBTemplate);
      this.Controls.Add(this.labelChooseTxtTemplate);
      this.Controls.Add(this.richTextBoxPartGradePresentationAndConversationScaled);
      this.Controls.Add(this.richTextBoxPartGradeDocumentationScaled);
      this.Controls.Add(this.richTextBoxPartGradeCompetenceScaled);
      this.Controls.Add(this.richTextBoxRawPartGradePresentationAndConversation);
      this.Controls.Add(this.labelGradePresentationAndConversation);
      this.Controls.Add(this.richTextBoxRawPartGradeDocumentation);
      this.Controls.Add(this.labelGradeDocumentation);
      this.Controls.Add(this.richTextBoxRawPartGradeCompetence);
      this.Controls.Add(this.labelGradeCompetence);
      this.Controls.Add(this.richTextBoxEndNote);
      this.Controls.Add(this.buttonShowTemplate);
      this.Controls.Add(this.buttonCreateTemplate);
      this.Controls.Add(this.checkedListBoxChooseTxtTemplate);
      this.Controls.Add(this.labelEndnote);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(1172, 513);
      this.Name = "Main_Form";
      this.Text = "IPA-Notenrechner";
      this.ResumeLayout(false);
      this.PerformLayout();

      }

    #endregion
    private System.Windows.Forms.Label labelEndnote;
    private System.Windows.Forms.CheckedListBox checkedListBoxChooseTxtTemplate;
    private System.Windows.Forms.Button buttonCreateTemplate;
    private System.Windows.Forms.Button buttonShowTemplate;
    private System.Windows.Forms.RichTextBox richTextBoxEndNote;
    private System.Windows.Forms.RichTextBox richTextBoxRawPartGradeCompetence;
    private System.Windows.Forms.Label labelGradeCompetence;
    private System.Windows.Forms.RichTextBox richTextBoxRawPartGradeDocumentation;
    private System.Windows.Forms.Label labelGradeDocumentation;
    private System.Windows.Forms.RichTextBox richTextBoxRawPartGradePresentationAndConversation;
    private System.Windows.Forms.Label labelGradePresentationAndConversation;
    private System.Windows.Forms.RichTextBox richTextBoxPartGradePresentationAndConversationScaled;
    private System.Windows.Forms.RichTextBox richTextBoxPartGradeDocumentationScaled;
    private System.Windows.Forms.RichTextBox richTextBoxPartGradeCompetenceScaled;
    private System.Windows.Forms.Label labelChooseTxtTemplate;
    private System.Windows.Forms.Label labelChooseDBTemplate;
    private System.Windows.Forms.CheckedListBox checkedListBoxChooseDBTemplate;
    private System.Windows.Forms.Label labelRawPartGrade;
    private System.Windows.Forms.Label labelGradeScaled;
    private System.Windows.Forms.Label labelNoteProPunktKompetenz;
    private System.Windows.Forms.Label labelNoteProPunktDokumentation;
    private System.Windows.Forms.Label labelNoteProPunktPrasentationUndFachgesprach;
    private System.Windows.Forms.Button buttonEditTemplate;
    private System.Windows.Forms.RichTextBox richTextBoxTxtDesciption;
    private System.Windows.Forms.RichTextBox richTextBoxDBDescption;
    }
  }

