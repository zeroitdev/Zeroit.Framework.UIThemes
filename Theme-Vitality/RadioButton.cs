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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Vitality
{
    [DefaultEvent("CheckedChanged")]
    public class VitalityRadiobutton : ThemeControl154
    {

        Color BG;
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

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is VitalityRadiobutton)
                {
                    ((VitalityRadiobutton)C).Checked = false;
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

        public VitalityRadiobutton()
        {
            LockHeight = 22;
            Width = 140;
            SetColor("BG", Color.FromArgb(240, 240, 240));
        }

        protected override void ColorHook()
        {
            BG = GetColor("BG");
        }

        protected override void PaintHook()
        {
            G.Clear(BG);

            G.SmoothingMode = SmoothingMode.HighQuality;

            if (_Checked)
                G.FillEllipse(Brushes.Gray, new Rectangle(new Point(7, 7), new Size(8, 8)));

            if (State == MouseState.Over)
            {
                G.FillEllipse(Brushes.White, new Rectangle(new Point(4, 4), new Size(14, 14)));
                if (_Checked)
                    G.FillEllipse(Brushes.Gray, new Rectangle(new Point(7, 7), new Size(8, 8)));
            }

            G.DrawEllipse(Pens.White, new Rectangle(new Point(3, 3), new Size(16, 16)));
            G.DrawEllipse(Pens.LightGray, new Rectangle(new Point(2, 2), new Size(18, 18)));
            G.DrawEllipse(Pens.LightGray, new Rectangle(new Point(4, 4), new Size(14, 14)));

            G.DrawString(Text, new Font("Segoe UI", 9), Brushes.Gray, 23, 3);
        }
    }


}

