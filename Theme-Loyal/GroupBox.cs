// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Loyal
{

    public class LoyalGroupBox : ContainerControl
    {

        #region " Back End "

        #region " Enums "

        public enum TextAlign
        {
            Left = 0,
            Center = 1,
            Right = 2
        }

        #endregion

        #region " Properties "

        private int _HeaderSize = 35;
        [Category("Header Properties")]
        public int HeaderSize
        {
            get { return _HeaderSize; }
            set
            {
                _HeaderSize = value;
                Invalidate();
            }
        }

        private Color _HeaderColor = Color.FromArgb(102, 51, 153);
        [Category("Header Properties")]
        public Color HeaderColor
        {
            get { return _HeaderColor; }
            set
            {
                _HeaderColor = value;
                Invalidate();
            }
        }

        private TextAlign _TextAlignment = TextAlign.Left;
        public TextAlign TextAlignment
        {
            get { return _TextAlignment; }
            set { _TextAlignment = value; }
        }

        #endregion

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            BackColor = Color.FromArgb(40, 40, 40);
        }

        public LoyalGroupBox()
        {
            Size = new Size(200, 100);
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            var _with3 = G;
            _with3.Clear(Color.FromArgb(40, 40, 40));
            _with3.FillRectangle(new SolidBrush(_HeaderColor), new Rectangle(5, 5, Width - 10, _HeaderSize - 5));
            _with3.DrawLine(new Pen(Color.FromArgb(30, Color.White)), new Point(6, 5), new Point(Width - 6, 5));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, 0, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(Width - 1, 0, 1, 1));
            _with3.DrawLine(new Pen(Color.FromArgb(70, Color.Black)), new Point(5, _HeaderSize), new Point(Width - 6, _HeaderSize));
            _with3.DrawRectangle(new Pen(Color.FromArgb(18, 18, 18)), new Rectangle(0, 0, Width - 1, Height - 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(5, 5, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(Width - 6, 5, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, 0, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, Height - 1, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(Width - 1, 0, 1, 1));
            _with3.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(Width - 1, Height - 1, 1, 1));
            StringFormat _StringF = new StringFormat { LineAlignment = StringAlignment.Center };
            switch (_TextAlignment)
            {
                case TextAlign.Center:
                    _StringF.Alignment = StringAlignment.Center;
                    _with3.DrawString(Text, new Font("Arial", 9), Brushes.White, new RectangleF(5, 5, Width - 10, _HeaderSize - 5), _StringF);
                    break;
                case TextAlign.Left:
                    _with3.DrawString(Text, new Font("Arial", 9), Brushes.White, new RectangleF(12, 5, Width - 10, _HeaderSize - 5), _StringF);
                    break;
                case TextAlign.Right:
                    int _StringLength = TextRenderer.MeasureText(Text, new Font("Arial", 9)).Width + 8;
                    _with3.DrawString(Text, new Font("Arial", 9), Brushes.White, new Rectangle(Width - _StringLength, 5, Width - _StringLength, _HeaderSize - 5), _StringF);
                    break;
            }
        }
    }


}


