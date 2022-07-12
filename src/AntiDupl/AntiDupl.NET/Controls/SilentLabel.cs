using System;
using System.Windows.Forms;

namespace AntiDupl.NET.Controls
{
	class SilentLabel : Label
	{
		private string text;

		public override string Text
		{
			get { return text; }
			set
			{
				if (value == null) {
					value = "";
				}

				if (text != value) {
					text = value;
					Refresh();
					OnTextChanged(EventArgs.Empty);
				}
			}
		}
	}
}