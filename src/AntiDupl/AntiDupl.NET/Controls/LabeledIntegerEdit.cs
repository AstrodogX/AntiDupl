using System;
using System.Windows.Forms;
using System.Drawing;

namespace AntiDupl.NET.Controls
{
	public class LabeledIntegerEdit : LabeledAbstractEdit
	{
		protected NumericUpDown Box { get; }

		public int Value
		{
			get { return (int) Box.Value; }
			set { Box.Value = value; }
		}

		public int Min
		{
			get { return (int) Box.Minimum; }
			set { Box.Minimum = value; }
		}

		public int Max
		{
			get { return (int) Box.Maximum; }
			set { Box.Maximum = value; }
		}

		public LabeledIntegerEdit(int boxWidth, int boxHeight, EventHandler valueChangedHandler)
		{
			Box = new NumericUpDown {
				Minimum = int.MinValue,
				Maximum = int.MaxValue,
				Size = new Size(boxWidth, boxHeight),
				Padding = new Padding(0, 0, 0, 0),
				Margin = new Padding(0, 0, 0, 0),
				DecimalPlaces = 0
			};
			Box.ValueChanged += valueChangedHandler;
			Box.MouseWheel += new MouseEventHandler((sender, e) => {
				NumericUpDown box = sender as NumericUpDown;
				HandledMouseEventArgs args = e as HandledMouseEventArgs;
				args.Handled = true;
				box.Value += args.Delta > 0 ? box.Increment : -box.Increment;
			});
			Controls.Add(Box, 0, 0);
		}
	}
}
