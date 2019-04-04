// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="DropDownCombo.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.VibeLander
{
    public class VibeDropDownComboBox : ComboBox
    {
        private int X;

        private bool Over;
        public VibeDropDownComboBox() : base()
        {
            TextChanged += GhostCombo_TextChanged;
            DropDownClosed += GhostComboBox_DropDownClosed;
            DropDown += GhostComboBox_DropDown;
            Font = new Font("Tahoma", 9, FontStyle.Regular);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 25;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            Over = true;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            Over = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.Font = new Font("Tahoma", 9, FontStyle.Regular);
            SolidBrush bs = new SolidBrush(this.ForeColor);
            if (!(DropDownStyle == ComboBoxStyle.DropDownList))
                DropDownStyle = ComboBoxStyle.DropDownList;
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Font m = new Font("Marlett", 11);
            G.Clear(Color.FromArgb(50, 50, 50));
            LinearGradientBrush GradientBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(234, 234, 234), Color.FromArgb(242, 242, 242), 270f);
            G.FillRectangle(GradientBrush, new Rectangle(0, 0, Width, Height));


            Pen op = new Pen(Color.FromArgb(204, 204, 204), 1);
            Pen o = new Pen(Color.FromArgb(237, 237, 237), 6);

            G.DrawPath(o, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            G.DrawPath(op, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));

            if (X >= Width - 20 & Over)
            {
                GradientBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(239, 239, 239), Color.FromArgb(236, 236, 236), 90f);
                G.FillRectangle(GradientBrush, new Rectangle(Width - 22, 2, 20, Height - 4));
            }
            else if (X < Width - 20 & Over)
            {
                GradientBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(239, 239, 239), Color.FromArgb(236, 236, 236), 90f);
                G.FillRectangle(GradientBrush, new Rectangle(2, 2, Width - 27, Height - 4));
            }

            int S1 = (int)G.MeasureString(" ... ", Font).Height;
            if (SelectedIndex != -1)
            {
                G.DrawString(Items[SelectedIndex].ToString(), Font, bs, 4, (Height / 2 - S1 / 2));
                G.DrawString("6", m, bs, Width - 22, (Height / 2 - S1 / 2));
            }
            else
            {
                if ((Items != null) & Items.Count > 0)
                {
                    G.DrawString(Items[0].ToString(), Font, bs, 4, (Height / 2 - S1 / 2));
                    G.DrawString("6", m, bs, Width - 22, (Height / 2 - S1 / 2));
                }
                else
                {
                    G.DrawString(" ... ", Font, bs, 4, (Height / 2 - S1 / 2));
                    G.DrawString("6", m, bs, Width - 22, (Height / 2 - S1 / 2));
                }
            }
            G.DrawLine(new Pen(Color.FromArgb(120, 255, 255, 255)), 1, 1, Width - 3, 1);
            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);

            G.Dispose();
            B.Dispose();

        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Rectangle rect = new Rectangle();
            rect.X = e.Bounds.X;
            rect.Y = e.Bounds.Y;
            rect.Width = e.Bounds.Width - 1;
            rect.Height = e.Bounds.Height - 1;

            e.DrawBackground();
            if (e.State == DrawItemState.Selected | e.State == DrawItemState.Focus)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(235, 235, 235)), e.Bounds);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, this.ForeColor)), e.Bounds);
                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y + 5);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y + 4);
            }
            base.OnDrawItem(e);
        }


        private void GhostComboBox_DropDown(object sender, System.EventArgs e)
        {
        }

        private void GhostComboBox_DropDownClosed(object sender, System.EventArgs e)
        {
            DropDownStyle = ComboBoxStyle.Simple;
            Application.DoEvents();
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void GhostCombo_TextChanged(object sender, System.EventArgs e)
        {
            Invalidate();
        }
    }


}

