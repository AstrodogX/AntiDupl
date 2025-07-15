using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AntiDupl.NET
{
	public static class RegexExtensions
	{
		public static string Replace(this string input, Regex regex, Dictionary<string, string> captureGroupReplacements)
		{
			string temp = input;

			foreach (var key in captureGroupReplacements?.Keys) {
				temp = regex?.Replace(temp, m => {
					return ReplaceNamedGroup(key, captureGroupReplacements[key], m);
				});
			}

			return temp;
		}

		private static string ReplaceNamedGroup(string groupName, string replacement, Match m)
		{
			string capture = m.Value;
			capture = capture.Remove(m.Groups[groupName].Index - m.Index, m.Groups[groupName].Length);
			capture = capture.Insert(m.Groups[groupName].Index - m.Index, replacement);
			return capture;
		}
	}
}
