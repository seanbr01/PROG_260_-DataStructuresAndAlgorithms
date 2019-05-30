namespace BubbleSortFormQuizSol
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
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(242, 36);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(152, 23);
            this.buttonShow.TabIndex = 0;
            this.buttonShow.Text = "Show List Values";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(242, 147);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(152, 23);
            this.buttonSort.TabIndex = 1;
            this.buttonSort.Text = "Sort List";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(9, 87);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(110, 13);
            this.labelOutput.TabIndex = 2;
            this.labelOutput.Text = "List Data Shows Here";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(55, 189);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(181, 13);
            this.labelCount.TabIndex = 3;
            this.labelCount.Text = "How Many Outside Loops Required?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 228);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonShow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Label labelCount;
    }
}

