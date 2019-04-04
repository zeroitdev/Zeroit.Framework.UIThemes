// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ListBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.MetroDisk.Helpers;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.MetroDisk
{
    public class MetroDiskListBox : Control
    {

        #region " Variables"

        private ListBox withEventsField_ListBx = new ListBox();
        private ListBox ListBx
        {
            get { return withEventsField_ListBx; }
            set
            {
                if (withEventsField_ListBx != null)
                {
                    withEventsField_ListBx.DrawItem -= Drawitem;
                }
                withEventsField_ListBx = value;
                if (withEventsField_ListBx != null)
                {
                    withEventsField_ListBx.DrawItem += Drawitem;
                }
            }
        }
        private string[] _items = { "" };

        private bool _LightTheme;
        #endregion

        #region " Poperties"

        public bool LightTheme
        {
            get { return _LightTheme; }
            set { _LightTheme = value; }
        }

        [Category("Options")]
        public string[] items
        {
            get { return _items; }
            set
            {
                _items = value;
                ListBx.Items.Clear();
                ListBx.Items.AddRange(value);
                Invalidate();
            }
        }

        [Category("Colors")]
        public Color SelectedColor
        {
            get { return _SelectedColor; }
            set { _SelectedColor = value; }
        }

        public string SelectedItem
        {
            get { return ListBx.SelectedItem.ToString(); }
        }

        public int SelectedIndex
        {
            get
            {
                int functionReturnValue = 0;
                return ListBx.SelectedIndex;
                if (ListBx.SelectedIndex < 0)
                    return functionReturnValue;
                return functionReturnValue;
            }
        }

        public void Clear()
        {
            ListBx.Items.Clear();
        }

        public void ClearSelected()
        {
            for (int i = (ListBx.SelectedItems.Count - 1); i >= 0; i += -1)
            {
                ListBx.Items.Remove(ListBx.SelectedItems[i]);
            }
        }

        public void Drawitem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            e.DrawBackground();
            e.DrawFocusRectangle();

            e.Graphics.SmoothingMode = (SmoothingMode)2;
            e.Graphics.PixelOffsetMode = (PixelOffsetMode)2;
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.TextRenderingHint = (TextRenderingHint)5;

            //-- if selected
            if (String.Compare(e.State.ToString(), "Selected,") > 0)
            {
                //-- Base
                e.Graphics.FillRectangle(new SolidBrush(_SelectedColor), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));

                //-- Text
                e.Graphics.DrawString(" " + ListBx.Items[e.Index].ToString(), new Font("Segoe UI", 8), Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
            }
            else
            {
                //-- Base
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(51, 53, 55)), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));

                //-- Text 
                e.Graphics.DrawString(" " + ListBx.Items[e.Index].ToString(), new Font("Segoe UI", 8), Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
            }

            e.Graphics.Dispose();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(ListBx))
            {
                Controls.Add(ListBx);
            }
        }

        public void AddRange(object[] items)
        {
            ListBx.Items.Remove("");
            ListBx.Items.AddRange(items);
        }

        public void AddItem(object item)
        {
            ListBx.Items.Remove("");
            ListBx.Items.Add(item);
        }

        #endregion

        #region " Colors"

        private Color BaseColor = Color.FromArgb(45, 47, 49);

        private Color _SelectedColor = _FlatColor;
        #endregion

        public MetroDiskListBox()
        {
            if (_LightTheme)
            {
                BaseColor = Color.FromArgb(255, 255, 255);
                ForeColor = Color.FromArgb(0, 0, 0);
                _SelectedColor = Color.FromArgb(200, 200, 200);
            }
            else
            {
                BaseColor = Color.FromArgb(0, 0, 0);
                ForeColor = Color.FromArgb(255, 255, 255);
                _SelectedColor = Color.FromArgb(20, 20, 20);
            }
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            ListBx.DrawMode = DrawMode.OwnerDrawFixed;
            ListBx.ScrollAlwaysVisible = false;
            ListBx.HorizontalScrollbar = false;
            ListBx.BorderStyle = BorderStyle.None;
            ListBx.BackColor = BaseColor;
            //ListBx.ForeColor = Color.White
            ListBx.Location = new Point(3, 3);
            ListBx.Font = new Font("Segoe UI", 8);
            ListBx.ItemHeight = 20;
            ListBx.Items.Clear();
            ListBx.IntegralHeight = false;

            Size = new Size(131, 101);
            BackColor = BaseColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_LightTheme)
            {
                BaseColor = Color.FromArgb(255, 255, 255);
                ForeColor = Color.FromArgb(0, 0, 0);
            }
            else
            {
                BaseColor = Color.FromArgb(0, 0, 0);
                ForeColor = Color.FromArgb(255, 255, 255);
            }
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            Rectangle Base = new Rectangle(0, 0, Width, Height);

            var _with16 = G;
            _with16.SmoothingMode = (SmoothingMode)2;
            _with16.PixelOffsetMode = (PixelOffsetMode)2;
            _with16.TextRenderingHint = (TextRenderingHint)5;
            _with16.Clear(BackColor);

            //-- Size
            ListBx.Size = new Size(Width - 6, Height - 2);

            //-- Base
            _with16.FillRectangle(new SolidBrush(BaseColor), Base);

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

    }

}