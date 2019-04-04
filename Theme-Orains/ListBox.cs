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


namespace Zeroit.Framework.UIThemes.Orains
{
    public class OrainsListBox : ListBox
    {


        ScrollBar SCROLL;
        public OrainsListBox()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            //Font = New Font("Arial", 8)
            BorderStyle = BorderStyle.None;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 15;
            ForeColor = Color.Orange;
            BackColor = Color.FromArgb(20, 20, 20);
            IntegralHeight = false;
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 15)
                CustomPaint();
        }

        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                if (e.Index < 0)
                    return;
                e.DrawBackground();
                Rectangle rect = new Rectangle(new Point(e.Bounds.Left, e.Bounds.Top + 2), new Size(Bounds.Width, 16));
                e.DrawFocusRectangle();
                if (String.Compare(e.State.ToString(), "Selected,") > 0)
                {
                    e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
                    Rectangle x2 = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 1, e.Bounds.Height));
                    Rectangle x3 = new Rectangle(x2.Location, new Size(x2.Width, (x2.Height / 2)));
                    LinearGradientBrush G1 = new LinearGradientBrush(new Point(x2.X, x2.Y), new Point(x2.X, x2.Y + x2.Height), Color.FromArgb(255, 128, 0), Color.FromArgb(153, 76, 0));
                    HatchBrush H = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(10, Color.Black), Color.Transparent);
                    e.Graphics.FillRectangle(G1, x2);
                    G1.Dispose();
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), x3);
                    e.Graphics.FillRectangle(H, x2);
                    G1.Dispose();
                    e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, Brushes.Black, e.Bounds.X, e.Bounds.Y + 1);
                }
                else
                {
                    e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, Brushes.Orange, e.Bounds.X, e.Bounds.Y + 1);
                }
                e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, Width - 1, Height - 1));
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(40, 40, 40)), new Rectangle(1, 1, Width - 3, Height - 3));
                base.OnDrawItem(e);
            }
            catch (Exception ex)
            {
            }

        }

        public void CustomPaint()
        {
            CreateGraphics().DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, Width - 1, Height - 1));
            CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(40, 40, 40)), new Rectangle(1, 1, Width - 3, Height - 3));
        }
    }

}


