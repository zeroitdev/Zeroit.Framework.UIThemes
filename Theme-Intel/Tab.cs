// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Intel
{

    public class iTabControl : TabControl
    {

        private Color _BG;
        public override Color BackColor
        {
            get { return _BG; }
            set { _BG = value; }
        }

        public iTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(45, 45, 45);
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }

        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            try
            {
                SelectedTab.BackColor = BackColor;
            }
            catch
            {
            }
            G.Clear(BackColor);
            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    Rectangle x2 = new Rectangle(GetTabRect(i).X - 2, GetTabRect(i).Y, GetTabRect(i).Width, GetTabRect(i).Height - 2);
                    Rectangle x3 = new Rectangle(GetTabRect(i).X - 2, GetTabRect(i).Y, GetTabRect(i).Width, GetTabRect(i).Height - 1);
                    Rectangle x4 = new Rectangle(GetTabRect(i).X - 2, GetTabRect(i).Y, GetTabRect(i).Width, GetTabRect(i).Height);
                    LinearGradientBrush G1 = new LinearGradientBrush(x3, Color.FromArgb(10, 0, 0, 0), Color.FromArgb(35, 35, 35), 90f);
                    HatchBrush HB = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(10, Color.Black), Color.Transparent);

                    G.FillRectangle(HB, x3);
                    HB.Dispose();
                    G.FillRectangle(G1, x3);
                    G1.Dispose();
                    G.DrawLine(new Pen(Color.FromArgb(10, 10, 10)), x2.Location, new Point(x2.Location.X, x2.Location.Y + x2.Height));
                    G.DrawLine(new Pen(Color.FromArgb(10, 10, 10)), new Point(x2.Location.X + x2.Width, x2.Location.Y), new Point(x2.Location.X + x2.Width, x2.Location.Y + x2.Height));
                    G.DrawLine(new Pen(Color.FromArgb(10, 10, 10)), new Point(x2.Location.X, x2.Location.Y), new Point(x2.Location.X + x2.Width, x2.Location.Y));
                    G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.DeepSkyBlue), x4, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
                else
                {
                    Rectangle x2 = new Rectangle(GetTabRect(i).X - 2, GetTabRect(i).Y + 3, GetTabRect(i).Width, GetTabRect(i).Height - 5);
                    LinearGradientBrush G1 = new LinearGradientBrush(x2, Color.FromArgb(30, 30, 30), Color.FromArgb(35, 35, 35), -90f);
                    G.FillRectangle(G1, x2);
                    G1.Dispose();
                    G.DrawRectangle(new Pen(Color.FromArgb(15, 15, 15)), x2);
                    G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.FromArgb(75, 75, 75)), x2, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
            }
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(10, 10, 10))), new Rectangle(0, 21, Width - 1, Height - 22));

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
            G.Dispose();
            B.Dispose();
        }


    }


}


