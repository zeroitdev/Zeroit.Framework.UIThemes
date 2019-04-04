// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBoxRound.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GameBooster
{
    [DefaultEvent("TextChanged")]
    public class GameBoosterTextBoxRound : ThemeControl154
    {

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
        private bool _ReadOnly;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (Base != null)
                {
                    Base.ReadOnly = value;
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

        protected override void OnCreation()
        {
            if (!Controls.Contains(Base))
            {
                Controls.Add(Base);
            }
        }

        private TextBox Base;
        public GameBoosterTextBoxRound()
        {
            Base = new TextBox();

            Base.Font = Font;
            Base.Text = Text;
            Base.MaxLength = _MaxLength;
            Base.Multiline = _Multiline;
            Base.ReadOnly = _ReadOnly;
            Base.UseSystemPasswordChar = _UseSystemPasswordChar;

            Base.BorderStyle = BorderStyle.None;

            Base.Location = new Point(4, 4);
            Base.Width = Width - 10;

            if (_Multiline)
            {
                Base.Height = Height - 11;
            }
            else
            {
                LockHeight = Base.Height + 11;
            }

            Base.TextChanged += OnBaseTextChanged;
            Base.KeyDown += OnBaseKeyDown;
        }


        protected override void ColorHook()
        {
            Base.ForeColor = Color.FromArgb(204, 204, 204);
            Base.BackColor = Color.FromArgb(32, 32, 32);
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(32, 32, 32));

            G.DrawLine(new Pen(Color.FromArgb(23, 23, 23)), 0, 0, Width, 0);
            G.DrawLine(new Pen(Color.FromArgb(28, 28, 28)), 0, 1, Width, 1);
            G.DrawLine(new Pen(Color.FromArgb(31, 31, 31)), 0, 2, Width, 2);

            G.DrawLine(new Pen(Color.FromArgb(29, 29, 29)), 0, Height - 2, Width, Height - 2);
            G.DrawLine(new Pen(Color.FromArgb(70, 70, 70)), 0, Height - 1, Width, Height - 1);
            DrawPixel(Color.FromArgb(51, 51, 51), 0, 0);
            DrawPixel(Color.FromArgb(51, 51, 51), 0, 1);
            DrawPixel(Color.FromArgb(44, 44, 44), 0, 2);
            DrawPixel(Color.FromArgb(28, 28, 28), 0, 3);
            DrawPixel(Color.FromArgb(24, 24, 24), 0, 4);
            DrawPixel(Color.FromArgb(22, 22, 22), 0, 5);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 6);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 7);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 8);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 9);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 10);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 11);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 12);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 13);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 14);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 15);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 16);
            DrawPixel(Color.FromArgb(23, 23, 23), 0, 17);
            DrawPixel(Color.FromArgb(25, 25, 25), 0, 18);
            DrawPixel(Color.FromArgb(29, 29, 29), 0, 19);
            DrawPixel(Color.FromArgb(44, 44, 44), 0, 20);
            DrawPixel(Color.FromArgb(51, 51, 51), 0, 21);
            DrawPixel(Color.FromArgb(51, 51, 51), 0, 22);
            DrawPixel(Color.FromArgb(51, 51, 51), 0, 23);
            DrawPixel(Color.FromArgb(51, 51, 51), 1, 0);
            DrawPixel(Color.FromArgb(37, 37, 37), 1, 1);
            DrawPixel(Color.FromArgb(23, 23, 23), 1, 2);
            DrawPixel(Color.FromArgb(24, 24, 24), 1, 3);
            DrawPixel(Color.FromArgb(27, 27, 27), 1, 4);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 5);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 6);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 7);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 8);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 9);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 10);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 11);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 12);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 13);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 14);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 15);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 16);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 17);
            DrawPixel(Color.FromArgb(28, 28, 28), 1, 18);
            DrawPixel(Color.FromArgb(27, 27, 27), 1, 19);
            DrawPixel(Color.FromArgb(26, 26, 26), 1, 20);
            DrawPixel(Color.FromArgb(40, 40, 40), 1, 21);
            DrawPixel(Color.FromArgb(51, 51, 51), 1, 22);
            DrawPixel(Color.FromArgb(51, 51, 51), 1, 23);
            DrawPixel(Color.FromArgb(44, 44, 44), 2, 0);
            DrawPixel(Color.FromArgb(22, 22, 22), 2, 1);
            DrawPixel(Color.FromArgb(26, 26, 26), 2, 2);
            DrawPixel(Color.FromArgb(28, 28, 28), 2, 3);
            DrawPixel(Color.FromArgb(29, 29, 29), 2, 4);
            DrawPixel(Color.FromArgb(30, 30, 30), 2, 5);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 6);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 7);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 8);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 9);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 10);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 11);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 12);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 13);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 14);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 15);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 16);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 17);
            DrawPixel(Color.FromArgb(31, 31, 31), 2, 18);
            DrawPixel(Color.FromArgb(30, 30, 30), 2, 19);
            DrawPixel(Color.FromArgb(29, 29, 29), 2, 20);
            DrawPixel(Color.FromArgb(26, 26, 26), 2, 21);
            DrawPixel(Color.FromArgb(51, 51, 51), 2, 22);
            DrawPixel(Color.FromArgb(51, 51, 51), 2, 23);
            DrawPixel(Color.FromArgb(31, 31, 31), 3, 0);
            DrawPixel(Color.FromArgb(24, 24, 24), 3, 1);
            DrawPixel(Color.FromArgb(28, 28, 28), 3, 2);
            DrawPixel(Color.FromArgb(30, 30, 30), 3, 3);
            DrawPixel(Color.FromArgb(31, 31, 31), 3, 4);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 5);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 6);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 7);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 8);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 9);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 10);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 11);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 12);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 13);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 14);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 15);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 16);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 17);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 18);
            DrawPixel(Color.FromArgb(32, 32, 32), 3, 19);
            DrawPixel(Color.FromArgb(31, 31, 31), 3, 20);
            DrawPixel(Color.FromArgb(29, 29, 29), 3, 21);
            DrawPixel(Color.FromArgb(40, 40, 40), 3, 22);
            DrawPixel(Color.FromArgb(56, 56, 56), 3, 23);
            DrawPixel(Color.FromArgb(25, 25, 25), 4, 0);
            DrawPixel(Color.FromArgb(26, 26, 26), 4, 1);
            DrawPixel(Color.FromArgb(29, 29, 29), 4, 2);
            DrawPixel(Color.FromArgb(31, 31, 31), 4, 3);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 4);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 5);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 6);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 7);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 8);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 9);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 10);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 11);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 12);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 13);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 14);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 15);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 16);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 17);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 18);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 19);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 20);
            DrawPixel(Color.FromArgb(31, 31, 31), 4, 21);
            DrawPixel(Color.FromArgb(32, 32, 32), 4, 22);
            DrawPixel(Color.FromArgb(64, 64, 64), 4, 23);

            DrawPixel(Color.FromArgb(51, 51, 51), Width - 0, 0);
            DrawPixel(Color.FromArgb(51, 51, 51), Width - 0, 1);
            DrawPixel(Color.FromArgb(44, 44, 44), Width - 0, 2);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 0, 3);
            DrawPixel(Color.FromArgb(24, 24, 24), Width - 0, 4);
            DrawPixel(Color.FromArgb(22, 22, 22), Width - 0, 5);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 6);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 7);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 8);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 9);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 10);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 11);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 12);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 13);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 14);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 15);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 16);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 0, 17);
            DrawPixel(Color.FromArgb(25, 25, 25), Width - 0, 18);
            DrawPixel(Color.FromArgb(29, 29, 29), Width - 0, 19);
            DrawPixel(Color.FromArgb(44, 44, 44), Width - 0, 20);
            DrawPixel(Color.FromArgb(51, 51, 51), Width - 0, 21);
            DrawPixel(Color.FromArgb(51, 51, 51), Width - 0, 22);
            DrawPixel(Color.FromArgb(51, 51, 51), Width - 0, 23);
            DrawPixel(Color.FromArgb(51, 51, 51), Width - 1, 0);
            DrawPixel(Color.FromArgb(37, 37, 37), Width - 1, 1);
            DrawPixel(Color.FromArgb(23, 23, 23), Width - 1, 2);
            DrawPixel(Color.FromArgb(24, 24, 24), Width - 1, 3);
            DrawPixel(Color.FromArgb(27, 27, 27), Width - 1, 4);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 5);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 6);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 7);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 8);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 9);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 10);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 11);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 12);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 13);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 14);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 15);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 16);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 17);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 1, 18);
            DrawPixel(Color.FromArgb(27, 27, 27), Width - 1, 19);
            DrawPixel(Color.FromArgb(26, 26, 26), Width - 1, 20);
            DrawPixel(Color.FromArgb(40, 40, 40), Width - 1, 21);
            DrawPixel(Color.FromArgb(51, 51, 51), Width - 1, 22);
            DrawPixel(Color.FromArgb(51, 51, 51), Width - 1, 23);
            DrawPixel(Color.FromArgb(44, 44, 44), Width - 2, 0);
            DrawPixel(Color.FromArgb(22, 22, 22), Width - 2, 1);
            DrawPixel(Color.FromArgb(26, 26, 26), Width - 2, 2);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 2, 3);
            DrawPixel(Color.FromArgb(29, 29, 29), Width - 2, 4);
            DrawPixel(Color.FromArgb(30, 30, 30), Width - 2, 5);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 6);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 7);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 8);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 9);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 10);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 11);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 12);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 13);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 14);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 15);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 16);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 17);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 2, 18);
            DrawPixel(Color.FromArgb(30, 30, 30), Width - 2, 19);
            DrawPixel(Color.FromArgb(29, 29, 29), Width - 2, 20);
            DrawPixel(Color.FromArgb(26, 26, 26), Width - 2, 21);
            DrawPixel(Color.FromArgb(51, 51, 51), Width - 2, 22);
            DrawPixel(Color.FromArgb(51, 51, 51), Width - 2, 23);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 3, 0);
            DrawPixel(Color.FromArgb(24, 24, 24), Width - 3, 1);
            DrawPixel(Color.FromArgb(28, 28, 28), Width - 3, 2);
            DrawPixel(Color.FromArgb(30, 30, 30), Width - 3, 3);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 3, 4);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 5);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 6);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 7);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 8);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 9);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 10);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 11);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 12);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 13);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 14);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 15);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 16);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 17);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 18);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 3, 19);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 3, 20);
            DrawPixel(Color.FromArgb(29, 29, 29), Width - 3, 21);
            DrawPixel(Color.FromArgb(40, 40, 40), Width - 3, 22);
            DrawPixel(Color.FromArgb(56, 56, 56), Width - 3, 23);
            DrawPixel(Color.FromArgb(25, 25, 25), Width - 4, 0);
            DrawPixel(Color.FromArgb(26, 26, 26), Width - 4, 1);
            DrawPixel(Color.FromArgb(29, 29, 29), Width - 4, 2);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 4, 3);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 4);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 5);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 6);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 7);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 8);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 9);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 10);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 11);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 12);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 13);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 14);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 15);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 16);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 17);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 18);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 19);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 20);
            DrawPixel(Color.FromArgb(31, 31, 31), Width - 4, 21);
            DrawPixel(Color.FromArgb(32, 32, 32), Width - 4, 22);
            DrawPixel(Color.FromArgb(64, 64, 64), Width - 4, 23);


        }
        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = Base.Text;
        }
        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                Base.SelectAll();
                e.SuppressKeyPress = true;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            Base.Location = new Point(4, 5);
            Base.Width = Width - 8;

            if (_Multiline)
            {
                Base.Height = Height - 5;
            }


            base.OnResize(e);
        }

    }

}


