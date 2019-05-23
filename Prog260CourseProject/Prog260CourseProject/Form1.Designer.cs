namespace Prog260CourseProject
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbISBN = new System.Windows.Forms.TextBox();
            this.txbTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbRating = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbYear = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddNewBook = new System.Windows.Forms.Button();
            this.btnFindFromISBN = new System.Windows.Forms.Button();
            this.btnRemoveFromISBN = new System.Windows.Forms.Button();
            this.btnGetAllISBNs = new System.Windows.Forms.Button();
            this.dgvISBN = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvISBN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book ISBN:";
            // 
            // txbISBN
            // 
            this.txbISBN.Location = new System.Drawing.Point(127, 25);
            this.txbISBN.Name = "txbISBN";
            this.txbISBN.Size = new System.Drawing.Size(100, 20);
            this.txbISBN.TabIndex = 1;
            // 
            // txbTitle
            // 
            this.txbTitle.Location = new System.Drawing.Point(127, 62);
            this.txbTitle.Name = "txbTitle";
            this.txbTitle.Size = new System.Drawing.Size(214, 20);
            this.txbTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Book Title:";
            // 
            // txbAuthor
            // 
            this.txbAuthor.Location = new System.Drawing.Point(127, 98);
            this.txbAuthor.Name = "txbAuthor";
            this.txbAuthor.Size = new System.Drawing.Size(214, 20);
            this.txbAuthor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Book Author:";
            // 
            // txbRating
            // 
            this.txbRating.Location = new System.Drawing.Point(127, 135);
            this.txbRating.Name = "txbRating";
            this.txbRating.Size = new System.Drawing.Size(100, 20);
            this.txbRating.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Book Rating:";
            // 
            // txbYear
            // 
            this.txbYear.Location = new System.Drawing.Point(127, 173);
            this.txbYear.Name = "txbYear";
            this.txbYear.Size = new System.Drawing.Size(100, 20);
            this.txbYear.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Book Year:";
            // 
            // btnAddNewBook
            // 
            this.btnAddNewBook.Location = new System.Drawing.Point(37, 229);
            this.btnAddNewBook.Name = "btnAddNewBook";
            this.btnAddNewBook.Size = new System.Drawing.Size(75, 58);
            this.btnAddNewBook.TabIndex = 10;
            this.btnAddNewBook.Text = "Add New Book";
            this.btnAddNewBook.UseVisualStyleBackColor = true;
            this.btnAddNewBook.Click += new System.EventHandler(this.btnAddNewBook_Click);
            // 
            // btnFindFromISBN
            // 
            this.btnFindFromISBN.Location = new System.Drawing.Point(152, 229);
            this.btnFindFromISBN.Name = "btnFindFromISBN";
            this.btnFindFromISBN.Size = new System.Drawing.Size(75, 58);
            this.btnFindFromISBN.TabIndex = 11;
            this.btnFindFromISBN.Text = "Find From ISBN";
            this.btnFindFromISBN.UseVisualStyleBackColor = true;
            this.btnFindFromISBN.Click += new System.EventHandler(this.btnFindFromISBN_Click);
            // 
            // btnRemoveFromISBN
            // 
            this.btnRemoveFromISBN.Location = new System.Drawing.Point(266, 229);
            this.btnRemoveFromISBN.Name = "btnRemoveFromISBN";
            this.btnRemoveFromISBN.Size = new System.Drawing.Size(75, 58);
            this.btnRemoveFromISBN.TabIndex = 12;
            this.btnRemoveFromISBN.Text = "Remove from ISBN";
            this.btnRemoveFromISBN.UseVisualStyleBackColor = true;
            this.btnRemoveFromISBN.Click += new System.EventHandler(this.btnRemoveFromISBN_Click);
            // 
            // btnGetAllISBNs
            // 
            this.btnGetAllISBNs.Location = new System.Drawing.Point(415, 247);
            this.btnGetAllISBNs.Name = "btnGetAllISBNs";
            this.btnGetAllISBNs.Size = new System.Drawing.Size(141, 23);
            this.btnGetAllISBNs.TabIndex = 13;
            this.btnGetAllISBNs.Text = "Get All ISBNs";
            this.btnGetAllISBNs.UseVisualStyleBackColor = true;
            this.btnGetAllISBNs.Click += new System.EventHandler(this.btnGetAllISBNs_Click);
            // 
            // dgvISBN
            // 
            this.dgvISBN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvISBN.Location = new System.Drawing.Point(368, 25);
            this.dgvISBN.Name = "dgvISBN";
            this.dgvISBN.Size = new System.Drawing.Size(240, 216);
            this.dgvISBN.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 442);
            this.Controls.Add(this.dgvISBN);
            this.Controls.Add(this.btnGetAllISBNs);
            this.Controls.Add(this.btnRemoveFromISBN);
            this.Controls.Add(this.btnFindFromISBN);
            this.Controls.Add(this.btnAddNewBook);
            this.Controls.Add(this.txbYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbRating);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbAuthor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbISBN);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvISBN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbISBN;
        private System.Windows.Forms.TextBox txbTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbRating;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddNewBook;
        private System.Windows.Forms.Button btnFindFromISBN;
        private System.Windows.Forms.Button btnRemoveFromISBN;
        private System.Windows.Forms.Button btnGetAllISBNs;
        private System.Windows.Forms.DataGridView dgvISBN;
    }
}

