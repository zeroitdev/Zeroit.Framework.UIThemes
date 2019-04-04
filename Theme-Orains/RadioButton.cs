// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Orains
{
    [DefaultEvent("CheckedChanged")]
    public class OrainsRadioButton : ThemeControl154
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
                if (!object.ReferenceEquals(C, this) && C is OrainsRadioButton)
                {
                    ((OrainsRadioButton)C).Checked = false;
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
        Brush TextColor;
        Pen CircleColor;

        Pen CircleInner;
        protected override void ColorHook()
        {
            TextColor = GetBrush("Text");
            CircleColor = GetPen("Circle");
            CircleInner = GetPen("Inner");
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            this.Width = 30 + textSize;
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            if (_Checked)
            {
                G.DrawEllipse(CircleColor, new Rectangle(0, 0, 16, 16));
                G.DrawEllipse(CircleInner, new Rectangle(1, 1, 14, 14));
                G.FillEllipse(new SolidBrush(Color.DarkOrange), new Rectangle(5, 5, 6, 6));

            }
            else
            {
                G.DrawEllipse(CircleColor, new Rectangle(0, 0, 16, 16));
                G.DrawEllipse(CircleInner, new Rectangle(1, 1, 14, 14));
            }

            if (State == MouseState.Over)
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(20, Color.Orange)), 5, 5, 6, 6);
            }

            G.DrawString(Text, Font, TextColor, new Point(22, 2));
        }

        public OrainsRadioButton()
        {
            this.Size = new Size(50, 17);
            SetColor("Text", Color.Orange);
            SetColor("Circle", Color.Black);
            SetColor("Inner", Color.FromArgb(40, 40, 40));
        }
    }

}


