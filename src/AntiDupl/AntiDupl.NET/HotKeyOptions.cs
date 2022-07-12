using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace AntiDupl.NET
{
	public class HotKeyOptions
	{
		public enum Action
		{
			CurrentDefectDelete,
			CurrentDuplPairDeleteFirst,
			CurrentDuplPairDeleteSecond,
			CurrentDuplPairDeleteBoth,
			CurrentDuplPairRenameFirstToSecond,
			CurrentDuplPairRenameSecondToFirst,
			CurrentMistake,
			ShowNeighbours,
			QuickRename
		}

		public Dictionary<Action, Keys> Bindings { get; private set; } = new();

		private static readonly Dictionary<Action, Keys> Defaults = new() {
			[Action.CurrentDefectDelete] = Keys.NumPad1,
			[Action.CurrentDuplPairDeleteFirst] = Keys.NumPad1,
			[Action.CurrentDuplPairDeleteSecond] = Keys.NumPad2,
			[Action.CurrentDuplPairDeleteBoth] = Keys.NumPad3,
			[Action.CurrentDuplPairRenameFirstToSecond] = Keys.NumPad4,
			[Action.CurrentDuplPairRenameSecondToFirst] = Keys.NumPad6,
			[Action.CurrentMistake] = Keys.NumPad5,
			[Action.ShowNeighbours] = Keys.Control | Keys.Q,
			[Action.QuickRename] = Keys.F2,
		};

		private static readonly Keys[] ReservedKeyCombinations = {
			Keys.A | Keys.Control,
			Keys.C | Keys.Control,
			Keys.Z | Keys.Control,
			Keys.Y | Keys.Control
		};

		private static readonly Keys[] ReservedKeys = {
			Keys.Up,
			Keys.Down,
			Keys.PageUp,
			Keys.PageDown,
			Keys.Home,
			Keys.End
		};

		public int Count { get => Bindings.Count; }

		public static int TotalCount { get => Defaults.Count; }

		public static Action[] AvailableActions()
		{
			return Defaults.Keys.ToArray();
		}

		public HotKeyOptions()
		{
			Reset();
		}

		public HotKeyOptions(HotKeyOptions other)
		{
			if (other != null) {
				Bindings = new(other.Bindings);
			} else {
				Reset();
			}
		}

		public Keys Binding(Action action)
		{
			return Bindings.GetValueOrDefault(action, Keys.None);
		}

		public void Bind(Action action, Keys keys)
		{
			Bindings[action] = keys;
		}

		public void Clear(Action action)
		{
			Bindings[action] = Keys.None;
		}

		public Action[] Actions(Keys keys)
		{
			List<Action> result = new();

			foreach (var item in Bindings) {
				if (item.Value == keys) {
					result.Add(item.Key);
				}
			}

			return result.ToArray();
		}

		public void Reset()
		{
			foreach (var item in Defaults) {
				Bindings[item.Key] = item.Value;
			}
		}

		public void Reset(Action action)
		{
			Bindings[action] = Defaults.GetValueOrDefault(action, Keys.None);
		}

		public bool IsEqualsTo(HotKeyOptions other)
		{
			return other != null && Bindings.Count == other.Bindings.Count && Bindings.Except(other.Bindings).Any() == false;
		}

		public static bool IsKeysAllowed(Keys keys)
		{
			if (keys == Keys.None) {
				return true;
			}

			if (ReservedKeyCombinations.Contains(keys)) {
				return false;
			}

			return ReservedKeys.Contains((new KeyEventArgs(keys)).KeyCode) == false;
		}

		public bool IsValid(Action action)
		{
			Keys keys = Binding(action);

			if (keys == Keys.None) {
				return true;
			}

			if (IsKeysAllowed(keys) == false) {
				return false;
			}

			Action[] actions = Actions(keys);

			// no other action is bound to this key
			if (actions.Length <= 1) {
				return true;
			}

			// can share any keys except CurrentMistake keys
			if (action == Action.CurrentDefectDelete) {
				return actions.Contains(Action.CurrentMistake) == false;
			}
			if (action != Action.CurrentMistake && actions.Length == 2 && actions.Contains(Action.CurrentDefectDelete)) {
				return true;
			}

			return false;
		}

		public bool IsValid()
		{
			foreach (var item in Bindings) {
				if (IsValid(item.Key) == false) {
					return false;
				}
			}
			return true;
		}

	}
}
