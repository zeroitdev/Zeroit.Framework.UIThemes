// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Thirteen
{
    public class ThirteenTextBox : TextBox
    {
        public enum ColorSchemes
        {
            Light,
            Dark
        }
        public event ColorSchemeChangedEventHandler ColorSchemeChanged;
        public delegate void ColorSchemeChangedEventHandler();
        private ColorSchemes _ColorScheme;
        public ColorSchemes ColorScheme
        {
            get { return _ColorScheme; }
            set
            {
                _ColorScheme = value;
                if (ColorSchemeChanged != null)
                {
                    ColorSchemeChanged();
                }
            }
        }

        public ThirteenTextBox()
        {
            ColorSchemeChanged += OnColorSchemeChanged;
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Segoe UI Semilight", 9.75f);
            BackColor = Color.FromArgb(35, 35, 35);
            ForeColor = Color.White;
            ColorScheme = ColorSchemes.Dark;
        }

        protected void OnColorSchemeChanged()
        {
            Invalidate();
            switch (ColorScheme)
            {
                case ColorSchemes.Dark:
                    BackColor = Color.FromArgb(35, 35, 35);
                    ForeColor = Color.White;
                    break;
                case ColorSchemes.Light:
                    BackColor = Color.White;
                    ForeColor = Color.Black;
                    break;
            }
        }
    }
}

