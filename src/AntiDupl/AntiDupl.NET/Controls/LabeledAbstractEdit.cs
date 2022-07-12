using System;
using System.Windows.Forms;
using System.Drawing;

namespace AntiDupl.NET.Controls
{
	public class LabeledAbstractEdit : TableLayoutPanel
	{
		protected Label Label { get; }

		public override String Text
		{
			get { return Label.Text; }
			set { Label.Text = value; }
		}
		
		public LabeledAbstractEdit()
		{
			Location = new Point(0, 0);
			AutoSize = true;
			ColumnCount = 2;
			RowCount = 1;

			Label = new Label {
				AutoSize = true,
				Padding = new Padding(0, 5, 5, 5)
			};
			Controls.Add(Label, 1, 0);
		}
	}
}
