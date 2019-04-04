// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Thirteen
{
    [ToolboxItem(false)]
    public class ThirteenForm : ContainerControl
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
        protected void OnColorSchemeChanged()
        {
            Invalidate();
            switch (ColorScheme)
            {
                case ColorSchemes.Dark:
                    BackColor = Color.FromArgb(50, 50, 50);
                    ForeColor = Color.White;
                    break;
                case ColorSchemes.Light:
                    BackColor = Color.White;
                    ForeColor = Color.Black;
                    break;
            }
        }
        #region " Properties "
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
        #endregion
        #region " Constructor "
        public ThirteenForm() : base()
        {
            AccentColorChanged += OnAccentColorChanged;
            ColorSchemeChanged += OnColorSchemeChanged;
            DoubleBuffered = true;
            Font = new Font("Segoe UI Semilight", 9.75f);
            //AccentColor = Color.FromArgb(150, 0, 150)
            AccentColor = Color.DodgerBlue;
            ColorScheme = ColorSchemes.Dark;
            ForeColor = Color.White;
            BackColor = Color.FromArgb(50, 50, 50);
            MoveHeight = 32;
        }
        #endregion
        #region " Events "
        public event AccentColorChangedEventHandler AccentColorChanged;
        public delegate void AccentColorChangedEventHandler();
        #endregion
        #region " Overrides "
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight;
        private int pos = 0;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                Cap = true;
                MouseP = e.Location;
            }
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Dock = DockStyle.Fill;
            Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            base.OnPaint(e);

            G.Clear(BackColor);
            G.DrawLine(new Pen(_AccentColor, 2), new Point(0, 30), new Point(Width, 30));
            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(8, 6, Width - 1, Height - 1), StringFormat.GenericDefault);
            G.DrawLine(new Pen(_AccentColor, 3), new Point(8, 27), new Point(8 + (int)G.MeasureString(Text, Font).Width, 27));

            G.DrawRectangle(new Pen(Color.FromArgb(100, 100, 100)), new Rectangle(0, 0, Width - 1, Height - 1));

            e.Graphics.DrawImage(B, new Point(0, 0));
            G.Dispose();
            B.Dispose();
        }
        protected void OnAccentColorChanged()
        {
            Invalidate();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
        #endregion

    }

    
}

