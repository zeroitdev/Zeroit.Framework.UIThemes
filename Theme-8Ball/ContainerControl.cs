// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="ContainerControl.cs" company="Zeroit Dev Technologies">
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

    [ToolboxItem(false)]
public class EightBallContainer : ContainerControl
{

    private int moveHeight = 39;
    private bool formCanMove = false;
    private int mouseX;
    private int mouseY;
    private bool overExit;
    private bool overMin;

    private Color tKey = Color.FromArgb(0, 1, 1);
    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            Invalidate();
        }
    }

    private Icon _icon;
    public Icon Icon
    {
        get { return _icon; }
        set
        {
            _icon = value;
            Invalidate();
        }
    }

    private bool _showIcon;
    public bool ShowIcon
    {
        get { return _showIcon; }
        set
        {
            _showIcon = value;
            Invalidate();
        }
    }

    public EightBallContainer()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        Dock = DockStyle.Fill;
        Font = new Font("Segoe UI", 9);
        BackColor = Color.FromArgb(90, 90, 90);
        ShowIcon = true;
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();
        if (Parent.FindForm().TransparencyKey == null)
            Parent.FindForm().TransparencyKey = tKey;
        Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.Clear(tKey);

        Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
        int slope = 8;
        GraphicsPath mainPath = Drawing.TopRoundRect(mainRect, slope);
        g.FillPath(new SolidBrush(Color.FromArgb(60, 60, 60)), mainPath);

        Rectangle titleTopRect = new Rectangle(0, 0, Width - 1, Convert.ToInt32(moveHeight / 1.75f));
        GraphicsPath titleTopPath = Drawing.TopRoundRect(titleTopRect, slope);
        LinearGradientBrush titleTopBrush = new LinearGradientBrush(new Rectangle(titleTopRect.X, titleTopRect.Y, titleTopRect.Width, titleTopRect.Height + 2), Color.FromArgb(100, 100, 100), Color.FromArgb(60, 60, 60), 90f);
        g.FillPath(titleTopBrush, titleTopPath);

        Rectangle innerRect = new Rectangle(6, moveHeight, Width - 13, Height - moveHeight - 8);
        g.FillRectangle(new SolidBrush(BackColor), innerRect);
        g.DrawRectangle(Pens.Black, innerRect);

        int textY = (moveHeight / 2) - (Convert.ToInt32(g.MeasureString(Text, Font).Height / 2) + 1);
        if (_showIcon & _icon != null)
        {
            g.DrawIcon(_icon, new Rectangle(8, 6, moveHeight - 11, moveHeight - 11));
            Drawing.ShadowedString(g, Text, Font, Brushes.White, new Point(8 + moveHeight - 11 + 4, textY));
        }
        else
        {
            Drawing.ShadowedString(g, Text, Font, Brushes.White, new Point(8, textY));
        }

        Rectangle exitRect = new Rectangle(Width - 29, 8, 22, 22);
        GraphicsPath exitPath = Drawing.RoundRect(exitRect, 3);
        LinearGradientBrush exitBrush = new LinearGradientBrush(exitRect, Color.FromArgb(105, 105, 105), Color.FromArgb(75, 75, 75), 90f);
        g.FillPath(exitBrush, exitPath);
        if (overExit)
            g.FillPath(new SolidBrush(Color.FromArgb(15, Color.White)), exitPath);
        g.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), exitPath);
        g.DrawString("r", new Font("Marlett", 10), Brushes.LightGray, new Point(Width - 26, 13));

        Rectangle minRect = new Rectangle(Width - 55, 8, 22, 22);
        GraphicsPath minPath = Drawing.RoundRect(minRect, 3);
        LinearGradientBrush minBrush = new LinearGradientBrush(minRect, Color.FromArgb(105, 105, 105), Color.FromArgb(75, 75, 75), 90f);
        g.FillPath(minBrush, minPath);
        if (overMin)
            g.FillPath(new SolidBrush(Color.FromArgb(15, Color.White)), minPath);
        g.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), minPath);
        g.DrawString("0", new Font("Marlett", 13), Brushes.LightGray, new Point(Width - 53, 10));

        g.SmoothingMode = SmoothingMode.Default;
        g.DrawPath(Pens.DimGray, Drawing.TopRoundRect(new Rectangle(mainRect.X + 1, mainRect.Y, mainRect.Width - 2, mainRect.Height), slope));
        g.DrawPath(Pens.DimGray, Drawing.TopRoundRect(new Rectangle(mainRect.X, mainRect.Y + 1, mainRect.Width, mainRect.Height - 2), slope));
        g.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), mainPath);

    }

    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseMove(e);

        if (formCanMove == true)
        {
            Parent.FindForm().Location = new Point(MousePosition.X - mouseX, MousePosition.Y - mouseY);
        }

        if (e.Y > 8 && e.Y < 30)
        {
            if (e.X > Width - 29 && e.X < Width - 7)
                overExit = true;
            else
                overExit = false;
            if (e.X > Width - 55 && e.X < Width - 33)
                overMin = true;
            else
                overMin = false;
        }
        else
        {
            overExit = false;
            overMin = false;
        }

        Invalidate();

    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDown(e);

        mouseX = e.X;
        mouseY = e.Y;

        if (e.Y <= moveHeight && overExit == false && overMin == false)
            formCanMove = true;

        if (overExit)
        {
            Parent.FindForm().Close();
        }
        else if (overMin)
        {
            Parent.FindForm().WindowState = FormWindowState.Minimized;
        }
        else
        {
            Focus();
        }

    }

    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseUp(e);
        formCanMove = false;
    }

}

}

