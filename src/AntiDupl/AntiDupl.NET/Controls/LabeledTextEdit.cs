using System;
using System.Windows.Forms;
using System.Drawing;

namespace AntiDupl.NET.Controls
{
	public class LabeledTextEdit : LabeledAbstractEdit
	{
		protected TextBox Box { get; }

		public string Value
		{
			get { return Box.Text; }
			set { Box.Text = value; }
		}

		public LabeledTextEdit(int boxWidth, int boxHeight, EventHandler valueChangedHandler)
		{
			Box = new TextBox {
				Size = new Size(boxWidth, boxHeight),
				Padding = new Padding(0, 0, 0, 0),
				Margin = new Padding(0, 0, 0, 0),
				Multiline = false
			};
			Box.TextChanged += valueChangedHandler;
			Controls.Add(Box, 0, 0);
		}
	}
}
