// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Clarity
{
    public class iClarityCheckBox : ThemeControl154
    {
        private bool _Checked;

        private int X;
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
            }
        }
        Brush TextColor;
        Pen BorderBox;
        Pen InnerBox;
        protected override void ColorHook()
        {
            TextColor = GetBrush("Text");
            BorderBox = GetPen("Border");
            InnerBox = GetPen("Inner");
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = Convert.ToInt32(CreateGraphics().MeasureString(Text, Font).Width);
            this.Width = 30 + textSize;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_Checked == true)
                _Checked = false;
            else
                _Checked = true;
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;
            int Curve = 4;

            if (_Checked)
            {
                G.FillRectangle(new SolidBrush(Color.White), new Rectangle(3, 3, 10, 10));
                G.DrawString("a", new Font("Marlett", 12), Brushes.White, new Point(-2, 0));

                G.DrawRectangle(InnerBox, new Rectangle(1, 1, 14, 14));
                G.DrawRectangle(BorderBox, new Rectangle(0, 0, 16, 16));



            }
            else
            {

                G.DrawRectangle(InnerBox, new Rectangle(1, 1, 14, 14));
                G.DrawRectangle(BorderBox, new Rectangle(0, 0, 16, 16));
            }

            if (State == MouseState.Over)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), 3, 3, 10, 10);
            }

            G.DrawString(Text, Font, TextColor, new Point(22, 2));

        }

        public iClarityCheckBox()
        {
            this.Size = new Size(50, 17);
            SetColor("Text", Color.White);
            SetColor("Border", Color.Black);
            SetColor("Inner", Color.FromArgb(40, 40, 40));
        }
    }


}


