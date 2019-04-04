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
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Earn
{
    [DefaultEvent("CheckedChanged")]
    public class EarnRadiobutton : ThemeControl154
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
                if (!object.ReferenceEquals(C, this) && C is EarnRadiobutton)
                {
                    ((EarnRadiobutton)C).Checked = false;
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
        Pen Outline;
        protected override void ColorHook()
        {
            TextColor = GetBrush("Text");
            CircleColor = GetPen("Circle");
            Outline = GetPen("Outline");
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)(this.CreateGraphics().MeasureString(Text, Font).Width);
            this.Width = 20 + textSize + 5;
        }

        protected override void PaintHook()
        {
            Color c1 = Color.FromArgb(130, 208, 73);
            Color c2 = Color.FromArgb(79, 178, 52);
            G.Clear(Color.FromArgb(240, 240, 240));
            G.SmoothingMode = SmoothingMode.HighQuality;
            if (_Checked)
            {
                G.DrawEllipse(Outline, new Rectangle(3, 3, 12, 12));
                G.FillEllipse(new SolidBrush(Color.FromArgb(79, 178, 52)), new Rectangle(6, 6, 6, 6));
            }
            else
            {
                G.DrawEllipse(Outline, new Rectangle(3, 3, 12, 12));
            }
            G.DrawString(Text, Font, TextColor, new Point(22, 2));
        }

        public EarnRadiobutton()
        {
            SetColor("Text", Color.FromArgb(75, 77, 89));
            SetColor("Circle", Color.FromArgb(214, 214, 214));
            SetColor("Outline", Color.FromArgb(75, 77, 89));
        }
    }


}

