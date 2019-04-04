// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlButton.cs" company="Zeroit Dev Technologies">
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

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.CarbonFibre
{
    public class CarbonFiberControlButton : ThemeControl154
    {
        #region "Properties"
        public CarbonFiberControlButton()
        {
            this.Size = new Size(26, 20);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }
        private bool _StateMinimize = false;
        public bool StateMinimize
        {
            get { return _StateMinimize; }
            set
            {
                _StateMinimize = value;
                Invalidate();
            }
        }

        private bool _StateClose = false;
        public bool StateClose
        {
            get { return _StateClose; }
            set
            {
                _StateClose = value;
                Invalidate();
            }
        }

        private bool _StateMaximize = false;
        public bool StateMaximize
        {
            get { return _StateMaximize; }
            set
            {
                _StateMaximize = value;
                Invalidate();
            }
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(26, 20);
        }
        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (_StateMinimize == true)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
                // true
                // Else
                _StateClose = false;
                // false
                _StateMaximize = false;
            }
            if (_StateClose == true)
            {
                Parent.FindForm().Close();
                //Else
                _StateMinimize = false;
                _StateMaximize = false;
            }
            if (_StateMaximize == true)
            {
                if (Parent.FindForm().WindowState != FormWindowState.Maximized)
                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                else
                    Parent.FindForm().WindowState = FormWindowState.Normal;

                _StateClose = false;
                // false
                _StateMinimize = false;
            }
        }


        protected override void ColorHook()
        {
        }
        #endregion
        #region "Color Of Control"
        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));
            G.SmoothingMode = SmoothingMode.HighQuality;

            LinearGradientBrush Header = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(22, 22, 22), Color.FromArgb(35, 35, 35), 270);
            G.FillRectangle(Header, new Rectangle(0, 0, Width - 1, Height - 1));

            HatchBrush HeaderHatch = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
            G.FillRectangle(HeaderHatch, new Rectangle(0, 0, Width - 1, Height - 1));

            G.FillRectangle(new SolidBrush(Color.FromArgb(8, Color.White)), 0, 0, Width - 1, 10);
            G.DrawLine(new Pen(Color.FromArgb(33, 33, 33)), 0, 9, Width - 1, 10);
            // Cuz it has a bug dont worry i will fix it =)

            switch (State)
            {
                case MouseState.Over:
                    LinearGradientBrush Header1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(40, 40, 40), 270);
                    G.FillRectangle(Header1, new Rectangle(0, 0, Width - 1, Height - 1));
                    HatchBrush HeaderHatch1 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
                    G.FillRectangle(HeaderHatch1, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(10, Color.White)), 0, 0, Width - 1, 10);
                    G.DrawLine(new Pen(Color.FromArgb(38, 38, 38)), 0, 9, Width - 1, 10);
                    // Cuz it has a bug dont worry i will fix it =)
                    break;
                case MouseState.Down:
                    LinearGradientBrush Header2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(35, 35, 35), 270);
                    G.FillRectangle(Header2, new Rectangle(0, 0, Width - 1, Height - 1));
                    HatchBrush HeaderHatch2 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
                    G.FillRectangle(HeaderHatch2, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(8, Color.White)), 0, 0, Width - 1, 10);
                    G.DrawLine(new Pen(Color.FromArgb(35, 35, 35)), 0, 9, Width - 1, 10);
                    // Cuz it has a bug dont worry i will fix it =)
                    break;

            }
            //Draw Text


            if (_StateMinimize == true)
            {
                G.DrawString("0", new Font("Marlett", 8), new SolidBrush(Color.FromArgb(255, 150, 0)), new Point(6, 4));
                _StateClose = false;
                // false
                _StateMaximize = false;
            }
            if (_StateClose == true)
            {
                G.DrawString("r", new Font("Marlett", 8), new SolidBrush(Color.FromArgb(255, 150, 0)), new Point(6, 4));
                _StateMinimize = false;
                _StateMaximize = false;
            }

            if (_StateMaximize == true)
            {
                if (Parent.FindForm().WindowState != FormWindowState.Maximized)
                    G.DrawString("1", new Font("Marlett", 8), new SolidBrush(Color.FromArgb(255, 150, 0)), new Point(6, 4));
                else
                    G.DrawString("2", new Font("Marlett", 8), new SolidBrush(Color.FromArgb(255, 150, 0)), new Point(6, 4));
                _StateClose = false;
                // false
                _StateMinimize = false;
            }


            //Draw Gloss
            //Draw Border
            DrawBorders(Pens.Black);
            // DrawBorders(New Pen(Color.FromArgb(32, 32, 32)))
        }
        #endregion
    }

}


