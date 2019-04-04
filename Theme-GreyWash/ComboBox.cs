// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GreyWash
{
    public class GreywashComboBox : ComboBox
    {
        #region  Declarations 
        private int _StartIndex = 0;
        private Color _BorderColour = Color.LightGray;
        private Color _BaseColour = Color.White;
        private Color _FontColour = Color.Gray;
        private Color _LineColour = Color.White;
        private Color _SqaureColour = Color.DarkGray;
        private Color _SqaureHoverColour = Color.LightGray;
        private MouseState State = MouseState.None;
        #endregion

        #region  Properties 

        [Category("Colours")]
        public Color LineColour
        {
            get
            {
                return _LineColour;
            }
            set
            {
                _LineColour = value;
            }
        }

        [Category("Colours")]
        public Color SqaureColour
        {
            get
            {
                return _SqaureColour;
            }
            set
            {
                _SqaureColour = value;
            }
        }

        [Category("Colours")]
        public Color SqaureHoverColour
        {
            get
            {
                return _SqaureHoverColour;
            }
            set
            {
                _SqaureHoverColour = value;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get
            {
                return _BorderColour;
            }
            set
            {
                _BorderColour = value;
            }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get
            {
                return _BaseColour;
            }
            set
            {
                _BaseColour = value;
            }
        }

        [Category("Colours")]
        public Color FontColour
        {
            get
            {
                return _FontColour;
            }
            set
            {
                _FontColour = value;
            }
        }

        public int StartIndex
        {
            get
            {
                return _StartIndex;
            }
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

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Invalidate();
            OnMouseClick(e);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            Invalidate();
            base.OnMouseUp(e);
        }

        #endregion

        public void ReplaceItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            Rectangle Rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(_SqaureColour), Rect);
                    e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(_FontColour), 1, e.Bounds.Top + 2);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(_BaseColour), Rect);
                    e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(_FontColour), 1, e.Bounds.Top + 2);
                }
            }
            catch
            {
            }
            e.DrawFocusRectangle();
            Invalidate();

        }

        public GreywashComboBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            Width = 163;
            Font = new Font("Segoe UI", 10);
            SubscribeToEvents();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);
            G.Clear(BackColor);

            Rectangle Square = new Rectangle(Width - 25, 0, Width, Height);
            G.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width - 25, Height));
            G.DrawLine(new Pen(_LineColour), new Point(Width - 26, 1), new Point(Width - 26, Height));
            G.DrawString(Text, Font, new SolidBrush(_FontColour), new Rectangle(3, 0, Width - 20, Height), new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });


            G.DrawRectangle(new Pen(_BorderColour, 2F), new Rectangle(0, 0, Width, Height));
            switch (State)
            {
                case MouseState.None:
                    G.FillRectangle(new SolidBrush(_SqaureColour), Square);
                    break;
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(_SqaureHoverColour), Square);
                    break;
            }


            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }


        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.DrawItem += ReplaceItem;
        }

    }

}
