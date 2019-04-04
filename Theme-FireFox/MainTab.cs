// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="MainTab.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.FireFox
{

    public class FirefoxMainTabControl : TabControl
    {

        #region " Private "
        private Graphics G;
        private Rectangle TabRect;
        #endregion
        private Color FC;

        #region " Control "

        public FirefoxMainTabControl()
        {
            DoubleBuffered = true;
            ItemSize = new Size(43, 152);
            Alignment = TabAlignment.Left;
            SizeMode = TabSizeMode.Fixed;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            try
            {
                for (int i = 0; i <= TabPages.Count - 1; i++)
                {
                    TabPages[i].BackColor = Color.White;
                    TabPages[i].ForeColor = Color.FromArgb(66, 79, 90);
                    TabPages[i].Font = Theme.GlobalFont;
                }
            }
            catch
            {
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Color.FromArgb(66, 79, 90));


            for (int i = 0; i <= TabPages.Count - 1; i++)
            {
                TabRect = GetTabRect(i);


                if (SelectedIndex == i)
                {
                    using (SolidBrush B = new SolidBrush(Color.FromArgb(52, 63, 72)))
                    {
                        G.FillRectangle(B, TabRect);
                    }

                    FC = Helpers.GreyColor(245);

                    using (SolidBrush B = new SolidBrush(Color.FromArgb(255, 175, 54)))
                    {
                        G.FillRectangle(B, new Rectangle(TabRect.Location.X - 3, TabRect.Location.Y + 1, 5, TabRect.Height - 2));
                    }

                }
                else
                {
                    FC = Helpers.GreyColor(192);

                    using (SolidBrush B = new SolidBrush(Color.FromArgb(66, 79, 90)))
                    {
                        G.FillRectangle(B, TabRect);
                    }

                }

                using (SolidBrush B = new SolidBrush(FC))
                {
                    G.DrawString(TabPages[i].Text, Theme.GlobalFont, B, new Point(TabRect.X + 50, TabRect.Y + 12));
                }

                if ((ImageList != null))
                {
                    if (!(TabPages[i].ImageIndex < 0))
                    {
                        G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Rectangle(TabRect.X + 19, TabRect.Y + ((TabRect.Height / 2) - 10), 18, 18));
                    }
                }

            }

        }

        #endregion

    }


}


