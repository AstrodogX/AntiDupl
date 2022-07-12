/*
* AntiDupl.NET Program (http://ermig1979.github.io/AntiDupl).
*
* Copyright (c) 2002-2018 Yermalayeu Ihar.
*
* Permission is hereby granted, free of charge, to any person obtaining a copy 
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
* copies of the Software, and to permit persons to whom the Software is 
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in 
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KeyAction = AntiDupl.NET.HotKeyOptions.Action;

namespace AntiDupl.NET
{
	public class SelectHotKeysForm : Form
    {
		private struct HotKeyItem
		{
			public PictureBox Icon;
			public Label Text;
			public CheckBox Check;
			public TextBox Edit;
		};

		private Options m_options;
        private HotKeyOptions m_newHotKeyOptions;

        private Button m_setDefaultButton;
        private Button m_okButton;
        private Button m_cancelButton;
        private Dictionary<KeyAction, HotKeyItem> m_hotKeyItems = new();
        private ToolTip m_toolTip;

        private string m_invalidHotKeyToolTipText;

		public SelectHotKeysForm(Options options)
		{
			m_options = options;
			m_newHotKeyOptions = new HotKeyOptions(m_options.hotKeyOptions);
			InitializeComponents();
			UpdateStrings();
			UpdateOptions();
		}

		private static readonly Dictionary<ResultsOptions.ViewMode, Dictionary<KeyAction, string>> Icons = new() {
      [ResultsOptions.ViewMode.VerticalPairTable] = new() {
        [KeyAction.CurrentDefectDelete]                = "DeleteDefectVerticalButton",
        [KeyAction.CurrentDuplPairDeleteFirst]         = "DeleteFirstVerticalButton",
        [KeyAction.CurrentDuplPairDeleteSecond]        = "DeleteSecondVerticalButton",
        [KeyAction.CurrentDuplPairDeleteBoth]          = "DeleteBothVerticalButton",
        [KeyAction.CurrentDuplPairRenameFirstToSecond] = "RenameFirstToSecondVerticalButton",
        [KeyAction.CurrentDuplPairRenameSecondToFirst] = "RenameSecondToFirstVerticalButton",
        [KeyAction.CurrentMistake]                     = "MistakeButton"
			},
      [ResultsOptions.ViewMode.HorizontalPairTable] = new() {
        [KeyAction.CurrentDefectDelete]                = "DeleteDefectHorizontalButton",
        [KeyAction.CurrentDuplPairDeleteFirst]         = "DeleteFirstHorizontalButton",
        [KeyAction.CurrentDuplPairDeleteSecond]        = "DeleteSecondHorizontalButton",
        [KeyAction.CurrentDuplPairDeleteBoth]          = "DeleteBothHorizontalButton",
        [KeyAction.CurrentDuplPairRenameFirstToSecond] = "RenameFirstToSecondHorizontalButton",
        [KeyAction.CurrentDuplPairRenameSecondToFirst] = "RenameSecondToFirstHorizontalButton",
        [KeyAction.CurrentMistake]                     = "MistakeButton"
			}
    };

        private void InitializeComponents()
        {
            ClientSize = new System.Drawing.Size(420, 315);
            FormBorderStyle = FormBorderStyle.Sizable;
            StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            MaximizeBox = false;
            MinimizeBox = false;

            Resources.Help.Bind(this, Resources.Help.HotKeys);

            m_toolTip = new ToolTip();
            m_toolTip.ShowAlways = true;

            TableLayoutPanel mainTableLayoutPanel = InitFactory.Layout.Create(1, 2, 5);
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            Controls.Add(mainTableLayoutPanel);

            KeyAction[] actions = HotKeyOptions.AvailableActions();
            int count = actions.Length;

            TableLayoutPanel hotKeysTableLayoutPanel = InitFactory.Layout.Create(4, count, 5);
            //hotKeysTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;                       
            hotKeysTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
            hotKeysTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            hotKeysTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20)); 
            hotKeysTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            hotKeysTableLayoutPanel.AutoScroll = true;

            mainTableLayoutPanel.Controls.Add(hotKeysTableLayoutPanel, 0, 0);

            for (int i = 0; i < count; ++i) {
              KeyAction action = actions[i];

                HotKeyItem item = new();

                item.Check = new CheckBox();
                item.Check.Location = new System.Drawing.Point(0, 0);
                item.Check.Size = new System.Drawing.Size(20, 20);
                item.Check.Tag = action;
                item.Check.Click += new EventHandler(OnCheckBoxClick);
                hotKeysTableLayoutPanel.Controls.Add(item.Check, 0, i);

                item.Edit = new TextBox();
                item.Edit.Location = new System.Drawing.Point(0, 0);
                item.Edit.ReadOnly = true;
                item.Edit.Multiline = false;
                item.Edit.KeyDown += new KeyEventHandler(OnTextBoxKeyDown);
                item.Edit.Tag = action;
                hotKeysTableLayoutPanel.Controls.Add(item.Edit, 1, i);
                
                item.Icon = new PictureBox();
                item.Icon.Location = new System.Drawing.Point(0, 0);
                item.Icon.Size = new System.Drawing.Size(20, 20);
                item.Icon.SizeMode = PictureBoxSizeMode.Zoom;

                item.Icon.Image = Resources.Images.Get(Icons.GetValueOrDefault(m_options.resultsOptions.viewMode).GetValueOrDefault(action));

                hotKeysTableLayoutPanel.Controls.Add(item.Icon, 2, i);    

                item.Text = new Label();
                item.Text.Location = new System.Drawing.Point(0, 0);
                item.Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                item.Text.Dock = DockStyle.Fill;
                item.Text.MinimumSize = new(20, 20);
                item.Text.MaximumSize = new(100000, 20);
                hotKeysTableLayoutPanel.Controls.Add(item.Text, 3, i);
                
                m_hotKeyItems[action] = item;
            }

            FlowLayoutPanel buttons = new();
            buttons.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            buttons.AutoSize = true;
            mainTableLayoutPanel.Controls.Add(buttons, 0, 1);

            m_okButton = new Button();
            m_okButton.Anchor = AnchorStyles.Right;
            m_okButton.Click += new System.EventHandler(OnButtonClick);
            buttons.Controls.Add(m_okButton);

            m_cancelButton = new Button();
            m_cancelButton.Anchor = AnchorStyles.Right;
            m_cancelButton.Click += new System.EventHandler(OnButtonClick);
            buttons.Controls.Add(m_cancelButton);
            
            m_setDefaultButton = new Button();
            m_setDefaultButton.AutoSize = true;
            m_setDefaultButton.Click += new System.EventHandler(OnButtonClick);
            buttons.Controls.Add(m_setDefaultButton);
        }
        

        private void UpdateStrings()
        {
            Strings s = Resources.Strings.Current;

            Text = s.MainMenu_View_HotKeysMenuItem_Text;

            m_setDefaultButton.Text = s.SetDefaultButton_Text;
            m_okButton.Text = s.OkButton_Text;
            m_cancelButton.Text = s.CancelButton_Text;

            m_invalidHotKeyToolTipText = s.SelectHotKeysForm_InvalidHotKeyToolTipText;

            m_hotKeyItems[KeyAction.CurrentDefectDelete].Text.Text = s.ResultsPreviewDefect_DeleteButton_ToolTip_Text;
            m_hotKeyItems[KeyAction.CurrentDuplPairDeleteFirst].Text.Text = s.ResultsPreviewDuplPair_DeleteFirstButton_ToolTip_Text;
            m_hotKeyItems[KeyAction.CurrentDuplPairDeleteSecond].Text.Text = s.ResultsPreviewDuplPair_DeleteSecondButton_ToolTip_Text;
            m_hotKeyItems[KeyAction.CurrentDuplPairDeleteBoth].Text.Text = s.ResultsPreviewDuplPair_DeleteBothButton_ToolTip_Text;
            m_hotKeyItems[KeyAction.CurrentDuplPairRenameFirstToSecond].Text.Text = s.ResultsPreviewDuplPair_RenameFirstToSecondButton_ToolTip_Text;
            m_hotKeyItems[KeyAction.CurrentDuplPairRenameSecondToFirst].Text.Text = s.ResultsPreviewDuplPair_RenameSecondToFirstButton_ToolTip_Text;
            m_hotKeyItems[KeyAction.CurrentMistake].Text.Text = s.ResultsPreviewDuplPair_MistakeButton_ToolTip_Text;
            m_hotKeyItems[KeyAction.ShowNeighbours].Text.Text = s.MainMenu_View_ShowNeighbourImageMenuItem_Text;

      m_hotKeyItems[KeyAction.QuickRename].Text.Text = s.Value("menu/edit/quick_rename");
        }

		private void OnButtonClick(object sender, EventArgs e)
		{
			Button button = (Button) sender;

			if (button == m_setDefaultButton) {
				m_newHotKeyOptions.Reset();
				UpdateOptions();
				return;
			}

			if (button == m_okButton) {
        m_options.hotKeyOptions = new(m_newHotKeyOptions);
				// для обновления подсказки в меню
				Resources.Strings.Update();
			}

			Close();
		}

		private void OnCheckBoxClick(object sender, EventArgs e)
		{
			CheckBox box = (CheckBox) sender;
      KeyAction action = (KeyAction) box.Tag;
			
			if (box.Checked) {
        m_newHotKeyOptions.Reset(action);				
			} else {
        m_newHotKeyOptions.Clear(action);
			}

			UpdateOptions();
		}

		private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			TextBox box = (TextBox) sender;
      KeyAction action = (KeyAction) box.Tag;

      m_newHotKeyOptions.Bind(action, e.KeyData);

			UpdateOptions();
		}

		private void UpdateOptions()
		{
      bool optionsValid = true;
      foreach (var pair in m_hotKeyItems) {
        KeyAction action = pair.Key;
        HotKeyItem item = pair.Value;

        bool valid = m_newHotKeyOptions.IsValid(action);
        if (optionsValid && valid == false) {
          optionsValid = valid;
				}

        TextBox edit = item.Edit;
        m_toolTip.SetToolTip(edit, valid ? "" : m_invalidHotKeyToolTipText);
				edit.ForeColor = valid ? TextBox.DefaultForeColor : Color.Red;
        edit.BackColor = valid ? TextBox.DefaultBackColor : TextBox.DefaultBackColor;

        CheckBox check = item.Check;
        Keys keys = m_newHotKeyOptions.Binding(action);
        check.Checked = keys != Keys.None;
        edit.Text = keys.ToString().Replace(',', '+');
			}

      m_okButton.Enabled = optionsValid && m_newHotKeyOptions.IsEqualsTo(m_options.hotKeyOptions) == false;
			m_setDefaultButton.Enabled = m_newHotKeyOptions.IsEqualsTo(new HotKeyOptions()) == false;
		}
	}
}
