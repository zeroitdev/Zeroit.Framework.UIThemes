// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Thirteen
{
    public class ThirteenButton : Button
    {
        public enum MouseState
        {
            None,
            Over,
            Down
        }
        public enum ColorSchemes
        {
            Light,
            Dark
        }
        private ColorSchemes _ColorScheme;
        public ColorSchemes ColorScheme
        {
            get { return _ColorScheme; }
            set
            {
                _ColorScheme = value;
                Invalidate();
            }
        }

        MouseState State = MouseState.None;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }

        private Color _AccentColor;
        public Color AccentColor
        {
            get { return _AccentColor; }
            set
            {
                _AccentColor = value;
                OnAccentColorChanged();
            }
        }

        public event AccentColorChangedEventHandler AccentColorChanged;
        public delegate void AccentColorChangedEventHandler();

        public ThirteenButton() : base()
        {
            AccentColorChanged += OnAccentColorChanged;
            Font = new Font("Segoe UI Semilight", 9.75f);
            ForeColor = Color.White;
            BackColor = Color.FromArgb(50, 50, 50);
            AccentColor = Color.DodgerBlue;
            ColorScheme = ColorSchemes.Dark;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            base.OnPaint(e);
            Color BGColor = default(Color);
            switch (ColorScheme)
            {
                case ColorSchemes.Dark:
                    BGColor = Color.FromArgb(50, 50, 50);
                    break;
                case ColorSchemes.Light:
                    BGColor = Color.White;
                    break;
            }

            switch (State)
            {
                case MouseState.None:
                    G.Clear(BGColor);
                    break;
                case MouseState.Over:
                    G.Clear(AccentColor);
                    break;
                case MouseState.Down:
                    G.Clear(AccentColor);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Black)), new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
            }


            G.DrawRectangle(new Pen(Color.FromArgb(100, 100, 100)), new Rectangle(0, 0, Width - 1, Height - 1));

            StringFormat ButtonString = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            switch (ColorScheme)
            {
                case ColorSchemes.Dark:
                    G.DrawString(Text, Font, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), ButtonString);
                    break;
                case ColorSchemes.Light:
                    G.DrawString(Text, Font, Brushes.Black, new Rectangle(0, 0, Width - 1, Height - 1), ButtonString);
                    break;
            }

            e.Graphics.DrawImage(B, new Point(0, 0));
            G.Dispose();
            B.Dispose();
        }
        protected void OnAccentColorChanged()
        {
            Invalidate();
        }
    }

}

