// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Influx
{
    [DefaultEvent("CheckedChanged")]
    public class InfluxRadioButton : ThemeControl154
    {
        private int X;

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        protected override void OnCreation()
        {
            InvalidateControls();
        }

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is InfluxRadioButton)
                {
                    ((InfluxRadioButton)C).Checked = false;
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }


        Brush TextBrush;
        protected override void ColorHook()
        {
            TextBrush = GetBrush("Text");
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = Convert.ToInt32(this.CreateGraphics().MeasureString(Text, Font).Width);
            this.Width = 20 + textSize;
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            //HatchBrush
            HatchBrush HB = new HatchBrush(HatchStyle.Percent20, Color.FromArgb(83, 83, 83), BackColor);
            G.FillRectangle(HB, new Rectangle(0, 0, Width, Height));

            if (_Checked)
            {
                if (State == MouseState.Over & X <= 11)
                {
                    G.FillEllipse(new SolidBrush(Color.FromArgb(100, 100, 100)), new Rectangle(0, 3, 11, 11));
                }
                else
                {
                    G.FillEllipse(new SolidBrush(Color.FromArgb(95, 95, 95)), new Rectangle(0, 3, 11, 11));
                }
                G.FillEllipse(new SolidBrush(Color.FromArgb(214, 214, 214)), new Rectangle(3, 6, 5, 5));
                G.DrawEllipse(new Pen(new SolidBrush(Color.FromArgb(68, 68, 68))), new Rectangle(0, 3, 11, 11));
            }
            else
            {
                if (State == MouseState.Over & X <= 11)
                {
                    G.FillEllipse(new SolidBrush(Color.FromArgb(94, 94, 94)), new Rectangle(0, 3, 11, 11));
                    G.FillEllipse(new SolidBrush(Color.FromArgb(88, 88, 88)), new Rectangle(2, 5, 8, 9));
                }
                else
                {
                    G.FillEllipse(new SolidBrush(Color.FromArgb(89, 89, 89)), new Rectangle(0, 3, 11, 11));
                    G.FillEllipse(new SolidBrush(Color.FromArgb(83, 83, 83)), new Rectangle(2, 5, 8, 9));
                }
                G.DrawEllipse(new Pen(new SolidBrush(Color.FromArgb(68, 68, 68))), new Rectangle(0, 3, 11, 11));
            }
            G.DrawString(Text, Font, TextBrush, new Point(17, 2));
        }

        public InfluxRadioButton()
        {
            this.Size = new Size(50, 16);
            SetColor("Text", Color.FromArgb(229, 229, 229));
            BackColor = Color.FromArgb(77, 77, 77);
        }
    }

}


