// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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

    public class ExonBlazeProgressbar : Control
{

    private Color _barColor;
    public Color BarColor
    {
        get { return _barColor; }
        set
        {
            _barColor = value;
            Invalidate();
        }
    }

    private int _maximum = 100;
    public int Maximum
    {
        get { return _maximum; }
        set
        {
            if (value < 1)
                value = 1;
            if (value < _value)
                _value = value;
            _maximum = value;
            Invalidate();
        }
    }

    private int _value;
    public int Value
    {
        get { return _value; }
        set
        {
            if (value > _maximum)
                value = _maximum;
            _value = value;
            Invalidate();
        }
    }

    public ExonBlazeProgressbar()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        Size = new Size(200, 26);
        BackColor = Color.FromArgb(80, 80, 80);
        BarColor = Color.Gray;
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
        LinearGradientBrush bgBrush = new LinearGradientBrush(mainRect, BackColor, Color.FromArgb(25, 25, 25), 90f);
        g.FillPath(bgBrush, mainPath);

        float percent = (_value / _maximum) * 100;
        if (percent > 2.75)
        {
            Rectangle barRect = new Rectangle(0, 0, Convert.ToInt32((Width / _maximum) * _value) - 1, Height - 1);
            GraphicsPath barPath = Drawing.RoundRect(barRect, slope);
            LinearGradientBrush barBrush = new LinearGradientBrush(barRect, BarColor, Color.FromArgb(45, 45, 45), 90f);
            g.FillPath(barBrush, barPath);
        }

        g.DrawPath(new Pen(Color.FromArgb(50, 50, 50)), mainPath);

    }

}

}

