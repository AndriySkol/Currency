using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    partial class DatabaseTable
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
            this.mainTable = new System.Windows.Forms.DataGridView();
            this.backMove = new System.Windows.Forms.Button();
            this.aheadMove = new System.Windows.Forms.Button();
            this.labelDatabaseIsntReady = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainTable)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTable
            // 
            this.mainTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainTable.Location = new System.Drawing.Point(0, 0);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowTemplate.Height = 28;
            this.mainTable.Size = new System.Drawing.Size(1146, 428);
            this.mainTable.TabIndex = 0;
            // 
            // backMove
            // 
            this.backMove.Location = new System.Drawing.Point(104, 459);
            this.backMove.Name = "backMove";
            this.backMove.Size = new System.Drawing.Size(129, 45);
            this.backMove.TabIndex = 1;
            this.backMove.Text = "Back";
            this.backMove.UseVisualStyleBackColor = true;
            this.backMove.Click += new System.EventHandler(this.backMove_Click);
            // 
            // aheadMove
            // 
            this.aheadMove.Location = new System.Drawing.Point(913, 459);
            this.aheadMove.Name = "aheadMove";
            this.aheadMove.Size = new System.Drawing.Size(127, 45);
            this.aheadMove.TabIndex = 2;
            this.aheadMove.Text = "Ahead";
            this.aheadMove.UseVisualStyleBackColor = true;
            this.aheadMove.Click += new System.EventHandler(this.aheadMove_Click);
            // 
            // labelDatabaseIsntReady
            // 
            this.labelDatabaseIsntReady.AutoSize = true;
            this.labelDatabaseIsntReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDatabaseIsntReady.Location = new System.Drawing.Point(296, 192);
            this.labelDatabaseIsntReady.Name = "labelDatabaseIsntReady";
            this.labelDatabaseIsntReady.Size = new System.Drawing.Size(623, 40);
            this.labelDatabaseIsntReady.TabIndex = 3;
            this.labelDatabaseIsntReady.Text = "Please wait, while database is loading";
            // 
            // DatabaseTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 516);
            this.Controls.Add(this.labelDatabaseIsntReady);
            this.Controls.Add(this.aheadMove);
            this.Controls.Add(this.backMove);
            this.Controls.Add(this.mainTable);
            this.Name = "DatabaseTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DatabaseTable";
            ((System.ComponentModel.ISupportInitialize)(this.mainTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainTable;
        private System.Windows.Forms.Button backMove;
        private System.Windows.Forms.Button aheadMove;
        private int index = Database.Data.Currencies.Select(b => b.ID).FirstOrDefault();
        private int maxIndex = Database.Data.Currencies.Select(b => b.ID).LastOrDefault();
        private Label labelDatabaseIsntReady;
        }
}