// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SkyLimit
{

    public class SkyDarkRadio : Control
    {

        public enum MouseState
        {
            None,
            Down
        }

        #region "Properties"

        private MouseState ms;
        public MouseState State
        {
            get { return ms; }
            set
            {
                ms = value;
                Invalidate();
            }
        }

        private bool chk;
        public bool Checked
        {
            get { return chk; }
            set
            {
                chk = value;
                Invalidate();
                //'Error code: Whenever I add this it overflows like an infinite loop...
                try
                {
                    if (value)
                    {
                        foreach (SkyDarkRadio ctl_loopVariable in Parent.Controls)
                        {
                            SkyDarkRadio ctl = ctl_loopVariable;
                            if (ctl is SkyDarkRadio)
                            {
                                if ((!object.ReferenceEquals(ctl, this)) & ((SkyDarkRadio)ctl).Enabled)
                                {
                                    ((SkyDarkRadio)ctl).Checked = false;
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        #endregion

        public SkyDarkRadio()
        {
            Size = new Size(Width, 13);
        }

        Color C1 = Color.FromArgb(35, 35, 35);
        Color C2 = Color.Transparent;
        Color C3 = Color.Transparent;
        Color C4 = Color.Transparent;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.Clear(Parent.BackColor);

            switch (Enabled)
            {
                case true:
                    switch (State)
                    {
                        case MouseState.None:
                            C2 = Color.FromArgb(70, 70, 70);
                            C3 = Color.FromArgb(54, 54, 51);
                            C4 = Color.FromArgb(152, 182, 192);
                            break;
                        case MouseState.Down:
                            C2 = Color.FromArgb(54, 54, 51);
                            C3 = Color.FromArgb(70, 70, 70);
                            C4 = Color.FromArgb(112, 142, 152);
                            break;
                    }
                    break;
                case false:
                    C2 = Color.FromArgb(70, 70, 70);
                    C3 = Color.FromArgb(54, 54, 51);
                    C4 = Color.FromArgb(89, 88, 88);
                    break;
            }
            
            Rectangle radRec = new Rectangle(0, 0, Height - 1, Height - 1);
            LinearGradientBrush B1 = new LinearGradientBrush(new Point(radRec.X + radRec.Width / 2, radRec.Y), new Point(radRec.X + radRec.Width / 2, radRec.Y + radRec.Height), C2, C3);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.FillEllipse(B1, radRec);
            G.DrawEllipse(new Pen(ConversionFunctions.ToBrush(C1)), radRec);
            if (Checked)
                G.FillEllipse(ConversionFunctions.ToBrush(C4), new Rectangle(radRec.X + radRec.Width / 4, radRec.Y + radRec.Height / 4, radRec.Width / 2, radRec.Height / 2));
            G.DrawString(Text, Font, ConversionFunctions.ToBrush(C4), new Rectangle(radRec.X + radRec.Width + 5, 0, Width - radRec.X - radRec.Width - 5, Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });


            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (Enabled)
            {
                State = MouseState.None;
                if (!Checked)
                {
                    Checked = true;
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!Enabled)
                State = MouseState.Down;
        }
    }

}