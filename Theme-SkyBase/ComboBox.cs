// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
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

    public class SkyDarkCombo : ComboBox
    {
        public SkyDarkCombo() : base()
        {
            TextChanged += SkyDarkCombo_TextChanged;
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.FromArgb(235, 235, 235);
            ForeColor = Color.FromArgb(31, 31, 31);
            DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private int _StartIndex = 0;
        public int StartIndex
        {
            get { return _StartIndex; }
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }

        Color C1 = Color.FromArgb(48, 48, 48);
        Color C2 = Color.FromArgb(81, 79, 77);

        Color C3 = Color.FromArgb(62, 60, 58);
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(DropDownStyle == ComboBoxStyle.DropDownList))
                DropDownStyle = ComboBoxStyle.DropDownList;
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.Clear(C3);


            int S1 = (int)G.MeasureString("...", Font).Height;

            if (SelectedIndex != -1)
            {
                G.DrawString(Items[SelectedIndex].ToString(), Font, ConversionFunctions.ToBrush(152, 182, 192), 4, Height / 2 - S1 / 2);
            }
            else
            {
                if ((Items != null) & Items.Count > 0)
                {
                    G.DrawString(Items[0].ToString(), Font, ConversionFunctions.ToBrush(152, 182, 192), 4, Height / 2 - S1 / 2);
                }
                else
                {
                    G.DrawString("...", Font, ConversionFunctions.ToBrush(152, 182, 192), 4, Height / 2 - S1 / 2);
                }
            }

            LinearGradientBrush G1 = new LinearGradientBrush(new Point(Width - 30, Height / 2), new Point(Width - 22, Height / 2), Color.Transparent, C3);
            G.FillRectangle(G1, Width - 30, 0, 8, Height);

            G.DrawRectangle(ConversionFunctions.ToPen(C1), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(ConversionFunctions.ToPen(C1), new Point(Width - 21, 0), new Point(Width - 21, Height));

            G.DrawRectangle(ConversionFunctions.ToPen(C2), 1, 1, Width - 23, Height - 3);

            G.FillRectangle(ConversionFunctions.ToBrush(C3), Width - 20, 1, 18, Height - 3);
            G.FillRectangle(ConversionFunctions.ToBrush(10, Color.White), Width - 20, 1, 18, Height - 3);
            G.DrawRectangle(ConversionFunctions.ToPen(C2), Width - 20, 1, 18, Height - 3);

            G.FillPolygon(Brushes.Black, Shapes.Triangle(new Point(Width - 12, Height / 2), new Size(5, 3)));
            G.FillPolygon(Brushes.LightBlue, Shapes.Triangle(new Point(Width - 13, Height / 2 - 1), new Size(5, 3)));

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
        public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics G = e.Graphics;
            Color C4 = Color.Empty;
            e.DrawBackground();
            try
            {
                if (e.State == DrawItemState.Selected && e.State == DrawItemState.Focus)
                {
                    G.FillRectangle(ConversionFunctions.ToBrush(50, 80, 120), new Rectangle(e.Bounds.X - 1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height + 2));
                    G.DrawRectangle(new Pen(ConversionFunctions.ToBrush(180, Color.Black), 1), new Rectangle(e.Bounds.X - 1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height + 2));
                    C4 = Color.FromArgb(100, 165, 185);
                }
                else
                {
                    G.FillRectangle(ConversionFunctions.ToBrush(62, 60, 58), new Rectangle(e.Bounds.X - 1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height + 2));
                    C4 = Color.FromArgb(200, 200, 200);
                }

                G.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, ConversionFunctions.ToBrush(C4), e.Bounds, new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
            }
            catch
            {
            }
        }
        
        private void SkyDarkCombo_TextChanged(object sender, System.EventArgs e)
        {
            Invalidate();
        }
    }

}