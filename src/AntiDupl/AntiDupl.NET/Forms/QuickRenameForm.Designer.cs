
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
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			Cancel = new System.Windows.Forms.Button();
			Rename = new System.Windows.Forms.Button();
			FirstLabel = new SilentLabel();
			SecondLabel = new SilentLabel();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			SecondExtension = new System.Windows.Forms.TextBox();
			SecondID = new ColoredTextBox();
			SecondPrefix = new ColoredTextBox();
			SecondAuthor = new ColoredTextBox();
			tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			SecondName = new ColoredTextBox();
			tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			FirstName = new ColoredTextBox();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			FirstExtension = new System.Windows.Forms.TextBox();
			FirstAuthor = new ColoredTextBox();
			FirstID = new ColoredTextBox();
			FirstPrefix = new ColoredTextBox();
			tableLayoutPanel1.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			tableLayoutPanel6.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 6);
			tableLayoutPanel1.Controls.Add(FirstLabel, 0, 0);
			tableLayoutPanel1.Controls.Add(SecondLabel, 0, 3);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 5);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 4);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel6, 0, 1);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 7;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
			tableLayoutPanel1.Size = new System.Drawing.Size(686, 231);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.AutoSize = true;
			flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel1.SetColumnSpan(flowLayoutPanel1, 5);
			flowLayoutPanel1.Controls.Add(Cancel);
			flowLayoutPanel1.Controls.Add(Rename);
			flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			flowLayoutPanel1.Location = new System.Drawing.Point(0, 186);
			flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new System.Drawing.Size(686, 45);
			flowLayoutPanel1.TabIndex = 2;
			// 
			// Cancel
			// 
			Cancel.Location = new System.Drawing.Point(608, 3);
			Cancel.Name = "Cancel";
			Cancel.Size = new System.Drawing.Size(75, 23);
			Cancel.TabIndex = 3;
			Cancel.Text = "Cancel";
			Cancel.UseVisualStyleBackColor = true;
			// 
			// Rename
			// 
			Rename.Location = new System.Drawing.Point(527, 3);
			Rename.Name = "Rename";
			Rename.Size = new System.Drawing.Size(75, 23);
			Rename.TabIndex = 2;
			Rename.Text = "Rename";
			Rename.UseVisualStyleBackColor = true;
			// 
			// FirstLabel
			// 
			FirstLabel.AutoSize = true;
			tableLayoutPanel1.SetColumnSpan(FirstLabel, 5);
			FirstLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			FirstLabel.Location = new System.Drawing.Point(3, 0);
			FirstLabel.Name = "FirstLabel";
			FirstLabel.Size = new System.Drawing.Size(680, 24);
			FirstLabel.TabIndex = 5;
			FirstLabel.Text = "First File Path";
			FirstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SecondLabel
			// 
			SecondLabel.AutoSize = true;
			tableLayoutPanel1.SetColumnSpan(SecondLabel, 5);
			SecondLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			SecondLabel.Location = new System.Drawing.Point(3, 88);
			SecondLabel.Name = "SecondLabel";
			SecondLabel.Size = new System.Drawing.Size(680, 24);
			SecondLabel.TabIndex = 6;
			SecondLabel.Text = "Second File Path";
			SecondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.AutoSize = true;
			tableLayoutPanel2.ColumnCount = 4;
			tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 2);
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			tableLayoutPanel2.Controls.Add(SecondExtension, 3, 0);
			tableLayoutPanel2.Controls.Add(SecondID, 2, 0);
			tableLayoutPanel2.Controls.Add(SecondPrefix, 1, 0);
			tableLayoutPanel2.Controls.Add(SecondAuthor, 0, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 147);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new System.Drawing.Size(680, 26);
			tableLayoutPanel2.TabIndex = 4;
			// 
			// SecondExtension
			// 
			SecondExtension.Dock = System.Windows.Forms.DockStyle.Top;
			SecondExtension.Location = new System.Drawing.Point(633, 3);
			SecondExtension.Name = "SecondExtension";
			SecondExtension.Size = new System.Drawing.Size(44, 23);
			SecondExtension.TabIndex = 12;
			// 
			// SecondID
			// 
			SecondID.BorderColor = System.Drawing.SystemColors.ControlDark;
			SecondID.BorderDefaultColor = System.Drawing.SystemColors.ControlDark;
			SecondID.Dock = System.Windows.Forms.DockStyle.Top;
			SecondID.Location = new System.Drawing.Point(343, 3);
			SecondID.Name = "SecondID";
			SecondID.PlaceholderText = "ID";
			SecondID.Size = new System.Drawing.Size(284, 23);
			SecondID.TabIndex = 5;
			// 
			// SecondPrefix
			// 
			SecondPrefix.BorderColor = System.Drawing.SystemColors.ControlDark;
			SecondPrefix.BorderDefaultColor = System.Drawing.SystemColors.ControlDark;
			SecondPrefix.Dock = System.Windows.Forms.DockStyle.Top;
			SecondPrefix.Location = new System.Drawing.Point(293, 3);
			SecondPrefix.Name = "SecondPrefix";
			SecondPrefix.PlaceholderText = "Prefix";
			SecondPrefix.Size = new System.Drawing.Size(44, 23);
			SecondPrefix.TabIndex = 9;
			// 
			// SecondAuthor
			// 
			SecondAuthor.BorderColor = System.Drawing.SystemColors.ControlDark;
			SecondAuthor.BorderDefaultColor = System.Drawing.SystemColors.ControlDark;
			SecondAuthor.Dock = System.Windows.Forms.DockStyle.Top;
			SecondAuthor.Location = new System.Drawing.Point(3, 3);
			SecondAuthor.Name = "SecondAuthor";
			SecondAuthor.PlaceholderText = "Author";
			SecondAuthor.Size = new System.Drawing.Size(284, 23);
			SecondAuthor.TabIndex = 7;
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.AutoSize = true;
			tableLayoutPanel4.ColumnCount = 1;
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			tableLayoutPanel4.Controls.Add(SecondName, 0, 0);
			tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
			tableLayoutPanel4.Location = new System.Drawing.Point(3, 115);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 1;
			tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel4.Size = new System.Drawing.Size(680, 26);
			tableLayoutPanel4.TabIndex = 1;
			// 
			// SecondName
			// 
			SecondName.BorderColor = System.Drawing.SystemColors.ControlDark;
			SecondName.BorderDefaultColor = System.Drawing.SystemColors.ControlDark;
			SecondName.Dock = System.Windows.Forms.DockStyle.Top;
			SecondName.Location = new System.Drawing.Point(3, 3);
			SecondName.Name = "SecondName";
			SecondName.Size = new System.Drawing.Size(674, 23);
			SecondName.TabIndex = 1;
			// 
			// tableLayoutPanel6
			// 
			tableLayoutPanel6.AutoSize = true;
			tableLayoutPanel6.ColumnCount = 1;
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			tableLayoutPanel6.Controls.Add(FirstName, 0, 0);
			tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
			tableLayoutPanel6.Location = new System.Drawing.Point(3, 27);
			tableLayoutPanel6.Name = "tableLayoutPanel6";
			tableLayoutPanel6.RowCount = 1;
			tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel6.Size = new System.Drawing.Size(680, 26);
			tableLayoutPanel6.TabIndex = 0;
			// 
			// FirstName
			// 
			FirstName.BorderColor = System.Drawing.SystemColors.ControlDark;
			FirstName.BorderDefaultColor = System.Drawing.SystemColors.ControlDark;
			FirstName.Dock = System.Windows.Forms.DockStyle.Top;
			FirstName.Location = new System.Drawing.Point(3, 3);
			FirstName.Name = "FirstName";
			FirstName.Size = new System.Drawing.Size(674, 23);
			FirstName.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.AutoSize = true;
			tableLayoutPanel3.ColumnCount = 4;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			tableLayoutPanel3.Controls.Add(FirstExtension, 3, 0);
			tableLayoutPanel3.Controls.Add(FirstAuthor, 0, 0);
			tableLayoutPanel3.Controls.Add(FirstID, 2, 0);
			tableLayoutPanel3.Controls.Add(FirstPrefix, 1, 0);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
			tableLayoutPanel3.Location = new System.Drawing.Point(3, 59);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.Size = new System.Drawing.Size(680, 26);
			tableLayoutPanel3.TabIndex = 3;
			// 
			// FirstExtension
			// 
			FirstExtension.Dock = System.Windows.Forms.DockStyle.Top;
			FirstExtension.Location = new System.Drawing.Point(633, 3);
			FirstExtension.Name = "FirstExtension";
			FirstExtension.Size = new System.Drawing.Size(44, 23);
			FirstExtension.TabIndex = 11;
			// 
			// FirstAuthor
			// 
			FirstAuthor.BorderColor = System.Drawing.SystemColors.ControlDark;
			FirstAuthor.BorderDefaultColor = System.Drawing.SystemColors.ControlDark;
			FirstAuthor.Dock = System.Windows.Forms.DockStyle.Top;
			FirstAuthor.Location = new System.Drawing.Point(3, 3);
			FirstAuthor.Name = "FirstAuthor";
			FirstAuthor.PlaceholderText = "Author";
			FirstAuthor.Size = new System.Drawing.Size(284, 23);
			FirstAuthor.TabIndex = 6;
			// 
			// FirstID
			// 
			FirstID.BorderColor = System.Drawing.SystemColors.ControlDark;
			FirstID.BorderDefaultColor = System.Drawing.SystemColors.ControlDark;
			FirstID.Dock = System.Windows.Forms.DockStyle.Top;
			FirstID.Location = new System.Drawing.Point(343, 3);
			FirstID.Name = "FirstID";
			FirstID.PlaceholderText = "ID";
			FirstID.Size = new System.Drawing.Size(284, 23);
			FirstID.TabIndex = 4;
			// 
			// FirstPrefix
			// 
			FirstPrefix.BorderColor = System.Drawing.SystemColors.ControlDark;
			FirstPrefix.BorderDefaultColor = System.Drawing.SystemColors.ControlDark;
			FirstPrefix.Dock = System.Windows.Forms.DockStyle.Top;
			FirstPrefix.Location = new System.Drawing.Point(293, 3);
			FirstPrefix.Name = "FirstPrefix";
			FirstPrefix.PlaceholderText = "Prefix";
			FirstPrefix.Size = new System.Drawing.Size(44, 23);
			FirstPrefix.TabIndex = 8;
			// 
			// QuickRenameForm
			// 
			AcceptButton = Rename;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			CancelButton = Cancel;
			ClientSize = new System.Drawing.Size(696, 241);
			Controls.Add(tableLayoutPanel1);
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(100000000, 280);
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(300, 280);
			Name = "QuickRenameForm";
			Padding = new System.Windows.Forms.Padding(5);
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Quick renaming";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			tableLayoutPanel4.ResumeLayout(false);
			tableLayoutPanel4.PerformLayout();
			tableLayoutPanel6.ResumeLayout(false);
			tableLayoutPanel6.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			ResumeLayout(false);

		}

		#endregion
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button Rename;
		private SilentLabel FirstLabel;
		private SilentLabel SecondLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private ColoredTextBox SecondID;
		private ColoredTextBox SecondPrefix;
		private ColoredTextBox SecondAuthor;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private ColoredTextBox SecondName;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private ColoredTextBox FirstName;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private ColoredTextBox FirstAuthor;
		private ColoredTextBox FirstID;
		private ColoredTextBox FirstPrefix;
		private System.Windows.Forms.TextBox SecondExtension;
		private System.Windows.Forms.TextBox FirstExtension;
	}
}