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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Frog
{

    //Skidded form Mava~
    public class FrogRadioButton : ThemeControl154
    {

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
                if (C.GetType().ToString() == String.Format(Application.ProductName, " ", "_") + ".RadioButton")
                {
                    RadioButton CC = null;
                    CC = (RadioButton)C;
                    CC.Checked = false;

                }
                else
                {
                }
            }
            _Checked = true;
        }

        protected override void ColorHook()
        {
            SetColor("Border", Color.FromArgb(255, 200, 200, 200));
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
            G.Clear(Color.FromArgb(255, 60, 60, 60));
            G.SmoothingMode = SmoothingMode.AntiAlias;

            Color Border = Color.FromArgb(160, GetColor("Border"));
            LinearGradientBrush LGBNone = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 50, 50, 50));
            LinearGradientBrush LGBOver = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 40, 40, 40));
            LinearGradientBrush LGBDown = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 30, 30, 30));


            switch (State)
            {
                case MouseState.Down:
                    G.FillEllipse(LGBDown, 1, 1, 15, 15);
                    break;
                case MouseState.None:
                    G.FillEllipse(LGBNone, 1, 1, 15, 15);
                    break;
                case MouseState.Over:
                    G.FillEllipse(LGBOver, 1, 1, 15, 15);
                    break;
            }

            G.DrawEllipse(Pens.Black, 0, 0, 16, 16);
            G.DrawEllipse(new Pen(GetColor("Border")), 1, 1, 14, 14);

            if ((_Checked))
            {
                G.FillEllipse(new SolidBrush(GetColor("Border")), 5, 5, 6, 6);
            }

            G.DrawString(Text, Font, new SolidBrush(GetColor("Border")), 18, 2);
        }
    }


}

