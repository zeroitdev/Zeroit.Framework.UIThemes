// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInListBox : Control
    {

        #region "Variables"

        private ListBox withEventsField_ListB = new ListBox();
        private ListBox ListB
        {
            get { return withEventsField_ListB; }
            set
            {
                if (withEventsField_ListB != null)
                {
                    withEventsField_ListB.DrawItem -= Drawitem;
                }
                withEventsField_ListB = value;
                if (withEventsField_ListB != null)
                {
                    withEventsField_ListB.DrawItem += Drawitem;
                }
            }
        }
        private string[] _Items = { "" };
        private Color _BaseColour = Color.FromArgb(42, 42, 42);
        private Color _SelectedColour = Color.FromArgb(55, 55, 55);
        private Color _ListBaseColour = Color.FromArgb(47, 47, 47);
        private Color _TextColour = Color.FromArgb(255, 255, 255);

        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        #endregion

        #region "Properties"

        [Category("Control")]
        public string[] Items
        {
            get { return _Items; }
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
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color SelectedColour
        {
            get { return _SelectedColour; }
            set { _SelectedColour = value; }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color ListBaseColour
        {
            get { return _ListBaseColour; }
            set { _ListBaseColour = value; }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        public string SelectedItem
        {
            get { return Convert.ToString(ListB.SelectedItem); }
        }

        public int SelectedIndex
        {
            get
            {
                int functionReturnValue = 0;
                return ListB.SelectedIndex;
                if (ListB.SelectedIndex < 0)
                    return functionReturnValue;
                return functionReturnValue;
            }
        }

        public void Clear()
        {
            ListB.Items.Clear();
        }

        public void ClearSelected()
        {
            for (int i = (ListB.SelectedItems.Count - 1); i >= 0; i += -1)
            {
                ListB.Items.Remove(ListB.SelectedItems[i]);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(ListB))
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

        #region "Draw Control"

        public void Drawitem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            e.DrawBackground();
            e.DrawFocusRectangle();
            var _with15 = e.Graphics;
            _with15.SmoothingMode = SmoothingMode.HighQuality;
            _with15.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with15.InterpolationMode = InterpolationMode.HighQualityBicubic;
            _with15.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            if (String.Compare(e.State.ToString(), "Selected,") > 0)
            {
                _with15.FillRectangle(new SolidBrush(_SelectedColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 1));
                _with15.DrawString(" " + ListB.Items[e.Index].ToString(), new Font("Segoe UI", 9, FontStyle.Bold), new SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2);
            }
            else
            {
                _with15.FillRectangle(new SolidBrush(_ListBaseColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                _with15.DrawString(" " + ListB.Items[e.Index].ToString(), new Font("Segoe UI", 8), new SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2);
            }
            _with15.Dispose();
        }

        public LogInListBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            ListB.DrawMode = DrawMode.OwnerDrawFixed;
            ListB.ScrollAlwaysVisible = false;
            ListB.HorizontalScrollbar = false;
            ListB.BorderStyle = BorderStyle.None;
            ListB.BackColor = _BaseColour;
            ListB.Location = new Point(3, 3);
            ListB.Font = new Font("Segoe UI", 8);
            ListB.ItemHeight = 20;
            ListB.Items.Clear();
            ListB.IntegralHeight = false;
            Size = new Size(130, 100);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with16 = G;
            _with16.SmoothingMode = SmoothingMode.HighQuality;
            _with16.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with16.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with16.Clear(BackColor);
            ListB.Size = new Size(Width - 6, Height - 5);
            _with16.FillRectangle(new SolidBrush(_BaseColour), Base);
            _with16.DrawRectangle(new Pen(_BorderColour, 3), new Rectangle(0, 0, Width, Height - 1));
            _with16.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}


