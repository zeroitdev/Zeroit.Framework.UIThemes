// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
    public class MorphicRadioButton : Control
    {
        public delegate void CheckedChangedEventHandler(object sender);
        public event CheckedChangedEventHandler CheckedChanged;

        private DrawingHelper dh = new DrawingHelper();
        private Graphics g;

        private Rectangle checkRect;
        private bool mouseOver;

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

        public MorphicRadioButton()
        {
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

            LinearGradientBrush backBrush = new LinearGradientBrush(checkRect, Preferences.ControlBackColor, dh.AdjustColor(Preferences.ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F);
            g.FillEllipse(backBrush, checkRect);
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
            g.FillEllipse(screenBrush, checkRect);
            screenBrush.Dispose();

            if (_checked)
            {
                g.FillEllipse(new SolidBrush(Preferences.TextColor), dh.ResizeRect(checkRect, 7));
            }

            g.DrawEllipse(new Pen(Preferences.BorderColor), checkRect);

            SizeF textSize = g.MeasureString(Text, Font);
            int textX = Height + 2;
            int textY = Convert.ToInt32((Height / 2) - (textSize.Height / 2.0));
            g.DrawString(Text, Font, new SolidBrush(Preferences.TextColor), textX, textY);

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (checkRect.Contains(new Point(e.X, e.Y)))
            {
                if (!Checked)
                {
                    foreach (Control c in Parent.Controls)
                    {
                        if (c is MorphicRadioButton && c != this)
                        {
                            ((MorphicRadioButton)c).Checked = false;
                        }
                    }
                    Checked = true;
                    if (CheckedChanged != null)
                        CheckedChanged(this);
                }
            }

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
