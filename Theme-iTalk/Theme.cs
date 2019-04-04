// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.iTalk
{

    #region  RoundRect 

	    

	    internal static class RoundRectangle
	    {
		    public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
		    {
			    GraphicsPath GP = new GraphicsPath();
			    int EndArcWidth = Curve * 2;
			    GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -180F, 90F);
			    GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -90F, 90F);
			    GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 0F, 90F);
			    GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 90F, 90F);
			    GP.AddLine(new Point(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
			    return GP;
		    }

		    public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
		    {
			    Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
			    GraphicsPath GP = new GraphicsPath();
			    int EndArcWidth = Curve * 2;
			    GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -180F, 90F);
			    GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -90F, 90F);
			    GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 0F, 90F);
			    GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 90F, 90F);
			    GP.AddLine(new Point(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
			    return GP;
		    }
	    }

    #endregion

    #region  Control Renderer 

    #region  Color Table 

	    public abstract class xColorTable
	    {
		    public abstract Color TextColor {get;}
		    public abstract Color Background {get;}
		    public abstract Color SelectionBorder {get;}
		    public abstract Color SelectionTopGradient {get;}
		    public abstract Color SelectionMidGradient {get;}
		    public abstract Color SelectionBottomGradient {get;}
		    public abstract Color PressedBackground {get;}
		    public abstract Color CheckedBackground {get;}
		    public abstract Color CheckedSelectedBackground {get;}
		    public abstract Color DropdownBorder {get;}
		    public abstract Color Arrow {get;}
		    public abstract Color OverflowBackground {get;}
	    }

	    public abstract class ColorTable
	    {
		    public abstract xColorTable CommonColorTable {get;}
		    public abstract Color BackgroundTopGradient {get;}
		    public abstract Color BackgroundBottomGradient {get;}
		    public abstract Color DroppedDownItemBackground {get;}
		    public abstract Color DropdownTopGradient {get;}
		    public abstract Color DropdownBottomGradient {get;}
		    public abstract Color Separator {get;}
		    public abstract Color ImageMargin {get;}
	    }

	    public class MSColorTable : ColorTable
	    {
		    private xColorTable _CommonColorTable;

		    public MSColorTable()
		    {
			    _CommonColorTable = new DefaultCColorTable();
		    }

		    public override xColorTable CommonColorTable
		    {
			    get
			    {
				    return _CommonColorTable;
			    }
		    }

		    public override System.Drawing.Color BackgroundTopGradient
		    {
			    get
			    {
				    return Color.FromArgb(246, 246, 246);
			    }
		    }

		    public override System.Drawing.Color BackgroundBottomGradient
		    {
			    get
			    {
				    return Color.FromArgb(226, 226, 226);
			    }
		    }

		    public override System.Drawing.Color DropdownTopGradient
		    {
			    get
			    {
				    return Color.FromArgb(246, 246, 246);
			    }
		    }

		    public override System.Drawing.Color DropdownBottomGradient
		    {
			    get
			    {
				    return Color.FromArgb(246, 246, 246);
			    }
		    }

		    public override System.Drawing.Color DroppedDownItemBackground
		    {
			    get
			    {
				    return Color.FromArgb(240, 240, 240);
			    }
		    }

		    public override System.Drawing.Color Separator
		    {
			    get
			    {
				    return Color.FromArgb(190, 195, 203);
			    }
		    }

		    public override System.Drawing.Color ImageMargin
		    {
			    get
			    {
				    return Color.FromArgb(240, 240, 240);
			    }
		    }
	    }

	    public class DefaultCColorTable : xColorTable
	    {
		    public override System.Drawing.Color CheckedBackground
		    {
			    get
			    {
				    return Color.FromArgb(230, 230, 230);
			    }
		    }

		    public override System.Drawing.Color CheckedSelectedBackground
		    {
			    get
			    {
				    return Color.FromArgb(230, 230, 230);
			    }
		    }

		    public override System.Drawing.Color SelectionBorder
		    {
			    get
			    {
				    return Color.FromArgb(180, 180, 180);
			    }
		    }

		    public override System.Drawing.Color SelectionTopGradient
		    {
			    get
			    {
				    return Color.FromArgb(240, 240, 240);
			    }
		    }

		    public override System.Drawing.Color SelectionMidGradient
		    {
			    get
			    {
				    return Color.FromArgb(235, 235, 235);
			    }
		    }

		    public override System.Drawing.Color SelectionBottomGradient
		    {
			    get
			    {
				    return Color.FromArgb(230, 230, 230);
			    }
		    }

		    public override System.Drawing.Color PressedBackground
		    {
			    get
			    {
				    return Color.FromArgb(232, 232, 232);
			    }
		    }

		    public override System.Drawing.Color TextColor
		    {
			    get
			    {
				    return Color.FromArgb(80, 80, 80);
			    }
		    }

		    public override System.Drawing.Color Background
		    {
			    get
			    {
				    return Color.FromArgb(188, 199, 216);
			    }
		    }

		    public override System.Drawing.Color DropdownBorder
		    {
			    get
			    {
				    return Color.LightGray;
			    }
		    }

		    public override System.Drawing.Color Arrow
		    {
			    get
			    {
				    return Color.Black;
			    }
		    }

		    public override System.Drawing.Color OverflowBackground
		    {
			    get
			    {
				    return Color.FromArgb(213, 220, 232);
			    }
		    }
	    }

    #endregion
    #region  Renderer 

	    public class ControlRenderer : ToolStripProfessionalRenderer
	    {
		    public ControlRenderer() : this(new MSColorTable())
		    {
		    }

		    public ControlRenderer(ColorTable ColorTable)
		    {
			    this.ColorTable = ColorTable;
		    }

		    private ColorTable _ColorTable;
		    public ColorTable ColorTable
		    {
			    get
			    {
				    if (_ColorTable == null)
				    {
					    _ColorTable = new MSColorTable();
				    }
				    return _ColorTable;
			    }
			    set
			    {
				    _ColorTable = value;
			    }
		    }

		    protected override void OnRenderToolStripBackground(System.Windows.Forms.ToolStripRenderEventArgs e)
		    {
			    base.OnRenderToolStripBackground(e);

			    // Menu strip bar gradient
			    using (LinearGradientBrush LGB = new LinearGradientBrush(e.AffectedBounds, this.ColorTable.BackgroundTopGradient, this.ColorTable.BackgroundBottomGradient, LinearGradientMode.Vertical))
			    {
				    e.Graphics.FillRectangle(LGB, e.AffectedBounds);
			    }
		    }

		    protected override void OnRenderToolStripBorder(System.Windows.Forms.ToolStripRenderEventArgs e)
		    {
			    if (e.ToolStrip.Parent == null)
			    {
				    // Draw border around the menu drop-down
				    Rectangle Rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
				    using (Pen P1 = new Pen(this.ColorTable.CommonColorTable.DropdownBorder))
				    {
					    e.Graphics.DrawRectangle(P1, Rect);
				    }

				    // Fill the gap between menu drop-down and owner item
				    using (SolidBrush B1 = new SolidBrush(this.ColorTable.DroppedDownItemBackground))
				    {
					    e.Graphics.FillRectangle(B1, e.ConnectedArea);
				    }
			    }
		    }

		    protected override void OnRenderMenuItemBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
		    {
			    if (e.Item.Enabled)
			    {
				    if (e.Item.Selected)
				    {
					    if (!e.Item.IsOnDropDown)
					    {
						    Rectangle SelRect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
						    RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, SelRect);
					    }
					    else
					    {
						    Rectangle SelRect = new Rectangle(2, 0, e.Item.Width - 4, e.Item.Height - 1);
						    RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, SelRect);
					    }
				    }

				    if (((ToolStripMenuItem)e.Item).DropDown.Visible && !e.Item.IsOnDropDown)
				    {
					    Rectangle BorderRect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height);
					    // Fill the background
					    Rectangle BackgroundRect = new Rectangle(1, 1, e.Item.Width - 2, e.Item.Height + 2);
					    using (SolidBrush B1 = new SolidBrush(this.ColorTable.DroppedDownItemBackground))
					    {
						    e.Graphics.FillRectangle(B1, BackgroundRect);
					    }

					    // Draw border
					    using (Pen P1 = new Pen(this.ColorTable.CommonColorTable.DropdownBorder))
					    {
						    RectDrawing.DrawRoundedRectangle(e.Graphics, P1, BorderRect.X, BorderRect.Y, BorderRect.Width, BorderRect.Height, 2F);
					    }
				    }
				    e.Item.ForeColor = this.ColorTable.CommonColorTable.TextColor;
			    }
		    }

		    protected override void OnRenderItemText(System.Windows.Forms.ToolStripItemTextRenderEventArgs e)
		    {
			    e.TextColor = this.ColorTable.CommonColorTable.TextColor;
			    base.OnRenderItemText(e);
		    }

		    protected override void OnRenderItemCheck(System.Windows.Forms.ToolStripItemImageRenderEventArgs e)
		    {
			    base.OnRenderItemCheck(e);

			    Rectangle rect = new Rectangle(3, 1, e.Item.Height - 3, e.Item.Height - 3);
			    Color c = new Color();

			    if (e.Item.Selected)
			    {
				    c = this.ColorTable.CommonColorTable.CheckedSelectedBackground;
			    }
			    else
			    {
				    c = this.ColorTable.CommonColorTable.CheckedBackground;
			    }

			    using (SolidBrush b = new SolidBrush(c))
			    {
				    e.Graphics.FillRectangle(b, rect);
			    }

			    using (Pen p = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
			    {
				    e.Graphics.DrawRectangle(p, rect);
			    }

			    e.Graphics.DrawString("ü", new Font("Wingdings", 13F, FontStyle.Regular), Brushes.Black, new Point(4, 2));
		    }

		    protected override void OnRenderSeparator(System.Windows.Forms.ToolStripSeparatorRenderEventArgs e)
		    {
			    base.OnRenderSeparator(e);
			    int PT1 = 28;
			    int PT2 = e.Item.Width;
			    int Y = 3;
			    using (Pen P1 = new Pen(this.ColorTable.Separator))
			    {
				    e.Graphics.DrawLine(P1, PT1, Y, PT2, Y);
			    }
		    }

		    protected override void OnRenderImageMargin(System.Windows.Forms.ToolStripRenderEventArgs e)
		    {
			    base.OnRenderImageMargin(e);

			    Rectangle BackgroundRect = new Rectangle(0, -1, e.ToolStrip.Width, e.ToolStrip.Height + 1);
			    using (LinearGradientBrush LGB = new LinearGradientBrush(BackgroundRect, this.ColorTable.DropdownTopGradient, this.ColorTable.DropdownBottomGradient, LinearGradientMode.Vertical))
			    {
				    e.Graphics.FillRectangle(LGB, BackgroundRect);
			    }

			    using (SolidBrush B1 = new SolidBrush(this.ColorTable.ImageMargin))
			    {
				    e.Graphics.FillRectangle(B1, e.AffectedBounds);
			    }
		    }

		    protected override void OnRenderButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
		    {
			    Rectangle rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
			    bool @checked = ((ToolStripButton)e.Item).Checked;
			    bool drawBorder = false;

			    if (@checked)
			    {
				    drawBorder = true;

				    if (e.Item.Selected && !e.Item.Pressed)
				    {
					    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.CheckedSelectedBackground))
					    {
						    e.Graphics.FillRectangle(b, rect);
					    }
				    }
				    else
				    {
					    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.CheckedBackground))
					    {
						    e.Graphics.FillRectangle(b, rect);
					    }
				    }

			    }
			    else
			    {

				    if (e.Item.Pressed)
				    {
					    drawBorder = true;
					    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
					    {
						    e.Graphics.FillRectangle(b, rect);
					    }
				    }
				    else if (e.Item.Selected)
				    {
					    drawBorder = true;
					    RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect);
				    }

			    }

			    if (drawBorder)
			    {
				    using (Pen p = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
				    {
					    e.Graphics.DrawRectangle(p, rect);
				    }
			    }
		    }

		    protected override void OnRenderDropDownButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
		    {
			    Rectangle rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
			    bool drawBorder = false;

			    if (e.Item.Pressed)
			    {
				    drawBorder = true;
				    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
				    {
					    e.Graphics.FillRectangle(b, rect);
				    }
			    }
			    else if (e.Item.Selected)
			    {
				    drawBorder = true;
				    RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect);
			    }

			    if (drawBorder)
			    {
				    using (Pen p = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
				    {
					    e.Graphics.DrawRectangle(p, rect);
				    }
			    }
		    }

		    protected override void OnRenderSplitButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
		    {
			    base.OnRenderSplitButtonBackground(e);

			    bool drawBorder = false;
			    bool drawSeparator = true;

			    var item = (ToolStripSplitButton)e.Item;

			    Rectangle btnRect = new Rectangle(0, 0, item.ButtonBounds.Width - 1, item.ButtonBounds.Height - 1);
			    Rectangle borderRect = new Rectangle(0, 0, item.Bounds.Width - 1, item.Bounds.Height - 1);

			    if (item.DropDownButtonPressed)
			    {
				    drawBorder = true;
				    drawSeparator = false;
				    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
				    {
					    e.Graphics.FillRectangle(b, borderRect);
				    }
			    }
			    else if (item.DropDownButtonSelected)
			    {
				    drawBorder = true;
				    RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, borderRect);
			    }

			    if (item.ButtonPressed)
			    {
				    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
				    {
					    e.Graphics.FillRectangle(b, btnRect);
				    }
			    }

			    if (drawBorder)
			    {
				    using (Pen p = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
				    {
					    e.Graphics.DrawRectangle(p, borderRect);
					    if (drawSeparator)
					    {
						    e.Graphics.DrawRectangle(p, btnRect);
					    }
				    }

				    this.DrawCustomArrow(e.Graphics, item);
			    }
		    }

		    private void DrawCustomArrow(Graphics g, ToolStripSplitButton item)
		    {
			    int dropWidth = item.DropDownButtonBounds.Width - 1;
			    int dropHeight = item.DropDownButtonBounds.Height - 1;
			    float triangleWidth = dropWidth / 2.0F + 1;
			    float triangleLeft = item.DropDownButtonBounds.Left + (dropWidth - triangleWidth) / 2.0F;
			    float triangleHeight = triangleWidth / 2.0F;
			    float triangleTop = item.DropDownButtonBounds.Top + (dropHeight - triangleHeight) / 2.0F + 1;
			    RectangleF arrowRect = new RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight);

			    this.DrawCustomArrow(g, item, Rectangle.Round(arrowRect));
		    }

		    private void DrawCustomArrow(Graphics g, ToolStripItem item, Rectangle rect)
		    {
			    ToolStripArrowRenderEventArgs arrowEventArgs = new ToolStripArrowRenderEventArgs(g, item, rect, this.ColorTable.CommonColorTable.Arrow, ArrowDirection.Down);
			    base.OnRenderArrow(arrowEventArgs);
		    }

		    protected override void OnRenderOverflowButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
		    {
			    Rectangle rect = new Rectangle();
			    Rectangle rectEnd = new Rectangle();
			    rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2);
			    rectEnd = new Rectangle(rect.X - 5, rect.Y, rect.Width - 5, rect.Height);

			    if (e.Item.Pressed)
			    {
				    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
				    {
					    e.Graphics.FillRectangle(b, rect);
				    }
			    }
			    else if (e.Item.Selected)
			    {
				    RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect);
			    }
			    else
			    {
				    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.OverflowBackground))
				    {
					    e.Graphics.FillRectangle(b, rect);
				    }
			    }

			    using (Pen P1 = new Pen(this.ColorTable.CommonColorTable.Background))
			    {
				    RectDrawing.DrawRoundedRectangle(e.Graphics, P1, rectEnd.X, rectEnd.Y, rectEnd.Width, rectEnd.Height, 3F);
			    }

			    // Icon
			    int w = rect.Width - 1;
			    int h = rect.Height - 1;
			    float triangleWidth = w / 2.0F + 1;
			    float triangleLeft = rect.Left + (w - triangleWidth) / 2.0F + 3;
			    float triangleHeight = triangleWidth / 2.0F;
			    float triangleTop = rect.Top + (h - triangleHeight) / 2.0F + 7;
			    RectangleF arrowRect = new RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight);
			    this.DrawCustomArrow(e.Graphics, e.Item, Rectangle.Round(arrowRect));

			    using (Pen p = new Pen(this.ColorTable.CommonColorTable.Arrow))
			    {
				    e.Graphics.DrawLine(p, triangleLeft + 2, triangleTop - 2, triangleLeft + triangleWidth - 2, triangleTop - 2);
			    }
		    }
	    }

    #endregion
    #region  Drawing 

	    public class RectDrawing
	    {

		    public static void DrawSelection(Graphics G, xColorTable ColorTable, Rectangle Rect)
		    {
			    Rectangle TopRect = new Rectangle();
			    Rectangle BottomRect = new Rectangle();
			    Rectangle FillRect = new Rectangle(Rect.X + 1, Rect.Y + 1, Rect.Width - 1, Rect.Height - 1);

			    TopRect = FillRect;
			    TopRect.Height -= Convert.ToInt32(TopRect.Height / 2.0);
			    BottomRect = new Rectangle(TopRect.X, TopRect.Bottom, TopRect.Width, FillRect.Height - TopRect.Height);

			    // Top gradient
			    using (LinearGradientBrush LGB = new LinearGradientBrush(TopRect, ColorTable.SelectionTopGradient, ColorTable.SelectionMidGradient, LinearGradientMode.Vertical))
			    {
				    G.FillRectangle(LGB, TopRect);
			    }

			    // Bottom
			    using (SolidBrush B1 = new SolidBrush(ColorTable.SelectionBottomGradient))
			    {
				    G.FillRectangle(B1, BottomRect);
			    }

			    // Border
			    using (Pen P1 = new Pen(ColorTable.SelectionBorder))
			    {
				    RectDrawing.DrawRoundedRectangle(G, P1, Rect.X, Rect.Y, Rect.Width, Rect.Height, 2F);
			    }
		    }

		    public static void DrawRoundedRectangle(Graphics G, Pen P, float X, float Y, float W, float H, float Rad)
		    {

			    using (GraphicsPath gp = new GraphicsPath())
			    {
				    gp.AddLine(X + Rad, Y, X + W - (Rad * 2), Y);
				    gp.AddArc(X + W - (Rad * 2), Y, Rad * 2, Rad * 2, 270, 90);
				    gp.AddLine(X + W, Y + Rad, X + W, Y + H - (Rad * 2));
				    gp.AddArc(X + W - (Rad * 2), Y + H - (Rad * 2), Rad * 2, Rad * 2, 0, 90);
				    gp.AddLine(X + W - (Rad * 2), Y + H, X + Rad, Y + H);
				    gp.AddArc(X, Y + H - (Rad * 2), Rad * 2, Rad * 2, 90, 90);
				    gp.AddLine(X, Y + H - (Rad * 2), X, Y + Rad);
				    gp.AddArc(X, Y, Rad * 2, Rad * 2, 180, 90);
				    gp.CloseFigure();

				    G.SmoothingMode = SmoothingMode.AntiAlias;
				    G.DrawPath(P, gp);
				    G.SmoothingMode = SmoothingMode.Default;
			    }
		    }
	    }

    #endregion

    #endregion
    #region  ThemeContainer 

	    public class iTalkThemeContainer : ContainerControl
	    {

    #region  Variables 

		    private Point MouseP = new Point(0, 0);
		    private bool Cap = false;
		    private int MoveHeight;
		    private string _TextBottom = null;
		    private const int BorderCurve = 7;
		    protected MouseState State;
		    private bool HasShown;
		    private Rectangle HeaderRect;

    #endregion
    #region  Enums 

		    public enum MouseState: byte
		    {
			    None = 0,
			    Over = 1,
			    Down = 2
		    }

    #endregion
    #region  Properties 

		    private bool _Sizable = true;
		    public bool Sizable
		    {
			    get
			    {
				    return _Sizable;
			    }
			    set
			    {
				    _Sizable = value;
			    }
		    }

		    private bool _SmartBounds = false;
		    public bool SmartBounds
		    {
			    get
			    {
				    return _SmartBounds;
			    }
			    set
			    {
				    _SmartBounds = value;
			    }
		    }

		    private bool _IsParentForm;
		    protected bool IsParentForm
		    {
			    get
			    {
				    return _IsParentForm;
			    }
		    }

		    protected bool IsParentMdi
		    {
			    get
			    {
				    if (Parent == null)
				    {
					    return false;
				    }
				    return Parent.Parent != null;
			    }
		    }

		    private bool _ControlMode;
		    protected bool ControlMode
		    {
			    get
			    {
				    return _ControlMode;
			    }
			    set
			    {
				    _ControlMode = value;
				    Invalidate();
			    }
		    }

		    private FormStartPosition _StartPosition;
		    public FormStartPosition StartPosition
		    {
			    get
			    {
				    if (_IsParentForm && !_ControlMode)
				    {
					    return ParentForm.StartPosition;
				    }
				    else
				    {
					    return _StartPosition;
				    }
			    }
			    set
			    {
				    _StartPosition = value;

				    if (_IsParentForm && !_ControlMode)
				    {
					    ParentForm.StartPosition = value;
				    }
			    }
		    }

    #endregion
    #region  EventArgs 

		    protected sealed override void OnParentChanged(EventArgs e)
		    {
			    base.OnParentChanged(e);

			    if (Parent == null)
			    {
				    return;
			    }
			    _IsParentForm = Parent is System.Windows.Forms.Form;

			    if (!_ControlMode)
			    {
				    InitializeMessages();

				    if (_IsParentForm)
				    {
					    this.ParentForm.FormBorderStyle = FormBorderStyle.None;
					    this.ParentForm.TransparencyKey = Color.Fuchsia;

					    if (!DesignMode)
					    {
						    ParentForm.Shown += FormShown;
					    }
				    }
				    Parent.BackColor = BackColor;
				    Parent.MinimumSize = new Size(126, 39);
			    }
		    }

		    protected sealed override void OnSizeChanged(EventArgs e)
		    {
			    base.OnSizeChanged(e);
			    if (!_ControlMode)
			    {
				    HeaderRect = new Rectangle(0, 0, Width - 14, MoveHeight - 7);
			    }
			    Invalidate();
		    }

		    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		    {
			    base.OnMouseDown(e);
			    if (e.Button == MouseButtons.Left)
			    {
				    SetState(MouseState.Down);
			    }
			    if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode))
			    {
				    if (HeaderRect.Contains(e.Location))
				    {
					    Capture = false;
					    WM_LMBUTTONDOWN = true;
					    DefWndProc(ref Messages[0]);
				    }
				    else if (_Sizable && !(Previous == 0))
				    {
					    Capture = false;
					    WM_LMBUTTONDOWN = true;
					    DefWndProc(ref Messages[Previous]);
				    }
			    }
		    }

		    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		    {
			    base.OnMouseUp(e);
			    Cap = false;
		    }

		    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		    {
			    base.OnMouseMove(e);
			    if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized))
			    {
				    if (_Sizable && !_ControlMode)
				    {
					    InvalidateMouse();
				    }
			    }
			    if (Cap)
			    {
				    Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
			    }
		    }

		    protected override void OnInvalidated(System.Windows.Forms.InvalidateEventArgs e)
		    {
			    base.OnInvalidated(e);
			    ParentForm.Text = Text;
		    }

		    protected override void OnPaintBackground(PaintEventArgs e)
		    {
			    base.OnPaintBackground(e);
		    }

		    protected override void OnTextChanged(System.EventArgs e)
		    {
			    base.OnTextChanged(e);
			    Invalidate();
		    }

		    private void FormShown(object sender, EventArgs e)
		    {
			    if (_ControlMode || HasShown)
			    {
				    return;
			    }

			    if (_StartPosition == FormStartPosition.CenterParent || _StartPosition == FormStartPosition.CenterScreen)
			    {
				    Rectangle SB = Screen.PrimaryScreen.Bounds;
				    Rectangle CB = ParentForm.Bounds;
				    ParentForm.Location = new Point(SB.Width / 2 - CB.Width / 2, SB.Height / 2 - CB.Width / 2);
			    }
			    HasShown = true;
		    }

    #endregion
    #region  Mouse & Size 

		    private void SetState(MouseState current)
		    {
			    State = current;
			    Invalidate();
		    }

		    private Point GetIndexPoint;
		    private bool B1x;
		    private bool B2x;
		    private bool B3;
		    private bool B4;
		    private int GetIndex()
		    {
			    GetIndexPoint = PointToClient(MousePosition);
			    B1x = GetIndexPoint.X < 7;
			    B2x = GetIndexPoint.X > Width - 7;
			    B3 = GetIndexPoint.Y < 7;
			    B4 = GetIndexPoint.Y > Height - 7;

			    if (B1x && B3)
			    {
				    return 4;
			    }
			    if (B1x && B4)
			    {
				    return 7;
			    }
			    if (B2x && B3)
			    {
				    return 5;
			    }
			    if (B2x && B4)
			    {
				    return 8;
			    }
			    if (B1x)
			    {
				    return 1;
			    }
			    if (B2x)
			    {
				    return 2;
			    }
			    if (B3)
			    {
				    return 3;
			    }
			    if (B4)
			    {
				    return 6;
			    }
			    return 0;
		    }

		    private int Current;
		    private int Previous;
		    private void InvalidateMouse()
		    {
			    Current = GetIndex();
			    if (Current == Previous)
			    {
				    return;
			    }

			    Previous = Current;
			    switch (Previous)
			    {
				    case 0:
					    Cursor = Cursors.Default;
					    break;
				    case 6:
					    Cursor = Cursors.SizeNS;
					    break;
				    case 8:
					    Cursor = Cursors.SizeNWSE;
					    break;
				    case 7:
					    Cursor = Cursors.SizeNESW;
					    break;
			    }
		    }

		    private Message[] Messages = new Message[9];
		    private void InitializeMessages()
		    {
			    Messages[0] = Message.Create(Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
			    for (int I = 1; I <= 8; I++)
			    {
				    Messages[I] = Message.Create(Parent.Handle, 161, new IntPtr(I + 9), IntPtr.Zero);
			    }
		    }

		    private void CorrectBounds(Rectangle bounds)
		    {
			    if (Parent.Width > bounds.Width)
			    {
				    Parent.Width = bounds.Width;
			    }
			    if (Parent.Height > bounds.Height)
			    {
				    Parent.Height = bounds.Height;
			    }

			    int X = Parent.Location.X;
			    int Y = Parent.Location.Y;

			    if (X < bounds.X)
			    {
				    X = bounds.X;
			    }
			    if (Y < bounds.Y)
			    {
				    Y = bounds.Y;
			    }

			    int Width = bounds.X + bounds.Width;
			    int Height = bounds.Y + bounds.Height;

			    if (X + Parent.Width > Width)
			    {
				    X = Width - Parent.Width;
			    }
			    if (Y + Parent.Height > Height)
			    {
				    Y = Height - Parent.Height;
			    }

			    Parent.Location = new Point(X, Y);
		    }

		    private bool WM_LMBUTTONDOWN;
		    protected override void WndProc(ref Message m)
		    {
			    base.WndProc(ref m);

			    if (WM_LMBUTTONDOWN && m.Msg == 513)
			    {
				    WM_LMBUTTONDOWN = false;

				    SetState(MouseState.Over);
				    if (!_SmartBounds)
				    {
					    return;
				    }

				    if (IsParentMdi)
				    {
					    CorrectBounds(new Rectangle(Point.Empty, Parent.Parent.Size));
				    }
				    else
				    {
					    CorrectBounds(Screen.FromControl(Parent).WorkingArea);
				    }
			    }
		    }

    #endregion

		    protected override void OnCreateControl()
		    {
			    base.OnCreateControl();
			    this.ParentForm.FormBorderStyle = FormBorderStyle.None;
			    this.ParentForm.TransparencyKey = Color.Fuchsia;
		    }

		    protected override void CreateHandle()
		    {
			    base.CreateHandle();
		    }

		    public iTalkThemeContainer() : base()
		    {
			    SetStyle((ControlStyles)139270, true);
			    Dock = DockStyle.Fill;
			    MoveHeight = 25;
			    Padding = new Padding(3, 28, 3, 28);
			    Font = new Font("Segoe UI", 8F, FontStyle.Regular);
			    ForeColor = Color.FromArgb(142, 142, 142);
			    BackColor = Color.FromArgb(246, 246, 246);
			    DoubleBuffered = true;
		    }

		    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		    {
			    base.OnPaint(e);

			    Bitmap B = new Bitmap(Width, Height);
			    Graphics G = Graphics.FromImage(B);
			    Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
			    Color TransparencyKey = this.ParentForm.TransparencyKey;

			    G.SmoothingMode = SmoothingMode.Default;
			    G.Clear(TransparencyKey);

			    // Draw the container borders
			    G.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(ClientRectangle, BorderCurve));
			    // Draw a rectangle in which the controls should be added on
			    G.FillPath(new SolidBrush(Color.FromArgb(246, 246, 246)), RoundRectangle.RoundRect(new Rectangle(2, 20, Width - 5, Height - 42), BorderCurve));

			    // Patch the header with a rectangle that has a curve so its border will remain within container bounds
			    G.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(new Rectangle(2, 2, Width / 2 + 2, 16), BorderCurve));
			    G.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(new Rectangle(Width / 2 - 3, 2, Width / 2, 16), BorderCurve));
			    // Fill the header rectangle below the patch
			    G.FillRectangle(new SolidBrush(Color.FromArgb(52, 52, 52)), new Rectangle(2, 15, Width - 5, 10));

			    // Increase the thickness of the container borders
			    G.DrawPath(new Pen(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(new Rectangle(2, 2, Width - 5, Height - 5), BorderCurve));
			    G.DrawPath(new Pen(Color.FromArgb(52, 52, 52)), RoundRectangle.RoundRect(ClientRectangle, BorderCurve));

			    // Draw the string from the specified 'Text' property on the header rectangle
			    G.DrawString(Text, new Font("Trebuchet MS", 10F, FontStyle.Bold), new SolidBrush(Color.FromArgb(221, 221, 221)), new Rectangle(BorderCurve, BorderCurve - 4, Width - 1, 22), new StringFormat() {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near});


			    // Draws a rectangle at the bottom of the container
			    G.FillRectangle(new SolidBrush(Color.FromArgb(52, 52, 52)), 0, Height - 25, Width - 3, 22 - 2);
			    G.DrawLine(new Pen(Color.FromArgb(52, 52, 52)), 5, Height - 5, Width - 6, Height - 5);
			    G.DrawLine(new Pen(Color.FromArgb(52, 52, 52)), 7, Height - 4, Width - 7, Height - 4);

			    G.DrawString(_TextBottom, new Font("Trebuchet MS", 10F, FontStyle.Bold), new SolidBrush(Color.FromArgb(221, 221, 221)), 5, Height - 23);

			    e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
			    G.Dispose();
			    B.Dispose();
		    }
	    }

    #endregion

}