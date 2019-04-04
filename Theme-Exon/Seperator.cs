// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.ExonBlaze
{

    public class ExonBlazeSeperator : Control
{

    private bool _showText;
    public bool ShowText
    {
        get { return _showText; }
        set
        {
            _showText = value;
            Invalidate();
        }
    }

    private Color getLineColor()
    {

        int r = 0;
        int g = 0;
        int b = 0;
        Color parentBack = Parent.BackColor;

        r = parentBack.R;
        if (r - 20 < 0)
        {
            r = 0;
        }
        else
        {
            r = parentBack.R - 20;
        }

        g = parentBack.G;
        if (g - 20 < 0)
        {
            g = 0;
        }
        else
        {
            g = parentBack.G - 20;
        }

        b = parentBack.B;
        if (b - 20 < 0)
        {
            b = 0;
        }
        else
        {
            b = parentBack.B - 20;
        }

        return Color.FromArgb(r, g, b);

    }

    public ExonBlazeSeperator()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        Size = new Size(200, 15);
        Font = new Font("Segoe UI", 9);
        ForeColor = Color.WhiteSmoke;
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.Clear(Parent.BackColor);
        g.SmoothingMode = SmoothingMode.HighQuality;

        g.DrawLine(new Pen(getLineColor()), new Point(8, 7), new Point(Width - 9, 7));

        if (_showText && Text.Length > 0)
        {
            SizeF textSize = g.MeasureString(Text, Font);
            int textX = 0;
            int textY = 0;
            textX = (this.Width / 2) - Convert.ToInt32((textSize.Width / 2));
            textY = (this.Height / 2) - Convert.ToInt32((textSize.Height / 2));
            Rectangle textRect = new Rectangle(textX - 12, 0, Convert.ToInt32(textSize.Width + 20), this.Height - 1);
            g.FillRectangle(new SolidBrush(Parent.BackColor), textRect);
            g.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(textX, textY));
        }

    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(this.Width, 15);
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

}

}

