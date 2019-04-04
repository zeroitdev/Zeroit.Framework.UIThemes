// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Influence
{
    public class InfluenceListBox : Control
    {
        private ListBox withEventsField_lstbox = new ListBox();
        public ListBox lstbox
        {
            get { return withEventsField_lstbox; }
            set
            {
                if (withEventsField_lstbox != null)
                {
                    withEventsField_lstbox.DrawItem -= DrawItem;
                }
                withEventsField_lstbox = value;
                if (withEventsField_lstbox != null)
                {
                    withEventsField_lstbox.DrawItem += DrawItem;
                }
            }
        }

        private string[] __Items = { "" };
        #region " Control Help - Properties & Flicker Control "
        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            lstbox.Size = new Size(Width - 6, Height - 6);
            Invalidate();
        }
        protected override void OnBackColorChanged(System.EventArgs e)
        {
            base.OnBackColorChanged(e);
            lstbox.BackColor = Color.FromArgb(43, 43, 43);
            Invalidate();
        }
        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            lstbox.ForeColor = ForeColor;
            Invalidate();
        }
        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            lstbox.Font = Font;
        }
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            lstbox.Focus();
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            lstbox.Size = new Size(Width - 11, Height - 11);
            Invalidate();
        }
        public string[] Items
        {
            get
            {
                return __Items;
                Invalidate();
            }
            set
            {
                __Items = value;
                lstbox.Items.Clear();
                Invalidate();
                lstbox.Items.AddRange(value);
                Invalidate();
            }
        }
        public string SelectedItem
        {
            get { return lstbox.SelectedItem.ToString(); }
        }
        public void DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                e.Graphics.DrawString(lstbox.Items[e.Index].ToString(), e.Font, new SolidBrush(lstbox.ForeColor), e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
            catch
            {
            }
        }
        public void AddRange(object[] Items)
        {
            lstbox.Items.Remove("");
            lstbox.Items.AddRange(Items);
            Invalidate();
        }
        public void AddItem(object Item)
        {
            lstbox.Items.Add(Item);
            Invalidate();
        }
        public void NewListBox()
        {
            lstbox.Size = new Size(Width - 8, Height - 8);
            lstbox.BorderStyle = BorderStyle.None;
            lstbox.DrawMode = DrawMode.OwnerDrawVariable;
            lstbox.Location = new Point(3, 3);
            lstbox.ForeColor = Color.White;
            lstbox.BackColor = Color.FromArgb(43, 43, 43);
            lstbox.Items.Clear();
        }

        #endregion

        public InfluenceListBox()
            : base()
        {

            NewListBox();
            Controls.Add(lstbox);

            Size = new Size(128, 108);
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.HighQuality;
            Draw d = new Draw();
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            lstbox.Size = new Size(Width - 7, Height - 7);

            G.Clear(BackColor);

            LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), 90);
            G.FillPath(g1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2), 2));
            LinearGradientBrush g2 = new LinearGradientBrush(new Rectangle(0, Height / 2, Width - 1, Height / 2), Color.FromArgb(45, 45, 45), Color.FromArgb(40, 40, 40), 90);
            G.FillPath(g2, d.RoundRect(new Rectangle(0, Height / 2 - 3, Width - 1, Height / 2 + 2), 2));

            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), d.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), 2));
            G.DrawPath(new Pen(Color.FromArgb(10, 10, 10)), d.RoundRect(ClientRectangle, 2));

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


}

