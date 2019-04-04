// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="WarningMessage.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Onyl
{
    public class OnylWarningMessage : Control
    {
        private Image _image;

        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        public OnylWarningMessage()
        {

            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Font = new Font(Font.FontFamily, 9);
            Size = new Size(140, 26);

        }

        private Rectangle imageRect;
        private Rectangle boundsRect;

        protected override void OnPaint(PaintEventArgs e)
        {

            ThemeModule.g = e.Graphics;
            ThemeModule.g.Clear(Parent.BackColor);
            ThemeModule.g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_image != null)
            {
                imageRect = new Rectangle(0, (Height * 2) - 10, 20, 20);
                ThemeModule.g.DrawImage(_image, imageRect);
            }

            ThemeModule.g.DrawString(Text, Font, Brushes.WhiteSmoke, new Point(24, (int)((Height * 2) - ThemeModule.g.MeasureString(Text, Font).Height * 2)));

        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

    }
}
