// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SkyLimit
{
    public class SkyDarkTabControl : TabControl
    {

        public SkyDarkTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }
        Color C1 = Color.FromArgb(62, 60, 58);
        Color C2 = Color.FromArgb(80, 78, 76);
        Color C3 = Color.FromArgb(51, 49, 47);
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            try
            {
                SelectedTab.BackColor = C1;
            }
            catch
            {
            }
            G.Clear(Parent.BackColor);
            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (!(i == SelectedIndex))
                {
                    Rectangle x2 = new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 3, GetTabRect(i).Width + 2, GetTabRect(i).Height);
                    LinearGradientBrush G1 = new LinearGradientBrush(new Point(x2.X, x2.Y), new Point(x2.X, x2.Y + x2.Height), Color.FromArgb(60, 59, 58), Color.FromArgb(69, 69, 70));
                    G.FillRectangle(G1, x2);
                    G1.Dispose();
                    G.DrawRectangle(ConversionFunctions.ToPen(C3), x2);
                    G.DrawRectangle(ConversionFunctions.ToPen(C2), new Rectangle(x2.X + 1, x2.Y + 1, x2.Width - 2, x2.Height));
                    G.DrawString(TabPages[i].Text, Font, ConversionFunctions.ToBrush(130, 176, 190), x2, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
            }

            G.FillRectangle(ConversionFunctions.ToBrush(C1), 0, ItemSize.Height, Width, Height);
            G.DrawRectangle(ConversionFunctions.ToPen(C2), 0, ItemSize.Height, Width - 1, Height - ItemSize.Height - 1);
            G.DrawRectangle(ConversionFunctions.ToPen(C3), 1, ItemSize.Height + 1, Width - 3, Height - ItemSize.Height - 3);
            if (!(SelectedIndex == -1))
            {
                Rectangle x1 = new Rectangle(GetTabRect(SelectedIndex).X - 2, GetTabRect(SelectedIndex).Y, GetTabRect(SelectedIndex).Width + 3, GetTabRect(SelectedIndex).Height);
                G.FillRectangle(ConversionFunctions.ToBrush(C1), new Rectangle(x1.X + 2, x1.Y + 2, x1.Width - 2, x1.Height));
                G.DrawLine(ConversionFunctions.ToPen(C2), new Point(x1.X, x1.Y + x1.Height - 2), new Point(x1.X, x1.Y));
                G.DrawLine(ConversionFunctions.ToPen(C2), new Point(x1.X, x1.Y), new Point(x1.X + x1.Width, x1.Y));
                G.DrawLine(ConversionFunctions.ToPen(C2), new Point(x1.X + x1.Width, x1.Y), new Point(x1.X + x1.Width, x1.Y + x1.Height - 2));

                G.DrawLine(ConversionFunctions.ToPen(C3), new Point(x1.X + 1, x1.Y + x1.Height - 1), new Point(x1.X + 1, x1.Y + 1));
                G.DrawLine(ConversionFunctions.ToPen(C3), new Point(x1.X + 1, x1.Y + 1), new Point(x1.X + x1.Width - 1, x1.Y + 1));
                G.DrawLine(ConversionFunctions.ToPen(C3), new Point(x1.X + x1.Width - 1, x1.Y + 1), new Point(x1.X + x1.Width - 1, x1.Y + x1.Height - 1));

                G.DrawString(TabPages[SelectedIndex].Text, Font, ConversionFunctions.ToBrush(130, 176, 190), x1, new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}