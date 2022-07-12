
using AntiDupl.NET.Controls;

namespace AntiDupl.NET.Forms
{
	partial class QuickRenameForm
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
			if (disposing && (components != null)) {
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
			this.FirstName = new ColoredTextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.SecondName = new ColoredTextBox();
			this.SecondExtension = new System.Windows.Forms.TextBox();
			this.FirstExtension = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.Cancel = new System.Windows.Forms.Button();
			this.Rename = new System.Windows.Forms.Button();
			this.FirstLabel = new AntiDupl.NET.Controls.SilentLabel();
			this.SecondLabel = new AntiDupl.NET.Controls.SilentLabel();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// FirstName
			// 
			this.FirstName.Dock = System.Windows.Forms.DockStyle.Top;
			this.FirstName.Location = new System.Drawing.Point(3, 27);
			this.FirstName.Name = "FirstName";
			this.FirstName.Size = new System.Drawing.Size(318, 23);
			this.FirstName.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.Controls.Add(this.SecondName, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.SecondExtension, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.FirstName, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.FirstExtension, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.FirstLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.SecondLabel, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 151);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// SecondName
			// 
			this.SecondName.Dock = System.Windows.Forms.DockStyle.Top;
			this.SecondName.Location = new System.Drawing.Point(3, 83);
			this.SecondName.Name = "SecondName";
			this.SecondName.Size = new System.Drawing.Size(318, 23);
			this.SecondName.TabIndex = 1;
			// 
			// SecondExtension
			// 
			this.SecondExtension.Dock = System.Windows.Forms.DockStyle.Top;
			this.SecondExtension.Location = new System.Drawing.Point(327, 83);
			this.SecondExtension.Name = "SecondExtension";
			this.SecondExtension.Size = new System.Drawing.Size(94, 23);
			this.SecondExtension.TabIndex = 3;
			// 
			// FirstExtension
			// 
			this.FirstExtension.Dock = System.Windows.Forms.DockStyle.Top;
			this.FirstExtension.Location = new System.Drawing.Point(327, 27);
			this.FirstExtension.Name = "FirstExtension";
			this.FirstExtension.Size = new System.Drawing.Size(94, 23);
			this.FirstExtension.TabIndex = 2;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
			this.flowLayoutPanel1.Controls.Add(this.Cancel);
			this.flowLayoutPanel1.Controls.Add(this.Rename);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 122);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(424, 29);
			this.flowLayoutPanel1.TabIndex = 4;
			// 
			// Cancel
			// 
			this.Cancel.Location = new System.Drawing.Point(346, 3);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 1;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			// 
			// Rename
			// 
			this.Rename.Location = new System.Drawing.Point(265, 3);
			this.Rename.Name = "Rename";
			this.Rename.Size = new System.Drawing.Size(75, 23);
			this.Rename.TabIndex = 0;
			this.Rename.Text = "Rename";
			this.Rename.UseVisualStyleBackColor = true;
			// 
			// FirstLabel
			// 
			this.FirstLabel.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.FirstLabel, 2);
			this.FirstLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FirstLabel.Location = new System.Drawing.Point(3, 0);
			this.FirstLabel.Name = "FirstLabel";
			this.FirstLabel.Size = new System.Drawing.Size(418, 24);
			this.FirstLabel.TabIndex = 5;
			this.FirstLabel.Text = "First File Path";
			this.FirstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SecondLabel
			// 
			this.SecondLabel.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.SecondLabel, 2);
			this.SecondLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SecondLabel.Location = new System.Drawing.Point(3, 56);
			this.SecondLabel.Name = "SecondLabel";
			this.SecondLabel.Size = new System.Drawing.Size(418, 24);
			this.SecondLabel.TabIndex = 6;
			this.SecondLabel.Text = "Second File Path";
			this.SecondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QuickRenameForm
			// 
			this.AcceptButton = this.Rename;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(434, 161);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(100000000, 200);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 200);
			this.Name = "QuickRenameForm";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quick file renaming";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ColoredTextBox FirstName;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private ColoredTextBox SecondName;
		private System.Windows.Forms.TextBox SecondExtension;
		private System.Windows.Forms.TextBox FirstExtension;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private Controls.SilentLabel FirstLabel;
		private Controls.SilentLabel SecondLabel;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button Rename;
	}
}