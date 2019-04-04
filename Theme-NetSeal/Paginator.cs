// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Paginator.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    [DefaultEvent("SelectedIndexChanged")]
    public class NSPaginator : Control
    {

        public event SelectedIndexChangedEventHandler SelectedIndexChanged;
        public delegate void SelectedIndexChangedEventHandler(object sender, EventArgs e);

        private Bitmap TextBitmap;

        private Graphics TextGraphics;
        public NSPaginator()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Size = new Size(202, 26);

            TextBitmap = new Bitmap(1, 1);
            TextGraphics = Graphics.FromImage(TextBitmap);

            InvalidateItems();

            B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
            B2 = new SolidBrush(Color.FromArgb(55, 55, 55));

            P1 = new Pen(Color.FromArgb(24, 24, 24));
            P2 = new Pen(Color.FromArgb(55, 55, 55));
            P3 = new Pen(Color.FromArgb(65, 65, 65));
        }

        private int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                _SelectedIndex = Math.Max(Math.Min(value, MaximumIndex), 0);
                Invalidate();
            }
        }

        private int _NumberOfPages;
        public int NumberOfPages
        {
            get { return _NumberOfPages; }
            set
            {
                _NumberOfPages = value;
                _SelectedIndex = Math.Max(Math.Min(_SelectedIndex, MaximumIndex), 0);
                Invalidate();
            }
        }

        public int MaximumIndex
        {
            get { return NumberOfPages - 1; }
        }


        private int ItemWidth;
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;

                InvalidateItems();
                Invalidate();
            }
        }

        private void InvalidateItems()
        {
            Size S = TextGraphics.MeasureString("000 ..", Font).ToSize();
            ItemWidth = S.Width + 10;
        }

        private GraphicsPath GP1;

        private GraphicsPath GP2;

        private Rectangle R1;
        private Size SZ1;

        private Point PT1;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;

        private SolidBrush B2;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            bool LeftEllipse = false;
            bool RightEllipse = false;

            if (_SelectedIndex < 4)
            {
                for (int I = 0; I <= Math.Min(MaximumIndex, 4); I++)
                {
                    RightEllipse = (I == 4) && (MaximumIndex > 4);
                    DrawBox(I * ItemWidth, I, false, RightEllipse);
                }
            }
            else if (_SelectedIndex > 3 && _SelectedIndex < (MaximumIndex - 3))
            {
                for (int I = 0; I <= 4; I++)
                {
                    LeftEllipse = (I == 0);
                    RightEllipse = (I == 4);
                    DrawBox(I * ItemWidth, _SelectedIndex + I - 2, LeftEllipse, RightEllipse);
                }
            }
            else
            {
                for (int I = 0; I <= 4; I++)
                {
                    LeftEllipse = (I == 0) && (MaximumIndex > 4);
                    DrawBox(I * ItemWidth, MaximumIndex - (4 - I), LeftEllipse, false);
                }
            }
        }

        private void DrawBox(int x, int index, bool leftEllipse, bool rightEllipse)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            R1 = new Rectangle(x, 0, ItemWidth - 4, Height - 1);

            GP1 = theme.CreateRound(R1, 7);
            GP2 = theme.CreateRound(R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2, 7);

            string T = Convert.ToString(index + 1);

            if (leftEllipse)
                T = ".. " + T;
            if (rightEllipse)
                T = T + " ..";

            SZ1 = G.MeasureString(T, Font).ToSize();
            PT1 = new Point(R1.X + (R1.Width / 2 - SZ1.Width / 2), R1.Y + (R1.Height / 2 - SZ1.Height / 2));

            if (index == _SelectedIndex)
            {
                G.FillPath(B1, GP1);

                Font F = new Font(Font, FontStyle.Underline);
                G.DrawString(T, F, Brushes.Black, PT1.X + 1, PT1.Y + 1);
                G.DrawString(T, F, Brushes.WhiteSmoke, PT1);
                F.Dispose();

                G.DrawPath(P1, GP2);
                G.DrawPath(P2, GP1);
            }
            else
            {
                G.FillPath(B2, GP1);

                G.DrawString(T, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
                G.DrawString(T, Font, Brushes.WhiteSmoke, PT1);

                G.DrawPath(P3, GP2);
                G.DrawPath(P1, GP1);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int NewIndex = 0;
                int OldIndex = _SelectedIndex;

                if (_SelectedIndex < 4)
                {
                    NewIndex = (e.X / ItemWidth);
                }
                else if (_SelectedIndex > 3 && _SelectedIndex < (MaximumIndex - 3))
                {
                    NewIndex = (e.X / ItemWidth);


                    if (NewIndex == 2)
                    {
                        NewIndex = OldIndex;
                    }

                    else if (NewIndex == 2)
                    {
                        NewIndex = OldIndex - (2 - NewIndex);
                    }

                    else if (NewIndex == 2)
                    {
                        NewIndex = OldIndex + (NewIndex - 2);
                    }

                    #region Old Code
                    //				switch (NewIndex) {
                    //					case 2:
                    //						NewIndex = OldIndex;
                    //						break;
                    //					case  // ERROR: Case labels with binary operators are unsupported : LessThan
                    //2:
                    //						NewIndex = OldIndex - (2 - NewIndex);
                    //						break;
                    //					case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                    //2:
                    //						NewIndex = OldIndex + (NewIndex - 2);
                    //						break;
                    //				} 
                    #endregion

                }

                else
                {
                    NewIndex = MaximumIndex - (4 - (e.X / ItemWidth));
                }

                if ((NewIndex < _NumberOfPages) && (!(NewIndex == OldIndex)))
                {
                    SelectedIndex = NewIndex;
                    if (SelectedIndexChanged != null)
                    {
                        SelectedIndexChanged(this, null);
                    }
                }
            }

            base.OnMouseDown(e);
        }

    }

}


