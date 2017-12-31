namespace CSSPServicesGenerateCode
{
    partial class CSSPServicesGenerateCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.butRepopulateTesDB = new System.Windows.Forms.Button();
            this.butGenerateClassServiceGenerated = new System.Windows.Forms.Button();
            this.butGenerateClassServiceTestGenerated = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.richTextBoxStatus2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.lblNote);
            this.splitContainer1.Panel1.Controls.Add(this.butRepopulateTesDB);
            this.splitContainer1.Panel1.Controls.Add(this.butGenerateClassServiceGenerated);
            this.splitContainer1.Panel1.Controls.Add(this.butGenerateClassServiceTestGenerated);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1015, 725);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblStatusText);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 245);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1015, 31);
            this.panel2.TabIndex = 30;
            // 
            // lblStatusText
            // 
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Location = new System.Drawing.Point(12, 9);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(40, 13);
            this.lblStatusText.TabIndex = 3;
            this.lblStatusText.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(66, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 4;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(24, 51);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(504, 24);
            this.lblNote.TabIndex = 26;
            this.lblNote.Text = "Note: You will have to recompile the CSSPServices project.";
            // 
            // butRepopulateTesDB
            // 
            this.butRepopulateTesDB.Location = new System.Drawing.Point(12, 12);
            this.butRepopulateTesDB.Name = "butRepopulateTesDB";
            this.butRepopulateTesDB.Size = new System.Drawing.Size(133, 23);
            this.butRepopulateTesDB.TabIndex = 11;
            this.butRepopulateTesDB.Text = "Repopulate TestDB";
            this.butRepopulateTesDB.UseVisualStyleBackColor = true;
            this.butRepopulateTesDB.Click += new System.EventHandler(this.butRepopulateTesDB_Click);
            // 
            // butGenerateClassServiceGenerated
            // 
            this.butGenerateClassServiceGenerated.Location = new System.Drawing.Point(174, 12);
            this.butGenerateClassServiceGenerated.Name = "butGenerateClassServiceGenerated";
            this.butGenerateClassServiceGenerated.Size = new System.Drawing.Size(199, 23);
            this.butGenerateClassServiceGenerated.TabIndex = 11;
            this.butGenerateClassServiceGenerated.Text = "Generate [Class]ServiceGenerated";
            this.butGenerateClassServiceGenerated.UseVisualStyleBackColor = true;
            this.butGenerateClassServiceGenerated.Click += new System.EventHandler(this.butGenerateClassServiceGenerated_Click);
            // 
            // butGenerateClassServiceTestGenerated
            // 
            this.butGenerateClassServiceTestGenerated.Location = new System.Drawing.Point(396, 12);
            this.butGenerateClassServiceTestGenerated.Name = "butGenerateClassServiceTestGenerated";
            this.butGenerateClassServiceTestGenerated.Size = new System.Drawing.Size(229, 23);
            this.butGenerateClassServiceTestGenerated.TabIndex = 11;
            this.butGenerateClassServiceTestGenerated.Text = "Generate [Class]ServiceTestGenerated";
            this.butGenerateClassServiceTestGenerated.UseVisualStyleBackColor = true;
            this.butGenerateClassServiceTestGenerated.Click += new System.EventHandler(this.butGenerateClassServiceTestGenerated_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.richTextBoxStatus);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBoxStatus2);
            this.splitContainer2.Size = new System.Drawing.Size(1015, 445);
            this.splitContainer2.SplitterDistance = 497;
            this.splitContainer2.TabIndex = 1;
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(497, 445);
            this.richTextBoxStatus.TabIndex = 0;
            this.richTextBoxStatus.Text = "";
            // 
            // richTextBoxStatus2
            // 
            this.richTextBoxStatus2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStatus2.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxStatus2.Name = "richTextBoxStatus2";
            this.richTextBoxStatus2.Size = new System.Drawing.Size(514, 445);
            this.richTextBoxStatus2.TabIndex = 1;
            this.richTextBoxStatus2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(721, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(730, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(721, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 20);
            this.textBox1.TabIndex = 32;
            // 
            // CSSPServicesGenerateCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 725);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CSSPServicesGenerateCode";
            this.Text = "CSSP Services Generate Code";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button butGenerateClassServiceTestGenerated;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Button butGenerateClassServiceGenerated;
        private System.Windows.Forms.Button butRepopulateTesDB;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox richTextBoxStatus2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

