﻿namespace ProgettoStudio
{
    partial class FrmElenco
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
            this.newButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.filtraButton = new System.Windows.Forms.Button();
            this.filtraTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(12, 12);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(799, 407);
            this.dataGridView.TabIndex = 4;
            // 
            // filtraButton
            // 
            this.filtraButton.Location = new System.Drawing.Point(694, 12);
            this.filtraButton.Name = "filtraButton";
            this.filtraButton.Size = new System.Drawing.Size(75, 23);
            this.filtraButton.TabIndex = 5;
            this.filtraButton.Text = "Filter";
            this.filtraButton.UseVisualStyleBackColor = true;
            // 
            // filtraTextBox
            // 
            this.filtraTextBox.Location = new System.Drawing.Point(568, 14);
            this.filtraTextBox.Name = "filtraTextBox";
            this.filtraTextBox.Size = new System.Drawing.Size(120, 20);
            this.filtraTextBox.TabIndex = 6;
            // 
            // FrmElenco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.filtraTextBox);
            this.Controls.Add(this.filtraButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.newButton);
            this.Name = "FrmElenco";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button filtraButton;
        private System.Windows.Forms.TextBox filtraTextBox;
    }
}