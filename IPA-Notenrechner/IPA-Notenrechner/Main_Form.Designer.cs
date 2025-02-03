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
      this.labelEndnote = new System.Windows.Forms.Label();
      this.checkedListBoxChooseTxtTemplate = new System.Windows.Forms.CheckedListBox();
      this.buttonCreateTemplate = new System.Windows.Forms.Button();
      this.buttonShowTemplate = new System.Windows.Forms.Button();
      this.richTextBoxEndNote = new System.Windows.Forms.RichTextBox();
      this.richTextBoxGradeCompetence = new System.Windows.Forms.RichTextBox();
      this.labelGradeCompetence = new System.Windows.Forms.Label();
      this.richTextBoxGradeDocumentation = new System.Windows.Forms.RichTextBox();
      this.labelGradeDocumentation = new System.Windows.Forms.Label();
      this.richTextBoxGradePresentationAndConversation = new System.Windows.Forms.RichTextBox();
      this.labelGradePresentationAndConversation = new System.Windows.Forms.Label();
      this.richTextBoxGradePresentationAndConversationScaled = new System.Windows.Forms.RichTextBox();
      this.richTextBoxGradeDocumentationScaled = new System.Windows.Forms.RichTextBox();
      this.richTextBoxGradeCompetenceScaled = new System.Windows.Forms.RichTextBox();
      this.labelChooseTxtTemplate = new System.Windows.Forms.Label();
      this.labelChooseDBTemplate = new System.Windows.Forms.Label();
      this.checkedListBoxChooseDBTemplate = new System.Windows.Forms.CheckedListBox();
      this.labelRawPartGrade = new System.Windows.Forms.Label();
      this.labelGradeScaled = new System.Windows.Forms.Label();
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
      this.checkedListBoxChooseTxtTemplate.Location = new System.Drawing.Point(953, 36);
      this.checkedListBoxChooseTxtTemplate.Name = "checkedListBoxChooseTxtTemplate";
      this.checkedListBoxChooseTxtTemplate.Size = new System.Drawing.Size(187, 259);
      this.checkedListBoxChooseTxtTemplate.TabIndex = 1;
      this.checkedListBoxChooseTxtTemplate.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxChooseTxtTemplate_ItemCheck);
      // 
      // buttonCreateTemplate
      // 
      this.buttonCreateTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.buttonCreateTemplate.Location = new System.Drawing.Point(760, 322);
      this.buttonCreateTemplate.Name = "buttonCreateTemplate";
      this.buttonCreateTemplate.Size = new System.Drawing.Size(380, 32);
      this.buttonCreateTemplate.TabIndex = 2;
      this.buttonCreateTemplate.Text = "Erstelle ein Template";
      this.buttonCreateTemplate.UseVisualStyleBackColor = true;
      this.buttonCreateTemplate.Click += new System.EventHandler(this.buttonCreateTemplate_Click);
      // 
      // buttonShowTemplate
      // 
      this.buttonShowTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.buttonShowTemplate.Location = new System.Drawing.Point(760, 359);
      this.buttonShowTemplate.Name = "buttonShowTemplate";
      this.buttonShowTemplate.Size = new System.Drawing.Size(380, 32);
      this.buttonShowTemplate.TabIndex = 3;
      this.buttonShowTemplate.Text = "Template anzeigen lassen";
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
      // richTextBoxGradeCompetence
      // 
      this.richTextBoxGradeCompetence.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradeCompetence.Location = new System.Drawing.Point(529, 172);
      this.richTextBoxGradeCompetence.Name = "richTextBoxGradeCompetence";
      this.richTextBoxGradeCompetence.ReadOnly = true;
      this.richTextBoxGradeCompetence.Size = new System.Drawing.Size(92, 78);
      this.richTextBoxGradeCompetence.TabIndex = 6;
      this.richTextBoxGradeCompetence.Text = "";
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
      // richTextBoxGradeDocumentation
      // 
      this.richTextBoxGradeDocumentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradeDocumentation.Location = new System.Drawing.Point(529, 256);
      this.richTextBoxGradeDocumentation.Name = "richTextBoxGradeDocumentation";
      this.richTextBoxGradeDocumentation.ReadOnly = true;
      this.richTextBoxGradeDocumentation.Size = new System.Drawing.Size(92, 78);
      this.richTextBoxGradeDocumentation.TabIndex = 8;
      this.richTextBoxGradeDocumentation.Text = "";
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
      // richTextBoxGradePresentationAndConversation
      // 
      this.richTextBoxGradePresentationAndConversation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradePresentationAndConversation.Location = new System.Drawing.Point(529, 340);
      this.richTextBoxGradePresentationAndConversation.Name = "richTextBoxGradePresentationAndConversation";
      this.richTextBoxGradePresentationAndConversation.ReadOnly = true;
      this.richTextBoxGradePresentationAndConversation.Size = new System.Drawing.Size(92, 78);
      this.richTextBoxGradePresentationAndConversation.TabIndex = 10;
      this.richTextBoxGradePresentationAndConversation.Text = "";
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
      // richTextBoxGradePresentationAndConversationScaled
      // 
      this.richTextBoxGradePresentationAndConversationScaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradePresentationAndConversationScaled.Location = new System.Drawing.Point(635, 340);
      this.richTextBoxGradePresentationAndConversationScaled.Name = "richTextBoxGradePresentationAndConversationScaled";
      this.richTextBoxGradePresentationAndConversationScaled.ReadOnly = true;
      this.richTextBoxGradePresentationAndConversationScaled.Size = new System.Drawing.Size(119, 78);
      this.richTextBoxGradePresentationAndConversationScaled.TabIndex = 13;
      this.richTextBoxGradePresentationAndConversationScaled.Text = "";
      // 
      // richTextBoxGradeDocumentationScaled
      // 
      this.richTextBoxGradeDocumentationScaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradeDocumentationScaled.Location = new System.Drawing.Point(635, 256);
      this.richTextBoxGradeDocumentationScaled.Name = "richTextBoxGradeDocumentationScaled";
      this.richTextBoxGradeDocumentationScaled.ReadOnly = true;
      this.richTextBoxGradeDocumentationScaled.Size = new System.Drawing.Size(119, 78);
      this.richTextBoxGradeDocumentationScaled.TabIndex = 12;
      this.richTextBoxGradeDocumentationScaled.Text = "";
      // 
      // richTextBoxGradeCompetenceScaled
      // 
      this.richTextBoxGradeCompetenceScaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradeCompetenceScaled.Location = new System.Drawing.Point(635, 172);
      this.richTextBoxGradeCompetenceScaled.Name = "richTextBoxGradeCompetenceScaled";
      this.richTextBoxGradeCompetenceScaled.ReadOnly = true;
      this.richTextBoxGradeCompetenceScaled.Size = new System.Drawing.Size(119, 78);
      this.richTextBoxGradeCompetenceScaled.TabIndex = 11;
      this.richTextBoxGradeCompetenceScaled.Text = "";
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
      this.checkedListBoxChooseDBTemplate.Location = new System.Drawing.Point(760, 36);
      this.checkedListBoxChooseDBTemplate.Name = "checkedListBoxChooseDBTemplate";
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
      // Main_Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1156, 429);
      this.Controls.Add(this.labelGradeScaled);
      this.Controls.Add(this.labelRawPartGrade);
      this.Controls.Add(this.labelChooseDBTemplate);
      this.Controls.Add(this.checkedListBoxChooseDBTemplate);
      this.Controls.Add(this.labelChooseTxtTemplate);
      this.Controls.Add(this.richTextBoxGradePresentationAndConversationScaled);
      this.Controls.Add(this.richTextBoxGradeDocumentationScaled);
      this.Controls.Add(this.richTextBoxGradeCompetenceScaled);
      this.Controls.Add(this.richTextBoxGradePresentationAndConversation);
      this.Controls.Add(this.labelGradePresentationAndConversation);
      this.Controls.Add(this.richTextBoxGradeDocumentation);
      this.Controls.Add(this.labelGradeDocumentation);
      this.Controls.Add(this.richTextBoxGradeCompetence);
      this.Controls.Add(this.labelGradeCompetence);
      this.Controls.Add(this.richTextBoxEndNote);
      this.Controls.Add(this.buttonShowTemplate);
      this.Controls.Add(this.buttonCreateTemplate);
      this.Controls.Add(this.checkedListBoxChooseTxtTemplate);
      this.Controls.Add(this.labelEndnote);
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
    private System.Windows.Forms.RichTextBox richTextBoxGradeCompetence;
    private System.Windows.Forms.Label labelGradeCompetence;
    private System.Windows.Forms.RichTextBox richTextBoxGradeDocumentation;
    private System.Windows.Forms.Label labelGradeDocumentation;
    private System.Windows.Forms.RichTextBox richTextBoxGradePresentationAndConversation;
    private System.Windows.Forms.Label labelGradePresentationAndConversation;
    private System.Windows.Forms.RichTextBox richTextBoxGradePresentationAndConversationScaled;
    private System.Windows.Forms.RichTextBox richTextBoxGradeDocumentationScaled;
    private System.Windows.Forms.RichTextBox richTextBoxGradeCompetenceScaled;
    private System.Windows.Forms.Label labelChooseTxtTemplate;
    private System.Windows.Forms.Label labelChooseDBTemplate;
    private System.Windows.Forms.CheckedListBox checkedListBoxChooseDBTemplate;
    private System.Windows.Forms.Label labelRawPartGrade;
    private System.Windows.Forms.Label labelGradeScaled;
    }
  }

