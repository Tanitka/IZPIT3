namespace PresentationLayer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBooks = new System.Windows.Forms.Button();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonLibraries = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBooks
            // 
            this.buttonBooks.Location = new System.Drawing.Point(126, 102);
            this.buttonBooks.Name = "buttonBooks";
            this.buttonBooks.Size = new System.Drawing.Size(75, 23);
            this.buttonBooks.TabIndex = 0;
            this.buttonBooks.Text = "Books";
            this.buttonBooks.UseVisualStyleBackColor = true;
            this.buttonBooks.Click += new System.EventHandler(this.buttonBooks_Click);
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Location = new System.Drawing.Point(520, 102);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(75, 23);
            this.buttonCustomers.TabIndex = 1;
            this.buttonCustomers.Text = "Customers";
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonLibraries
            // 
            this.buttonLibraries.Location = new System.Drawing.Point(126, 195);
            this.buttonLibraries.Name = "buttonLibraries";
            this.buttonLibraries.Size = new System.Drawing.Size(75, 23);
            this.buttonLibraries.TabIndex = 2;
            this.buttonLibraries.Text = "Libraries";
            this.buttonLibraries.UseVisualStyleBackColor = true;
            this.buttonLibraries.Click += new System.EventHandler(this.buttonLibraries_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(520, 195);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonLibraries);
            this.Controls.Add(this.buttonCustomers);
            this.Controls.Add(this.buttonBooks);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBooks;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonLibraries;
        private System.Windows.Forms.Button buttonExit;
    }
}
