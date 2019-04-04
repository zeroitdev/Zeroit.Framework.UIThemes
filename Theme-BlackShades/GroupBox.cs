// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.UIThemes.BlackShades
{

    public class BlackShadesNetGroupBox : ContainerControl
    {

        #region " Control Help - Properties & Flicker Control"
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        #endregion

        public BlackShadesNetGroupBox() : base()
        {
            BackColor = Color.FromArgb(33, 33, 33);
            Size = new Size(200, 100);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.HighSpeed;
            const int curve = 3;
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            Color TransparencyKey = this.ParentForm.TransparencyKey;
            Draw d = new Draw();
            base.OnPaint(e);

            G.Clear(Color.FromArgb(42, 47, 49));



            G.DrawPath(new Pen(Color.FromArgb(67, 75, 78)), d.RoundRect(new Rectangle(2, 7, Width - 5, Height - 9), curve));
            LinearGradientBrush outerBorder = new LinearGradientBrush(ClientRectangle, Color.FromArgb(30, 32, 32), Color.Transparent, 90);
            G.DrawPath(new Pen(outerBorder), d.RoundRect(new Rectangle(1, 6, Width - 3, Height - 9), curve));
            LinearGradientBrush innerBorder = new LinearGradientBrush(new Rectangle(3, 7, Width - 7, Height - 10), Color.Transparent, Color.FromArgb(30, 32, 32), 90);
            G.DrawPath(new Pen(innerBorder), d.RoundRect(new Rectangle(3, 7, Width - 7, Height - 10), curve));

            G.FillRectangle(new SolidBrush(Color.FromArgb(42, 47, 49)), new Rectangle(8, 0, Text.Length * 6, 11));

            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(8, 0, Width - 1, 11), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }


    }

}
