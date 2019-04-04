// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupDropBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.VibeLander
{

    public class VibeGroupDropBox : ThemeContainerControl
    {
        private bool _Checked;
        private int X;
        private int y;

        private Size _OpenedSize;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }
        public Size OpenSize
        {
            get { return _OpenedSize; }
            set
            {
                _OpenedSize = value;
                Invalidate();
            }
        }
        public VibeGroupDropBox()
        {
            MouseDown += changeCheck;
            Resize += meResize;
            AllowTransparent();
            Size = new Size(90, 30);
            MinimumSize = new Size(5, 30);
            _Checked = true;
        }
        public override void PaintHook()
        {
            this.Font = new Font("Tahoma", 10);
            this.ForeColor = Color.FromArgb(40, 40, 40);
            if (_Checked == true)
            {
                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.Clear(Color.FromArgb(245, 245, 245));
                G.FillRectangle(new SolidBrush(Color.FromArgb(231, 231, 231)), new Rectangle(0, 0, Width, 30));
                G.DrawLine(new Pen(Color.FromArgb(237, 237, 237)), 1, 1, Width - 2, 1);
                G.DrawRectangle(new Pen(Color.FromArgb(214, 214, 214)), 0, 0, Width - 1, Height - 1);
                G.DrawRectangle(new Pen(Color.FromArgb(214, 214, 214)), 0, 0, Width - 1, 30);
                this.Size = _OpenedSize;
                G.DrawString("t", new Font("Marlett", 12), new SolidBrush(this.ForeColor), Width - 25, 5);
            }
            else
            {
                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.Clear(Color.FromArgb(245, 245, 245));
                G.FillRectangle(new SolidBrush(Color.FromArgb(231, 231, 231)), new Rectangle(0, 0, Width, 30));
                G.DrawLine(new Pen(Color.FromArgb(237, 237, 237)), 1, 1, Width - 2, 1);
                G.DrawRectangle(new Pen(Color.FromArgb(214, 214, 214)), 0, 0, Width - 1, Height - 1);
                G.DrawRectangle(new Pen(Color.FromArgb(214, 214, 214)), 0, 0, Width - 1, 30);
                this.Size = new Size(Width, 30);
                G.DrawString("u", new Font("Marlett", 12), new SolidBrush(this.ForeColor), Width - 25, 5);
            }
            G.DrawString(Text, Font, new SolidBrush(this.ForeColor), 7, 6);
        }

        private void meResize(object sender, System.EventArgs e)
        {
            if (_Checked == true)
            {
                _OpenedSize = this.Size;
            }
            else
            {
            }
        }


        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            y = e.Y;
            Invalidate();
        }


        public void changeCheck(object sender, EventArgs e)
        {

            if (X >= Width - 22)
            {
                if (y <= 30)
                {
                    switch (Checked)
                    {
                        case true:
                            Checked = false;
                            break;
                        case false:
                            Checked = true;
                            break;
                    }
                }
            }
        }
    }

}

