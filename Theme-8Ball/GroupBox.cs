// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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

    public class EightBallGroupBox : ContainerControl
{

    private HorizontalAlignment _titleAlign;
    public HorizontalAlignment TitleAlignment
    {
        get { return _titleAlign; }
        set
        {
            _titleAlign = value;
            Invalidate();
        }
    }

    protected override void OnTextChanged(System.EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

    public EightBallGroupBox()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.ContainerControl, true);
        Size = new Size(300, 140);
        BackColor = Color.FromArgb(70, 70, 70);
        ForeColor = Color.WhiteSmoke;
        Font = new Font("Segoe UI", 9);
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.Clear(Parent.BackColor);
        g.SmoothingMode = SmoothingMode.HighQuality;

        int slope = 6;

        Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
        GraphicsPath mainPath = Drawing.RoundRect(mainRect, slope);
        g.FillPath(new SolidBrush(BackColor), mainPath);

        Rectangle titleRect = new Rectangle(0, 0, Width - 1, 26);
        GraphicsPath titlePath = Drawing.TopRoundRect(titleRect, slope);
        LinearGradientBrush titleBrush = new LinearGradientBrush(titleRect, Color.FromArgb(100, 100, 100), BackColor, 90f);
        g.FillPath(titleBrush, titlePath);

        int textX = 0;
        if (_titleAlign == HorizontalAlignment.Left)
        {
            textX = 5;
        }
        else if (_titleAlign == HorizontalAlignment.Center)
        {
            textX = ((this.Width - 1) / 2) - Convert.ToInt32((g.MeasureString(Text, Font).Width / 2));
        }
        else
        {
            textX = this.Width - 5 - Convert.ToInt32(g.MeasureString(Text, Font).Width - 1);
        }
        g.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(textX, 5));

        Pen borderPen = new Pen(Color.FromArgb(55, 55, 55));
        g.DrawPath(borderPen, mainPath);
        g.DrawLine(borderPen, new Point(0, 26), new Point(Width - 1, 26));
        borderPen.Dispose();

    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDown(e);
        Focus();
    }

}

}

