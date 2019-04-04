// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="HeaderButton.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Empire
{
    public class TheEmpireHeaderButton : Control
    {

        #region "CreateRound"
        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;
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
        #endregion

        #region "Mouse states"
        private MouseStates State;
        public enum MouseStates
        {
            None = 0,
            Over = 1,
            Down = 2
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            State = MouseStates.Over;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            State = MouseStates.None;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            State = MouseStates.Down;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            State = MouseStates.Over;
            Invalidate();
            if (e.Button == MouseButtons.Left)
                base.OnClick(null);
            //This fixes some fucked up lag you get...
            base.OnMouseDown(e);
        }

        //Do nothing here or it fires twice
        protected override void OnClick(EventArgs e)
        {
        }
        #endregion


        Color EmpirePurple = Color.FromArgb(55, 173, 242);
        public TheEmpireHeaderButton()
        {
            Size = new Size(75, 37);
            Text = "Button";
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Font = new Font("Segoe UI", 9);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);

            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(0, 0, Width, 37), Color.FromArgb(36, 36, 36), Color.FromArgb(25, 25, 25), 90f);
            e.Graphics.FillRectangle(LGB, LGB.Rectangle);
            LGB = new LinearGradientBrush(new Rectangle(0, 37, Width, 8), Color.FromArgb(80, Color.Black), Color.Transparent, 90f);
            e.Graphics.FillRectangle(LGB, LGB.Rectangle);
            e.Graphics.FillRectangle(new SolidBrush(EmpirePurple), new Rectangle(0, 35, Width, 2));

            LGB = new LinearGradientBrush(new Rectangle(1, 5, 1, 30), Color.FromArgb(180, EmpirePurple), Color.Transparent, -90f);
            e.Graphics.FillRectangle(LGB, LGB.Rectangle);
            e.Graphics.FillRectangle(LGB, new Rectangle(Width - 2, 5, 1, 30));

            LGB = new LinearGradientBrush(new Rectangle(0, 5, 1, 30), Color.FromArgb(180, Color.Black), Color.Transparent, -90f);
            e.Graphics.FillRectangle(LGB, LGB.Rectangle);
            e.Graphics.FillRectangle(LGB, new Rectangle(Width - 1, 5, 1, 30));

            switch (State)
            {
                case MouseStates.Over:
                    LGB = new LinearGradientBrush(new Rectangle(2, 15, Width - 5, 20), Color.Transparent, Color.FromArgb(15, Color.White), 90f);
                    e.Graphics.FillRectangle(LGB, LGB.Rectangle);
                    break;
                case MouseStates.Down:
                    LGB = new LinearGradientBrush(new Rectangle(2, 13, Width - 5, 22), Color.Transparent, Color.FromArgb(7, Color.White), 90f);
                    e.Graphics.FillRectangle(LGB, LGB.Rectangle);
                    break;
            }

            e.Graphics.DrawString(Text, Font, Brushes.White, new Rectangle(3, 9, Width - 7, Height - 14), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            });

            base.OnPaint(e);
        }

    }


}