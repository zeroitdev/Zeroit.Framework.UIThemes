// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Cypher
{
    public class CyperxComboBox : Control
    {

        public CyperxComboBox()
        {
            Font = new Font("Arial", 8);
            ForeColor = Color.White;
            MinimumSize = new Size(130, 23);

        }

        protected override void OnHandleCreated(System.EventArgs e)
        {
            if (_Items.Length < 0)
                _Items = new string[] { Text };
            base.OnHandleCreated(e);
        }
        private enum State
        {
            MouseDown = 0,
            MouseEnter = 1,
            MouseLeft = 2,
            Wait = 3
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            if (!(MouseState == State.Wait))
            {
                MouseState = State.MouseLeft;
                Invalidate();
            }
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            if (!(MouseState == State.Wait))
            {
                MouseState = State.MouseEnter;
                Invalidate();
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (!(MouseState == State.Wait))
            {
                MouseState = State.MouseEnter;
                Invalidate();
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {

            MouseState = State.Wait;
            System.Threading.Thread ShowPopup = new System.Threading.Thread(ShowAndWait);
            ShowPopup.Start();

            Invalidate();

            base.OnMouseDown(e);
        }

        public void ShowAndWait()
        {
            Popup pop = new Popup(_Items);
            pop.Location = new Point(Location.X, Location.Y + Height + 2);

            Invoke(new AddX(AddControl), pop);


            pop.WaitForInput();

            MouseState = State.MouseLeft;
            if (!string.IsNullOrEmpty(pop.SelectedItem))
            {
                Invoke(new UpdateTextD(UpdateText), pop.SelectedItem);
            }
            else
            {
                Invoke(new UpdateTextD(UpdateText), Text);
            }


        }

        public delegate void UpdateTextD(string text);
        public void UpdateText(string text)
        {
            this.Text = text;
            Invalidate();
        }

        public delegate void AddX(Control control);
        public void AddControl(Control control)
        {
            Parent.Controls.Add(control);
        }
        string[] _Items = new string[] { "" };
        public string[] Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                Text = value[0];
                Invalidate();
            }
        }
        State MouseState = State.MouseLeft;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap b = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    Rectangle OuterR = new Rectangle(0, 0, Width - 1, Height - 1);
                    Rectangle InnerR = new Rectangle(1, 1, Width - 3, Height - 3);
                    Rectangle UpHalf = new Rectangle(2, 2, Width - 3, (Height - 1) / 2);
                    Rectangle DownHalf = new Rectangle(2, (Height - 1) / 2, Width - 3, (Height - 1) / 2);

                    switch (MouseState)
                    {
                        case State.MouseLeft:
                            Draw.Gradient(g, Color.FromArgb(88, 79, 72), Color.FromArgb(76, 69, 61), UpHalf);
                            Draw.Gradient(g, Color.FromArgb(56, 46, 36), Color.FromArgb(66, 56, 46), DownHalf);
                            g.DrawRectangle(Pens.Black, OuterR);
                            g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(75, 66, 60))), InnerR);
                            ForeColor = Color.White;
                            break;
                        case State.MouseEnter:
                            ForeColor = Color.FromArgb(23, 32, 37);
                            Draw.Gradient(g, Color.FromArgb(234, 236, 241), Color.FromArgb(215, 219, 225), UpHalf);
                            Draw.Gradient(g, Color.FromArgb(189, 193, 198), Color.FromArgb(195, 198, 201), DownHalf);
                            break;
                        case State.Wait:
                            ForeColor = Color.FromArgb(23, 32, 37);
                            Draw.Gradient(g, Color.FromArgb(234, 236, 241), Color.FromArgb(215, 219, 225), UpHalf);
                            Draw.Gradient(g, Color.FromArgb(189, 193, 198), Color.FromArgb(195, 198, 201), DownHalf);
                            break;
                    }


                    Rectangle UpRec = new Rectangle(Width - 18, 2, 1, 5);
                    Draw.Gradient(g, Color.Transparent, Color.FromArgb(25, 18, 12), UpRec);
                    g.DrawLine(new Pen(Color.FromArgb(28, 18, 12), 1), new Point(Width - 18, 7), new Point(Width - 18, Height - 7));
                    Draw.Gradient(g, Color.FromArgb(28, 18, 12), Color.Transparent, new Rectangle(Width - 18, Height - 7, 1, 5));

                    g.DrawLine(new Pen(Brushes.White, 2), new Point(Width - 15, 9), new Point(Width - 10, 14));
                    g.DrawLine(new Pen(Brushes.White, 2), new Point(Width - 5, 9), new Point(Width - 10, 14));

                    SizeF S = g.MeasureString(Text, Font);
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), 5, Convert.ToInt32(Height / 2 - S.Height / 2));

                    e.Graphics.DrawImage((Bitmap)b.Clone(), 0, 0);
                }
            }
            base.OnPaint(e);
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
    }


}
