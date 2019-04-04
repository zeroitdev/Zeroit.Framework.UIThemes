// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
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

    [DefaultEvent("TextChanged")]
public class EightBallTextBox : Control
{

    private int _MaxLength = 32767;
    public int MaxLength
    {
        get { return _MaxLength; }
        set
        {
            _MaxLength = value;
            if (Base != null)
            {
                Base.MaxLength = value;
            }
        }
    }

    private bool _ReadOnly;
    public bool ReadOnly
    {
        get { return _ReadOnly; }
        set
        {
            _ReadOnly = value;
            if (Base != null)
            {
                Base.ReadOnly = value;
            }
        }
    }

    private bool _UseSystemPasswordChar;
    public bool UseSystemPasswordChar
    {
        get { return _UseSystemPasswordChar; }
        set
        {
            _UseSystemPasswordChar = value;
            if (Base != null)
            {
                Base.UseSystemPasswordChar = value;
            }
        }
    }

    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            if (Base != null)
            {
                Base.Text = value;
            }
        }
    }

    public override Font Font
    {
        get { return base.Font; }
        set
        {
            base.Font = value;
            if (Base != null)
            {
                Base.Font = value;
                Base.Location = new Point(3, 5);
                Base.Width = Width - 6;
            }
        }
    }

    private Image _image;
    public Image Image
    {
        get { return _image; }
        set
        {
            _image = value;
            if (_image != null)
            {
                Base.Location = new Point(33, 5);
                Base.Width = Width - 38;
            }
            else
            {
                Base.Location = new Point(5, 5);
                Base.Width = Width - 10;
            }
            Invalidate();
        }
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        if (!Controls.Contains(Base))
        {
            Controls.Add(Base);
        }
    }


    private TextBox Base;

    public EightBallTextBox()
    {
        Font = new Font("Arial", 9);
        ForeColor = Color.DimGray;
        Cursor = Cursors.IBeam;

        Base = new TextBox();
        Base.Font = Font;
        Base.Text = Text;
        Base.ForeColor = ForeColor;
        Base.MaxLength = _MaxLength;
        Base.ReadOnly = _ReadOnly;
        Base.BackColor = Color.Gainsboro;
        Base.UseSystemPasswordChar = _UseSystemPasswordChar;
        Base.BorderStyle = BorderStyle.None;
        Base.Location = new Point(5, 5);
        Base.Width = Width - 10;

        Base.TextChanged += OnBaseTextChanged;
        Base.KeyDown += OnBaseKeyDown;

    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);

        Size = new Size(Size.Width, Base.Height + 12);

        Graphics G = e.Graphics;

        G.SmoothingMode = SmoothingMode.HighQuality;
        G.Clear(Parent.BackColor);

        int slope = 3;

        Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
        GraphicsPath mainPath = Drawing.RoundRect(mainRect, slope);
        G.FillPath(Brushes.Gainsboro, mainPath);
        G.DrawPath(new Pen(Color.FromArgb(55, 55, 55)), mainPath);

        if (_image != null)
        {
            GraphicsPath imageArea = new GraphicsPath();
            imageArea.AddArc(0, 0, slope * 2, slope * 2, -90, -90);
            imageArea.AddLine(new Point(0, slope), new Point(0, Height - slope - 1));
            imageArea.AddArc(0, Height - (slope * 2) - 1, slope * 2, slope * 2, -180, -90);
            imageArea.AddLine(new Point(slope * 2, Height - 1), new Point(28, Height - 1));
            imageArea.AddLine(new Point(28, Height - 1), new Point(28, 0));
            imageArea.AddLine(new Point(28, 0), new Point(slope * 2, 0));
            imageArea.CloseAllFigures();
            G.FillPath(Brushes.Gainsboro, imageArea);
            G.DrawPath(new Pen(Color.FromArgb(55, 55, 55)), imageArea);
            G.DrawImage(_image, 7, 5, 16, 16);
        }

    }

    private void OnBaseTextChanged(object s, EventArgs e)
    {
        Text = Base.Text;
    }

    private void OnBaseKeyDown(object s, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            Base.SelectAll();
            e.SuppressKeyPress = true;
        }
    }

    private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
    [Category("Options")]
    public HorizontalAlignment TextAlign
    {
        get { return _TextAlign; }
        set
        {
            _TextAlign = value;
            if (Base != null)
            {
                Base.TextAlign = value;
            }
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (_image != null)
        {
            Base.Location = new Point(33, 6);
            Base.Width = Width - 38;
        }
        else
        {
            Base.Location = new Point(6, 6);
            Base.Width = Width - 12;
        }
    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDown(e);
        Base.SelectionStart = Base.TextLength;
        Base.Focus();
    }

}

}

