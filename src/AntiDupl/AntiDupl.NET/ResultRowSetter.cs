/*
* AntiDupl.NET Program (http://ermig1979.github.io/AntiDupl).
*
* Copyright (c) 2002-2018 Yermalayeu Ihar, 2013-2018 Borisov Dmitry.
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
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using H = AntiDupl.NET.ResultsListView.ColumnsTypeHorizontal;
using V = AntiDupl.NET.ResultsListView.ColumnsTypeVertical;

namespace AntiDupl.NET
{
    /// <summary>
    /// Set table of out defect and dublicate pair.
    /// Установка таблицы вывода дефектов и дубликатов.
    /// </summary>
    public class ResultRowSetter
    {
        private AntiDupl.NET.Options m_options;
        private DataGridView m_dataGridView;

        private Image m_nullIcon;

        private Image m_defectIcon;
        
        private Image m_duplPairVerticalIcon;
        private Image m_duplPairHorizontalIcon;

        private Image m_unknownDefectIcon;
        private Image m_jpegEndMarkerIsAbsentIcon;
        private Image m_blockinessIcon;
        private Image m_blurringIcon;

        private Image m_deleteDefectIcon;
        private Image m_deleteFirstVerticalIcon;
        private Image m_deleteFirstHorizontalIcon;
        private Image m_deleteSecondVerticalIcon;
        private Image m_deleteSecondHorizontalIcon;
        private Image m_renameFirstToSecondVerticalIcon;
        private Image m_renameFirstToSecondHorizontalIcon;
        private Image m_renameSecondToFirstVerticalIcon;
        private Image m_renameSecondToFirstHorizontalIcon;

        private Image m_turn_0_Icon;
        private Image m_turn_90_Icon;
        private Image m_turn_180_Icon;
        private Image m_turn_270_Icon;
        private Image m_mirrorTurn_0_Icon;
        private Image m_mirrorTurn_90_Icon;
        private Image m_mirrorTurn_180_Icon;
        private Image m_mirrorTurn_270_Icon;

        private string m_defectIconToolTipText;
        private string m_duplPairIconToolTipText;

        private string m_unknownDefectIconToolTipText;
        private string m_jpegEndMarkerIsAbsentIconToolTipText;
        private string m_blockinessIconToolTipText;
        private string m_blurringIconToolTipText;

        private string m_deleteDefectIconToolTipText;
        private string m_deleteFirstIconToolTipText;
        private string m_deleteSecondIconToolTipText;
        private string m_renameFirstToSecondIconToolTipText;
        private string m_renameSecondToFirstIconToolTipText;

        private string m_turn_0_IconToolTipText;
        private string m_turn_90_IconToolTipText;
        private string m_turn_180_IconToolTipText;
        private string m_turn_270_IconToolTipText;
        private string m_mirrorTurn_0_IconToolTipText;
        private string m_mirrorTurn_90_IconToolTipText;
        private string m_mirrorTurn_180_IconToolTipText;
        private string m_mirrorTurn_270_IconToolTipText;

        public ResultRowSetter(AntiDupl.NET.Options options, DataGridView dataGridView)
        {
            m_options = options;
            m_dataGridView = dataGridView;
            InitializeImages();
            UpdateStrings();
            Resources.Strings.OnCurrentChange += new Resources.Strings.CurrentChangeHandler(UpdateStrings);
        }
        
        private void InitializeImages()
        {
            m_nullIcon = Resources.Images.GetNullImage();

            m_defectIcon = Resources.Images.Get("DefectIcon");
            m_duplPairVerticalIcon = Resources.Images.Get("DuplPairVerticalIcon");
            m_duplPairHorizontalIcon = Resources.Images.Get("DuplPairHorizontalIcon");

            m_unknownDefectIcon = Resources.Images.Get("UnknownDefectIcon");
            m_jpegEndMarkerIsAbsentIcon = Resources.Images.Get("JpegEndMarkerIsAbsentIcon");
            m_blockinessIcon = Resources.Images.Get("BlockinessIcon");
            m_blurringIcon = Resources.Images.Get("BlurringIcon");

            m_deleteDefectIcon = Resources.Images.Get("DeleteDefectIcon");
            m_deleteFirstVerticalIcon = Resources.Images.Get("DeleteFirstVerticalIcon");
            m_deleteFirstHorizontalIcon = Resources.Images.Get("DeleteFirstHorizontalIcon");
            m_deleteSecondVerticalIcon = Resources.Images.Get("DeleteSecondVerticalIcon");
            m_deleteSecondHorizontalIcon = Resources.Images.Get("DeleteSecondHorizontalIcon");
            m_renameFirstToSecondVerticalIcon = Resources.Images.Get("RenameFirstToSecondVerticalIcon");
            m_renameFirstToSecondHorizontalIcon = Resources.Images.Get("RenameFirstToSecondHorizontalIcon");
            m_renameSecondToFirstVerticalIcon = Resources.Images.Get("RenameSecondToFirstVerticalIcon");
            m_renameSecondToFirstHorizontalIcon = Resources.Images.Get("RenameSecondToFirstHorizontalIcon");

            m_turn_0_Icon = Resources.Images.Get("Turn_0_Icon");
            m_turn_90_Icon = Resources.Images.Get("Turn_90_Icon");
            m_turn_180_Icon = Resources.Images.Get("Turn_180_Icon");
            m_turn_270_Icon = Resources.Images.Get("Turn_270_Icon");
            m_mirrorTurn_0_Icon = Resources.Images.Get("MirrorTurn_0_Icon");
            m_mirrorTurn_90_Icon = Resources.Images.Get("MirrorTurn_90_Icon");
            m_mirrorTurn_180_Icon = Resources.Images.Get("MirrorTurn_180_Icon");
            m_mirrorTurn_270_Icon = Resources.Images.Get("MirrorTurn_270_Icon");
        }

        private void UpdateStrings()
        {
            Strings s = Resources.Strings.Current;

            m_defectIconToolTipText = s.ResultRowSetter_DefectIcon_ToolTip_Text;
            m_duplPairIconToolTipText = s.ResultRowSetter_DuplPairIcon_ToolTip_Text;

            m_unknownDefectIconToolTipText = s.ResultRowSetter_UnknownDefectIcon_ToolTip_Text;
            m_jpegEndMarkerIsAbsentIconToolTipText = s.ResultRowSetter_JpegEndMarkerIsAbsentIcon_ToolTip_Text;
            m_blockinessIconToolTipText = s.ResultRowSetter_blockinessIcon_ToolTip_Text;
            m_blurringIconToolTipText = s.ResultRowSetter_blurringIcon_ToolTip_Text;

            m_deleteDefectIconToolTipText = s.ResultRowSetter_DeleteDefectIcon_ToolTip_Text;
            m_deleteFirstIconToolTipText = s.ResultRowSetter_DeleteFirstIcon_ToolTip_Text;
            m_deleteSecondIconToolTipText = s.ResultRowSetter_DeleteSecondIcon_ToolTip_Text;
            m_renameFirstToSecondIconToolTipText = s.ResultRowSetter_RenameFirstToSecondIcon_ToolTip_Text;
            m_renameSecondToFirstIconToolTipText = s.ResultRowSetter_RenameSecondToFirstIcon_ToolTip_Text;

            m_turn_0_IconToolTipText = s.ResultRowSetter_Turn_0_Icon_ToolTip_Text;
            m_turn_90_IconToolTipText = s.ResultRowSetter_Turn_90_Icon_ToolTip_Text;
            m_turn_180_IconToolTipText = s.ResultRowSetter_Turn_180_Icon_ToolTip_Text;
            m_turn_270_IconToolTipText = s.ResultRowSetter_Turn_270_Icon_ToolTip_Text;
            m_mirrorTurn_0_IconToolTipText = s.ResultRowSetter_MirrorTurn_0_Icon_ToolTip_Text;
            m_mirrorTurn_90_IconToolTipText = s.ResultRowSetter_MirrorTurn_90_Icon_ToolTip_Text;
            m_mirrorTurn_180_IconToolTipText = s.ResultRowSetter_MirrorTurn_180_Icon_ToolTip_Text;
            m_mirrorTurn_270_IconToolTipText = s.ResultRowSetter_MirrorTurn_270_Icon_ToolTip_Text;
        }

		public void Set(CoreResult result, DataGridViewCustomRow row)
		{
			switch (result.type) {
				case CoreDll.ResultType.DefectImage:
					SetDefectToRow(row.Cells, result);
					break;

				case CoreDll.ResultType.DuplImagePair:
					SetDuplPairToRow(row.Cells, result);
					break;
			}
		}

		private void SetDefectToRow(DataGridViewCellCollection cells, CoreResult result)
        {
            cells[(int) H.Type] = new DataGridViewImageCell();
            cells[(int) H.Type].Value = m_defectIcon;
            cells[(int) H.Type].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cells[(int) H.Type].ToolTipText = m_defectIconToolTipText;

            cells[(int) H.Group] = new DataGridViewTextBoxCell();
            cells[(int) H.Group].Value = (result.group == -1 ? "" : result.group.ToString());
            cells[(int) H.Group].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            cells[(int) H.GroupSize] = new DataGridViewTextBoxCell();
            cells[(int) H.GroupSize].Value = (result.groupSize == -1 ? "" : result.groupSize.ToString());
            cells[(int) H.GroupSize].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            cells[(int) H.Difference].Value = "";

            cells[(int) H.Defect] = new DataGridViewImageCell();
            cells[(int) H.Defect].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            switch (result.defect)
            {
                case CoreDll.DefectType.None:
                    cells[(int) H.Defect].Value = m_nullIcon;
                    break;
                case CoreDll.DefectType.Unknown:
                    cells[(int) H.Defect].Value = m_unknownDefectIcon;
                    cells[(int) H.Defect].ToolTipText = m_unknownDefectIconToolTipText;
                    break;
                case CoreDll.DefectType.JpegEndMarkerIsAbsent:
                    cells[(int) H.Defect].Value = m_jpegEndMarkerIsAbsentIcon;
                    cells[(int) H.Defect].ToolTipText = m_jpegEndMarkerIsAbsentIconToolTipText;
                    break;
                case CoreDll.DefectType.Blockiness:
                    cells[(int) H.Defect].Value = m_blockinessIcon;
                    cells[(int) H.Defect].ToolTipText = m_blockinessIconToolTipText;
                    break;
                case CoreDll.DefectType.Blurring:
                    cells[(int) H.Defect].Value = m_blurringIcon;
                    cells[(int) H.Defect].ToolTipText = m_blurringIconToolTipText;
                    break;
            }

            cells[(int) H.Transform] = new DataGridViewTextBoxCell();
            cells[(int) H.Transform].Value = "";

            cells[(int) H.Hint] = new DataGridViewImageCell();
            cells[(int) H.Hint].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            switch (result.hint)
            {
                case CoreDll.HintType.DeleteFirst:
                    cells[(int) H.Hint].Value = m_deleteDefectIcon;
                    cells[(int) H.Hint].ToolTipText = m_deleteDefectIconToolTipText;
                    break;
                default:
                    cells[(int) H.Hint].Value = m_nullIcon;
                    break;
            } 
            
            switch (m_options.resultsOptions.viewMode)
            {
                case ResultsOptions.ViewMode.VerticalPairTable:
                    SetDefectToRowVertical(cells, result);
                    break;
                case ResultsOptions.ViewMode.HorizontalPairTable:
                    SetDefectToRowHorizontal(cells, result);
                    break;
            }
        }

        /// <summary>
        /// Set cell defect in vertical mode.
        /// Установка яйчейки дефектов в вертикальном режиме.
        /// </summary>
        private void SetDefectToRowVertical(DataGridViewCellCollection cells, CoreResult result)
        {
            for (int col = (int) V.FileName; col < (int) V.Size; col++)
                cells[col] = new DataGridViewTextBoxCell();
            cells[(int) V.FileName].Value = Path.GetFileName(result.first.path);
            cells[(int) V.FileDirectory].Value = result.first.GetDirectoryString();
            cells[(int) V.ImageSize].Value = result.first.GetImageSizeString();
            cells[(int) V.ImageType].Value = result.first.GetImageTypeString();

            cells[(int) V.Blockiness].Value = result.first.GetBlockinessString();
            cells[(int) V.Blockiness].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            cells[(int) V.Blurring].Value = result.first.GetBlurringString();
            cells[(int) V.Blurring].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            cells[(int) V.FileSize].Value = result.first.GetFileSizeString();
            cells[(int) V.FileSize].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            cells[(int) V.FileTime].Value = result.first.GetFileTimeString();
        }

        /// <summary>
        /// Set cell defect in horizontal mode.
        /// Установка яйчейки дефектов в горизонтальном режиме.
        /// </summary>
        private void SetDefectToRowHorizontal(DataGridViewCellCollection cells, CoreResult result)
        {
            for (int col = (int) H.FirstFileName; col < (int) H.Size; col++)
                cells[col] = new DataGridViewTextBoxCell();
            cells[(int) H.FirstFileName].Value = Path.GetFileName(result.first.path);
            cells[(int) H.FirstFileDirectory].Value = result.first.GetDirectoryString();
            cells[(int) H.FirstImageSize].Value = result.first.GetImageSizeString();
            cells[(int) H.FirstImageType].Value = result.first.GetImageTypeString();
            cells[(int) H.FirstBlockiness].Value = result.first.GetBlockinessString();
            cells[(int) H.FirstBlockiness].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            cells[(int) H.FirstBlurring].Value = result.first.GetBlurringString();
            cells[(int) H.FirstBlurring].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            cells[(int) H.FirstFileSize].Value = result.first.GetFileSizeString();
            cells[(int) H.FirstFileSize].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            cells[(int) H.FirstFileTime].Value = result.first.GetFileTimeString();
            
            cells[(int) H.SecondFileName].Value = "";
            cells[(int) H.SecondFileDirectory].Value = "";
            cells[(int) H.SecondImageSize].Value = "";
            cells[(int) H.SecondImageType].Value = "";
            cells[(int) H.SecondFileSize].Value = "";
            cells[(int) H.SecondFileTime].Value = "";
        }

        private void SetDuplPairToRow(DataGridViewCellCollection cells, CoreResult result)
        {
            cells[(int) H.Type] = new DataGridViewImageCell();
            cells[(int) H.Type].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cells[(int) H.Type].ToolTipText = m_duplPairIconToolTipText;

            cells[(int) H.Group] = new DataGridViewTextBoxCell();
            cells[(int) H.Group].Value = (result.group == -1 ? "" : result.group.ToString());
            cells[(int) H.Group].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            cells[(int) H.GroupSize] = new DataGridViewTextBoxCell();
            cells[(int) H.GroupSize].Value = (result.groupSize == -1 ? "" : result.groupSize.ToString());
            cells[(int) H.GroupSize].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            cells[(int) H.Difference] = new DataGridViewTextBoxCell();
            cells[(int) H.Difference].Value = result.difference.ToString("F2");
            cells[(int) H.Difference].Style.Font =
                new Font(DataGridView.DefaultFont, result.difference == 0 ? FontStyle.Bold : FontStyle.Regular);
            cells[(int) H.Difference].Style.ForeColor =
                result.difference == 0 ? Color.LightGreen : DataGridView.DefaultForeColor;
            cells[(int) H.Difference].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            cells[(int) H.Defect] = new DataGridViewTextBoxCell();
            cells[(int) H.Defect].Value = "";

            cells[(int) H.Transform] = new DataGridViewImageCell();
            cells[(int) H.Transform].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            switch (result.transform)
            {
                case CoreDll.TransformType.Turn_0:
                    cells[(int) H.Transform].Value = m_turn_0_Icon;
                    cells[(int) H.Transform].ToolTipText = m_turn_0_IconToolTipText;
                    break;
                case CoreDll.TransformType.Turn_90:
                    cells[(int) H.Transform].Value = m_turn_90_Icon;
                    cells[(int) H.Transform].ToolTipText = m_turn_90_IconToolTipText;
                    break;
                case CoreDll.TransformType.Turn_180:
                    cells[(int) H.Transform].Value = m_turn_180_Icon;
                    cells[(int) H.Transform].ToolTipText = m_turn_180_IconToolTipText;
                    break;
                case CoreDll.TransformType.Turn_270:
                    cells[(int) H.Transform].Value = m_turn_270_Icon;
                    cells[(int) H.Transform].ToolTipText = m_turn_270_IconToolTipText;
                    break;
                case CoreDll.TransformType.MirrorTurn_0:
                    cells[(int) H.Transform].Value = m_mirrorTurn_0_Icon;
                    cells[(int) H.Transform].ToolTipText = m_mirrorTurn_0_IconToolTipText;
                    break;
                case CoreDll.TransformType.MirrorTurn_90:
                    cells[(int) H.Transform].Value = m_mirrorTurn_90_Icon;
                    cells[(int) H.Transform].ToolTipText = m_mirrorTurn_90_IconToolTipText;
                    break;
                case CoreDll.TransformType.MirrorTurn_180:
                    cells[(int) H.Transform].Value = m_mirrorTurn_180_Icon;
                    cells[(int) H.Transform].ToolTipText = m_mirrorTurn_180_IconToolTipText;
                    break;
                case CoreDll.TransformType.MirrorTurn_270:
                    cells[(int) H.Transform].Value = m_mirrorTurn_270_Icon;
                    cells[(int) H.Transform].ToolTipText = m_mirrorTurn_270_IconToolTipText;
                    break;
            }

            cells[(int) V.Hint] = new DataGridViewImageCell();
            cells[(int) V.Hint].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            switch (result.hint)
            {
                case CoreDll.HintType.DeleteFirst:
                    cells[(int) V.Hint].ToolTipText = m_deleteFirstIconToolTipText;
                    break;
                case CoreDll.HintType.DeleteSecond:
                    cells[(int) V.Hint].ToolTipText = m_deleteSecondIconToolTipText;
                    break;
                case CoreDll.HintType.RenameFirstToSecond:
                    cells[(int) V.Hint].ToolTipText = m_renameFirstToSecondIconToolTipText;
                    break;
                case CoreDll.HintType.RenameSecondToFirst:
                    cells[(int) V.Hint].ToolTipText = m_renameSecondToFirstIconToolTipText;
                    break;
                default:
                    cells[(int) V.Hint].Value = m_nullIcon;
                    cells[(int) V.Hint].ToolTipText = "";
                    break;
            }

            switch (m_options.resultsOptions.viewMode)
            {
                case ResultsOptions.ViewMode.VerticalPairTable:
                    SetDuplicatePairToRowVertical(cells, result);
                    break;
                case ResultsOptions.ViewMode.HorizontalPairTable:
                    SetDuplPairToRowHorizontal(cells, result);
                    break;
            }
        }

		private void SetDuplicatePairToRowVertical(DataGridViewCellCollection cells, CoreResult result)
		{
      cells[(int) V.Type].Value = m_duplPairVerticalIcon;

			switch (result.hint) {
				case CoreDll.HintType.DeleteFirst:
					cells[(int) V.Hint].Value = m_deleteFirstVerticalIcon;
					break;
				case CoreDll.HintType.DeleteSecond:
					cells[(int) V.Hint].Value = m_deleteSecondVerticalIcon;
					break;
				case CoreDll.HintType.RenameFirstToSecond:
					cells[(int) V.Hint].Value = m_renameFirstToSecondVerticalIcon;
					break;
				case CoreDll.HintType.RenameSecondToFirst:
					cells[(int) V.Hint].Value = m_renameSecondToFirstVerticalIcon;
					break;
			}

      CoreImageInfo first = result.first;
			CoreImageInfo second = result.second;
      Highlight hl = new(first, second, Color.Empty);

			cells[(int) V.FileName] = new DataGridViewDoubleTextBoxCell(Path.GetFileName(first.path), Path.GetFileName(second.path));

			cells[(int) V.FileDirectory] = new DataGridViewDoubleTextBoxCell(first.GetDirectoryString(), second.GetDirectoryString());

			cells[(int) V.ImageSize] = new DataGridViewDoubleTextBoxCell(first.GetImageSizeString(), second.GetImageSizeString()) {
				FirstColor = hl.ImageDimension(),
				SecondColor = hl.ImageDimension(true)
			};

			cells[(int) V.ImageType] = new DataGridViewDoubleTextBoxCell(first.GetImageTypeString(), second.GetImageTypeString()) {
				FirstColor = hl.ImageType(),
				SecondColor = hl.ImageType(true)
			};

			cells[(int) V.FileSize] = new DataGridViewDoubleTextBoxCell(first.GetFileSizeString(), second.GetFileSizeString()) {
				FirstColor = hl.ImageSize(),
				SecondColor = hl.ImageSize(true),
				Alignment = DataGridViewContentAlignment.MiddleRight
			};

			cells[(int) V.Blockiness] = new DataGridViewDoubleTextBoxCell(first.GetBlockinessString(), second.GetBlockinessString()) {
				FirstColor = hl.ImageBlockiness(),
				SecondColor = hl.ImageBlockiness(true),
				Alignment = DataGridViewContentAlignment.MiddleRight
			};

			cells[(int) V.Blurring] = new DataGridViewDoubleTextBoxCell(first.GetBlurringString(), second.GetBlurringString()) {
				FirstColor = hl.ImageBlurring(),
				SecondColor = hl.ImageBlurring(true),
				Alignment = DataGridViewContentAlignment.MiddleRight
			};

			cells[(int) V.FileTime] = new DataGridViewDoubleTextBoxCell(first.GetFileTimeString(), second.GetFileTimeString());
		}

		    private void SetDuplPairToRowHorizontal(DataGridViewCellCollection cells, CoreResult result)
        {
          CoreImageInfo first = result.first;
          CoreImageInfo second = result.second;

            cells[(int) H.Type].Value = m_duplPairHorizontalIcon;

            switch (result.hint)
            {
                case CoreDll.HintType.DeleteFirst:
                    cells[(int) H.Hint].Value = m_deleteFirstHorizontalIcon;
                    break;
                case CoreDll.HintType.DeleteSecond:
                    cells[(int) H.Hint].Value = m_deleteSecondHorizontalIcon;
                    break;
                case CoreDll.HintType.RenameFirstToSecond:
                    cells[(int) H.Hint].Value = m_renameFirstToSecondHorizontalIcon;
                    break;
                case CoreDll.HintType.RenameSecondToFirst:
                    cells[(int) H.Hint].Value = m_renameSecondToFirstHorizontalIcon;
                    break;
            }

            for (int col = (int) H.FirstFileName; col < (int) H.Size; col++)
                cells[col] = new DataGridViewTextBoxCell();

            cells[(int) H.FirstFileName].Value = Path.GetFileName(first.path);

            cells[(int) H.FirstFileDirectory].Value = first.GetDirectoryString();

            cells[(int) H.FirstImageSize].Value = first.GetImageSizeString();

            cells[(int) H.FirstImageType].Value = first.GetImageTypeString();

            cells[(int) H.FirstBlockiness].Value = first.GetBlockinessString();
            cells[(int) H.FirstBlockiness].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            cells[(int) H.FirstBlurring].Value = first.GetBlurringString();
            cells[(int) H.FirstBlurring].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            cells[(int) H.FirstFileSize].Value = first.GetFileSizeString();
            cells[(int) H.FirstFileSize].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            cells[(int) H.FirstFileTime].Value = first.GetFileTimeString();

            cells[(int) H.SecondFileName].Value = Path.GetFileName(second.path);

            cells[(int) H.SecondFileDirectory].Value = second.GetDirectoryString();

            cells[(int) H.SecondImageSize].Value = second.GetImageSizeString();

            cells[(int) H.SecondImageType].Value = second.GetImageTypeString();

            cells[(int) H.SecondBlockiness].Value = second.GetBlockinessString();

            cells[(int) H.SecondBlockiness].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            cells[(int) H.SecondBlurring].Value = second.GetBlurringString();

            cells[(int) H.SecondBlurring].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            cells[(int) H.SecondFileSize].Value = second.GetFileSizeString();

            cells[(int) H.SecondFileSize].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            cells[(int) H.SecondFileTime].Value = second.GetFileTimeString();

            Highlight hl = new(first, second, m_dataGridView.DefaultCellStyle.ForeColor);

            cells[(int) H.FirstImageSize].Style.ForeColor = hl.ImageDimension();
            cells[(int) H.SecondImageSize].Style.ForeColor = hl.ImageDimension(true);

            cells[(int) H.FirstFileSize].Style.ForeColor = hl.ImageSize();
            cells[(int) H.SecondFileSize].Style.ForeColor = hl.ImageSize(true);

            cells[(int) H.FirstBlockiness].Style.ForeColor = hl.ImageBlockiness();
            cells[(int) H.SecondBlockiness].Style.ForeColor = hl.ImageBlockiness(true);

            cells[(int) H.FirstBlurring].Style.ForeColor = hl.ImageBlurring();
            cells[(int) H.SecondBlurring].Style.ForeColor = hl.ImageBlurring(true);

            cells[(int) H.FirstImageType].Style.ForeColor = hl.ImageType();
            cells[(int) H.SecondImageType].Style.ForeColor = hl.ImageType(true);
        }
    }
}
