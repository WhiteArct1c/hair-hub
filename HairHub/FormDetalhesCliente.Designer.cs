namespace HairHub
{
    partial class FormDetalhesCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridDetalhesCliente = new System.Windows.Forms.DataGridView();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefoneCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetalhesCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridDetalhesCliente
            // 
            this.dataGridDetalhesCliente.AllowUserToAddRows = false;
            this.dataGridDetalhesCliente.AllowUserToDeleteRows = false;
            this.dataGridDetalhesCliente.AllowUserToResizeColumns = false;
            this.dataGridDetalhesCliente.AllowUserToResizeRows = false;
            this.dataGridDetalhesCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDetalhesCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDetalhesCliente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.dataGridDetalhesCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridDetalhesCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetalhesCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cliente,
            this.telefoneCliente,
            this.servicoCliente,
            this.valorCliente});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDetalhesCliente.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDetalhesCliente.Location = new System.Drawing.Point(65, 73);
            this.dataGridDetalhesCliente.Name = "dataGridDetalhesCliente";
            this.dataGridDetalhesCliente.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDetalhesCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDetalhesCliente.RowHeadersVisible = false;
            this.dataGridDetalhesCliente.RowHeadersWidth = 51;
            this.dataGridDetalhesCliente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridDetalhesCliente.RowTemplate.Height = 24;
            this.dataGridDetalhesCliente.ShowEditingIcon = false;
            this.dataGridDetalhesCliente.Size = new System.Drawing.Size(995, 352);
            this.dataGridDetalhesCliente.TabIndex = 1;
            this.dataGridDetalhesCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDetalhesCliente_CellClick);
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.MinimumWidth = 6;
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // telefoneCliente
            // 
            this.telefoneCliente.HeaderText = "Telefone";
            this.telefoneCliente.MinimumWidth = 6;
            this.telefoneCliente.Name = "telefoneCliente";
            this.telefoneCliente.ReadOnly = true;
            // 
            // servicoCliente
            // 
            this.servicoCliente.HeaderText = "Serviço";
            this.servicoCliente.MinimumWidth = 6;
            this.servicoCliente.Name = "servicoCliente";
            this.servicoCliente.ReadOnly = true;
            // 
            // valorCliente
            // 
            this.valorCliente.HeaderText = "Valor";
            this.valorCliente.MinimumWidth = 6;
            this.valorCliente.Name = "valorCliente";
            this.valorCliente.ReadOnly = true;
            // 
            // FormDetalhesCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.ClientSize = new System.Drawing.Size(1125, 499);
            this.Controls.Add(this.dataGridDetalhesCliente);
            this.Name = "FormDetalhesCliente";
            this.Text = "DETALHE CLIENTE";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetalhesCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridDetalhesCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefoneCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorCliente;
    }
}