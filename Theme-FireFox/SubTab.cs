// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="SubTab.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.FireFox
{
    public class FirefoxSubTabControl : TabControl
    {

        #region " Private "
        private Graphics G;
        #endregion
        private Rectangle TabRect;

        #region " Control "

        public FirefoxSubTabControl()
        {
            DoubleBuffered = true;
            Alignment = TabAlignment.Top;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetStyle(ControlStyles.UserPaint, true);
            ItemSize = new Size(100, 40);
            SizeMode = TabSizeMode.Fixed;
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

            G.Clear(Parent.BackColor);


            for (int i = 0; i <= TabPages.Count - 1; i++)
            {
                TabRect = GetTabRect(i);


                if (GetTabRect(i).Contains(this.PointToClient(Cursor.Position)) & !(SelectedIndex == i))
                {
                    using (SolidBrush B = new SolidBrush(Helpers.GreyColor(240)))
                    {
                        G.FillRectangle(B, new Rectangle(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2, GetTabRect(i).Width, GetTabRect(i).Height + 1));
                    }


                }
                else if (SelectedIndex == i)
                {
                    using (SolidBrush B = new SolidBrush(Helpers.GreyColor(240)))
                    {
                        G.FillRectangle(B, new Rectangle(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2, GetTabRect(i).Width, GetTabRect(i).Height + 1));
                    }

                    using (Pen P = new Pen(Color.FromArgb(255, 149, 0), 4))
                    {
                        G.DrawLine(P, new Point(TabRect.X - 2, TabRect.Y + ItemSize.Height - 2), new Point(TabRect.X + TabRect.Width - 2, TabRect.Y + ItemSize.Height - 2));
                    }

                }
                else if (!(SelectedIndex == i))
                {
                    G.FillRectangle(Brushes.White, GetTabRect(i));
                }

                using (SolidBrush B = new SolidBrush(Color.FromArgb(56, 69, 80)))
                {
                    Helpers.CenterStringTab(G, TabPages[i].Text, Theme.GlobalFont, B, GetTabRect(i));
                }

            }

            using (Pen P = new Pen(Helpers.GreyColor(200)))
            {
                G.DrawLine(P, new Point(0, ItemSize.Height + 2), new Point(Width, ItemSize.Height + 2));
            }

        }

        #endregion

    }


}


