// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ListBoxWithScollBar.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Diagnostics;

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInListBoxWBuiltInScrollBar : Control
    {

        #region "Declarations"

        private List<LogInListBoxItem> _Items = new List<LogInListBoxItem>();
        private readonly List<LogInListBoxItem> _SelectedItems = new List<LogInListBoxItem>();
        private bool _MultiSelect = true;
        private int ItemHeight = 24;
        private readonly LogInVerticalScrollBar VerticalScrollbar;
        private Color _BaseColour = Color.FromArgb(55, 55, 55);
        private Color _SelectedItemColour = Color.FromArgb(50, 50, 50);
        private Color _NonSelectedItemColour = Color.FromArgb(47, 47, 47);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _TextColour = Color.FromArgb(255, 255, 255);

        private int _SelectedHeight = 1;
        #endregion

        #region "Properties"

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        [Category("Control")]
        public int SelectedHeight
        {
            get { return _SelectedHeight; }
            set
            {
                if (value < 1)
                {
                    _SelectedHeight = Height;
                }
                else
                {
                    _SelectedHeight = value;
                }
                InvalidateScroll();
            }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color SelectedItemColour
        {
            get { return _SelectedItemColour; }
            set { _SelectedItemColour = value; }
        }

        [Category("Colours")]
        public Color NonSelectedItemColour
        {
            get { return _NonSelectedItemColour; }
            set { _NonSelectedItemColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }


        private void HandleScroll(object sender)
        {
            Invalidate();
        }

        private void InvalidateScroll()
        {
            Debug.Print(Convert.ToString(Height));
            if (Convert.ToInt32(Math.Round((float)((_Items.Count) * ItemHeight) / _SelectedHeight)) < Convert.ToDouble((((_Items.Count) * ItemHeight) / _SelectedHeight)))
            {
                VerticalScrollbar._Maximum = Convert.ToInt32(Math.Ceiling((float)((_Items.Count) * ItemHeight) / _SelectedHeight));
            }
            else if (Convert.ToInt32(Math.Round((float)((_Items.Count) * ItemHeight) / _SelectedHeight)) == 0)
            {
                VerticalScrollbar._Maximum = 1;
            }
            else
            {
                VerticalScrollbar._Maximum = Convert.ToInt32(Math.Round((float)((_Items.Count) * ItemHeight) / _SelectedHeight));
            }
            Invalidate();
        }

        private void InvalidateLayout()
        {
            VerticalScrollbar.Location = new Point(Width - VerticalScrollbar.Width - 2, 2);
            VerticalScrollbar.Size = new Size(18, Height - 4);
            Invalidate();
        }

        public class LogInListBoxItem
        {
            public string Text { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public LogInListBoxItem[] Items
        {
            get { return _Items.ToArray(); }
            set
            {
                _Items = new List<LogInListBoxItem>(value);
                Invalidate();
                InvalidateScroll();
            }
        }

        public LogInListBoxItem[] SelectedItems
        {
            get { return _SelectedItems.ToArray(); }
        }

        public bool MultiSelect
        {
            get { return _MultiSelect; }
            set
            {
                _MultiSelect = value;

                if (_SelectedItems.Count > 1)
                {
                    _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1);
                }

                Invalidate();
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                ItemHeight = Convert.ToInt32(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height);
                if (VerticalScrollbar != null)
                {
                    VerticalScrollbar._SmallChange = 1;
                    VerticalScrollbar._LargeChange = 1;

                }
                base.Font = value;
                InvalidateLayout();
            }
        }

        public void AddItem(string Items)
        {
            LogInListBoxItem Item = new LogInListBoxItem();
            Item.Text = Items;
            _Items.Add(Item);
            Invalidate();
            InvalidateScroll();
        }

        public void AddItems(string[] Items)
        {
            foreach (String I_loopVariable in Items)
            {
                string I = I_loopVariable;
                LogInListBoxItem Item = new LogInListBoxItem();
                Item.Text = I;
                _Items.Add(Item);
            }
            Invalidate();
            InvalidateScroll();
        }

        public void RemoveItemAt(int index)
        {
            _Items.RemoveAt(index);
            Invalidate();
            InvalidateScroll();
        }

        public void RemoveItem(LogInListBoxItem item)
        {
            _Items.Remove(item);
            Invalidate();
            InvalidateScroll();
        }

        public void RemoveItems(LogInListBoxItem[] items)
        {
            foreach (LogInListBoxItem I in items)
            {
                _Items.Remove(I);
            }
            Invalidate();
            InvalidateScroll();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _SelectedHeight = Height;
            InvalidateScroll();
            InvalidateLayout();
            base.OnSizeChanged(e);
        }

        private void Vertical_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            if (e.Button == MouseButtons.Left)
            {
                int Offset = Convert.ToInt32(VerticalScrollbar.Value * (VerticalScrollbar.Maximum + (Height - (ItemHeight))));

                int Index = ((e.Y + Offset) / ItemHeight);

                if (Index > _Items.Count - 1)
                    Index = -1;


                if (!(Index == -1))
                {
                    if (ModifierKeys == Keys.Control && _MultiSelect)
                    {
                        if (_SelectedItems.Contains(_Items[Index]))
                        {
                            _SelectedItems.Remove(_Items[Index]);
                        }
                        else
                        {
                            _SelectedItems.Add(_Items[Index]);
                        }
                    }
                    else
                    {
                        _SelectedItems.Clear();
                        _SelectedItems.Add(_Items[Index]);
                    }
                    Debug.Print(Convert.ToString(_SelectedItems[0].Text));
                }

                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int Move = -((e.Delta * SystemInformation.MouseWheelScrollLines / 120) * (2 / 2));
            int Value = Math.Max(Math.Min(VerticalScrollbar.Value + Move, VerticalScrollbar.Maximum), VerticalScrollbar.Minimum);
            VerticalScrollbar.Value = Value;
            base.OnMouseWheel(e);
        }

        #endregion

        #region "Draw Control"

        public LogInListBoxWBuiltInScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            VerticalScrollbar = new LogInVerticalScrollBar();
            VerticalScrollbar._SmallChange = 1;
            VerticalScrollbar._LargeChange = 1;
            VerticalScrollbar.Scroll += HandleScroll;
            VerticalScrollbar.MouseDown += Vertical_MouseDown;
            Controls.Add(VerticalScrollbar);
            InvalidateLayout();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var _with31 = g;
            _with31.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with31.SmoothingMode = SmoothingMode.HighQuality;
            _with31.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with31.Clear(_BaseColour);
            LogInListBoxItem AllItems = null;
            int Offset = Convert.ToInt32(VerticalScrollbar.Value * (VerticalScrollbar.Maximum + (Height - (ItemHeight))));
            int StartIndex = 0;
            if (Offset == 0)
                StartIndex = 0;
            else
                StartIndex = Convert.ToInt32(Offset / ItemHeight / VerticalScrollbar.Maximum);
            int EndIndex = Math.Min(StartIndex + (Height / ItemHeight), _Items.Count - 1);
            _with31.DrawLine(new Pen(_BorderColour, 2), VerticalScrollbar.Location.X - 1, 0, VerticalScrollbar.Location.X - 1, Height);

            for (int I = StartIndex; I <= _Items.Count - 1; I++)
            {
                AllItems = Items[I];
                int Y = ((I * ItemHeight) + 1 - Offset) + Convert.ToInt32((ItemHeight / 2) - 8);
                if (_SelectedItems.Contains(AllItems))
                {
                    _with31.FillRectangle(new SolidBrush(_SelectedItemColour), new Rectangle(0, (I * ItemHeight) + 1 - Offset, Width - 19, ItemHeight - 1));
                }
                else
                {
                    _with31.FillRectangle(new SolidBrush(_NonSelectedItemColour), new Rectangle(0, (I * ItemHeight) + 1 - Offset, Width - 19, ItemHeight - 1));
                }
                _with31.DrawLine(new Pen(_BorderColour), 0, ((I * ItemHeight) + 1 - Offset) + ItemHeight - 1, Width - 18, ((I * ItemHeight) + 1 - Offset) + ItemHeight - 1);
                _with31.DrawString(AllItems.Text, new Font("Segoe UI", 8), new SolidBrush(_TextColour), 9, Y);
                _with31.ResetClip();
            }
            _with31.DrawRectangle(new Pen(Color.FromArgb(35, 35, 35), 2), 1, 1, Width - 2, Height - 2);
            //   .DrawLine(New Pen(_BorderColour), 0, ItemHeight, Width, ItemHeight)
            _with31.DrawLine(new Pen(_BorderColour, 2), VerticalScrollbar.Location.X - 1, 0, VerticalScrollbar.Location.X - 1, Height);
            _with31.InterpolationMode = (InterpolationMode)7;

        }

        #endregion

    }

}


