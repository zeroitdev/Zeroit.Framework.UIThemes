// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ListBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Empire
{
    public class TheEmpireListbox : ListBox
    {

        #region "CreateRound"

        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

        #endregion

        public TheEmpireListbox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BorderStyle = BorderStyle.None;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 24;
            ForeColor = Color.Black;
            BackColor = Color.FromArgb(200, 200, 200);
            IntegralHeight = false;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 15)
            {
                Graphics G = CreateGraphics();
                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.DrawPath(new Pen(Color.FromArgb(100, 100, 100)), CreateRound(0, 0, Width - 1, Height - 1, 7));
            }
            base.WndProc(ref m);
        }

        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            CreateGraphics().DrawPath(new Pen(Color.FromArgb(100, 100, 100)), CreateRound(0, 0, Width - 1, Height - 1, 7));

            if (e.Index < 0 | Items.Count < 1)
                return;
            Rectangle ItemRectangle = new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 1, e.Bounds.Width - 7, e.Bounds.Height - 2);


            e.Graphics.FillRectangle(new SolidBrush(BackColor), ItemRectangle);
            e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            if (e.State > 0)
            {
                LinearGradientBrush LGB = new LinearGradientBrush(ItemRectangle, Color.FromArgb(36, 36, 36), Color.FromArgb(25, 25, 25), 90f);
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.FillPath(LGB, CreateRound(ItemRectangle, 4));
                e.Graphics.SmoothingMode = SmoothingMode.None;

                e.Graphics.DrawString(GetItemText(Items[e.Index]), Font, Brushes.White, 7, e.Bounds.Y + 4);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
                e.Graphics.DrawString(GetItemText(Items[e.Index]), Font, Brushes.Black, 7, e.Bounds.Y + 4);
            }

            base.OnDrawItem(e);

            CreateGraphics().DrawPath(new Pen(Color.FromArgb(100, 100, 100)), CreateRound(0, 0, Width - 1, Height - 1, 7));
        }
    }


}