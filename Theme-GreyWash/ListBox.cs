// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ListBox.cs" company="Zeroit Dev Technologies">
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
    public class GreywashListBox : Control
    {
        #region  Declarations 
        private ListBox ListB = new ListBox();
        private string[] _Items = { "" };
        private Color _BaseColour = Color.White;
        private Color _SelectedColour = Color.DarkGray;
        private Color _ListBaseColour = Color.White;
        private Color _TextColour = Color.Gray;
        private Color _BorderColour = Color.LightGray;
        #endregion

        #region  Properties 

        [Category("Control")]
        public string[] Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                ListB.Items.Clear();
                ListB.Items.AddRange(value);
                Invalidate();
            }
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
        public Color SelectedColour
        {
            get
            {
                return _SelectedColour;
            }
            set
            {
                _SelectedColour = value;
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
        public Color ListBaseColour
        {
            get
            {
                return _ListBaseColour;
            }
            set
            {
                _ListBaseColour = value;
            }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get
            {
                return _TextColour;
            }
            set
            {
                _TextColour = value;
            }
        }

        public object SelectedItem
        {
            get
            {
                return ListB.SelectedItem;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return ListB.SelectedIndex;
                if (ListB.SelectedIndex < 0)
                {
                    return 0;
                }
                return 0;
            }
        }

        public void Clear()
        {
            ListB.Items.Clear();
        }

        public void ClearSelected()
        {
            for (int i = (ListB.SelectedItems.Count - 1); i >= 0; i--)
            {
                ListB.Items.Remove(ListB.SelectedItems[i]);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!(Controls.Contains(ListB)))
            {
                Controls.Add(ListB);
            }
        }

        public void AddRange(object[] items)
        {
            ListB.Items.Remove("");
            ListB.Items.AddRange(items);
        }

        public void AddItem(object item)
        {
            ListB.Items.Remove("");
            ListB.Items.Add(item);
        }

        #endregion

        public void Drawitem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.State.ToString().IndexOf("Selected,") + 1 > 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(_SelectedColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.Graphics.DrawString(" " + ListB.Items[e.Index].ToString(), new Font("Segoe UI", 10), new SolidBrush(Color.White), e.Bounds.X, e.Bounds.Y + 2);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(_ListBaseColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.Graphics.DrawString(" " + ListB.Items[e.Index].ToString(), new Font("Segoe UI", 10), new SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2);
            }
            e.Graphics.Dispose();
        }

        public GreywashListBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            ListB.DrawMode = DrawMode.OwnerDrawFixed;
            ListB.ScrollAlwaysVisible = false;
            ListB.HorizontalScrollbar = false;
            ListB.BorderStyle = BorderStyle.None;
            ListB.BackColor = _BaseColour;
            ListB.Location = new Point(3, 3);
            ListB.Font = new Font("Segoe UI", 10);
            ListB.ItemHeight = 20;
            ListB.Items.Clear();
            ListB.IntegralHeight = false;
            Size = new Size(130, 100);
            SubscribeToEvents();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            G.Clear(BackColor);
            ListB.Size = new Size(Width - 6, Height - 5);
            G.FillRectangle(new SolidBrush(_BaseColour), Base);
            G.DrawRectangle(new Pen(_BorderColour, -1F), new Rectangle(0, 0, Width - 1, Height - 1));
            base.OnPaint(e);
            G.Dispose();
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

            ListB.DrawItem += Drawitem;
        }

    }

}
