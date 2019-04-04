// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Text;
using System.Windows.Forms;




namespace Zeroit.Framework.UIThemes.BasicCode
{


    public class BCEvoTabControl : TabControl
    {

        private Color Light = Color.FromArgb(180, 180, 180);
        private Color Lighter = Color.FromArgb(230, 230, 230);
        private LinearGradientBrush DrawGradientBrush;
        private Color _ControlBColor;
        private Graphics G;
        public BCEvoTabControl() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }
        private LinearGradientBrush TCBrush;
        private LinearGradientBrush TCIBrush;
        private SolidBrush TCTBrush = new SolidBrush(Color.Empty);
        private SolidBrush TCIGBrush;
        private Rectangle TCItemB;
        private Rectangle TCItemR;
        private Rectangle TCItemG;
        private StringFormat TCTAT = new StringFormat();
        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            TCBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(255, 55, 55, 55), Color.FromArgb(255, 22, 22, 22), LinearGradientMode.Vertical);
            TCIBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(100, 0, 0), Color.FromArgb(60, 0, 0), LinearGradientMode.Vertical);
            TCIGBrush = new SolidBrush(Color.FromArgb(25, Color.White));
            TCTAT.LineAlignment = StringAlignment.Center;
            TCTAT.Alignment = StringAlignment.Center;

            G.FillRectangle(TCBrush, ClientRectangle);
            G.TextRenderingHint = TextRenderingHint.AntiAlias;

            for (int TabItemIndex = 0; TabItemIndex <= this.TabCount - 1; TabItemIndex++)
            {
                TCItemB = GetTabRect(TabItemIndex);

                //If TabItemIndex = 0 Then
                //    TCItemR = New Rectangle(10, TCItemB.Y + 1, TCItemB.Width - 18, TCItemB.Height - 5)
                //    TCItemG = New Rectangle(10, TCItemB.Y + 1, TCItemB.Width - 18, CInt(TCItemB.Height / 2 - 2))
                //Else
                //    TCItemR = New Rectangle(TCItemB.X + 8, TCItemB.Y + 1, TCItemB.Width - 17, TCItemB.Height - 5)
                //    TCItemG = New Rectangle(TCItemB.X + 8, TCItemB.Y + 1, TCItemB.Width - 17, CInt(TCItemB.Height / 2 - 2))
                //End If

                if (TabItemIndex == SelectedIndex)
                {
                }
                else
                {
                }

                if (SelectedIndex == TabItemIndex)
                {
                    TCTBrush.Color = Color.FromArgb(255, 255, 255);
                    //####################################
                    //G.FillRectangle(TCIBrush, TCItemR)
                    //G.FillRectangle(TCIGBrush, TCItemG) TabPage Outline + Gradient + Gloss
                    //G.DrawRectangle(Pens.Black, TCItemR)
                    //####################################
                }
                else
                {
                    TCTBrush.Color = Color.FromArgb(100, 100, 100);
                }
                try
                {
                    G.DrawString(TabPages[TabItemIndex].Text, Font, TCTBrush, new Rectangle(new Point(GetTabRect(TabItemIndex).Location.X, GetTabRect(TabItemIndex).Location.Y - 2), GetTabRect(TabItemIndex).Size), TCTAT);
                    TabPages[TabItemIndex].BackColor = Color.FromArgb(90, 90, 90);
                }
                catch
                {
                }
            }
            DrawBorders(Pens.Black);
            DrawBorders(Pens.Black, 2);
        }
        #region " DrawBorders "

        protected void DrawBorders(Pen p1, int offset)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset);
        }
        protected void DrawBorders(Pen p1, Rectangle r, int offset)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        protected void DrawBorders(Pen p1)
        {
            DrawBorders(p1, 0, 0, Width, Height);
        }
        protected void DrawBorders(Pen p1, Rectangle r)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        #endregion

    }

}
