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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Sugar
{
    [DefaultEvent("CheckedChanged")]
    public class SugarRadiobutton : ThemeControl154
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
                if (!object.ReferenceEquals(C, this) && C is SugarRadiobutton)
                {
                    ((SugarRadiobutton)C).Checked = false;
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
            G.Clear(Color.FromArgb(247, 249, 254));
            HatchBrush asdf = default(HatchBrush);
            asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black), Color.FromArgb(0, Color.Gray));
            G.FillRectangle(new SolidBrush(Color.FromArgb(247, 249, 254)), new Rectangle(0, 0, Width, Height));
            asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
            G.FillRectangle(asdf, 0, 0, Width, Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(247, 249, 254)), 0, 0, Width, Height);

            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.FillEllipse(new SolidBrush(Color.FromArgb(220, 232, 235)), 2, 2, 11, 11);
            G.DrawEllipse(Pens.Black, 0, 0, 13, 13);
            G.DrawEllipse(new Pen(Color.FromArgb(220, 232, 235)), 1, 1, 11, 11);

            if (_Checked == false)
            {
                HatchBrush hatch = default(HatchBrush);
                hatch = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(20, Color.White), Color.FromArgb(0, Color.Gray));
                G.FillEllipse(hatch, 2, 2, 10, 10);
            }
            else
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(80, 80, 80)), 3, 3, 7, 7);
                HatchBrush hatch = default(HatchBrush);
                hatch = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(60, Color.Black), Color.FromArgb(0, Color.Gray));
                G.FillRectangle(hatch, 3, 3, 7, 7);
            }

            if (State == MouseState.Over & X < 13)
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(20, Color.White)), 2, 2, 11, 11);
            }

            G.DrawString(Text, Font, Brushes.Black, 16, 0);
        }

        public SugarRadiobutton()
        {
            this.Size = new Size(50, 14);
        }
    }

}

