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
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Zeroit.Framework.UIThemes.Visible
{
    public class VIRadio : ThemeControl154
    {
        public VIRadio()
        {
            BackColor = Color.Transparent;
            Transparent = true;
            Size = new Size(50, 17);
        }
        private bool _Checked;
        public bool Checked
        {
            get
            {
                return _Checked;
            }
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
                if (C.GetType() == typeof(VIRadio))
                {
                    VIRadio CC = null;
                    CC = (VIRadio)C;
                    CC.Checked = false;
                }
                //if (C.GetType().ToString() == My.MyApplication.Application.Info.ProductName.Replace(" ", "_") + ".VRadiobutton")
                //{
                //    VIRadio CC = null;
                //    CC = C;
                //    CC.Checked = false;
                //}
            }
            _Checked = true;
        }

        protected override void ColorHook()
        {

        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = Convert.ToInt32(this.CreateGraphics().MeasureString(Text, Font).Width);
            this.Width = 25 + textSize;
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            if (_Checked == false)
            {
                G.FillEllipse(new SolidBrush(Color.Black), 0, 0, 16, 16);
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(1, 1, 14, 14), Color.FromArgb(24, 30, 36), Color.FromArgb(25, 25, 25), 90.0F);
                G.FillEllipse(Gbrush, new Rectangle(1, 1, 14, 14));
                Gbrush = new LinearGradientBrush(new Rectangle(2, 2, 12, 12), Color.FromArgb(12, 12, 12), Color.FromArgb(25, 25, 25), 90.0F);
                G.FillEllipse(Gbrush, new Rectangle(2, 2, 12, 12));
                G.DrawEllipse(Pens.Black, new Rectangle(3, 3, 10, 10));
            }
            else
            {
                G.FillEllipse(new SolidBrush(Color.Black), 0, 0, 16, 16);
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(1, 1, 14, 14), Color.FromArgb(45, 45, 45), Color.FromArgb(10, 10, 10), 90.0F);
                G.FillEllipse(Gbrush, new Rectangle(1, 1, 14, 14));
                Gbrush = new LinearGradientBrush(new Rectangle(2, 2, 12, 12), Color.FromArgb(25, 25, 25), Color.FromArgb(20, 20, 20), 90.0F);
                G.FillEllipse(Gbrush, new Rectangle(2, 2, 12, 12));
                G.FillEllipse(Brushes.Black, new Rectangle(5, 6, 5, 5));
                LinearGradientBrush Gbrush2 = new LinearGradientBrush(new Rectangle(1, 1, 14, 14), Color.FromArgb(130, 130, 130), Color.FromArgb(20, 20, 20), LinearGradientMode.ForwardDiagonal);
                G.FillEllipse(Gbrush2, new Rectangle(3, 3, 10, 10));
                G.DrawEllipse(Pens.Black, new Rectangle(3, 3, 10, 10));
            }
            G.DrawString(Text, Font, Brushes.White, 22, 2);
        }


    }
}


