namespace BancoSimple2T1
{
    partial class VerTransferenciaForms
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
            dgvTransferencias = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTransferencias).BeginInit();
            SuspendLayout();
            // 
            // dgvTransferencias
            // 
            dgvTransferencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransferencias.Location = new Point(70, 118);
            dgvTransferencias.Name = "dgvTransferencias";
            dgvTransferencias.RowHeadersWidth = 51;
            dgvTransferencias.Size = new Size(612, 263);
            dgvTransferencias.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(286, 62);
            label1.Name = "label1";
            label1.Size = new Size(177, 26);
            label1.TabIndex = 1;
            label1.Text = "Ver transferencias";
            // 
            // VerTransferenciaForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgvTransferencias);
            Name = "VerTransferenciaForms";
            Text = "Vistas de transferencia";
            ((System.ComponentModel.ISupportInitialize)dgvTransferencias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTransferencias;
        private Label label1;
    }
}