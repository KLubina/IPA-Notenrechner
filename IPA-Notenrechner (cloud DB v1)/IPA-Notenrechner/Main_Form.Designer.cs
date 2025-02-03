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
      this.checkedListBoxChooseTemplate = new System.Windows.Forms.CheckedListBox();
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
      this.SuspendLayout();
      // 
      // labelEndnote
      // 
      this.labelEndnote.AutoSize = true;
      this.labelEndnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.labelEndnote.Location = new System.Drawing.Point(22, 66);
      this.labelEndnote.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.labelEndnote.Name = "labelEndnote";
      this.labelEndnote.Size = new System.Drawing.Size(195, 51);
      this.labelEndnote.TabIndex = 0;
      this.labelEndnote.Text = "Endnote:";
      // 
      // checkedListBoxChooseTemplate
      // 
      this.checkedListBoxChooseTemplate.FormattingEnabled = true;
      this.checkedListBoxChooseTemplate.Location = new System.Drawing.Point(1287, 19);
      this.checkedListBoxChooseTemplate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.checkedListBoxChooseTemplate.Name = "checkedListBoxChooseTemplate";
      this.checkedListBoxChooseTemplate.Size = new System.Drawing.Size(340, 550);
      this.checkedListBoxChooseTemplate.TabIndex = 1;
      // 
      // buttonCreateTemplate
      // 
      this.buttonCreateTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.buttonCreateTemplate.Location = new System.Drawing.Point(1287, 601);
      this.buttonCreateTemplate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.buttonCreateTemplate.Name = "buttonCreateTemplate";
      this.buttonCreateTemplate.Size = new System.Drawing.Size(343, 59);
      this.buttonCreateTemplate.TabIndex = 2;
      this.buttonCreateTemplate.Text = "Erstelle ein Template";
      this.buttonCreateTemplate.UseVisualStyleBackColor = true;
      this.buttonCreateTemplate.Click += new System.EventHandler(this.buttonCreateTemplate_Click);
      // 
      // buttonShowTemplate
      // 
      this.buttonShowTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.buttonShowTemplate.Location = new System.Drawing.Point(1287, 671);
      this.buttonShowTemplate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.buttonShowTemplate.Name = "buttonShowTemplate";
      this.buttonShowTemplate.Size = new System.Drawing.Size(343, 59);
      this.buttonShowTemplate.TabIndex = 3;
      this.buttonShowTemplate.Text = "Template anzeigen lassen";
      this.buttonShowTemplate.UseVisualStyleBackColor = true;
      this.buttonShowTemplate.Click += new System.EventHandler(this.buttonShowTemplate_Click);
      // 
      // richTextBoxEndNote
      // 
      this.richTextBoxEndNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
      this.richTextBoxEndNote.Location = new System.Drawing.Point(740, 22);
      this.richTextBoxEndNote.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.richTextBoxEndNote.Name = "richTextBoxEndNote";
      this.richTextBoxEndNote.Size = new System.Drawing.Size(535, 242);
      this.richTextBoxEndNote.TabIndex = 4;
      this.richTextBoxEndNote.Text = "";
      // 
      // richTextBoxGradeCompetence
      // 
      this.richTextBoxGradeCompetence.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradeCompetence.Location = new System.Drawing.Point(914, 279);
      this.richTextBoxGradeCompetence.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.richTextBoxGradeCompetence.Name = "richTextBoxGradeCompetence";
      this.richTextBoxGradeCompetence.Size = new System.Drawing.Size(165, 141);
      this.richTextBoxGradeCompetence.TabIndex = 6;
      this.richTextBoxGradeCompetence.Text = "";
      // 
      // labelGradeCompetence
      // 
      this.labelGradeCompetence.AutoSize = true;
      this.labelGradeCompetence.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.labelGradeCompetence.Location = new System.Drawing.Point(22, 323);
      this.labelGradeCompetence.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.labelGradeCompetence.Name = "labelGradeCompetence";
      this.labelGradeCompetence.Size = new System.Drawing.Size(480, 51);
      this.labelGradeCompetence.TabIndex = 5;
      this.labelGradeCompetence.Text = "Note Kompetenz (50%):";
      // 
      // richTextBoxGradeDocumentation
      // 
      this.richTextBoxGradeDocumentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradeDocumentation.Location = new System.Drawing.Point(914, 434);
      this.richTextBoxGradeDocumentation.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.richTextBoxGradeDocumentation.Name = "richTextBoxGradeDocumentation";
      this.richTextBoxGradeDocumentation.Size = new System.Drawing.Size(165, 141);
      this.richTextBoxGradeDocumentation.TabIndex = 8;
      this.richTextBoxGradeDocumentation.Text = "";
      // 
      // labelGradeDocumentation
      // 
      this.labelGradeDocumentation.AutoSize = true;
      this.labelGradeDocumentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.labelGradeDocumentation.Location = new System.Drawing.Point(22, 478);
      this.labelGradeDocumentation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.labelGradeDocumentation.Name = "labelGradeDocumentation";
      this.labelGradeDocumentation.Size = new System.Drawing.Size(552, 51);
      this.labelGradeDocumentation.TabIndex = 7;
      this.labelGradeDocumentation.Text = "Note Dokumentation (20%):";
      // 
      // richTextBoxGradePresentationAndConversation
      // 
      this.richTextBoxGradePresentationAndConversation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradePresentationAndConversation.Location = new System.Drawing.Point(914, 589);
      this.richTextBoxGradePresentationAndConversation.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.richTextBoxGradePresentationAndConversation.Name = "richTextBoxGradePresentationAndConversation";
      this.richTextBoxGradePresentationAndConversation.Size = new System.Drawing.Size(165, 141);
      this.richTextBoxGradePresentationAndConversation.TabIndex = 10;
      this.richTextBoxGradePresentationAndConversation.Text = "";
      // 
      // labelGradePresentationAndConversation
      // 
      this.labelGradePresentationAndConversation.AutoSize = true;
      this.labelGradePresentationAndConversation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.labelGradePresentationAndConversation.Location = new System.Drawing.Point(22, 633);
      this.labelGradePresentationAndConversation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.labelGradePresentationAndConversation.Name = "labelGradePresentationAndConversation";
      this.labelGradePresentationAndConversation.Size = new System.Drawing.Size(872, 51);
      this.labelGradePresentationAndConversation.TabIndex = 9;
      this.labelGradePresentationAndConversation.Text = "Note Präsentation und Fachgespräch (30%):";
      // 
      // richTextBoxGradePresentationAndConversationScaled
      // 
      this.richTextBoxGradePresentationAndConversationScaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradePresentationAndConversationScaled.Location = new System.Drawing.Point(1110, 589);
      this.richTextBoxGradePresentationAndConversationScaled.Margin = new System.Windows.Forms.Padding(6);
      this.richTextBoxGradePresentationAndConversationScaled.Name = "richTextBoxGradePresentationAndConversationScaled";
      this.richTextBoxGradePresentationAndConversationScaled.Size = new System.Drawing.Size(165, 141);
      this.richTextBoxGradePresentationAndConversationScaled.TabIndex = 13;
      this.richTextBoxGradePresentationAndConversationScaled.Text = "";
      // 
      // richTextBoxGradeDocumentationScaled
      // 
      this.richTextBoxGradeDocumentationScaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradeDocumentationScaled.Location = new System.Drawing.Point(1110, 434);
      this.richTextBoxGradeDocumentationScaled.Margin = new System.Windows.Forms.Padding(6);
      this.richTextBoxGradeDocumentationScaled.Name = "richTextBoxGradeDocumentationScaled";
      this.richTextBoxGradeDocumentationScaled.Size = new System.Drawing.Size(165, 141);
      this.richTextBoxGradeDocumentationScaled.TabIndex = 12;
      this.richTextBoxGradeDocumentationScaled.Text = "";
      // 
      // richTextBoxGradeCompetenceScaled
      // 
      this.richTextBoxGradeCompetenceScaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
      this.richTextBoxGradeCompetenceScaled.Location = new System.Drawing.Point(1110, 279);
      this.richTextBoxGradeCompetenceScaled.Margin = new System.Windows.Forms.Padding(6);
      this.richTextBoxGradeCompetenceScaled.Name = "richTextBoxGradeCompetenceScaled";
      this.richTextBoxGradeCompetenceScaled.Size = new System.Drawing.Size(165, 141);
      this.richTextBoxGradeCompetenceScaled.TabIndex = 11;
      this.richTextBoxGradeCompetenceScaled.Text = "";
      // 
      // Main_Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1667, 762);
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
      this.Controls.Add(this.checkedListBoxChooseTemplate);
      this.Controls.Add(this.labelEndnote);
      this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
      this.Name = "Main_Form";
      this.Text = "IPA-Notenrechner";
      this.ResumeLayout(false);
      this.PerformLayout();

      }

    #endregion
    private System.Windows.Forms.Label labelEndnote;
    private System.Windows.Forms.CheckedListBox checkedListBoxChooseTemplate;
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
    }
  }

