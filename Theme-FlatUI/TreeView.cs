﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TreeView.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.FlatUI.Helpers;
//using System.Threading;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.FlatUI
{

    public class FlatTreeView : TreeView
    {

        #region " Variables"


        private TreeNodeStates State;
        #endregion

        #region " Properties"

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            try
            {
                Rectangle Bounds = new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width, e.Bounds.Height);
                //e.Node.Nodes.Item.
                switch (State)
                {
                    case TreeNodeStates.Default:
                        e.Graphics.FillRectangle(Brushes.Red, Bounds);
                        e.Graphics.DrawString(e.Node.Text, new Font("Segoe UI", 8), Brushes.LimeGreen, new Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), NearSF);
                        Invalidate();
                        break;
                    case TreeNodeStates.Checked:
                        e.Graphics.FillRectangle(Brushes.Green, Bounds);
                        e.Graphics.DrawString(e.Node.Text, new Font("Segoe UI", 8), Brushes.Black, new Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), NearSF);
                        Invalidate();
                        break;
                    case TreeNodeStates.Selected:
                        e.Graphics.FillRectangle(Brushes.Green, Bounds);
                        e.Graphics.DrawString(e.Node.Text, new Font("Segoe UI", 8), Brushes.Black, new Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), NearSF);
                        Invalidate();
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Interaction.MsgBox(ex.Message);
            }

            base.OnDrawNode(e);
        }

        #endregion

        #region " Colors"

        private Color _BaseColor = Color.FromArgb(45, 47, 49);

        private Color _LineColor = Color.FromArgb(25, 27, 29);
        #endregion

        public FlatTreeView()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            BackColor = _BaseColor;
            ForeColor = Color.White;
            LineColor = _LineColor;
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            Rectangle Base = new Rectangle(0, 0, Width, Height);

            var _with22 = G;
            _with22.SmoothingMode = SmoothingMode.HighQuality;
            _with22.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with22.TextRenderingHint = TextRenderingHint.AntiAlias;
            _with22.Clear(BackColor);

            _with22.FillRectangle(new SolidBrush(_BaseColor), Base);
            _with22.DrawString(Text, new Font("Segoe UI", 8), Brushes.White, new Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), NearSF);


            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

    }


}
