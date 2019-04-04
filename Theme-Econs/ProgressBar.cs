// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.Econs.Helpers;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.Econs
{
    public class EconsProgressBar : Control
    {

        #region " Variables"

        private int W;
        private int H;
        private int _Value = 0;

        private int _Maximum = 100;
        #endregion

        #region " Properties"

        #region " Control"

        [Category("Control")]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {

                if (value == _Value)
                {
                    _Value = value;
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //_Value:
                //					_Value = value;
                //					break;
                //			} 
                #endregion

                _Maximum = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public int Value
        {
            get
            {
                switch (_Value)
                {
                    case 0:
                        return 0;
                        Invalidate();
                        break;
                    default:
                        return _Value;
                        Invalidate();
                        break;
                }
            }
            set
            {

                if (value == _Maximum)
                {
                    value = _Maximum;
                    Invalidate();
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //_Maximum:
                //					value = _Maximum;
                //					Invalidate();
                //					break;
                //			} 
                #endregion

                _Value = value;
                Invalidate();
            }
        }

        #endregion

        #region " Colors"

        [Category("Colors")]
        public Color ProgressColor
        {
            get { return _ProgressColor; }
            set { _ProgressColor = value; }
        }

        [Category("Colors")]
        public Color DarkerProgress
        {
            get { return _DarkerProgress; }
            set { _DarkerProgress = value; }
        }

        #endregion

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 42;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Height = 42;
        }

        public void Increment(int Amount)
        {
            Value += Amount;
        }

        #endregion

        #region " Colors"

        private Color _BaseColor = Color.FromArgb(45, 47, 49);
        private Color _ProgressColor = _FlatColor;

        private Color _DarkerProgress = Color.FromArgb(23, 148, 92);
        #endregion

        public EconsProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(60, 70, 73);
            Height = 42;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width - 1;
            H = Height - 1;

            Rectangle Base = new Rectangle(0, 24, W, H);
            dynamic GP = default(GraphicsPath);
            dynamic GP2 = default(GraphicsPath);
            GraphicsPath GP3 = new GraphicsPath();

            var _with12 = G;
            _with12.SmoothingMode = (SmoothingMode)2;
            _with12.PixelOffsetMode = (PixelOffsetMode)2;
            _with12.TextRenderingHint = (TextRenderingHint)5;
            _with12.Clear(BackColor);

            //-- Progress Value
            int iValue = Convert.ToInt32(_Value / _Maximum * Width);

            switch (Value)
            {
                case 0:
                    //-- Base
                    _with12.FillRectangle(new SolidBrush(_BaseColor), Base);
                    //--Progress
                    _with12.FillRectangle(new SolidBrush(_ProgressColor), new Rectangle(0, 24, iValue - 1, H - 1));
                    break;
                case 100:
                    //-- Base
                    _with12.FillRectangle(new SolidBrush(_BaseColor), Base);
                    //--Progress
                    _with12.FillRectangle(new SolidBrush(_ProgressColor), new Rectangle(0, 24, iValue - 1, H - 1));
                    break;
                default:
                    //-- Base
                    _with12.FillRectangle(new SolidBrush(_BaseColor), Base);

                    //--Progress
                    GP.AddRectangle(new Rectangle(0, 24, iValue - 1, H - 1));
                    _with12.FillPath(new SolidBrush(_ProgressColor), GP);

                    break;
                    //-- Hatch Brush
                    //Dim HB As New HatchBrush(HatchStyle.Plaid, _DarkerProgress, _ProgressColor)
                    //.FillRectangle(HB, New Rectangle(0, 24, iValue - 1, H - 1))

                    //-- Balloon
                    //Dim Balloon As New Rectangle(iValue - 18, 25, 34, 16)
                    //GP2 = Helpers.RoundRec(Balloon, 4)
                    //.FillPath(New SolidBrush(_BaseColor), GP2)

                    //-- Arrow
                    //'GP3 = Helpers.DrawArrow(iValue - 9, 16, True)
                    //'.FillPath(New SolidBrush(_BaseColor), GP3)

                    //-- Value > You can add "%" > value & "%"
                    //.DrawString(Value, New Font("Segoe UI", 10), New SolidBrush(_ProgressColor), New Rectangle(iValue - 11, 25, W, H), NearSF)
            }

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

    }
}