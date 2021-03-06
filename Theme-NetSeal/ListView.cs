// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ListView.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    public class NSListView : Control
    {

        public class NSListViewItem
        {
            public string Text { get; set; }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public List<NSListViewSubItem> SubItems { get; set; }


            protected Guid UniqueId;
            public NSListViewItem()
            {
                UniqueId = Guid.NewGuid();
            }

            public override string ToString()
            {
                return Text;
            }

            public override bool Equals(object obj)
            {
                if (obj is NSListViewItem)
                {
                    return (((NSListViewItem)obj).UniqueId == UniqueId);
                }

                return false;
            }

        }

        public class NSListViewSubItem
        {
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public class NSListViewColumnHeader
        {
            public string Text { get; set; }
            public int Width { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private List<NSListViewItem> _Items = new List<NSListViewItem>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NSListViewItem[] Items
        {
            get { return _Items.ToArray(); }
            set
            {
                _Items = new List<NSListViewItem>(value);
                InvalidateScroll();
            }
        }

        private List<NSListViewItem> _SelectedItems = new List<NSListViewItem>();
        public NSListViewItem[] SelectedItems
        {
            get { return _SelectedItems.ToArray(); }
        }

        private List<NSListViewColumnHeader> _Columns = new List<NSListViewColumnHeader>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NSListViewColumnHeader[] Columns
        {
            get { return _Columns.ToArray(); }
            set
            {
                _Columns = new List<NSListViewColumnHeader>(value);
                InvalidateColumns();
            }
        }

        private bool _MultiSelect = true;
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

        private int ItemHeight = 24;
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                ItemHeight = Convert.ToInt32(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height) + 6;

                if (VS != null)
                {
                    VS.SmallChange = ItemHeight;
                    VS.LargeChange = ItemHeight;
                }

                base.Font = value;
                InvalidateLayout();
            }
        }

        #region " Item Helper Methods "

        //Ok, you've seen everything of importance at this point; I am begging you to spare yourself. You must not read any further!

        public void AddItem(string text, params string[] subItems)
        {
            List<NSListViewSubItem> Items = new List<NSListViewSubItem>();
            foreach (string I in subItems)
            {
                NSListViewSubItem SubItem = new NSListViewSubItem();
                SubItem.Text = I;
                Items.Add(SubItem);
            }

            NSListViewItem Item = new NSListViewItem();
            Item.Text = text;
            Item.SubItems = Items;

            _Items.Add(Item);
            InvalidateScroll();
        }

        public void RemoveItemAt(int index)
        {
            _Items.RemoveAt(index);
            InvalidateScroll();
        }

        public void RemoveItem(NSListViewItem item)
        {
            _Items.Remove(item);
            InvalidateScroll();
        }

        public void RemoveItems(NSListViewItem[] items)
        {
            foreach (NSListViewItem I in items)
            {
                _Items.Remove(I);
            }

            InvalidateScroll();
        }

        #endregion


        private NSVScrollBar VS;
        public NSListView()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, true);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(24, 24, 24));
            P3 = new Pen(Color.FromArgb(65, 65, 65));

            B1 = new SolidBrush(Color.FromArgb(62, 62, 62));
            B2 = new SolidBrush(Color.FromArgb(65, 65, 65));
            B3 = new SolidBrush(Color.FromArgb(47, 47, 47));
            B4 = new SolidBrush(Color.FromArgb(50, 50, 50));

            VS = new NSVScrollBar();
            VS.SmallChange = ItemHeight;
            VS.LargeChange = ItemHeight;

            VS.Scroll += HandleScroll;
            VS.MouseDown += VS_MouseDown;
            Controls.Add(VS);

            InvalidateLayout();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateLayout();
            base.OnSizeChanged(e);
        }

        private void HandleScroll(object sender)
        {
            Invalidate();
        }

        private void InvalidateScroll()
        {
            VS.Maximum = (_Items.Count * ItemHeight);
            Invalidate();
        }

        private void InvalidateLayout()
        {
            VS.Location = new Point(Width - VS.Width - 1, 1);
            VS.Size = new Size(18, Height - 2);

            Invalidate();
        }

        private int[] ColumnOffsets;
        private void InvalidateColumns()
        {
            int Width = 3;
            ColumnOffsets = new int[_Columns.Count];

            for (int I = 0; I <= _Columns.Count - 1; I++)
            {
                ColumnOffsets[I] = Width;
                Width += Columns[I].Width;
            }

            Invalidate();
        }

        private void VS_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();

            if (e.Button == MouseButtons.Left)
            {
                int Offset = Convert.ToInt32(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))));
                int Index = ((e.Y + Offset - ItemHeight) / ItemHeight);

                if (Index > _Items.Count - 1)
                    Index = -1;

                if (!(Index == -1))
                {
                    //TODO: Handle Shift key

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
                }

                Invalidate();
            }

            base.OnMouseDown(e);
        }

        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private SolidBrush B4;

        private LinearGradientBrush GB1;
        //I am so sorry you have to witness this. I tried warning you. ;.;

        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;


            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);

            int X = 0;
            int Y = 0;
            float H = 0;

            G.DrawRectangle(P1, 1, 1, Width - 3, Height - 3);

            Rectangle R1 = default(Rectangle);
            NSListViewItem CI = null;

            int Offset = Convert.ToInt32(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))));

            int StartIndex = 0;
            if (Offset == 0)
                StartIndex = 0;
            else
                StartIndex = (Offset / ItemHeight);

            int EndIndex = Math.Min(StartIndex + (Height / ItemHeight), _Items.Count - 1);

            for (int I = StartIndex; I <= EndIndex; I++)
            {
                CI = Items[I];

                R1 = new Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width, ItemHeight - 1);

                H = G.MeasureString(CI.Text, Font).Height;
                Y = R1.Y + Convert.ToInt32((ItemHeight / 2) - (H / 2));

                if (_SelectedItems.Contains(CI))
                {
                    if (I % 2 == 0)
                    {
                        G.FillRectangle(B1, R1);
                    }
                    else
                    {
                        G.FillRectangle(B2, R1);
                    }
                }
                else
                {
                    if (I % 2 == 0)
                    {
                        G.FillRectangle(B3, R1);
                    }
                    else
                    {
                        G.FillRectangle(B4, R1);
                    }
                }

                G.DrawLine(P2, 0, R1.Bottom, Width, R1.Bottom);

                if (Columns.Length > 0)
                {
                    R1.Width = Columns[0].Width;
                    G.SetClip(R1);
                }

                //TODO: Ellipse text that overhangs seperators.
                G.DrawString(CI.Text, Font, Brushes.Black, 10, Y + 1);
                G.DrawString(CI.Text, Font, Brushes.WhiteSmoke, 9, Y);

                if (CI.SubItems != null)
                {
                    for (int I2 = 0; I2 <= Math.Min(CI.SubItems.Count, _Columns.Count) - 1; I2++)
                    {
                        X = ColumnOffsets[I2 + 1] + 4;

                        R1.X = X;
                        R1.Width = Columns[I2].Width;
                        G.SetClip(R1);

                        G.DrawString(CI.SubItems[I2].Text, Font, Brushes.Black, X + 1, Y + 1);
                        G.DrawString(CI.SubItems[I2].Text, Font, Brushes.WhiteSmoke, X, Y);
                    }
                }

                G.ResetClip();
            }

            R1 = new Rectangle(0, 0, Width, ItemHeight);

            GB1 = new LinearGradientBrush(R1, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90f);
            G.FillRectangle(GB1, R1);
            G.DrawRectangle(P3, 1, 1, Width - 22, ItemHeight - 2);

            int LH = Math.Min(VS.Maximum + ItemHeight - Offset, Height);

            NSListViewColumnHeader CC = null;
            for (int I = 0; I <= _Columns.Count - 1; I++)
            {
                CC = Columns[I];

                H = G.MeasureString(CC.Text, Font).Height;
                Y = Convert.ToInt32((ItemHeight / 2) - (H / 2));
                X = ColumnOffsets[I];
                G.DrawString(CC.Text, Font, Brushes.Black, X + 1, Y + 1);
                G.DrawString(CC.Text, Font, Brushes.WhiteSmoke, X, Y);

                G.DrawLine(P2, X - 3, 0, X - 3, LH);
                G.DrawLine(P3, X - 2, 0, X - 2, ItemHeight);
            }

            G.DrawRectangle(P2, 0, 0, Width - 1, Height - 1);

            G.DrawLine(P2, 0, ItemHeight, Width, ItemHeight);
            G.DrawLine(P2, VS.Location.X - 1, 0, VS.Location.X - 1, Height);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int Move = -((e.Delta * SystemInformation.MouseWheelScrollLines / 120) * (ItemHeight / 2));

            int Value = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum);
            VS.Value = Value;

            base.OnMouseWheel(e);
        }

    }

}


