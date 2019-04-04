// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Hura
{


    public class HuraTextBox : TextBox
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

        public HuraTextBox()
        {
            ColorSchemeChanged += OnColorSchemeChanged;
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Segoe UI", 9.5f);
            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.White;
            ColorScheme = ColorSchemes.Dark;
        }

        protected void OnColorSchemeChanged()
        {
            Invalidate();
            switch (ColorScheme)
            {
                case ColorSchemes.Dark:
                    BackColor = Color.FromArgb(50, 50, 50);
                    ForeColor = Color.White;
                    break;
            }
        }
    }


}


