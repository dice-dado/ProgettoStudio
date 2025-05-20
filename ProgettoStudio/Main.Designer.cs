namespace ProgettoStudio
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
            this.areeButton = new System.Windows.Forms.Button();
            this.anagraficheButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // areeButton
            // 
            this.areeButton.Location = new System.Drawing.Point(12, 42);
            this.areeButton.Name = "areeButton";
            this.areeButton.Size = new System.Drawing.Size(75, 23);
            this.areeButton.TabIndex = 0;
            this.areeButton.Text = "Aree";
            this.areeButton.UseVisualStyleBackColor = true;
            // 
            // anagraficheButton
            // 
            this.anagraficheButton.Location = new System.Drawing.Point(117, 42);
            this.anagraficheButton.Name = "anagraficheButton";
            this.anagraficheButton.Size = new System.Drawing.Size(75, 23);
            this.anagraficheButton.TabIndex = 1;
            this.anagraficheButton.Text = "Anagrafiche";
            this.anagraficheButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.anagraficheButton);
            this.Controls.Add(this.areeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button areeButton;
        private System.Windows.Forms.Button anagraficheButton;
    }
}

