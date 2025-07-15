using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System;

using AntiDupl.NET.Controls;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AntiDupl.NET.Forms
{
	public partial class QuickRenameForm : Form
	{
		public CoreResult Result { get; }

		public string First
		{
			get => Lines[0].FileName;
		}

		public string Second
		{
			get => Lines[1].FileName;
		}

		public string FirstPath
		{
			get => Lines[0].FilePath;
		}

		public string SecondPath
		{
			get => Lines[1].FilePath;
		}

		public bool FirstFormer
		{
			get => Lines[0].Status == LineStatus.StatusFormer;
		}

		public bool SecondFormer
		{
			get => Lines[1].Status == LineStatus.StatusFormer;
		}

		public bool FirstValid
		{
			get => Lines[0].Status == LineStatus.StatusValid;
		}

		public bool SecondValid
		{
			get => Lines[1].Status == LineStatus.StatusValid;
		}

		private enum LineStatus
		{
			StatusValid,
			StatusInvalid,
			StatusFormer
		}

		private partial class Line
		{
			public required string OriginPath;
			public required Label Label;
			public required ColoredTextBox Name;
			public required ColoredTextBox ID;
			public required ColoredTextBox Prefix;
			public required ColoredTextBox Author;
			public required TextBox Extension;
			public LineStatus Status = LineStatus.StatusFormer;
			public int MatchedPattern = -1;

			public void Init()
			{
				Label.Text = Path.GetDirectoryName(OriginPath);

				string fullname = Path.GetFileNameWithoutExtension(OriginPath);

				int pattern_index = -1;
				foreach (Regex pattern in s_patterns) {
					++pattern_index;
					Match matches = pattern.Match(fullname);
					if (matches.Success) {
						MatchedPattern = pattern_index;
						Name.Text = matches.Groups["name"].Value;
						ID.Text = matches.Groups["id"].Value;
						Prefix.Text = matches.Groups["prefix"].Value;
						Author.Text = matches.Groups["author"].Value;
						break;
					}
				}

				if (MatchedPattern == -1) {
					Name.Text = fullname;
				}

				Extension.Text = Path.GetExtension(OriginPath).TrimStart('.');

				Name.TextChanged += new EventHandler((object sender, EventArgs e) => { Changed(this, EventArgs.Empty); });
				Extension.TextChanged += new EventHandler((object sender, EventArgs e) => { Changed(this, EventArgs.Empty); });
				ID.TextChanged += new EventHandler((object sender, EventArgs e) => { Changed(this, EventArgs.Empty); });
				Prefix.TextChanged += new EventHandler((object sender, EventArgs e) => { Changed(this, EventArgs.Empty); });
				Author.TextChanged += new EventHandler((object sender, EventArgs e) => { Changed(this, EventArgs.Empty); });
			}

			public event EventHandler Changed;

			private static List<Regex> s_patterns = [
				new(pattern: @"^\s*\[\s*(?:(?<prefix>[^_]*)_)?(?<id>[^\]]*)\s*\]\s*(?<name>.*)\s*$", options: RegexOptions.Compiled),
				new(pattern: @"^\s*(?:(?<author>.+?) - )?(?<name>.+?)\s*\(\s*\s*(?:(?<prefix>[^_\(\)]*)_)?(?<id>[\da-zA-Z-_]+)\s*\)\s*$", options: RegexOptions.Compiled),
				new(pattern: @"^\s*(?:(?<author>.+?) - )+(?<name>.+?)\s*$", options: RegexOptions.Compiled),
			];

			public string FileName
			{
				get
				{
					string fullname = Name.Text.Trim();
					string name = Path.GetFileName(fullname);
					string path = Path.GetDirectoryName(fullname);
					string id = ID.Text.Trim();
					string prefix = Prefix.Text.Trim();
					string author = Author.Text.Trim();

					bool has_id = string.IsNullOrEmpty(id) == false;
					bool has_prefix = string.IsNullOrEmpty(prefix) == false;
					bool has_author = string.IsNullOrEmpty(author) == false;

					//switch (MatchedPattern) {
					//	case 0:
					//		if (has_id == false) {
					//			MatchedPattern = -1;
					//		}
					//		break;

					//	case 1:
					//		if (has_author == false || has_id == false) {
					//			MatchedPattern = -1;
					//		}
					//		break;

					//	case 2:
					//		if (has_author == false || has_id) {
					//			MatchedPattern = -1;
					//		}
					//		break;
					//}

					fullname = "";

					//if (MatchedPattern != -1) {
					//	fullname = Path.GetFileNameWithoutExtension(OriginPath).Replace(s_patterns[MatchedPattern], new Dictionary<string, string> { 
					//		{"name", name},
					//		{"id", id},
					//		{"prefix", prefix},
					//		{"author", author},
					//	});
					//} else 
					
					if (has_author) {
						fullname = author + " - " + name;
						if (has_id) {
							fullname += " (";
							if (has_prefix) {
								fullname += prefix + '_';
							}
							fullname += id + ")";
						}
					} else {
						if (has_id) {
							fullname += '[';
							if (has_prefix) {
								fullname += prefix + '_';
							}
							fullname += id + "] ";
						}
						fullname += name;
					}

					if (string.IsNullOrEmpty(path) == false) {
						fullname = path + '\\' + fullname;
					}

					if (string.IsNullOrEmpty(fullname)) {
						return "";
					}

					string extension = Extension.Text.Trim();

					return string.IsNullOrEmpty(extension) ? fullname : (fullname + '.' + extension);
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

				if (IsFormer) {
					return false;
				}

				// renaming the same file, but in a different case
				if (string.Equals(FilePath, OriginPath, StringComparison.OrdinalIgnoreCase)) {
					return true;
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
				ID = FirstID,
				Prefix = FirstPrefix,
				Author = FirstAuthor,
				Extension = FirstExtension
			};

			Lines[1] = new Line {
				OriginPath = result.second.path,
				Label = SecondLabel,
				Name = SecondName,
				ID = SecondID,
				Prefix = SecondPrefix,
				Author = SecondAuthor,
				Extension = SecondExtension
			};

			foreach (Line line in Lines) {
				line.Init();
				line.Changed += new EventHandler((object sender, EventArgs e) => { Verify(line); });
			}

			Verify(Lines[0]);
			Verify(Lines[1]);

			this.Shown += new EventHandler((object sender, EventArgs e) => {
				FirstName.SelectionStart = FirstName.Text.Length;
				SecondName.SelectionStart = SecondName.Text.Length;
			});

			SizeF FirstSize = FirstName.CreateGraphics().MeasureString(FirstName.Text, FirstName.Font);
			SizeF SecondSize = SecondName.CreateGraphics().MeasureString(SecondName.Text, SecondName.Font);
			float screenWidth = Screen.FromControl(this).Bounds.Width;
			this.Width = (int) Math.Min(screenWidth - 200, Math.Max(450, Math.Max(FirstSize.Width, SecondSize.Width) + 140));
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