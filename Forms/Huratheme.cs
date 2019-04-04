// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Huratheme.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.UIThemes.Hura
{

    class HuraModule
    {

        #region " G"
        public Graphics G;
        #endregion
        public Bitmap B;


        public HuraModule()
        {
            TextBitmap = new Bitmap(1, 1);
            TextGraphics = Graphics.FromImage(TextBitmap);
        }

        public Bitmap TextBitmap;

        public Graphics TextGraphics;
        public SizeF MeasureString(string text, Font font)
        {
            return TextGraphics.MeasureString(text, font);
        }

        public SizeF MeasureString(string text, Font font, int width)
        {
            return TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic);
        }

        public GraphicsPath CreateRoundPath;

        public Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

    }

    public class HuraForm : ContainerControl
    {
        public enum ColorSchemes
        {
            Dark
        }
        public event ColorSchemeChangedEventHandler ColorSchemeChanged;
        public delegate void ColorSchemeChangedEventHandler();
        private ColorSchemes _ColorScheme;
        public ColorSchemes ColorScheme {
            get { return _ColorScheme; }
            set {
                _ColorScheme = value;
                if (ColorSchemeChanged != null) {
                    ColorSchemeChanged();
                }
            }
        }
        protected void OnColorSchemeChanged()
        {
            Invalidate();
            switch (ColorScheme) {
                case ColorSchemes.Dark:
                    BackColor = Color.FromArgb(40, 40, 40);
                    Font = new Font("Segoe UI", 9.5f);
                    AccentColor = Color.FromArgb(90, 90, 90);
                    ForeColor = Color.White;
                    break;
            }
        }

        #region " Properties "
        private Color _AccentColor;
        public Color AccentColor {
            get { return _AccentColor; }
            set {
                _AccentColor = value;
                OnAccentColorChanged();
            }
        }
        #endregion

        #region " Constructor "
        public HuraForm() : base()
        {
            AccentColorChanged += OnAccentColorChanged;
            ColorSchemeChanged += OnColorSchemeChanged;
            DoubleBuffered = true;
            Font = new Font("Segoe UI Semilight", 9.75f);
            //AccentColor = Color.FromArgb(150, 0, 150)
            AccentColor = Color.DodgerBlue;
            ColorScheme = ColorSchemes.Dark;
            ForeColor = Color.White;
            BackColor = Color.FromArgb(180, 180, 180);
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
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location)) {
                Cap = true;
                MouseP = e.Location;
            }
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap) {
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

            G.Clear(Color.FromArgb(40, 40, 40));
            G.DrawLine(new Pen(_AccentColor, 1), new Point(0, 30), new Point(Width, 30));
            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(8, 6, Width - 1, Height - 1), StringFormat.GenericDefault);
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


