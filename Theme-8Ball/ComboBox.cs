// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.EightBall
{

    public class EightBallComboBox : ComboBox
{

    public EightBallComboBox()
    {
        DrawItem += ReplaceItem;
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        Font = new Font("Arial", 9);
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();

        DrawMode = DrawMode.OwnerDrawFixed;
        DropDownStyle = ComboBoxStyle.DropDownList;
        DoubleBuffered = true;
        ItemHeight = 20;

    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics G = e.Graphics;
        G.SmoothingMode = SmoothingMode.HighQuality;
        G.Clear(Parent.BackColor);

        int slope = 4;

        Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
        GraphicsPath mainPath = Drawing.RoundRect(mainRect, slope);
        LinearGradientBrush bgLGB = new LinearGradientBrush(mainRect, Color.FromArgb(85, 85, 85), Color.FromArgb(60, 60, 60), 90f);
        G.FillPath(bgLGB, mainPath);
        G.DrawPath(new Pen(Color.FromArgb(55, 55, 55)), mainPath);

        Point[] triangle = new Point[] {
			new Point(Width - 14, 16),
			new Point(Width - 17, 10),
			new Point(Width - 11, 10)
		};
        G.FillPolygon(Brushes.DarkGray, triangle);
        G.DrawLine(new Pen(Color.FromArgb(55, 55, 55)), new Point(Width - 25, 1), new Point(Width - 25, Height - 2));

        try
        {
            if (Items.Count > 0)
            {
                if (!(SelectedIndex == -1))
                {
                    int textY = ((this.Height - 1) / 2) - Convert.ToInt32((G.MeasureString(GetItemText(Items[SelectedIndex]), Font).Height / 2));
                    G.DrawString(GetItemText(Items[SelectedIndex]), Font, Brushes.WhiteSmoke, new Point(6, textY));
                }
                else
                {
                    int textY = ((this.Height - 1) / 2) - Convert.ToInt32((G.MeasureString(GetItemText(Items[0]), Font).Height / 2));
                    G.DrawString(GetItemText(Items[0]), Font, Brushes.WhiteSmoke, new Point(6, textY));
                }
            }
        }
        catch
        {
        }

    }

    public void ReplaceItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
    {
        e.DrawBackground();

        Graphics G = e.Graphics;
        G.SmoothingMode = SmoothingMode.HighQuality;

        Rectangle rect = new Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 1, e.Bounds.Height + 1);


        try
        {
            G.FillRectangle(new SolidBrush(Parent.BackColor), e.Bounds);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                LinearGradientBrush bgBrush = new LinearGradientBrush(rect, Color.FromArgb(170, 170, 170), Color.FromArgb(140, 140, 140), 90f);
                G.FillRectangle(bgBrush, rect);
                G.DrawString(base.GetItemText(base.Items[e.Index]), Font, Brushes.White, new Rectangle(e.Bounds.X + 6, e.Bounds.Y + 3, e.Bounds.Width, e.Bounds.Height));
                G.DrawRectangle(Pens.Silver, rect);
            }
            else
            {
                LinearGradientBrush bgLGB = new LinearGradientBrush(rect, Color.FromArgb(135, 135, 135), Color.FromArgb(110, 110, 110), 90f);
                G.FillRectangle(bgLGB, rect);
                G.DrawString(base.GetItemText(base.Items[e.Index]), Font, Brushes.DarkGray, new Rectangle(e.Bounds.X + 6, e.Bounds.Y + 3, e.Bounds.Width, e.Bounds.Height));
                G.DrawRectangle(Pens.Silver, rect);
            }

        }
        catch
        {
        }

    }

    protected override void OnSelectedItemChanged(System.EventArgs e)
    {
        base.OnSelectedItemChanged(e);
        Invalidate();
    }

}

}

