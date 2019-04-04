// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Redemption
{
    public class RedemptionTabControl : TabControl
    {

        public enum HorizontalAlignments
        {
            Left,
            Center,
            Right
        }
        private HorizontalAlignments _Align = HorizontalAlignments.Left;
        public HorizontalAlignments TextAlign
        {
            get { return _Align; }
            set
            {
                _Align = value;
                Invalidate();
            }
        }
        private bool _BackgrounNoise;
        public bool BackgroundNoise
        {
            get { return _BackgrounNoise; }
            set
            {
                _BackgrounNoise = value;
                Invalidate();
            }
        }

        public RedemptionTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            BackColor = Color.Transparent;
            ItemSize = new Size(35, 100);
            Font = new Font("Arial", 8.25f, FontStyle.Bold);
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            int Curve = 6;
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.SmoothingMode = SmoothingMode.HighQuality;
            try
            {
                SelectedTab.BackColor = Color.FromArgb(47, 48, 52);
            }
            catch
            {
            }
            G.Clear(Color.FromArgb(51, 56, 60));
            if (BackgroundNoise)
            {
                TextureBrush MatteNoise = Draw.TiledTextureFromCode("iVBORw0KGgoAAAANSUhEUgAAAEYAAABGCAIAAAD+THXTAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA2ZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDo1OEU1MkNDNjNCQjBFMjExQjY2NkFFNERBQzEzREJERiIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDpGQTIzMjhDQUIwM0IxMUUyOEY4NDk4NjlBRTkxQzE1QyIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDpGQTIzMjhDOUIwM0IxMUUyOEY4NDk4NjlBRTkxQzE1QyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChXaW5kb3dzKSI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjU4RTUyQ0M2M0JCMEUyMTFCNjY2QUU0REFDMTNEQkRGIiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjU4RTUyQ0M2M0JCMEUyMTFCNjY2QUU0REFDMTNEQkRGIi8+IDwvcmRmOkRlc2NyaXB0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");
                G.FillRectangle(MatteNoise, new Rectangle(-1, -1, Width + 3, Height + 3));
                G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), new Rectangle(-1, -1, Width + 3, Height + 3));
            }
            G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(ItemSize.Height - 1, 0, Width - ItemSize.Height - 1 - 1, Height - 1), Curve));
            Color[] GradientPen = {
            Color.FromArgb(43, 44, 48),
            Color.FromArgb(44, 45, 49),
            Color.FromArgb(45, 46, 50),
            Color.FromArgb(46, 47, 51),
            Color.FromArgb(47, 48, 52),
            Color.FromArgb(48, 49, 53)
        };
            for (int i = 0; i <= 5; i++)
            {
                G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(ItemSize.Height - 1 + i + 1, i + 1, Width - ItemSize.Height - 1 - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
            }
            LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
            G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(ItemSize.Height - 1, 0, Width - ItemSize.Height - 1 - 1, Height - 1), Curve));
            G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(ItemSize.Height - 1, 0, Width - ItemSize.Height - 1 - 1, Height - 2), Curve));

            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    Rectangle OuterBorder = new Rectangle(new Point(GetTabRect(i).Location.X - 1, GetTabRect(i).Location.Y + 3), new Size(GetTabRect(i).Width - 7, GetTabRect(i).Height - 7));
                    Rectangle InnerBorder = new Rectangle(new Point(GetTabRect(i).Location.X - 1, GetTabRect(i).Location.Y + 4), new Size(GetTabRect(i).Width - 7, GetTabRect(i).Height - 8));
                    LinearGradientBrush MainBody = new LinearGradientBrush(OuterBorder, Color.FromArgb(72, 79, 87), Color.FromArgb(48, 51, 56), 90);
                    G.FillPath(MainBody, Draw.RoundRect(OuterBorder, Curve));
                    LinearGradientBrush GlossPen = new LinearGradientBrush(OuterBorder, Color.FromArgb(119, 124, 130), Color.FromArgb(64, 67, 72), 90);
                    G.DrawPath(new Pen(GlossPen), Draw.RoundRect(InnerBorder, Curve));
                    G.DrawPath(new Pen(Color.FromArgb(31, 36, 42)), Draw.RoundRect(OuterBorder, Curve));
                }

                switch (TextAlign)
                {
                    case HorizontalAlignments.Center:
                        Rectangle TextRectangle = new Rectangle(new Point(GetTabRect(i).Location.X - 4, GetTabRect(i).Location.Y + 4), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
                        Rectangle TextShadow = new Rectangle(new Point(GetTabRect(i).Location.X - 3, GetTabRect(i).Location.Y + 5), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
                        G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.FromArgb(150, Color.Black)), TextShadow, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                        G.DrawString(TabPages[i].Text, Font, Brushes.White, TextRectangle, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                        break;
                    case HorizontalAlignments.Left:
                        Rectangle TextRectangle1 = new Rectangle(new Point(GetTabRect(i).Location.X + 5, GetTabRect(i).Location.Y + 4), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
                        Rectangle TextShadow1 = new Rectangle(new Point(GetTabRect(i).Location.X + 6, GetTabRect(i).Location.Y + 5), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
                        G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.FromArgb(150, Color.Black)), TextShadow1, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        });
                        G.DrawString(TabPages[i].Text, Font, Brushes.White, TextRectangle1, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        });
                        break;
                    case HorizontalAlignments.Right:
                        Rectangle TextRectangle2 = new Rectangle(new Point(GetTabRect(i).Location.X - 9, GetTabRect(i).Location.Y + 4), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
                        Rectangle TextShadow2 = new Rectangle(new Point(GetTabRect(i).Location.X - 8, GetTabRect(i).Location.Y + 5), new Size(GetTabRect(i).Width - 1, GetTabRect(i).Height - 7));
                        G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.FromArgb(150, Color.Black)), TextShadow2, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Far
                        });
                        G.DrawString(TabPages[i].Text, Font, Brushes.White, TextRectangle2, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Far
                        });
                        break;
                }
            }
            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


}

