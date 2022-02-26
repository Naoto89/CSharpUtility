namespace CSharpUtility
{
    partial class FormDataGridvVew
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
            this.m_dataGridView = new System.Windows.Forms.DataGridView();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_btnAddRow = new System.Windows.Forms.Button();
            this.m_btnDeleteRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dataGridView
            // 
            this.m_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridView.Location = new System.Drawing.Point(13, 14);
            this.m_dataGridView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.m_dataGridView.Name = "m_dataGridView";
            this.m_dataGridView.RowTemplate.Height = 25;
            this.m_dataGridView.Size = new System.Drawing.Size(834, 318);
            this.m_dataGridView.TabIndex = 0;
            this.m_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dataGridView_CellContentClick);
            this.m_dataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.m_dataGridView_RowPostPaint);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Location = new System.Drawing.Point(687, 342);
            this.m_btnCancel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(162, 67);
            this.m_btnCancel.TabIndex = 1;
            this.m_btnCancel.Text = "キャンセル";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnOK
            // 
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.Location = new System.Drawing.Point(515, 342);
            this.m_btnOK.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(162, 67);
            this.m_btnOK.TabIndex = 2;
            this.m_btnOK.Text = "OK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
            // 
            // m_btnAddRow
            // 
            this.m_btnAddRow.Location = new System.Drawing.Point(14, 342);
            this.m_btnAddRow.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.m_btnAddRow.Name = "m_btnAddRow";
            this.m_btnAddRow.Size = new System.Drawing.Size(162, 67);
            this.m_btnAddRow.TabIndex = 3;
            this.m_btnAddRow.Text = "行追加";
            this.m_btnAddRow.UseVisualStyleBackColor = true;
            this.m_btnAddRow.Click += new System.EventHandler(this.m_btnAddRow_Click);
            // 
            // m_btnDeleteRow
            // 
            this.m_btnDeleteRow.Location = new System.Drawing.Point(186, 342);
            this.m_btnDeleteRow.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.m_btnDeleteRow.Name = "m_btnDeleteRow";
            this.m_btnDeleteRow.Size = new System.Drawing.Size(162, 67);
            this.m_btnDeleteRow.TabIndex = 4;
            this.m_btnDeleteRow.Text = "行削除";
            this.m_btnDeleteRow.UseVisualStyleBackColor = true;
            this.m_btnDeleteRow.Click += new System.EventHandler(this.m_btnDeleteRow_Click);
            // 
            // FormDataGridvVew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 423);
            this.Controls.Add(this.m_btnDeleteRow);
            this.Controls.Add(this.m_btnAddRow);
            this.Controls.Add(this.m_btnOK);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_dataGridView);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FormDataGridvVew";
            this.Text = "FormDataGridvVew";
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_dataGridView;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.Button m_btnAddRow;
        private System.Windows.Forms.Button m_btnDeleteRow;
    }
}