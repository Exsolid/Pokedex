namespace Pokedex
{
    partial class FormPokedex
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this._panelBackground = new System.Windows.Forms.Panel();
            this._labelPokedex = new System.Windows.Forms.Label();
            this._panelForForms = new System.Windows.Forms.Panel();
            this._dataGridViewPokedex = new System.Windows.Forms.DataGridView();
            this.PokeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._panelBackground.SuspendLayout();
            this._panelForForms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPokedex)).BeginInit();
            this.SuspendLayout();
            // 
            // _panelBackground
            // 
            this._panelBackground.BackColor = System.Drawing.Color.Maroon;
            this._panelBackground.Controls.Add(this._labelPokedex);
            this._panelBackground.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelBackground.Location = new System.Drawing.Point(0, 0);
            this._panelBackground.Name = "_panelBackground";
            this._panelBackground.Size = new System.Drawing.Size(800, 62);
            this._panelBackground.TabIndex = 0;
            // 
            // _labelPokedex
            // 
            this._labelPokedex.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._labelPokedex.AutoSize = true;
            this._labelPokedex.Font = new System.Drawing.Font("VCR OSD Mono", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelPokedex.Location = new System.Drawing.Point(267, -2);
            this._labelPokedex.Name = "_labelPokedex";
            this._labelPokedex.Size = new System.Drawing.Size(291, 64);
            this._labelPokedex.TabIndex = 0;
            this._labelPokedex.Text = "Pokedex";
            // 
            // _panelForForms
            // 
            this._panelForForms.Controls.Add(this._dataGridViewPokedex);
            this._panelForForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelForForms.Font = new System.Drawing.Font("VCR OSD Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._panelForForms.Location = new System.Drawing.Point(0, 62);
            this._panelForForms.Name = "_panelForForms";
            this._panelForForms.Size = new System.Drawing.Size(800, 353);
            this._panelForForms.TabIndex = 1;
            // 
            // _dataGridViewPokedex
            // 
            this._dataGridViewPokedex.AllowUserToAddRows = false;
            this._dataGridViewPokedex.AllowUserToDeleteRows = false;
            this._dataGridViewPokedex.AllowUserToOrderColumns = true;
            this._dataGridViewPokedex.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("VCR OSD Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._dataGridViewPokedex.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridViewPokedex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this._dataGridViewPokedex.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dataGridViewPokedex.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("VCR OSD Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridViewPokedex.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dataGridViewPokedex.ColumnHeadersHeight = 25;
            this._dataGridViewPokedex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._dataGridViewPokedex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PokeName,
            this.Nr,
            this.Region});
            this._dataGridViewPokedex.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("VCR OSD Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewPokedex.DefaultCellStyle = dataGridViewCellStyle3;
            this._dataGridViewPokedex.Dock = System.Windows.Forms.DockStyle.Left;
            this._dataGridViewPokedex.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._dataGridViewPokedex.EnableHeadersVisualStyles = false;
            this._dataGridViewPokedex.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._dataGridViewPokedex.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewPokedex.Name = "_dataGridViewPokedex";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("VCR OSD Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridViewPokedex.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this._dataGridViewPokedex.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this._dataGridViewPokedex.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this._dataGridViewPokedex.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("VCR OSD Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dataGridViewPokedex.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this._dataGridViewPokedex.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._dataGridViewPokedex.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this._dataGridViewPokedex.Size = new System.Drawing.Size(444, 353);
            this._dataGridViewPokedex.TabIndex = 1;
            this._dataGridViewPokedex.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.DataGridViewPokedex_SortCompare);
            // 
            // PokeName
            // 
            this.PokeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PokeName.HeaderText = "Name";
            this.PokeName.Name = "PokeName";
            this.PokeName.ReadOnly = true;
            // 
            // Nr
            // 
            this.Nr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nr.HeaderText = "Entry Number";
            this.Nr.Name = "Nr";
            this.Nr.ReadOnly = true;
            // 
            // Region
            // 
            this.Region.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Region.HeaderText = "Region";
            this.Region.Name = "Region";
            this.Region.ReadOnly = true;
            // 
            // FormPokedex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this._panelForForms);
            this.Controls.Add(this._panelBackground);
            this.Font = new System.Drawing.Font("VCR OSD Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormPokedex";
            this.Text = "Pokedex";
            this._panelBackground.ResumeLayout(false);
            this._panelBackground.PerformLayout();
            this._panelForForms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPokedex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panelBackground;
        private System.Windows.Forms.Label _labelPokedex;
        private System.Windows.Forms.Panel _panelForForms;
        private System.Windows.Forms.DataGridView _dataGridViewPokedex;
        private System.Windows.Forms.DataGridViewTextBoxColumn _pokeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nr;
        private System.Windows.Forms.DataGridViewTextBoxColumn _region;
        private System.Windows.Forms.DataGridViewTextBoxColumn PokeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Region;
    }
}

