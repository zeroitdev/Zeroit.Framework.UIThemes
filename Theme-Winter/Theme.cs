// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Winter
{

    

    enum MouseState
    {
        None = 0,
        Over = 1,
        Down = 2
    }

    [ToolboxItem(false)]
    public class WinterTheme : ContainerControl
    {

        #region " Declarations "
        private bool _Down = false;
        private int _Header = 31;
        #endregion
        private Point _MousePoint;

        #region " Mouse States "
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _Down = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Location.Y < _Header && e.Button == MouseButtons.Left)
            {
                _MousePoint = e.Location;
                _Down = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_Down == true)
            {
                ParentForm.Location = new Point(MousePosition.X - _MousePoint.X, MousePosition.Y - _MousePoint.Y);
            }
        }
        #endregion
        
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.TransparencyKey = Color.Fuchsia;
            Dock = DockStyle.Fill;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(40, 40, 40));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(0, _Header, Width, Height - _Header));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(0, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(1, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(0, 1, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 2, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 1, 1, 1, 1));

            StringFormat _StringF = new StringFormat();
            _StringF.Alignment = StringAlignment.Center;
            _StringF.LineAlignment = StringAlignment.Center;
            G.DrawString(Text, new Font("Segoe UI", 11), Brushes.White, new RectangleF(0, 0, Width, _Header), _StringF);
        }
    }
    

}

