namespace Work_sheet
{
    partial class New_Entry
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
            this.buttonStarted = new System.Windows.Forms.Button();
            this.buttonFinished = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxStarted = new System.Windows.Forms.TextBox();
            this.textBoxFinished = new System.Windows.Forms.TextBox();
            this.textBoxAssigned = new System.Windows.Forms.TextBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStarted
            // 
            this.buttonStarted.Location = new System.Drawing.Point(27, 36);
            this.buttonStarted.Name = "buttonStarted";
            this.buttonStarted.Size = new System.Drawing.Size(365, 25);
            this.buttonStarted.TabIndex = 0;
            this.buttonStarted.Text = "Insert current time";
            this.buttonStarted.UseVisualStyleBackColor = true;
            this.buttonStarted.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFinished
            // 
            this.buttonFinished.Location = new System.Drawing.Point(27, 124);
            this.buttonFinished.Name = "buttonFinished";
            this.buttonFinished.Size = new System.Drawing.Size(365, 25);
            this.buttonFinished.TabIndex = 1;
            this.buttonFinished.Text = "Insert current time";
            this.buttonFinished.UseVisualStyleBackColor = true;
            this.buttonFinished.Click += new System.EventHandler(this.buttonFinished_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 295);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(93, 295);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxStarted
            // 
            this.textBoxStarted.Location = new System.Drawing.Point(27, 67);
            this.textBoxStarted.Name = "textBoxStarted";
            this.textBoxStarted.Size = new System.Drawing.Size(365, 20);
            this.textBoxStarted.TabIndex = 4;
            // 
            // textBoxFinished
            // 
            this.textBoxFinished.Location = new System.Drawing.Point(27, 157);
            this.textBoxFinished.Name = "textBoxFinished";
            this.textBoxFinished.Size = new System.Drawing.Size(365, 20);
            this.textBoxFinished.TabIndex = 5;
            // 
            // textBoxAssigned
            // 
            this.textBoxAssigned.Location = new System.Drawing.Point(27, 206);
            this.textBoxAssigned.Name = "textBoxAssigned";
            this.textBoxAssigned.Size = new System.Drawing.Size(365, 20);
            this.textBoxAssigned.TabIndex = 6;
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(27, 260);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(365, 20);
            this.textBoxComment.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Job assigned by";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Comment about what you\'ve done";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Finished time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Started time";
            // 
            // New_Entry
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(418, 330);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.textBoxAssigned);
            this.Controls.Add(this.textBoxFinished);
            this.Controls.Add(this.textBoxStarted);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonFinished);
            this.Controls.Add(this.buttonStarted);
            this.Name = "New_Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStarted;
        private System.Windows.Forms.Button buttonFinished;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxStarted;
        private System.Windows.Forms.TextBox textBoxFinished;
        private System.Windows.Forms.TextBox textBoxAssigned;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}