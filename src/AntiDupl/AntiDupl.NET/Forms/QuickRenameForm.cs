using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System;

using AntiDupl.NET.Controls;

namespace AntiDupl.NET.Forms
{
	public partial class QuickRenameForm : Form
	{
		public CoreResult Result { get; }

		public string First {
			get => Lines[0].FileName;
		}

		public string Second {
			get => Lines[1].FileName;
		}

		public string FirstPath {
			get => Lines[0].FilePath;
		}

		public string SecondPath {
			get => Lines[1].FilePath;
		}

		public bool FirstFormer {
			get => Lines[0].Status == LineStatus.StatusFormer;
		}

		public bool SecondFormer {
			get => Lines[1].Status == LineStatus.StatusFormer;
		}

		public bool FirstValid {
			get => Lines[0].Status == LineStatus.StatusValid;
		}

		public bool SecondValid {
			get => Lines[1].Status == LineStatus.StatusValid;
		}

		private enum LineStatus
		{
			StatusValid,
			StatusInvalid,
			StatusFormer
		}

		private class Line
		{
			public string OriginPath;
			public Label Label;
			public ColoredTextBox Name;
			public TextBox Extension;
			public LineStatus Status = LineStatus.StatusFormer;

			public string FileName
			{
				get
				{
					string name = Name.Text.Trim();
					if (string.IsNullOrEmpty(name)) {
						return "";
					}
					string extension = Extension.Text.Trim();
					return string.IsNullOrEmpty(extension) ? name : (name + '.' + extension);
				}
			}

			public string FilePath
			{
				get
				{
					string name = FileName;
					return string.IsNullOrEmpty(name) ? name : Path.GetFullPath(name, Label.Text);
				}
			}

			public bool IsFormer
			{
				get => FilePath == OriginPath;
			}

			public bool Validate()
			{
				string name = Name.Text.Trim();

				if (string.IsNullOrEmpty(name)) {
					return false;
				}
				
				if (File.Exists(FilePath)) {
					return false;
				}

				return true;							
			}
		}

		private readonly Line[] Lines = new Line[2];

		public QuickRenameForm(CoreResult result)
		{
			Result = result ?? throw new ArgumentNullException(nameof(result));

			InitializeComponent();

			Rename.DialogResult = DialogResult.OK;

			Lines[0] = new Line {
				OriginPath = result.first.path,
				Label = FirstLabel,
				Name = FirstName,
				Extension = FirstExtension
			};

			Lines[1] = new Line {
				OriginPath = result.second.path,
				Label = SecondLabel,
				Name = SecondName,
				Extension = SecondExtension
			};

			foreach (Line line in Lines) {
				line.Label.Text = Path.GetDirectoryName(line.OriginPath);
				line.Name.Text = Path.GetFileNameWithoutExtension(line.OriginPath);
				line.Extension.Text = Path.GetExtension(line.OriginPath).TrimStart('.');

				line.Name.TextChanged += new EventHandler((object sender, EventArgs e) => { Verify(line); });
				line.Extension.TextChanged += new EventHandler((object sender, EventArgs e) => { Verify(line); });
			}

			Verify(Lines[0]);
			Verify(Lines[1]);

			this.Shown += new EventHandler((object sender, EventArgs e) => {
				FirstName.SelectionStart = FirstName.Text.Length;
				SecondName.SelectionStart = SecondName.Text.Length;
			});
		}

		private void Verify(Line line)
		{
			if (line.IsFormer) {
				line.Status = LineStatus.StatusFormer;
				line.Name.BorderColor = FirstName.BorderDefaultColor;
			} else {
				line.Status = line.Validate() ? LineStatus.StatusValid : LineStatus.StatusInvalid;
				line.Name.BorderColor = line.Status == LineStatus.StatusValid ? Color.Green : Color.Red;
			}

			if (FirstFormer && SecondFormer) {
				Rename.Enabled = false;
			} else {
				Rename.Enabled = (FirstValid || FirstFormer) && (SecondValid || SecondFormer);
			}
		}
	}
}