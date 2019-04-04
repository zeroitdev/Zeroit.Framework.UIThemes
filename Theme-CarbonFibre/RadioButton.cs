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

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.CarbonFibre
{
    [DefaultEvent("CheckedChanged")]
    public class CarbonFiberRadioButton : ThemeControl154
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
                if (!object.ReferenceEquals(C, this) && C is CarbonFiberRadioButton)
                {
                    ((CarbonFiberRadioButton)C).Checked = false;
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


        protected override void ColorHook()
        {
            // again and again another waste of time >.<
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            this.Width = 20 + textSize;
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));
            G.SmoothingMode = SmoothingMode.HighQuality;

            if (State == MouseState.Over)
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(29, 29, 29)), new Rectangle(3, 3, 10, 10));
                G.DrawEllipse(new Pen(Color.FromArgb(22, 22, 22)), 5, 5, 6, 6);
            }

            if (_Checked)
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(255, 150, 0)), 5, 5, 6, 6);
            }
            else
            {
            }

            G.DrawEllipse(new Pen(Color.FromArgb(6, 6, 6)), 0, 0, 16, 16);
            G.DrawEllipse(new Pen(Color.FromArgb(29, 29, 29)), 1, 1, 14, 14);
            G.DrawEllipse(new Pen(Color.FromArgb(6, 6, 6)), new Rectangle(2, 2, 12, 12));

            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(0, 0, 0)), 17, 0);
            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(255, 150, 0)), 18, 1);
        }

        public CarbonFiberRadioButton()
        {
            this.Size = new Size(50, 17);
            MinimumSize = new Size(50, 17);
            MaximumSize = new Size(600, 17);
        }

    }

}


