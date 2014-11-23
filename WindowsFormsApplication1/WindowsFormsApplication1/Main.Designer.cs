namespace WindowsFormsApplication1
{
    partial class Main
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
            this.databaseTable = new System.Windows.Forms.Button();
            this.Chosen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // databaseTable
            // 
            this.databaseTable.BackColor = System.Drawing.Color.PaleGreen;
            this.databaseTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.databaseTable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.databaseTable.Font = new System.Drawing.Font("Monotype Corsiva", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseTable.Location = new System.Drawing.Point(0, 0);
            this.databaseTable.Name = "databaseTable";
            this.databaseTable.Size = new System.Drawing.Size(1582, 340);
            this.databaseTable.TabIndex = 1;
            this.databaseTable.Text = "Показати таблицю";
            this.databaseTable.UseVisualStyleBackColor = false;
            this.databaseTable.Click += new System.EventHandler(this.databaseTable_Click);
            // 
            // Chosen
            // 
            this.Chosen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Chosen.Font = new System.Drawing.Font("Monotype Corsiva", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Chosen.Location = new System.Drawing.Point(0, 337);
            this.Chosen.Name = "Chosen";
            this.Chosen.Size = new System.Drawing.Size(1582, 330);
            this.Chosen.TabIndex = 2;
            this.Chosen.Text = "Зробити вибірку";
            this.Chosen.UseVisualStyleBackColor = true;
            this.Chosen.Click += new System.EventHandler(this.Chosen_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 667);
            this.Controls.Add(this.Chosen);
            this.Controls.Add(this.databaseTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.Text = "Головна";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button databaseTable;
        private System.Windows.Forms.Button Chosen;
        private DatabaseTable databasetable;
        private Graph chart;

    }
}

