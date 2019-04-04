// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TabTop.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Preview
{
    public class PVTabControlTop : ThemedTabControl
    {
        public PVTabControlTop() : base()
        {
            ItemSize = new Size(0, 60);
            Padding = new Point(18, 0);
            Font = new Font("Trebuchet MS", 10.0F);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            try
            {
                BackColor = this.Parent.BackColor;
                G.Clear(this.Parent.BackColor);
            }
            catch (Exception ex)
            {
                G.Clear(Pal.ColDim);
            }
            G.SmoothingMode = SmoothingMode.HighQuality;

            //| Drawing the base Container
            int OffsetY = 58;
            Rectangle ContBorderRect = new Rectangle(0, OffsetY, Width - 1, Height - 1 - OffsetY);
            Rectangle ContBorderInnerRect = new Rectangle(1, OffsetY + 1, Width - 3, Height - 3 - OffsetY);
            GraphicsPath ContPath1 = D.RoundRect(ContBorderRect, 3);
            GraphicsPath ContPath2 = D.RoundRect(ContBorderInnerRect, 5);
            LinearGradientBrush ContPath2LGB = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(200, Color.Black), Color.FromArgb(60, Pal.ColDim));
            G.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), ContBorderInnerRect);
            G.DrawPath(new Pen(ContPath2LGB, 3F), ContPath2);
            G.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), ContPath1);

            for (var i = 0; i < TabCount; i++)
            {
                //| Drawinh the tabs
                Rectangle TabRectBase = GetTabRect(i);
                int ButtonOffset = 7;
                int XOFF = 2;
                Rectangle TabRect = new Rectangle(XOFF + TabRectBase.X, TabRectBase.Y, TabRectBase.Width - 1 - XOFF * 2, TabRectBase.Height - 1 - ButtonOffset);
                Rectangle TabInnerRect = new Rectangle(XOFF + TabRectBase.X + 1, TabRectBase.Y + 1, TabRectBase.Width - 3 - XOFF * 2, TabRectBase.Height - 3 - ButtonOffset);
                Rectangle TabInnerButtonRect = new Rectangle(XOFF + TabRectBase.X + 5, TabRectBase.Y + 5, TabRectBase.Width - 11 - XOFF * 2, TabRectBase.Height - 11 - ButtonOffset);

                //| Drawing the tab button's hole into the form (Whats the whole that a button goes into? There even a name for that???)
                GraphicsPath TabRectPath = D.RoundRect(TabRect, 3);
                GraphicsPath TabInnerRectPath = D.RoundRect(TabInnerRect, 5);
                LinearGradientBrush TabInnerRectPathLGB = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
                G.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), TabInnerRect);
                G.DrawPath(new Pen(TabInnerRectPathLGB, 3F), TabInnerRectPath);
                G.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), TabRectPath);

                //| Drawing the tab button
                int InnerButtonWidth = 10;
                GraphicsPath TabInnerButtonPath = D.RoundRect(TabInnerButtonRect, 4);
                GraphicsPath TabInnermostButtonPath = D.RoundRect(new Rectangle(TabInnerButtonRect.X + InnerButtonWidth, TabInnerButtonRect.Y, TabInnerButtonRect.Width - (InnerButtonWidth * 2), TabInnerButtonRect.Height), 4);
                GraphicsPath TabInnerButtonHighlightPath = D.RoundRect(new Rectangle(TabInnerButtonRect.X, TabInnerButtonRect.Y + 1, TabInnerButtonRect.Width, TabInnerButtonRect.Height - 2), 4);

                if (i == SelectedIndex)
                {
                    G.FillPath(new SolidBrush(Color.FromArgb(70, Pal.ColDim)), TabInnerButtonPath);
                    G.FillPath(new SolidBrush(Pal.ColDim), TabInnermostButtonPath);
                    G.FillPath(new SolidBrush(Color.FromArgb(50, Pal.ColDark)), TabInnermostButtonPath);
                    D.FillGradientBeam(G, Color.FromArgb(35, Color.Black), Color.FromArgb(14, Pal.ColHighest), TabInnerButtonRect, GradientAlignment.Vertical);
                    TabInnerButtonHighlightPath = D.RoundRect(new Rectangle(TabInnerButtonRect.X, TabInnerButtonRect.Y + 1, TabInnerButtonRect.Width, TabInnerButtonRect.Height - 1), 4);
                    G.DrawPath(new Pen(Color.FromArgb(100, Color.Black), 3F), TabInnerButtonHighlightPath);
                    D.DrawTextWithShadow(G, TabInnerRect, TabPages[i].Text, Font, HorizontalAlignment.Center, Color.FromArgb(200, Pal.ColHighest), Color.Black);
                }
                else
                {
                    G.FillPath(new SolidBrush(Color.FromArgb(100, Pal.ColDim)), TabInnerButtonPath);
                    G.FillPath(new SolidBrush(Pal.ColDim), TabInnermostButtonPath);
                    D.FillGradientBeam(G, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), TabInnerButtonRect, GradientAlignment.Vertical);
                    G.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), TabInnerButtonHighlightPath);
                    D.DrawTextWithShadow(G, TabInnerRect, TabPages[i].Text, Font, HorizontalAlignment.Center, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);
                }

                G.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), TabInnerButtonHighlightPath);
                D.DrawTextWithShadow(G, TabInnerRect, Text, Font, HorizontalAlignment.Center, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);
                G.DrawPath(Pens.Black, TabInnerButtonPath);

                //| Changes the tab's BG color to match the surroundings.
                try
                {
                    Color ParentCol = this.Parent.BackColor;
                    Color MixCol = Pal.ColDark;
                    MixCol = Color.FromArgb((int)((MixCol.R + ParentCol.R) / 2.0), (int)((MixCol.G + ParentCol.G) / 2.0), (int)((MixCol.B + ParentCol.B) / 2.0));
                    TabPages[i].BackColor = MixCol;
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
