// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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
    [DefaultEvent("CheckedChanged")]
    public class MorphicCheckBox : Control
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            checkMark = dh.CodeToImage("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAADESURBVDhPxZIhCgJRFEU/ImIcXMZgEDGKwWQwGlyDQcQdmA0yyRWYXIIrmGhyAWIQs0nkex7eAcOIz6IHTpg79/6ZgQl/IcaY4FiX38GwjwccKvLBwJzjCVuKfTCoYIZnTBX7YGCu8YodxX4YLdEYKfLDaPrcxpWiciikuMWZIst6eMM91hSXQ2GDBQNs4BHtgLZq76FUxxyNHRYHZqp8hnIT7Yl3W8IFE932weD1UyaK/TCy39TeYoFVxX5shF1d/oIQHijh1y3sO6VaAAAAAElFTkSuQmCC");
        }

        public delegate void CheckedChangedEventHandler(object sender);
        public event CheckedChangedEventHandler CheckedChanged;

        private Graphics g;
        private DrawingHelper dh = new DrawingHelper();

        private Image checkMark;

        private bool mouseOver;
        private Rectangle checkRect;
        private bool _checked;

        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
                Invalidate();
            }
        }

        public MorphicCheckBox()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Size = new Size(150, 24);
            Font = new Font(Preferences.FontFamily, 9);
        }

        protected override void CreateHandle()
        {
            Font = new Font(Preferences.FontFamily, Font.Size);
            base.CreateHandle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent.BackColor);

            checkRect = new Rectangle(2, 2, Height - 5, Height - 5);
            GraphicsPath checkPath = dh.RoundRect(checkRect, Preferences.Rounding);

            LinearGradientBrush backBrush = new LinearGradientBrush(checkRect, Preferences.ControlBackColor, dh.AdjustColor(Preferences.ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F);
            g.FillPath(backBrush, checkPath);
            backBrush.Dispose();

            int brushIntensity = 0;

            if (Checked)
            {
                brushIntensity = 50;
            }
            else if (mouseOver)
            {
                brushIntensity = 20;
            }

            SolidBrush screenBrush = new SolidBrush(Color.FromArgb(brushIntensity, Preferences.MainColor));
            g.FillPath(screenBrush, checkPath);
            screenBrush.Dispose();

            g.DrawPath(new Pen(Preferences.BorderColor), checkPath);

            if (_checked)
            {
                g.DrawImage(checkMark, 7, 1);
            }

            SizeF textSize = g.MeasureString(Text, Font);
            int textX = Height + 2;
            int textY = Convert.ToInt32((Height / 2) - (textSize.Height / 2.0));
            g.DrawString(Text, Font, new SolidBrush(Preferences.TextColor), textX, textY);

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (checkRect.Contains(new Point(e.X, e.Y)))
            {
                Checked = !Checked;
                if (CheckedChanged != null)
                    CheckedChanged(this);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            mouseOver = checkRect.Contains(e.Location);
            Invalidate();
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mouseOver = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

    }
}
