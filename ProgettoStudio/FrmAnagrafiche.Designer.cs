namespace ProgettoStudio
{
    partial class FrmAnagrafiche
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
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.ragioneSocialeTextBox = new System.Windows.Forms.TextBox();
            this.indirizzoTextBox = new System.Windows.Forms.TextBox();
            this.partitaIVATextBox = new System.Windows.Forms.TextBox();
            this.telefonoTextBox = new System.Windows.Forms.TextBox();
            this.riferimentiDataGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.riferimentiDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(12, 32);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 0;
            // 
            // ragioneSocialeTextBox
            // 
            this.ragioneSocialeTextBox.Location = new System.Drawing.Point(153, 32);
            this.ragioneSocialeTextBox.Name = "ragioneSocialeTextBox";
            this.ragioneSocialeTextBox.Size = new System.Drawing.Size(535, 20);
            this.ragioneSocialeTextBox.TabIndex = 1;
            // 
            // indirizzoTextBox
            // 
            this.indirizzoTextBox.Location = new System.Drawing.Point(153, 81);
            this.indirizzoTextBox.Name = "indirizzoTextBox";
            this.indirizzoTextBox.Size = new System.Drawing.Size(282, 20);
            this.indirizzoTextBox.TabIndex = 2;
            // 
            // partitaIVATextBox
            // 
            this.partitaIVATextBox.Location = new System.Drawing.Point(12, 81);
            this.partitaIVATextBox.Name = "partitaIVATextBox";
            this.partitaIVATextBox.Size = new System.Drawing.Size(135, 20);
            this.partitaIVATextBox.TabIndex = 3;
            // 
            // telefonoTextBox
            // 
            this.telefonoTextBox.Location = new System.Drawing.Point(441, 81);
            this.telefonoTextBox.Name = "telefonoTextBox";
            this.telefonoTextBox.Size = new System.Drawing.Size(247, 20);
            this.telefonoTextBox.TabIndex = 4;
            // 
            // riferimentiDataGridView
            // 
            this.riferimentiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.riferimentiDataGridView.Location = new System.Drawing.Point(12, 140);
            this.riferimentiDataGridView.Name = "riferimentiDataGridView";
            this.riferimentiDataGridView.Size = new System.Drawing.Size(676, 255);
            this.riferimentiDataGridView.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(36, 415);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(76, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(130, 415);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ragione Sociale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "partita IVA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Indirizzo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Telefono";
            // 
            // FrmAnagrafiche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.riferimentiDataGridView);
            this.Controls.Add(this.telefonoTextBox);
            this.Controls.Add(this.partitaIVATextBox);
            this.Controls.Add(this.indirizzoTextBox);
            this.Controls.Add(this.ragioneSocialeTextBox);
            this.Controls.Add(this.idTextBox);
            this.Name = "FrmAnagrafiche";
            this.Text = "FrmAnagrafiche";
            ((System.ComponentModel.ISupportInitialize)(this.riferimentiDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox ragioneSocialeTextBox;
        private System.Windows.Forms.TextBox indirizzoTextBox;
        private System.Windows.Forms.TextBox partitaIVATextBox;
        private System.Windows.Forms.TextBox telefonoTextBox;
        private System.Windows.Forms.DataGridView riferimentiDataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}