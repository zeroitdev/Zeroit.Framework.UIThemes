// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Loyal
{

    public class LoyalButton : Control
    {

        #region " Back End "

        #region " Enums "
        public enum Alignment
        {
            Left = 0,
            Center = 1,
            Right = 2
        }
        #endregion

        #region " Declarations "
        #endregion
        private MouseState _State = MouseState.None;

        #region " Mouse States "

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _State = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _State = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _State = MouseState.Over;
            Invalidate();
        }

        #endregion

        #region " Properties "

        private Alignment _TextAlignment = Alignment.Center;
        [Category("Button Settings")]
        public Alignment TextAlignment
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
                Invalidate();
            }
        }

        private Color _OutlineColor = Color.FromArgb(102, 51, 153);
        [Category("Button Settings")]
        public Color OutlineColor
        {
            get { return _OutlineColor; }
            set
            {
                _OutlineColor = value;
                Invalidate();
            }
        }

        #endregion

        public LoyalButton()
        {
            Size = new Size(75, 25);
        }
        #endregion
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            var _with2 = G;
            _with2.Clear(Color.FromArgb(40, 40, 40));
            switch (_State)
            {
                case MouseState.None:
                    _with2.DrawRectangle(new Pen(Color.FromArgb(24, 24, 24)), new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
                case MouseState.Over:
                    _with2.DrawRectangle(new Pen(_OutlineColor), new Rectangle(0, 0, Width - 1, Height - 1));

                    break;
                case MouseState.Down:
                    _with2.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), new Rectangle(0, 0, Width - 1, Height - 1));
                    _with2.DrawRectangle(new Pen(_OutlineColor), new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
            }
            _with2.DrawRectangle(new Pen(Color.FromArgb(48, 48, 48)), new Rectangle(1, 1, Width - 3, Height - 3));
            _with2.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, 0, 1, 1));
            _with2.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, Height - 1, 1, 1));
            _with2.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(Width - 1, 0, 1, 1));
            _with2.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(Width - 1, Height - 1, 1, 1));
            StringFormat _StringF = new StringFormat { LineAlignment = StringAlignment.Center };
            switch (_TextAlignment)
            {
                case Alignment.Center:
                    _StringF.Alignment = StringAlignment.Center;
                    _with2.DrawString(Text, new Font("Arial", 9), Brushes.White, new RectangleF(0, 0, Width - 1, Height - 1), _StringF);
                    break;
                case Alignment.Left:
                    _with2.DrawString(Text, new Font("Arial", 9), Brushes.White, new RectangleF(7, 0, Width - 11, Height - 1), _StringF);
                    break;
                case Alignment.Right:
                    int _StringLength = TextRenderer.MeasureText(Text, new Font("Arial", 9)).Width + 8;
                    _with2.DrawString(Text, new Font("Arial", 9), Brushes.White, new Rectangle(Width - _StringLength, 0, Width - _StringLength, Height - 1), _StringF);
                    break;
            }
        }

    }


}


