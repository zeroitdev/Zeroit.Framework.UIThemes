// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Valley
{
    #region  Mouse States

    internal enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }

    #endregion

    public class ValleyTheme : ContainerControl
    {
        #region Variables
        private bool Cap = false;
        private Point MousePoint = new Point(0, 0);
        private object MoveHeight = 36;
        #endregion

        #region Properties

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.AllowTransparency = false;
            ParentForm.TransparencyKey = Color.Fuchsia;
            ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;
            Dock = DockStyle.Fill;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && (new Rectangle(0, 0, Width, Convert.ToInt32(MoveHeight))).Contains(e.Location))
            {
                Cap = true;
                MousePoint = e.Location;
            }
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MousePoint.X, MousePosition.Y - MousePoint.Y);
            }
        }
        #endregion

        public ValleyTheme()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(242, 242, 242);
            Font = new Font("Segoe UI", 9);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;

            G.Clear(Color.FromArgb(22, 22, 22));
            G.DrawRectangle(new Pen(Color.FromArgb(38, 38, 38)), new Rectangle(0, 0, Width - 1, Height - 1));
            G.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, 36), Color.FromArgb(50, 50, 50), Color.FromArgb(47, 47, 47)), new Rectangle(1, 1, Width - 2, 36));
            G.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(45, 45, 45), Color.FromArgb(23, 23, 23)), new Rectangle(1, 36, Width - 2, Height - 46));

            G.DrawRectangle(new Pen(Color.FromArgb(38, 38, 38)), new Rectangle(9, 35, Width - 19, Height - 45));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(10, 36, Width - 20, Height - 46));

            G.FillRectangle(new SolidBrush(Color.FromArgb(47, 47, 47)), new Rectangle(9, 35, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(47, 47, 47)), new Rectangle(Width - 10, 35, 1, 1));

            G.FillRectangle(new SolidBrush(Color.Fuchsia), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.Fuchsia), new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.Fuchsia), new Rectangle(0, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.Fuchsia), new Rectangle(Width - 1, Height - 1, 1, 1));

            G.DrawString(FindForm().Text, new Font("Segoe UI", 10), new SolidBrush(Color.FromArgb(242, 242, 242)), new Point(12, 6));
            base.OnPaint(e);


        }
    }
    
}


