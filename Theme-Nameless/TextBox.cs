// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Nameless
{
    public class NamelessTextBox : ThemeControl154
    {
        #region "Properties"
        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        public HorizontalAlignment TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                if (Base != null)
                {
                    Base.TextAlign = value;
                }
            }
        }
        private int _MaxLength = 32767;
        public int MaxLength
        {
            get { return _MaxLength; }
            set
            {
                _MaxLength = value;
                if (Base != null)
                {
                    Base.MaxLength = value;
                }
            }
        }
        private bool _UseSystemPasswordChar;
        public bool UseSystemPasswordChar
        {
            get { return _UseSystemPasswordChar; }
            set
            {
                _UseSystemPasswordChar = value;
                if (Base != null)
                {
                    Base.UseSystemPasswordChar = value;
                }
            }
        }
        private bool _Multiline;
        public bool Multiline
        {
            get { return _Multiline; }
            set
            {
                _Multiline = value;
                if (Base != null)
                {
                    Base.Multiline = value;

                    if (value)
                    {
                        LockHeight = 0;
                        Base.Height = Height - 11;
                    }
                    else
                    {
                        LockHeight = Base.Height + 11;
                    }
                }
            }
        }
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                if (Base != null)
                {
                    Base.Text = value;
                }
            }
        }
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                if (Base != null)
                {
                    Base.Font = value;
                    Base.Location = new Point(3, 5);
                    Base.Width = Width - 6;

                    if (!_Multiline)
                    {
                        LockHeight = Base.Height + 11;
                    }
                }
            }
        }
        #endregion
        protected override void OnCreation()
        {
            if (!Controls.Contains(Base))
            {
                Controls.Add(Base);
            }
        }

        private TextBox Base;
        public NamelessTextBox()
        {
            Base = new TextBox();

            Base.Font = Font;
            Base.Text = Text;
            Base.MaxLength = _MaxLength;
            Base.Multiline = _Multiline;
            Base.UseSystemPasswordChar = _UseSystemPasswordChar;
            Base.BackColor = Color.Black;
            Base.ForeColor = Color.White;
            Base.BorderStyle = BorderStyle.None;

            Base.Location = new Point(5, 5);
            Base.Width = Width - 10;

            if (_Multiline)
            {
                Base.Height = Height - 11;
            }
            else
            {
                LockHeight = Base.Height + 11;
            }




        }




        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.HighQuality;



            G.Clear(Color.Black);

            LinearGradientBrush innerBorderBrush = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 3), Color.FromArgb(40, 40, 40), Color.FromArgb(90, 90, 90), 90);
            Pen innerBorderPen = new Pen(innerBorderBrush);
            G.DrawRectangle(innerBorderPen, new Rectangle(1, 1, Width - 3, Height - 3));

            G.FillRectangle(new SolidBrush(Color.FromArgb(22, 22, 22)), ClientRectangle);
            G.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), new Rectangle(0, 0, Width - 1, Height - 1));

        }
        protected override void OnResize(EventArgs e)
        {
            Base.Location = new Point(5, 5);
            Base.Width = Width - 10;

            if (_Multiline)
            {
                Base.Height = Height - 11;
            }

            base.OnResize(e);
        }
    }

}