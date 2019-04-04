// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-19-2019
// ***********************************************************************
// <copyright file="Hex Theme.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.UIThemes.Hex
{

    

    enum MouseState
    {
        None = 0,
        Over = 1,
        Down = 2
    }

    public class HexTheme : ContainerControl
    {

        #region " Declarations "
        private bool _Down = false;
        private int _Header = 30;
        #endregion
        private Point _MousePoint;
        
        #region " Mouse States "
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Y < _Header && e.Button == MouseButtons.Left)
            {
                _Down = true;
                _MousePoint = e.Location;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _Down = false;
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
            G.Clear(Color.FromArgb(47, 51, 60));
            G.FillRectangle(new SolidBrush(Color.FromArgb(30, 33, 40)), new Rectangle(0, _Header, Width, Height - _Header));
            StringFormat _StringF = new StringFormat();
            _StringF.Alignment = StringAlignment.Center;
            _StringF.LineAlignment = StringAlignment.Center;
            G.DrawString(Text, new Font("Segoe UI", 11), new SolidBrush(Color.FromArgb(236, 95, 75)), new RectangleF(0, 0, Width, _Header), _StringF);
        }

    }

    

}

