// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Morphic
{
    public class MorphicButton : Control
    {
        private Graphics g;
        private DrawingHelper dh = new DrawingHelper();

        public enum MouseState
        {
            None,
            Over,
            Down
        }

        private MouseState state = MouseState.None;

        public MorphicButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Cursor = Cursors.Hand;
            Font = new Font(Preferences.FontFamily, 10);
            Size = new Size(100, 40);
        }

        protected override void CreateHandle()
        {
            Font = new Font(Preferences.FontFamily, Font.Size);
            base.CreateHandle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            g = e.Graphics;
            g.Clear(Parent.BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle boundsRect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath boundsPath = dh.RoundRect(boundsRect, Preferences.Rounding);

            LinearGradientBrush backBrush = new LinearGradientBrush(boundsRect, Preferences.ControlBackColor, dh.AdjustColor(Preferences.ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F);
            g.FillPath(backBrush, boundsPath);
            backBrush.Dispose();

            int brushIntensity = 0;

            if (state == MouseState.Over)
            {
                brushIntensity = 20;
            }
            else if (state == MouseState.Down)
            {
                brushIntensity = 50;
            }

            SolidBrush screenBrush = new SolidBrush(Color.FromArgb(brushIntensity, Preferences.MainColor));
            g.FillPath(screenBrush, boundsPath);
            screenBrush.Dispose();

            g.DrawPath(new Pen(Preferences.BorderColor), boundsPath);

            dh.DrawCenteredString(g, Text, Font, new SolidBrush(Preferences.TextColor), boundsRect);

        }

        protected override void OnMouseEnter(EventArgs e)
        {
            state = MouseState.Over;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            state = MouseState.None;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            state = MouseState.Down;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            state = MouseState.Over;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

    }
}
