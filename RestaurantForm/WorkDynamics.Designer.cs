namespace RestaurantForm
{
	partial class WorkDynamicsForm
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
			this.RestoranDataGrid = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.RestoranDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// RestoranDataGrid
			// 
			this.RestoranDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.RestoranDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.RestoranDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
			this.RestoranDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RestoranDataGrid.Location = new System.Drawing.Point(0, 0);
			this.RestoranDataGrid.Name = "RestoranDataGrid";
			this.RestoranDataGrid.ReadOnly = true;
			this.RestoranDataGrid.Size = new System.Drawing.Size(580, 493);
			this.RestoranDataGrid.TabIndex = 0;
			// 
			// WorkDynamicsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(580, 493);
			this.Controls.Add(this.RestoranDataGrid);
			this.Name = "WorkDynamicsForm";
			this.Text = "WorkDynamics";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkDynamicsForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.RestoranDataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView RestoranDataGrid;
	}
}