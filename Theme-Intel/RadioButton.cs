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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Intel
{
    public class iRadioButton : ThemeControl154
    {
        protected override void ColorHook()
        {
        }

        #region "Events"
        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            foreach (Control C in Parent.Controls)
            {
                if (C.GetType().ToString() == String.Format(Application.ProductName, " ", "_") + ".iRadioButton")
                {
                    iRadioButton CC = null;
                    CC = (iRadioButton)C;
                    CC.Checked = false;
                }
            }
            _Checked = true;
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            this.Width = 25 + textSize;
        }
        #endregion

        private bool Animation;
        public bool _Animation
        {
            get { return Animation; }
            set
            {
                Animation = value;
                Invalidate();
            }
        }

        private int glow = 150;

        private bool inc = true;
        public iRadioButton()
        {
            Size = new Size(50, 17);
            LockHeight = 17;
            IsAnimated = true;
            Animation = true;
        }


        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(45, 45, 45));
            G.SmoothingMode = SmoothingMode.AntiAlias;

            //Check Box
            if (_Checked)
            {
                if (Animation)
                {
                    G.FillEllipse(new SolidBrush(Color.FromArgb(glow, Color.SteelBlue)), new Rectangle(4, 4, 8, 8));
                }
                else
                {
                    G.FillEllipse(new SolidBrush(Color.FromArgb(205, Color.SteelBlue)), new Rectangle(4, 4, 8, 8));
                }
            }
            G.DrawEllipse(Pens.Black, new Rectangle(0, 0, 16, 16));

            //Text
            G.DrawString(Text, new Font("Verdana", 8), Brushes.Black, 21, 3);
            G.DrawString(Text, new Font("Verdana", 8), Brushes.WhiteSmoke, 20, 2);

        }

        protected override void OnAnimation()
        {
            base.OnAnimation();
            if (inc)
            {
                if (glow < 240)
                    glow += 1;
                else
                    inc = false;
            }
            else
            {
                if (glow > 150)
                    glow -= 2;
                else
                    inc = true;
            }
        }

    }


}


