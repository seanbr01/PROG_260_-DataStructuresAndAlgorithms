namespace ToDoLL
{
    partial class Form1
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
            this.labelRating = new System.Windows.Forms.Label();
            this.textBoxRating = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelRatingOutput = new System.Windows.Forms.Label();
            this.buttonGetNext = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelTitleOutput = new System.Windows.Forms.Label();
            this.labelAuthorOutput = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelRating
            // 
            this.labelRating.AutoSize = true;
            this.labelRating.Location = new System.Drawing.Point(34, 100);
            this.labelRating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRating.Name = "labelRating";
            this.labelRating.Size = new System.Drawing.Size(151, 20);
            this.labelRating.TabIndex = 0;
            this.labelRating.Text = "Enter A Rating (1-5)";
            // 
            // textBoxRating
            // 
            this.textBoxRating.Location = new System.Drawing.Point(248, 100);
            this.textBoxRating.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRating.Name = "textBoxRating";
            this.textBoxRating.Size = new System.Drawing.Size(148, 26);
            this.textBoxRating.TabIndex = 1;
            this.textBoxRating.TextChanged += new System.EventHandler(this.textBoxRating_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(250, 272);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(112, 35);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add To List";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelRatingOutput
            // 
            this.labelRatingOutput.AutoSize = true;
            this.labelRatingOutput.Location = new System.Drawing.Point(231, 500);
            this.labelRatingOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRatingOutput.Name = "labelRatingOutput";
            this.labelRatingOutput.Size = new System.Drawing.Size(51, 20);
            this.labelRatingOutput.TabIndex = 3;
            this.labelRatingOutput.Text = "label1";
            // 
            // buttonGetNext
            // 
            this.buttonGetNext.Location = new System.Drawing.Point(248, 380);
            this.buttonGetNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGetNext.Name = "buttonGetNext";
            this.buttonGetNext.Size = new System.Drawing.Size(144, 35);
            this.buttonGetNext.TabIndex = 5;
            this.buttonGetNext.Text = "Get Next Book";
            this.buttonGetNext.UseVisualStyleBackColor = true;
            this.buttonGetNext.Click += new System.EventHandler(this.buttonGetNext_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(248, 158);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(148, 26);
            this.textBoxTitle.TabIndex = 2;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(248, 222);
            this.textBoxAuthor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(148, 26);
            this.textBoxAuthor.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(34, 163);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(96, 20);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "Enter A Title";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(34, 226);
            this.labelAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(124, 20);
            this.labelAuthor.TabIndex = 8;
            this.labelAuthor.Text = "Enter An Author";
            // 
            // labelTitleOutput
            // 
            this.labelTitleOutput.AutoSize = true;
            this.labelTitleOutput.Location = new System.Drawing.Point(231, 569);
            this.labelTitleOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitleOutput.Name = "labelTitleOutput";
            this.labelTitleOutput.Size = new System.Drawing.Size(51, 20);
            this.labelTitleOutput.TabIndex = 9;
            this.labelTitleOutput.Text = "label2";
            // 
            // labelAuthorOutput
            // 
            this.labelAuthorOutput.AutoSize = true;
            this.labelAuthorOutput.Location = new System.Drawing.Point(231, 631);
            this.labelAuthorOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAuthorOutput.Name = "labelAuthorOutput";
            this.labelAuthorOutput.Size = new System.Drawing.Size(51, 20);
            this.labelAuthorOutput.TabIndex = 10;
            this.labelAuthorOutput.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 500);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rating";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 569);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Title";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 631);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "1 is highest priority";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 795);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAuthorOutput);
            this.Controls.Add(this.labelTitleOutput);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonGetNext);
            this.Controls.Add(this.labelRatingOutput);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxRating);
            this.Controls.Add(this.labelRating);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.TextBox textBoxRating;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelRatingOutput;
        private System.Windows.Forms.Button buttonGetNext;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelTitleOutput;
        private System.Windows.Forms.Label labelAuthorOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}

