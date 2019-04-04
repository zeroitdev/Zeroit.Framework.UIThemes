// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="BigTextBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Babylon
{
    #region  Big TextBox 

    [DefaultEvent("TextChanged")]
    public class BabylonTextBoxBig : Control
    {
        #region  Variables 

        public TextBox BabylonTB = new TextBox();
        private GraphicsPath Shape;
        private int _maxchars = 32767;
        private bool _ReadOnly;
        private bool _Multiline;
        private Image _Image;
        private Size _ImageSize;
        private HorizontalAlignment ALNType;
        private bool isPasswordMasked = false;
        private Pen P1;
        private SolidBrush B1;

        #endregion
        #region  Properties 

        public new HorizontalAlignment TextAlignment
        {
            get
            {
                return ALNType;
            }
            set
            {
                ALNType = value;
                Invalidate();
            }
        }
        public new int MaxLength
        {
            get
            {
                return _maxchars;
            }
            set
            {
                _maxchars = value;
                BabylonTB.MaxLength = MaxLength;
                Invalidate();
            }
        }

        public new bool UseSystemPasswordChar
        {
            get
            {
                return isPasswordMasked;
            }
            set
            {
                BabylonTB.UseSystemPasswordChar = UseSystemPasswordChar;
                isPasswordMasked = value;
                Invalidate();
            }
        }
        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
                if (BabylonTB != null)
                {
                    BabylonTB.ReadOnly = value;
                }
            }
        }
        public bool Multiline
        {
            get
            {
                return _Multiline;
            }
            set
            {
                _Multiline = value;
                if (BabylonTB != null)
                {
                    BabylonTB.Multiline = value;

                    if (value)
                    {
                        BabylonTB.Height = Height - 23;
                    }
                    else
                    {
                        Height = BabylonTB.Height + 23;
                    }
                }
            }
        }

        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;

                if (Image == null)
                {
                    BabylonTB.Location = new Point(8, 10);
                }
                else
                {
                    BabylonTB.Location = new Point(35, 11);
                }
                Invalidate();
            }
        }

        protected Size ImageSize
        {
            get
            {
                return _ImageSize;
            }
        }

        #endregion
        #region  EventArgs 

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            BabylonTB.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            BabylonTB.Font = Font;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void _OnKeyDown(object Obj, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                BabylonTB.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                BabylonTB.Copy();
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            if (_Multiline)
            {
                BabylonTB.Height = Height - 23;
            }
            else
            {
                Height = BabylonTB.Height + 23;
            }

            Shape = new GraphicsPath();
            Shape.AddArc(0, 0, 10, 10, 180, 90);
            Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            Shape.CloseAllFigures();
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            BabylonTB.Focus();
        }

        public void _TextChanged(object sender, EventArgs e)
        {
            Text = BabylonTB.Text;
        }

        public void _BaseTextChanged(object sender, EventArgs e)
        {
            BabylonTB.Text = Text;
        }

        #endregion

        public void AddTextBox()
        {
            BabylonTB.Location = new Point(7, 10);
            BabylonTB.Text = string.Empty;
            BabylonTB.BorderStyle = BorderStyle.None;
            BabylonTB.TextAlign = HorizontalAlignment.Left;
            BabylonTB.Font = new Font("Tahoma", 11);
            BabylonTB.UseSystemPasswordChar = UseSystemPasswordChar;
            BabylonTB.Multiline = false;
            BabylonTB.KeyDown += _OnKeyDown;
        }

        public BabylonTextBoxBig()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            AddTextBox();
            Controls.Add(BabylonTB);

            P1 = new Pen(Color.FromArgb(180, 180, 180));
            B1 = new SolidBrush(Color.White);
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;

            Text = null;
            Font = new Font("Tahoma", 11);
            Size = new Size(135, 43);
            DoubleBuffered = true;
            SubscribeToEvents();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.AntiAlias;


            if (Image == null)
            {
                BabylonTB.Width = Width - 18;
            }
            else
            {
                BabylonTB.Width = Width - 45;
            }

            BabylonTB.TextAlign = TextAlignment;
            BabylonTB.UseSystemPasswordChar = UseSystemPasswordChar;

            G.Clear(Color.Transparent);
            G.FillPath(B1, Shape); // Draw background
            G.DrawPath(P1, Shape); // Draw border

            if (Image != null)
            {
                G.DrawImage(_Image, 5, 8, 24, 24);
                // 24x24 is the perfect size of the image
            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            BabylonTB.TextChanged += _TextChanged;
            base.TextChanged += _BaseTextChanged;
        }

    }

    #endregion
}