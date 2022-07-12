using System;
using System.Collections.Generic;
using System.Text;

namespace AntiDupl.NET.OptionsBranches
{
	public class Naming
	{
		public string NumberSeparator = "_";

		public Naming()
		{}

		public Naming(Naming other)
		{
			if (other == null) {
				return;
			}
			NumberSeparator = other.NumberSeparator;
		}

		public Naming Clone()
		{
			return new Naming(this);
		}
	}
}
