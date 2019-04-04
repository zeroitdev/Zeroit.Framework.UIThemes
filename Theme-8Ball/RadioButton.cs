// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.EightBall
{

    [DefaultEvent("CheckedChanged")]
public class EightBallRadioButton : Control
{

    public event CheckedChangedEventHandler CheckedChanged;
    public delegate void CheckedChangedEventHandler(object sender);

    private bool _checked;
    public bool Checked
    {
        get { return _checked; }
        set
        {
            _checked = value;
            Invalidate();
        }
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

    public EightBallRadioButton()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        Size = new Size(140, 20);
        ForeColor = Color.WhiteSmoke;
        Font = new Font("Segoe UI", 9);
    }


    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.SmoothingMode = SmoothingMode.HighQuality;
        G.Clear(Parent.BackColor);

        Rectangle circleRect = new Rectangle(0, 0, Height - 1, Height - 1);
        LinearGradientBrush bgBrush = new LinearGradientBrush(circleRect, Color.FromArgb(120, 120, 120), Color.FromArgb(100, 100, 100), 90f);
        G.FillEllipse(bgBrush, circleRect);
        G.DrawEllipse(new Pen(Color.FromArgb(50, 50, 50)), circleRect);

        int textY = ((this.Height - 1) / 2) - Convert.ToInt32((G.MeasureString(Text, Font).Height / 2) + 1);
        G.DrawString(Text, Font, new SolidBrush(ForeColor), new Point((Height - 1) + 4, textY));

        if (_checked)
        {
            Rectangle checkedRect = new Rectangle(5, 5, Height - 11, Height - 11);
            LinearGradientBrush checkedBrush = new LinearGradientBrush(checkedRect, Color.LightGray, Color.Gray, 90f);
            G.FillEllipse(checkedBrush, checkedRect);
            G.DrawEllipse(new Pen(Color.FromArgb(70, 70, 70)), checkedRect);
        }

    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDown(e);

        foreach (Control C in Parent.Controls)
        {
            if (!object.ReferenceEquals(C, this) && C is EightBallRadioButton)
            {
                ((EightBallRadioButton)C).Checked = false;
            }
        }

        if (_checked)
        {
            _checked = false;
        }
        else
        {
            _checked = true;
        }

        if (CheckedChanged != null)
        {
            CheckedChanged(this);
        }
        Invalidate();

    }

}

}

