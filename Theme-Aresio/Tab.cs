// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 08-12-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 08-12-2017
// ***********************************************************************
// <copyright file="Aresio Theme.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Aresio
{

    /// <summary>
    /// Class AresioTabControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TabControl" />
    public class AresioTabControl : TabControl
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AresioTabControl"/> class.
        /// </summary>
        public AresioTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

        }
        /// <summary>
        /// This member overrides <see cref="M:System.Windows.Forms.Control.CreateHandle" />.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            SizeMode = TabSizeMode.Normal;
            ItemSize = new Size(77, 31);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Rectangle ItemBounds = default(Rectangle);
            SolidBrush TextBrush = new SolidBrush(Color.Empty);
            int SOFF = 0;
            G.Clear(Color.FromArgb(236, 237, 239));

            for (int TabItemIndex = 0; TabItemIndex <= this.TabCount - 1; TabItemIndex++)
            {
                ItemBounds = this.GetTabRect(TabItemIndex);

                if (!(TabItemIndex == SelectedIndex))
                {
                    SOFF = 2;

                    G.FillPath(DesignFunctions.ToBrush(10, Color.Black), DesignFunctions.RoundRect(new Rectangle(new Point(ItemBounds.X, ItemBounds.Y + SOFF), new Size(ItemBounds.Width, ItemBounds.Height)), 2));
                    G.DrawPath(DesignFunctions.ToPen(90, Color.Black), DesignFunctions.RoundRect(new Rectangle(new Point(ItemBounds.X, ItemBounds.Y + SOFF), new Size(ItemBounds.Width, ItemBounds.Height)), 2));

                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;
                    TextBrush.Color = Color.FromArgb(80, 80, 80);
                    try
                    {
                        G.DrawString(TabPages[TabItemIndex].Text, new Font(Font.Name, Font.Size - 1), TextBrush, new Rectangle(GetTabRect(TabItemIndex).Location, GetTabRect(TabItemIndex).Size), sf);
                        TabPages[TabItemIndex].BackColor = Color.FromArgb(236, 237, 239);
                    }
                    catch
                    {
                    }

                }
            }

            G.FillPath(DesignFunctions.ToBrush(236, 237, 239), DesignFunctions.RoundRect(0, ItemSize.Height - 1, Width - 1, Height - ItemSize.Height - 1, 2));
            G.DrawPath(DesignFunctions.ToPen(150, 151, 153), DesignFunctions.RoundRect(0, ItemSize.Height - 1, Width - 1, Height - ItemSize.Height - 1, 2));

            for (int TabItemIndex = 0; TabItemIndex <= this.TabCount - 1; TabItemIndex++)
            {
                ItemBounds = this.GetTabRect(TabItemIndex);


                if (TabItemIndex == SelectedIndex)
                {
                    G.FillPath(DesignFunctions.ToBrush(236, 237, 239), DesignFunctions.RoundRect(new Rectangle(new Point(ItemBounds.X - 2, ItemBounds.Y), new Size(ItemBounds.Width + 3, ItemBounds.Height - 2)), 2));
                    G.DrawPath(DesignFunctions.ToPen(150, 151, 153), DesignFunctions.RoundRect(new Rectangle(new Point(ItemBounds.X - 2, ItemBounds.Y), new Size(ItemBounds.Width + 2, ItemBounds.Height - 2)), 2));

                    G.FillRectangle(DesignFunctions.ToBrush(236, 237, 239), new Rectangle(new Point(ItemBounds.X - 1, ItemBounds.Y + 1), new Size(ItemBounds.Width + 1, ItemBounds.Height)));
                    SOFF = 0;

                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;
                    TextBrush.Color = Color.FromArgb(80, 80, 80);
                    try
                    {
                        G.DrawString(TabPages[TabItemIndex].Text, Font, TextBrush, new Rectangle(new Point(Convert.ToInt32(GetTabRect(TabItemIndex).Location), SOFF), GetTabRect(TabItemIndex).Size), sf);
                        TabPages[TabItemIndex].BackColor = Color.FromArgb(236, 237, 239);
                    }
                    catch
                    {
                    }

                }
            }
        }

    }

    
}