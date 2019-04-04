// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="TabControl.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Avira
{
    public class AviraTabControl : TabControl
    {

        //Background Color
        private Color BC = Color.FromArgb(73, 73, 73);
        //Selected Tab Gradient Color Top
        private Color SLGT = Color.FromArgb(255, 255, 255);
        //Selected Tab Gradient Color Bottom
        private Color SLGB = Color.FromArgb(200, 200, 200);
        //Selected Tab Line Color Top
        private Pen SLLT = new Pen(Color.FromArgb(165, 165, 165));
        //Selected Tab Line Color Bottom
        private Pen SLLB = new Pen(Color.FromArgb(98, 98, 98));
        //Header Text Color
        private SolidBrush TC = new SolidBrush(Color.FromArgb(180, 180, 180));
        //Unselected Tab Font Color
        private Brush UTC = Brushes.White;
        //Selected Tab Font Color
        private Brush STC = Brushes.Black;

        private SolidBrush BCB;
        private Pen BCP;
        private Rectangle TR;
        private Rectangle InTR;
        private Rectangle InR;
        private Rectangle LR;
        private Rectangle ImR;
        private StringFormat SF = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };
        private StringFormat SFHeader = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Far
        };
        private int ICounter = 0;
        private LinearGradientBrush SLGBr;
        private SolidBrush TSB;

        private int TROffset = 1;
        public AviraTabControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
            SetStyle(ControlStyles.Selectable, false);
            SizeMode = TabSizeMode.Fixed;
            Alignment = TabAlignment.Left;
            ItemSize = new Size(21, 180);
            DrawMode = TabDrawMode.OwnerDrawFixed;
            Font = new Font("Verdana", 8);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            BCB = new SolidBrush(BC);
            BCP = new Pen(BC);
            Graphics g = e.Graphics;

            if (!(SelectedIndex == null) && !(SelectedIndex == -1) && !(SelectedIndex > TabPages.Count - 1) && !(TabPages[SelectedIndex].BackColor == Color.Transparent))
            {
                g.Clear(TabPages[SelectedIndex].BackColor);
            }
            else
            {
                g.Clear(Color.White);
            }
            ICounter = 0;
            LR = new Rectangle(0, 0, ItemSize.Height + 3, Height);
            g.FillRectangle(BCB, LR);
            g.DrawRectangle(BCP, LR);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i <= TabCount - 1; i++)
            {
                TR = GetTabRect(i);
                TR = new Rectangle(TR.X, TR.Y, TR.Width - 1, TR.Height);
                if (TabPages[i].Tag != null && !object.ReferenceEquals(TabPages[i].Tag, string.Empty))
                {
                    InR = new Rectangle(TR.X + 10, TR.Y, TR.Width - 10, TR.Height);
                    g.DrawString(TabPages[i].Text.ToUpper(), Font, TC, InR, SFHeader);
                    ICounter += 1;
                }
                else
                {
                    if (i == SelectedIndex)
                    {
                        SLGBr = new LinearGradientBrush(TR, SLGT, SLGB, 90);
                        InR = new Rectangle(TR.X + 36, TR.Y, TR.Width - 36, TR.Height);
                        InTR = new Rectangle(TR.X, TR.Y + TROffset, TR.Width, TR.Height - (2 * TROffset));

                        g.FillRectangle(SLGBr, InTR);
                        g.DrawLine(SLLT, TR.X, TR.Y + TROffset, TR.X + TR.Width - 1, TR.Y + TROffset);
                        g.DrawLine(SLLB, TR.X, TR.Y + TR.Height - TROffset, TR.X + TR.Width - 1, TR.Y + TR.Height - TROffset);
                        g.DrawString(TabPages[i].Text, Font, STC, InR, SF);

                        if (SelectedImageList != null && SelectedImageList.Images.Count > i - ICounter && SelectedImageList.Images[i - ICounter] != null)
                        {
                            ImR = new Rectangle(TR.X + 13, TR.Y + ((TR.Height / 2) - 8), 16, 16);
                            g.DrawImage(SelectedImageList.Images[i - ICounter], ImR);
                        }

                    }
                    else
                    {
                        InR = new Rectangle(TR.X + 36, TR.Y, TR.Width - 36, TR.Height);
                        g.DrawString(TabPages[i].Text, Font, UTC, InR, SF);

                        if (UnselectedImageList != null && UnselectedImageList.Images.Count > i - ICounter && UnselectedImageList.Images[i - ICounter] != null)
                        {
                            ImR = new Rectangle(TR.X + 13, TR.Y + ((TR.Height / 2) - 8), 16, 16);
                            g.DrawImage(UnselectedImageList.Images[i - ICounter], ImR);
                        }

                    }
                }
            }


            g.Dispose();

        }

        private ImageList UnselectedImageList;
        public ImageList ImageList_Unselected
        {
            get { return UnselectedImageList; }
            set
            {
                UnselectedImageList = value;
                if (UnselectedImageList != null && !(UnselectedImageList.ImageSize == new Size(16, 16)))
                {
                    UnselectedImageList.ImageSize = new Size(16, 16);
                }
                Invalidate();
            }
        }

        private ImageList SelectedImageList;
        public ImageList ImageList_Selected
        {
            get { return SelectedImageList; }
            set
            {
                SelectedImageList = value;
                if (SelectedImageList != null && !(SelectedImageList.ImageSize == new Size(16, 16)))
                {
                    SelectedImageList.ImageSize = new Size(16, 16);
                }
                Invalidate();
            }
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);
            if (e.TabPage != null && e.TabPage.Tag != null && !object.ReferenceEquals(e.TabPage.Tag, string.Empty) && !DesignMode)
            {
                e.Cancel = true;
            }
        }

    }

}
