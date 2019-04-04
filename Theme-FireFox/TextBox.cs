// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.FireFox.Helpers;

namespace Zeroit.Framework.UIThemes.FireFox
{

    [DefaultEvent("TextChanged")]
    public class FirefoxTextbox : Control
    {
        
        #region " Private "
        private TextBox withEventsField_TB = new TextBox();
        private TextBox TB
        {
            get { return withEventsField_TB; }
            set
            {
                if (withEventsField_TB != null)
                {
                    withEventsField_TB.TextChanged -= TextChangeTb;
                }
                withEventsField_TB = value;
                if (withEventsField_TB != null)
                {
                    withEventsField_TB.TextChanged += TextChangeTb;



                }
            }
        }


        private Graphics G;
        private MouseState State;

        private bool IsDown;
        private bool _EnabledCalc;
        private bool _allowpassword = false;
        private int _maxChars = 32767;
        private HorizontalAlignment _textAlignment;
        private bool _multiLine = false;
        #endregion
        private bool _readOnly = false;

        #region " Properties "

        public new bool Enabled
        {
            get { return EnabledCalc; }
            set
            {
                TB.Enabled = value;
                _EnabledCalc = value;
                Invalidate();
            }
        }

        [DisplayName("Enabled")]
        public bool EnabledCalc
        {
            get { return _EnabledCalc; }
            set
            {
                Enabled = value;
                Invalidate();
            }
        }

        public new bool UseSystemPasswordChar
        {
            get { return _allowpassword; }
            set
            {
                TB.UseSystemPasswordChar = UseSystemPasswordChar;
                _allowpassword = value;
                Invalidate();
            }
        }

        public new int MaxLength
        {
            get { return _maxChars; }
            set
            {
                _maxChars = value;
                TB.MaxLength = MaxLength;
                Invalidate();
            }
        }

        public new HorizontalAlignment TextAlign
        {
            get { return _textAlignment; }
            set
            {
                _textAlignment = value;
                Invalidate();
            }
        }

        public new bool MultiLine
        {
            get { return _multiLine; }
            set
            {
                _multiLine = value;
                TB.Multiline = value;
                OnResize(EventArgs.Empty);
                Invalidate();
            }
        }

        public new bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                if (TB != null)
                {
                    TB.ReadOnly = value;
                }
            }
        }

        #endregion

        #region " Control "

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            TB.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            TB.Font = Font;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            TB.Focus();
        }

        private void TextChangeTb(object sender, EventArgs e)
        {
            Text = TB.Text;
        }

        private void TextChng(object sender, EventArgs e)
        {
            TB.Text = Text;
        }

        public void NewTextBox()
        {
            var _with1 = TB;
            _with1.Text = string.Empty;
            _with1.BackColor = Color.White;
            _with1.ForeColor = Color.FromArgb(66, 78, 90);
            _with1.TextAlign = HorizontalAlignment.Left;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(3, 3);
            _with1.Font = Theme.GlobalFont;
            _with1.Size = new Size(Width - 3, Height - 3);
            _with1.UseSystemPasswordChar = UseSystemPasswordChar;
        }

        public FirefoxTextbox() : base()
        {
            TextChanged += TextChng;
            NewTextBox();
            Controls.Add(TB);
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            TextAlign = HorizontalAlignment.Left;
            ForeColor = Color.FromArgb(66, 78, 90);
            Font = Theme.GlobalFont;
            Size = new Size(130, 29);
            Enabled = true;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Parent.BackColor);


            if (Enabled)
            {
                TB.ForeColor = Color.FromArgb(66, 78, 90);

                if (State == MouseState.Down)
                {
                    Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 3, Color.FromArgb(44, 156, 218));
                }
                else
                {
                    Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 3, Helpers.GreyColor(200));
                }

            }
            else
            {
                TB.ForeColor = Helpers.GreyColor(170);
                Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 3, Helpers.GreyColor(230));
            }

            TB.TextAlign = TextAlign;
            TB.UseSystemPasswordChar = UseSystemPasswordChar;

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!MultiLine)
            {
                int tbheight = TB.Height;
                TB.Location = new Point(10, Convert.ToInt32(((Height / 2) - (tbheight / 2) - 0)));
                TB.Size = new Size(Width - 20, tbheight);
            }
            else
            {
                TB.Location = new Point(10, 10);
                TB.Size = new Size(Width - 20, Height - 20);
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            State = MouseState.Down;
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

    }

}


