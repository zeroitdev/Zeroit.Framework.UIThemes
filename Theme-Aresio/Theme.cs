// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 08-12-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 08-12-2017
// ***********************************************************************
// <copyright file="Aresio Theme.cs" company="Zeroit Dev Technologies">
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

using System.Drawing.Drawing2D;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Aresio
{
    /// <summary>
    /// Class DesignFunctions.
    /// </summary>
    static class DesignFunctions
    {
        /// <summary>
        /// To the brush.
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="R">The r.</param>
        /// <param name="G">The g.</param>
        /// <param name="B">The b.</param>
        /// <returns>Brush.</returns>
        public static Brush ToBrush(int A, int R, int G, int B)
        {
            return ToBrush(Color.FromArgb(A, R, G, B));
        }
        /// <summary>
        /// To the brush.
        /// </summary>
        /// <param name="R">The r.</param>
        /// <param name="G">The g.</param>
        /// <param name="B">The b.</param>
        /// <returns>Brush.</returns>
        public static Brush ToBrush(int R, int G, int B)
        {
            return ToBrush(Color.FromArgb(R, G, B));
        }
        /// <summary>
        /// To the brush.
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="C">The c.</param>
        /// <returns>Brush.</returns>
        public static Brush ToBrush(int A, Color C)
        {
            return ToBrush(Color.FromArgb(A, C));
        }
        /// <summary>
        /// To the brush.
        /// </summary>
        /// <param name="Pen">The pen.</param>
        /// <returns>Brush.</returns>
        public static Brush ToBrush(Pen Pen)
        {
            return ToBrush(Pen.Color);
        }
        /// <summary>
        /// To the brush.
        /// </summary>
        /// <param name="Color">The color.</param>
        /// <returns>Brush.</returns>
        public static Brush ToBrush(Color Color)
        {
            return new SolidBrush(Color);
        }
        /// <summary>
        /// To the pen.
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="R">The r.</param>
        /// <param name="G">The g.</param>
        /// <param name="B">The b.</param>
        /// <returns>Pen.</returns>
        public static Pen ToPen(int A, int R, int G, int B)
        {
            return ToPen(Color.FromArgb(A, R, G, B));
        }
        /// <summary>
        /// To the pen.
        /// </summary>
        /// <param name="R">The r.</param>
        /// <param name="G">The g.</param>
        /// <param name="B">The b.</param>
        /// <returns>Pen.</returns>
        public static Pen ToPen(int R, int G, int B)
        {
            return ToPen(Color.FromArgb(R, G, B));
        }
        /// <summary>
        /// To the pen.
        /// </summary>
        /// <param name="A">a.</param>
        /// <param name="C">The c.</param>
        /// <returns>Pen.</returns>
        public static Pen ToPen(int A, Color C)
        {
            return ToPen(Color.FromArgb(A, C));
        }
        /// <summary>
        /// To the pen.
        /// </summary>
        /// <param name="Color">The color.</param>
        /// <returns>Pen.</returns>
        public static Pen ToPen(Color Color)
        {
            return ToPen(new SolidBrush(Color));
        }
        /// <summary>
        /// To the pen.
        /// </summary>
        /// <param name="Brush">The brush.</param>
        /// <returns>Pen.</returns>
        public static Pen ToPen(SolidBrush Brush)
        {
            return new Pen(Brush);
        }

        /// <summary>
        /// Class CornerStyle.
        /// </summary>
        public class CornerStyle
        {
            /// <summary>
            /// The top left
            /// </summary>
            public bool TopLeft;
            /// <summary>
            /// The top right
            /// </summary>
            public bool TopRight;
            /// <summary>
            /// The bottom left
            /// </summary>
            public bool BottomLeft;
            /// <summary>
            /// The bottom right
            /// </summary>
            public bool BottomRight;
        }

        /// <summary>
        /// Advs the rect.
        /// </summary>
        /// <param name="Rectangle">The rectangle.</param>
        /// <param name="CornerStyle">The corner style.</param>
        /// <param name="Curve">The curve.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath AdvRect(Rectangle Rectangle, CornerStyle CornerStyle, int Curve)
        {
            GraphicsPath functionReturnValue = default(GraphicsPath);
            functionReturnValue = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;

            if (CornerStyle.TopLeft)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X, Rectangle.Y, Rectangle.X + ArcRectangleWidth, Rectangle.Y);
            }

            if (CornerStyle.TopRight)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + ArcRectangleWidth);
            }

            if (CornerStyle.BottomRight)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height, Rectangle.X + Rectangle.Width - ArcRectangleWidth, Rectangle.Y + Rectangle.Height);
            }

            if (CornerStyle.BottomLeft)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y + Rectangle.Height - ArcRectangleWidth);
            }

            functionReturnValue.CloseAllFigures();

            return functionReturnValue;
            return functionReturnValue;
        }

        /// <summary>
        /// Rounds the rect.
        /// </summary>
        /// <param name="Rectangle">The rectangle.</param>
        /// <param name="Curve">The curve.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath functionReturnValue = default(GraphicsPath);
            functionReturnValue = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            functionReturnValue.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            functionReturnValue.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            functionReturnValue.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, ArcRectangleWidth + Rectangle.Y));
            functionReturnValue.CloseAllFigures();
            return functionReturnValue;
            return functionReturnValue;
        }

        /// <summary>
        /// Rounds the rect.
        /// </summary>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        /// <param name="Curve">The curve.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            return RoundRect(new Rectangle(X, Y, Width, Height), Curve);
        }

        /// <summary>
        /// Class PillStyle.
        /// </summary>
        public class PillStyle
        {
            /// <summary>
            /// The left
            /// </summary>
            public bool Left;
            /// <summary>
            /// The right
            /// </summary>
            public bool Right;
        }

        #region Trying to add
        //public enum Styles { Left, Right }
        //private static Styles styles = Styles.Left;

        //public static GraphicsPath Pill(Rectangle Rectangle, bool left, bool right)
        //{
        //    GraphicsPath functionReturnValue = default(GraphicsPath);
        //    functionReturnValue = new GraphicsPath();

        //    DesignFunctions.PillStyle pillstyle = new DesignFunctions.PillStyle();

        //    switch (styles)
        //    {
        //        case Styles.Left:
        //            pillstyle.Left = true;
        //            if (pillstyle.Left)
        //            {
        //                functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height), -270, 180);
        //            }
        //            else
        //            {
        //                functionReturnValue.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y);
        //            }
        //            break;
        //        case Styles.Right:
        //            pillstyle.Right = true;
        //            if (pillstyle.Right)
        //            {
        //                functionReturnValue.AddArc(new Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height, Rectangle.Height), -90, 180);
        //            }
        //            else
        //            {
        //                functionReturnValue.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height);
        //            }
        //            break;
        //        default:
        //            break;
        //    }

        //    functionReturnValue.CloseAllFigures();

        //    return functionReturnValue;
        //    return functionReturnValue;
        //} 
        #endregion

        /// <summary>
        /// Pills the specified rectangle.
        /// </summary>
        /// <param name="Rectangle">The rectangle.</param>
        /// <param name="PillStyle">The pill style.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath Pill(Rectangle Rectangle, PillStyle PillStyle)
        {
            GraphicsPath functionReturnValue = default(GraphicsPath);
            functionReturnValue = new GraphicsPath();

            if (PillStyle.Left)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height), -270, 180);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y);
            }

            if (PillStyle.Right)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height, Rectangle.Height), -90, 180);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height);
            }

            functionReturnValue.CloseAllFigures();

            //return Pill(new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height), PillStyle);
            return functionReturnValue;
            //return functionReturnValue;
        }

        /// <summary>
        /// Pills the specified x.
        /// </summary>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        /// <param name="PillStyle">The pill style.</param>
        /// <returns>System.Object.</returns>
        public static object Pill(int X, int Y, int Width, int Height, PillStyle PillStyle)
        {
            return Pill(new Rectangle(X, Y, Width, Height), PillStyle);
        }

    }

    
}