// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Helper.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Adobe
{



    #region RoundRect

    
    static class RoundRectangle
{
    public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
    {
        GraphicsPath GP = new GraphicsPath();
        int EndArcWidth = Curve * 2;
        GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -180, 90);
        GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -90, 90);
        GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 0, 90);
        GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 90, 90);
        GP.AddLine(new Point(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
        return GP;
    }

    public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
    {
        Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
        GraphicsPath GP = new GraphicsPath();
        int EndArcWidth = Curve * 2;
        GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -180, 90);
        GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -90, 90);
        GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 0, 90);
        GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 90, 90);
        GP.AddLine(new Point(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
        return GP;
    }
}

#endregion
    
#region  Control Renderer
#region  Color Table

public abstract class xColorTable
{
    public abstract Color TextColor { get; }
    public abstract Color Background { get; }
    public abstract Color SelectionBorder { get; }
    public abstract Color SelectionTopGradient { get; }
    public abstract Color SelectionMidGradient { get; }
    public abstract Color SelectionBottomGradient { get; }
    public abstract Color PressedBackground { get; }
    public abstract Color CheckedBackground { get; }
    public abstract Color CheckedSelectedBackground { get; }
    public abstract Color DropdownBorder { get; }
    public abstract Color Arrow { get; }
    public abstract Color OverflowBackground { get; }
}

public abstract class ColorTable
{
    public abstract xColorTable CommonColorTable { get; }
    public abstract Color BackgroundTopGradient { get; }
    public abstract Color BackgroundBottomGradient { get; }
    public abstract Color DroppedDownItemBackground { get; }
    public abstract Color DropdownTopGradient { get; }
    public abstract Color DropdownBottomGradient { get; }
    public abstract Color Separator { get; }
    public abstract Color ImageMargin { get; }
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

    public ControlRenderer()
        : this(new MSColorTable())
    {
    }

    public ControlRenderer(ColorTable ColorTable)
    {
        this.ColorTable = ColorTable;
    }

    private ColorTable _ColorTable;
    public new ColorTable ColorTable
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
                    RectDrawing.DrawRoundedRectangle(e.Graphics, P1, System.Convert.ToSingle(BorderRect.X), System.Convert.ToSingle(BorderRect.Y), System.Convert.ToSingle(BorderRect.Width), System.Convert.ToSingle(BorderRect.Height), 2);
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
        Color c = default(Color);

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


        e.Graphics.DrawString("�", new Font("Wingdings", 13, FontStyle.Regular), Brushes.Black, new Point(4, 2));
    }

    protected override void OnRenderSeparator(System.Windows.Forms.ToolStripSeparatorRenderEventArgs e)
    {
        base.OnRenderSeparator(e);
        int PT1 = 28;
        int PT2 = System.Convert.ToInt32(e.Item.Width);
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
        using (LinearGradientBrush LGB = new LinearGradientBrush(BackgroundRect,
                this.ColorTable.DropdownTopGradient,
                this.ColorTable.DropdownBottomGradient,
                LinearGradientMode.Vertical))
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
        bool @checked = System.Convert.ToBoolean(((ToolStripButton)e.Item).Checked);
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

    protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
    {
        base.OnRenderSplitButtonBackground(e);
        bool drawBorder = false;
        bool drawSeparator = true;
        ToolStripSplitButton item = (ToolStripSplitButton)e.Item;
        checked
        {
            Rectangle btnRect = new Rectangle(0, 0, item.ButtonBounds.Width - 1, item.ButtonBounds.Height - 1);
            Rectangle borderRect = new Rectangle(0, 0, item.Bounds.Width - 1, item.Bounds.Height - 1);
            bool flag = item.DropDownButtonPressed;
            if (flag)
            {
                drawBorder = true;
                drawSeparator = false;
                SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground);
                try
                {
                    e.Graphics.FillRectangle(b, borderRect);
                }
                finally
                {
                    flag = (b != null);
                    if (flag)
                    {
                        ((IDisposable)b).Dispose();
                    }
                }
            }
            else
            {
                flag = item.DropDownButtonSelected;
                if (flag)
                {
                    drawBorder = true;
                    RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, borderRect);
                }
            }
            flag = item.ButtonPressed;
            if (flag)
            {
                SolidBrush b2 = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground);
                try
                {
                    e.Graphics.FillRectangle(b2, btnRect);
                }
                finally
                {
                    flag = (b2 != null);
                    if (flag)
                    {
                        ((IDisposable)b2).Dispose();
                    }
                }
            }
            flag = drawBorder;
            if (flag)
            {
                Pen p = new Pen(this.ColorTable.CommonColorTable.SelectionBorder);
                try
                {
                    e.Graphics.DrawRectangle(p, borderRect);
                    flag = drawSeparator;
                    if (flag)
                    {
                        e.Graphics.DrawRectangle(p, btnRect);
                    }
                }
                finally
                {
                    flag = (p != null);
                    if (flag)
                    {
                        ((IDisposable)p).Dispose();
                    }
                }
                this.DrawCustomArrow(e.Graphics, item);
            }
        }
    }


    private void DrawCustomArrow(Graphics g, ToolStripSplitButton item)
    {
        int dropWidth = System.Convert.ToInt32(item.DropDownButtonBounds.Width - 1);
        int dropHeight = System.Convert.ToInt32(item.DropDownButtonBounds.Height - 1);
        float triangleWidth = dropWidth / 2.0F + 1;
        float triangleLeft = System.Convert.ToSingle(item.DropDownButtonBounds.Left + (dropWidth - triangleWidth) / 2.0F);
        float triangleHeight = triangleWidth / 2.0F;
        float triangleTop = System.Convert.ToSingle(item.DropDownButtonBounds.Top + (dropHeight - triangleHeight) / 2.0F + 1);
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
        Rectangle rect = default(Rectangle);
        Rectangle rectEnd = default(Rectangle);
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
            RectDrawing.DrawRoundedRectangle(e.Graphics, P1, System.Convert.ToSingle(rectEnd.X), System.Convert.ToSingle(rectEnd.Y), System.Convert.ToSingle(rectEnd.Width), System.Convert.ToSingle(rectEnd.Height), 3);
        }


        // Icon
        int w = System.Convert.ToInt32(rect.Width - 1);
        int h = System.Convert.ToInt32(rect.Height - 1);
        float triangleWidth = w / 2.0F + 1;
        float triangleLeft = System.Convert.ToSingle(rect.Left + (w - triangleWidth) / 2.0F + 3);
        float triangleHeight = triangleWidth / 2.0F;
        float triangleTop = System.Convert.ToSingle(rect.Top + (h - triangleHeight) / 2.0F + 7);
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
        Rectangle TopRect = default(Rectangle);
        Rectangle BottomRect = default(Rectangle);
        Rectangle FillRect = new Rectangle(Rect.X + 1, Rect.Y + 1, Rect.Width - 1, Rect.Height - 1);

        TopRect = FillRect;
        TopRect.Height -= System.Convert.ToInt32(TopRect.Height / 2);
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
            RectDrawing.DrawRoundedRectangle(G, P1, System.Convert.ToSingle(Rect.X), System.Convert.ToSingle(Rect.Y), System.Convert.ToSingle(Rect.Width), System.Convert.ToSingle(Rect.Height), 2);
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

#region ThemeContainer154 
public abstract class ThemeContainer154 : ContainerControl
{

    #region " Initialization "

    protected Graphics G;

    protected Bitmap B;
    public ThemeContainer154()
    {
        SetStyle((ControlStyles)139270, true);

        _ImageSize = Size.Empty;
        Font = new Font("Verdana", 8);

        MeasureBitmap = new Bitmap(1, 1);
        MeasureGraphics = Graphics.FromImage(MeasureBitmap);

        DrawRadialPath = new GraphicsPath();

        InvalidateCustimization();
    }

    protected override sealed void OnHandleCreated(EventArgs e)
    {
        if (DoneCreation)
            InitializeMessages();

        InvalidateCustimization();
        ColorHook();

        if (!(_LockWidth == 0))
            Width = _LockWidth;
        if (!(_LockHeight == 0))
            Height = _LockHeight;
        if (!_ControlMode)
            base.Dock = DockStyle.Fill;

        Transparent = _Transparent;
        if (_Transparent && _BackColor)
            BackColor = Color.Transparent;

        base.OnHandleCreated(e);
    }

    private bool DoneCreation;
    protected override sealed void OnParentChanged(EventArgs e)
    {
        base.OnParentChanged(e);

        if (Parent == null)
            return;
        _IsParentForm = Parent is System.Windows.Forms.Form;

        if (!_ControlMode)
        {
            InitializeMessages();

            if (_IsParentForm)
            {
                ParentForm.FormBorderStyle = _BorderStyle;
                ParentForm.TransparencyKey = _TransparencyKey;

                if (!DesignMode)
                {
                    ParentForm.Shown += FormShown;
                }
            }

            Parent.BackColor = BackColor;
        }

        OnCreation();
        DoneCreation = true;
        InvalidateTimer();
    }

    #endregion

    private void DoAnimation(bool i)
    {
        OnAnimation();
        if (i)
            Invalidate();
    }

    protected override sealed void OnPaint(PaintEventArgs e)
    {
        if (Width == 0 || Height == 0)
            return;

        if (_Transparent && _ControlMode)
        {
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }
        else
        {
            G = e.Graphics;
            PaintHook();
        }
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        ThemeShare.RemoveAnimationCallback(DoAnimation);
        base.OnHandleDestroyed(e);
    }

    private bool HasShown;
    private void FormShown(object sender, EventArgs e)
    {
        if (_ControlMode || HasShown)
            return;

        if (_StartPosition == FormStartPosition.CenterParent || _StartPosition == FormStartPosition.CenterScreen)
        {
            Rectangle SB = Screen.PrimaryScreen.Bounds;
            Rectangle CB = ParentForm.Bounds;
            ParentForm.Location = new Point(SB.Width / 2 - CB.Width / 2, SB.Height / 2 - CB.Width / 2);
        }

        HasShown = true;
    }


    #region " Size Handling "

    private Rectangle Frame;
    protected override sealed void OnSizeChanged(EventArgs e)
    {
        if (_Movable && !_ControlMode)
        {
            Frame = new Rectangle(7, 7, Width - 14, _Header - 7);
        }

        InvalidateBitmap();
        Invalidate();

        base.OnSizeChanged(e);
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        if (!(_LockWidth == 0))
            width = _LockWidth;
        if (!(_LockHeight == 0))
            height = _LockHeight;
        base.SetBoundsCore(x, y, width, height, specified);
    }

    #endregion

    #region " State Handling "

    protected MouseState State;
    private void SetState(MouseState current)
    {
        State = current;
        Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized))
        {
            if (_Sizable && !_ControlMode)
                InvalidateMouse();
        }

        base.OnMouseMove(e);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        if (Enabled)
            SetState(MouseState.None);
        else
            SetState(MouseState.Block);
        base.OnEnabledChanged(e);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        SetState(MouseState.Over);
        base.OnMouseEnter(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        SetState(MouseState.Over);
        base.OnMouseUp(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        SetState(MouseState.None);

        if (GetChildAtPoint(PointToClient(MousePosition)) != null)
        {
            if (_Sizable && !_ControlMode)
            {
                Cursor = Cursors.Default;
                Previous = 0;
            }
        }

        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            SetState(MouseState.Down);

        if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode))
        {
            if (_Movable && Frame.Contains(e.Location))
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

        base.OnMouseDown(e);
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
                return;

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

    private Point GetIndexPoint;
    private bool B1;
    private bool B2;
    private bool B3;
    private bool B4;
    private int GetIndex()
    {
        GetIndexPoint = PointToClient(MousePosition);
        B1 = GetIndexPoint.X < 7;
        B2 = GetIndexPoint.X > Width - 7;
        B3 = GetIndexPoint.Y < 7;
        B4 = GetIndexPoint.Y > Height - 7;

        if (B1 && B3)
            return 4;
        if (B1 && B4)
            return 7;
        if (B2 && B3)
            return 5;
        if (B2 && B4)
            return 8;
        if (B1)
            return 1;
        if (B2)
            return 2;
        if (B3)
            return 3;
        if (B4)
            return 6;
        return 0;
    }

    private int Current;
    private int Previous;
    private void InvalidateMouse()
    {
        Current = GetIndex();
        if (Current == Previous)
            return;

        Previous = Current;
        switch (Previous)
        {
            case 0:
                Cursor = Cursors.Default;
                break;
            case 1:
            case 2:
                Cursor = Cursors.SizeWE;
                break;
            case 3:
            case 6:
                Cursor = Cursors.SizeNS;
                break;
            case 4:
            case 8:
                Cursor = Cursors.SizeNWSE;
                break;
            case 5:
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
            Parent.Width = bounds.Width;
        if (Parent.Height > bounds.Height)
            Parent.Height = bounds.Height;

        int X = Parent.Location.X;
        int Y = Parent.Location.Y;

        if (X < bounds.X)
            X = bounds.X;
        if (Y < bounds.Y)
            Y = bounds.Y;

        int Width = bounds.X + bounds.Width;
        int Height = bounds.Y + bounds.Height;

        if (X + Parent.Width > Width)
            X = Width - Parent.Width;
        if (Y + Parent.Height > Height)
            Y = Height - Parent.Height;

        Parent.Location = new Point(X, Y);
    }

    #endregion


    #region " Base Properties "

    public override DockStyle Dock
    {
        get { return base.Dock; }
        set
        {
            if (!_ControlMode)
                return;
            base.Dock = value;
        }
    }

    private bool _BackColor;
    [Category("Misc")]
    public override Color BackColor
    {
        get { return base.BackColor; }
        set
        {
            if (value == base.BackColor)
                return;

            if (!IsHandleCreated && _ControlMode && value == Color.Transparent)
            {
                _BackColor = true;
                return;
            }

            base.BackColor = value;
            if (Parent != null)
            {
                if (!_ControlMode)
                    Parent.BackColor = value;
                ColorHook();
            }
        }
    }

    public override Size MinimumSize
    {
        get { return base.MinimumSize; }
        set
        {
            base.MinimumSize = value;
            if (Parent != null)
                Parent.MinimumSize = value;
        }
    }

    public override Size MaximumSize
    {
        get { return base.MaximumSize; }
        set
        {
            base.MaximumSize = value;
            if (Parent != null)
                Parent.MaximumSize = value;
        }
    }

    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            Invalidate();
        }
    }

    public override Font Font
    {
        get { return base.Font; }
        set
        {
            base.Font = value;
            Invalidate();
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
        get { return Color.Empty; }
        set { }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Image BackgroundImage
    {
        get { return null; }
        set { }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageLayout BackgroundImageLayout
    {
        get { return ImageLayout.None; }
        set { }
    }

    #endregion

    #region " Public Properties "

    private bool _SmartBounds = true;
    public bool SmartBounds
    {
        get { return _SmartBounds; }
        set { _SmartBounds = value; }
    }

    private bool _Movable = true;
    public bool Movable
    {
        get { return _Movable; }
        set { _Movable = value; }
    }

    private bool _Sizable = true;
    public bool Sizable
    {
        get { return _Sizable; }
        set { _Sizable = value; }
    }

    private Color _TransparencyKey;
    public Color TransparencyKey
    {
        get
        {
            if (_IsParentForm && !_ControlMode)
                return ParentForm.TransparencyKey;
            else
                return _TransparencyKey;
        }
        set
        {
            if (value == _TransparencyKey)
                return;
            _TransparencyKey = value;

            if (_IsParentForm && !_ControlMode)
            {
                ParentForm.TransparencyKey = value;
                ColorHook();
            }
        }
    }

    private FormBorderStyle _BorderStyle;
    public FormBorderStyle BorderStyle
    {
        get
        {
            if (_IsParentForm && !_ControlMode)
                return ParentForm.FormBorderStyle;
            else
                return _BorderStyle;
        }
        set
        {
            _BorderStyle = value;

            if (_IsParentForm && !_ControlMode)
            {
                ParentForm.FormBorderStyle = value;

                if (!(value == FormBorderStyle.None))
                {
                    Movable = false;
                    Sizable = false;
                }
            }
        }
    }

    private FormStartPosition _StartPosition;
    public FormStartPosition StartPosition
    {
        get
        {
            if (_IsParentForm && !_ControlMode)
                return ParentForm.StartPosition;
            else
                return _StartPosition;
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

    private bool _NoRounding;
    public bool NoRounding
    {
        get { return _NoRounding; }
        set
        {
            _NoRounding = value;
            Invalidate();
        }
    }

    private Image _Image;
    public Image Image
    {
        get { return _Image; }
        set
        {
            if (value == null)
                _ImageSize = Size.Empty;
            else
                _ImageSize = value.Size;

            _Image = value;
            Invalidate();
        }
    }

    private Dictionary<string, Color> Items = new Dictionary<string, Color>();
    public Bloom[] Colors
    {
        get
        {
            List<Bloom> T = new List<Bloom>();
            Dictionary<string, Color>.Enumerator E = Items.GetEnumerator();

            while (E.MoveNext())
            {
                T.Add(new Bloom(E.Current.Key, E.Current.Value));
            }

            return T.ToArray();
        }
        set
        {
            foreach (Bloom B in value)
            {
                if (Items.ContainsKey(B.Name))
                    Items[B.Name] = B.Value;
            }

            InvalidateCustimization();
            ColorHook();
            Invalidate();
        }
    }

    private string _Customization;
    public string Customization
    {
        get { return _Customization; }
        set
        {
            if (value == _Customization)
                return;

            byte[] Data = null;
            Bloom[] Items = Colors;

            try
            {
                Data = Convert.FromBase64String(value);
                for (int I = 0; I <= Items.Length - 1; I++)
                {
                    Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                }
            }
            catch
            {
                return;
            }

            _Customization = value;

            Colors = Items;
            ColorHook();
            Invalidate();
        }
    }

    private bool _Transparent;
    public bool Transparent
    {
        get { return _Transparent; }
        set
        {
            _Transparent = value;
            if (!(IsHandleCreated || _ControlMode))
                return;

            if (!value && !(BackColor.A == 255))
            {
                throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
            }

            SetStyle(ControlStyles.Opaque, !value);
            SetStyle(ControlStyles.SupportsTransparentBackColor, value);

            InvalidateBitmap();
            Invalidate();
        }
    }

    #endregion

    #region " Private Properties "

    private Size _ImageSize;
    protected Size ImageSize
    {
        get { return _ImageSize; }
    }

    private bool _IsParentForm;
    protected bool IsParentForm
    {
        get { return _IsParentForm; }
    }

    protected bool IsParentMdi
    {
        get
        {
            if (Parent == null)
                return false;
            return Parent.Parent != null;
        }
    }

    private int _LockWidth;
    protected int LockWidth
    {
        get { return _LockWidth; }
        set
        {
            _LockWidth = value;
            if (!(LockWidth == 0) && IsHandleCreated)
                Width = LockWidth;
        }
    }

    private int _LockHeight;
    protected int LockHeight
    {
        get { return _LockHeight; }
        set
        {
            _LockHeight = value;
            if (!(LockHeight == 0) && IsHandleCreated)
                Height = LockHeight;
        }
    }

    private int _Header = 24;
    protected int Header
    {
        get { return _Header; }
        set
        {
            _Header = value;

            if (!_ControlMode)
            {
                Frame = new Rectangle(7, 7, Width - 14, value - 7);
                Invalidate();
            }
        }
    }

    private bool _ControlMode;
    protected bool ControlMode
    {
        get { return _ControlMode; }
        set
        {
            _ControlMode = value;

            Transparent = _Transparent;
            if (_Transparent && _BackColor)
                BackColor = Color.Transparent;

            InvalidateBitmap();
            Invalidate();
        }
    }

    private bool _IsAnimated;
    protected bool IsAnimated
    {
        get { return _IsAnimated; }
        set
        {
            _IsAnimated = value;
            InvalidateTimer();
        }
    }

    #endregion


    #region " Property Helpers "

    protected Pen GetPen(string name)
    {
        return new Pen(Items[name]);
    }
    protected Pen GetPen(string name, float width)
    {
        return new Pen(Items[name], width);
    }

    protected SolidBrush GetBrush(string name)
    {
        return new SolidBrush(Items[name]);
    }

    protected Color GetColor(string name)
    {
        return Items[name];
    }

    protected void SetColor(string name, Color value)
    {
        if (Items.ContainsKey(name))
            Items[name] = value;
        else
            Items.Add(name, value);
    }
    protected void SetColor(string name, byte r, byte g, byte b)
    {
        SetColor(name, Color.FromArgb(r, g, b));
    }
    protected void SetColor(string name, byte a, byte r, byte g, byte b)
    {
        SetColor(name, Color.FromArgb(a, r, g, b));
    }
    protected void SetColor(string name, byte a, Color value)
    {
        SetColor(name, Color.FromArgb(a, value));
    }

    private void InvalidateBitmap()
    {
        if (_Transparent && _ControlMode)
        {
            if (Width == 0 || Height == 0)
                return;
            B = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
            G = Graphics.FromImage(B);
        }
        else
        {
            G = null;
            B = null;
        }
    }

    private void InvalidateCustimization()
    {
        MemoryStream M = new MemoryStream(Items.Count * 4);

        foreach (Bloom B in Colors)
        {
            M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
        }

        M.Close();
        _Customization = Convert.ToBase64String(M.ToArray());
    }

    private void InvalidateTimer()
    {
        if (DesignMode || !DoneCreation)
            return;

        if (_IsAnimated)
        {
            ThemeShare.AddAnimationCallback(DoAnimation);
        }
        else
        {
            ThemeShare.RemoveAnimationCallback(DoAnimation);
        }
    }

    #endregion


    #region " User Hooks "

    protected abstract void ColorHook();
    protected abstract void PaintHook();

    protected virtual void OnCreation()
    {
    }

    protected virtual void OnAnimation()
    {
    }

    #endregion


    #region " Offset "

    private Rectangle OffsetReturnRectangle;
    protected Rectangle Offset(Rectangle r, int amount)
    {
        OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
        return OffsetReturnRectangle;
    }

    private Size OffsetReturnSize;
    protected Size Offset(Size s, int amount)
    {
        OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
        return OffsetReturnSize;
    }

    private Point OffsetReturnPoint;
    protected Point Offset(Point p, int amount)
    {
        OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
        return OffsetReturnPoint;
    }

    #endregion

    #region " Center "


    private Point CenterReturn;
    protected Point Center(Rectangle p, Rectangle c)
    {
        CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
        return CenterReturn;
    }
    protected Point Center(Rectangle p, Size c)
    {
        CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
        return CenterReturn;
    }

    protected Point Center(Rectangle child)
    {
        return Center(Width, Height, child.Width, child.Height);
    }
    protected Point Center(Size child)
    {
        return Center(Width, Height, child.Width, child.Height);
    }
    protected Point Center(int childWidth, int childHeight)
    {
        return Center(Width, Height, childWidth, childHeight);
    }

    protected Point Center(Size p, Size c)
    {
        return Center(p.Width, p.Height, c.Width, c.Height);
    }

    protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
    {
        CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
        return CenterReturn;
    }

    #endregion

    #region " Measure "

    private Bitmap MeasureBitmap;

    private Graphics MeasureGraphics;
    protected Size Measure()
    {
        lock (MeasureGraphics)
        {
            return MeasureGraphics.MeasureString(Text, Font, Width).ToSize();
        }
    }
    protected Size Measure(string text)
    {
        lock (MeasureGraphics)
        {
            return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
        }
    }

    #endregion


    #region " DrawPixel "


    private SolidBrush DrawPixelBrush;
    protected void DrawPixel(Color c1, int x, int y)
    {
        if (_Transparent)
        {
            B.SetPixel(x, y, c1);
        }
        else
        {
            DrawPixelBrush = new SolidBrush(c1);
            G.FillRectangle(DrawPixelBrush, x, y, 1, 1);
        }
    }

    #endregion

    #region " DrawCorners "


    private SolidBrush DrawCornersBrush;
    protected void DrawCorners(Color c1, int offset)
    {
        DrawCorners(c1, 0, 0, Width, Height, offset);
    }
    protected void DrawCorners(Color c1, Rectangle r1, int offset)
    {
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
    }
    protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
    {
        DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
    }

    protected void DrawCorners(Color c1)
    {
        DrawCorners(c1, 0, 0, Width, Height);
    }
    protected void DrawCorners(Color c1, Rectangle r1)
    {
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
    }
    protected void DrawCorners(Color c1, int x, int y, int width, int height)
    {
        if (_NoRounding)
            return;

        if (_Transparent)
        {
            B.SetPixel(x, y, c1);
            B.SetPixel(x + (width - 1), y, c1);
            B.SetPixel(x, y + (height - 1), c1);
            B.SetPixel(x + (width - 1), y + (height - 1), c1);
        }
        else
        {
            DrawCornersBrush = new SolidBrush(c1);
            G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
        }
    }

    #endregion

    #region " DrawBorders "

    protected void DrawBorders(Pen p1, int offset)
    {
        DrawBorders(p1, 0, 0, Width, Height, offset);
    }
    protected void DrawBorders(Pen p1, Rectangle r, int offset)
    {
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
    }
    protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
    {
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
    }

    protected void DrawBorders(Pen p1)
    {
        DrawBorders(p1, 0, 0, Width, Height);
    }
    protected void DrawBorders(Pen p1, Rectangle r)
    {
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
    }
    protected void DrawBorders(Pen p1, int x, int y, int width, int height)
    {
        G.DrawRectangle(p1, x, y, width - 1, height - 1);
    }

    #endregion

    #region " DrawText "

    private Point DrawTextPoint;

    private Size DrawTextSize;
    protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
    {
        DrawText(b1, Text, a, x, y);
    }
    protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
    {
        if (text.Length == 0)
            return;

        DrawTextSize = Measure(text);
        DrawTextPoint = new Point(Width / 2 - DrawTextSize.Width / 2, Header / 2 - DrawTextSize.Height / 2);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y);
                break;
            case HorizontalAlignment.Center:
                G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                break;
            case HorizontalAlignment.Right:
                G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                break;
        }
    }

    protected void DrawText(Brush b1, Point p1)
    {
        if (Text.Length == 0)
            return;
        G.DrawString(Text, Font, b1, p1);
    }
    protected void DrawText(Brush b1, int x, int y)
    {
        if (Text.Length == 0)
            return;
        G.DrawString(Text, Font, b1, x, y);
    }

    #endregion

    #region " DrawImage "


    private Point DrawImagePoint;
    protected void DrawImage(HorizontalAlignment a, int x, int y)
    {
        DrawImage(_Image, a, x, y);
    }
    protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
    {
        if (image == null)
            return;
        DrawImagePoint = new Point(Width / 2 - image.Width / 2, Header / 2 - image.Height / 2);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
            case HorizontalAlignment.Center:
                G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
            case HorizontalAlignment.Right:
                G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
        }
    }

    protected void DrawImage(Point p1)
    {
        DrawImage(_Image, p1.X, p1.Y);
    }
    protected void DrawImage(int x, int y)
    {
        DrawImage(_Image, x, y);
    }

    protected void DrawImage(Image image, Point p1)
    {
        DrawImage(image, p1.X, p1.Y);
    }
    protected void DrawImage(Image image, int x, int y)
    {
        if (image == null)
            return;
        G.DrawImage(image, x, y, image.Width, image.Height);
    }

    #endregion

    #region " DrawGradient "

    private LinearGradientBrush DrawGradientBrush;

    private Rectangle DrawGradientRectangle;
    protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(blend, DrawGradientRectangle);
    }
    protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(blend, DrawGradientRectangle, angle);
    }

    protected void DrawGradient(ColorBlend blend, Rectangle r)
    {
        DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
        DrawGradientBrush.InterpolationColors = blend;
        G.FillRectangle(DrawGradientBrush, r);
    }
    protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
    {
        DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
        DrawGradientBrush.InterpolationColors = blend;
        G.FillRectangle(DrawGradientBrush, r);
    }


    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(c1, c2, DrawGradientRectangle);
    }
    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(c1, c2, DrawGradientRectangle, angle);
    }

    protected void DrawGradient(Color c1, Color c2, Rectangle r)
    {
        DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
        G.FillRectangle(DrawGradientBrush, r);
    }
    protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
    {
        DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
        G.FillRectangle(DrawGradientBrush, r);
    }

    #endregion

    #region " DrawRadial "

    private GraphicsPath DrawRadialPath;
    private PathGradientBrush DrawRadialBrush1;
    private LinearGradientBrush DrawRadialBrush2;

    private Rectangle DrawRadialRectangle;
    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, width / 2, height / 2);
    }
    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, center.X, center.Y);
    }
    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, cx, cy);
    }

    public void DrawRadial(ColorBlend blend, Rectangle r)
    {
        DrawRadial(blend, r, r.Width / 2, r.Height / 2);
    }
    public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
    {
        DrawRadial(blend, r, center.X, center.Y);
    }
    public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
    {
        DrawRadialPath.Reset();
        DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

        DrawRadialBrush1 = new PathGradientBrush(DrawRadialPath);
        DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
        DrawRadialBrush1.InterpolationColors = blend;

        if (G.SmoothingMode == SmoothingMode.AntiAlias)
        {
            G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
        }
        else
        {
            G.FillEllipse(DrawRadialBrush1, r);
        }
    }


    protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(c1, c2, DrawGradientRectangle);
    }
    protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(c1, c2, DrawGradientRectangle, angle);
    }

    protected void DrawRadial(Color c1, Color c2, Rectangle r)
    {
        DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
        G.FillRectangle(DrawGradientBrush, r);
    }
    protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
    {
        DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
        G.FillEllipse(DrawGradientBrush, r);
    }

    #endregion

    #region " CreateRound "

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

}

public abstract class ThemeControl154 : Control
{


    #region " Initialization "

    protected Graphics G;

    protected Bitmap B;
    public ThemeControl154()
    {
        SetStyle((ControlStyles)139270, true);

        _ImageSize = Size.Empty;
        Font = new Font("Verdana", 8);

        MeasureBitmap = new Bitmap(1, 1);
        MeasureGraphics = Graphics.FromImage(MeasureBitmap);

        DrawRadialPath = new GraphicsPath();

        InvalidateCustimization();
        //Remove?
    }

    protected override sealed void OnHandleCreated(EventArgs e)
    {
        InvalidateCustimization();
        ColorHook();

        if (!(_LockWidth == 0))
            Width = _LockWidth;
        if (!(_LockHeight == 0))
            Height = _LockHeight;

        Transparent = _Transparent;
        if (_Transparent && _BackColor)
            BackColor = Color.Transparent;

        base.OnHandleCreated(e);
    }

    private bool DoneCreation;
    protected override sealed void OnParentChanged(EventArgs e)
    {
        if (Parent != null)
        {
            OnCreation();
            DoneCreation = true;
            InvalidateTimer();
        }

        base.OnParentChanged(e);
    }

    #endregion

    private void DoAnimation(bool i)
    {
        OnAnimation();
        if (i)
            Invalidate();
    }

    protected override sealed void OnPaint(PaintEventArgs e)
    {
        if (Width == 0 || Height == 0)
            return;

        if (_Transparent)
        {
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }
        else
        {
            G = e.Graphics;
            PaintHook();
        }
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        ThemeShare.RemoveAnimationCallback(DoAnimation);
        base.OnHandleDestroyed(e);
    }

    #region " Size Handling "

    protected override sealed void OnSizeChanged(EventArgs e)
    {
        if (_Transparent)
        {
            InvalidateBitmap();
        }

        Invalidate();
        base.OnSizeChanged(e);
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        if (!(_LockWidth == 0))
            width = _LockWidth;
        if (!(_LockHeight == 0))
            height = _LockHeight;
        base.SetBoundsCore(x, y, width, height, specified);
    }

    #endregion

    #region " State Handling "

    private bool InPosition;
    protected override void OnMouseEnter(EventArgs e)
    {
        InPosition = true;
        SetState(MouseState.Over);
        base.OnMouseEnter(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (InPosition)
            SetState(MouseState.Over);
        base.OnMouseUp(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            SetState(MouseState.Down);
        base.OnMouseDown(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        InPosition = false;
        SetState(MouseState.None);
        base.OnMouseLeave(e);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        if (Enabled)
            SetState(MouseState.None);
        else
            SetState(MouseState.Block);
        base.OnEnabledChanged(e);
    }

    protected MouseState State;
    private void SetState(MouseState current)
    {
        State = current;
        Invalidate();
    }

    #endregion


    #region " Base Properties "

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
        get { return Color.Empty; }
        set { }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Image BackgroundImage
    {
        get { return null; }
        set { }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageLayout BackgroundImageLayout
    {
        get { return ImageLayout.None; }
        set { }
    }

    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            Invalidate();
        }
    }
    public override Font Font
    {
        get { return base.Font; }
        set
        {
            base.Font = value;
            Invalidate();
        }
    }

    private bool _BackColor;
    [Category("Misc")]
    public override Color BackColor
    {
        get { return base.BackColor; }
        set
        {
            if (!IsHandleCreated && value == Color.Transparent)
            {
                _BackColor = true;
                return;
            }

            base.BackColor = value;
            if (Parent != null)
                ColorHook();
        }
    }

    #endregion

    #region " Public Properties "

    private bool _NoRounding;
    public bool NoRounding
    {
        get { return _NoRounding; }
        set
        {
            _NoRounding = value;
            Invalidate();
        }
    }

    private Image _Image;
    public Image Image
    {
        get { return _Image; }
        set
        {
            if (value == null)
            {
                _ImageSize = Size.Empty;
            }
            else
            {
                _ImageSize = value.Size;
            }

            _Image = value;
            Invalidate();
        }
    }

    private bool _Transparent;
    public bool Transparent
    {
        get { return _Transparent; }
        set
        {
            _Transparent = value;
            if (!IsHandleCreated)
                return;

            if (!value && !(BackColor.A == 255))
            {
                throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
            }

            SetStyle(ControlStyles.Opaque, !value);
            SetStyle(ControlStyles.SupportsTransparentBackColor, value);

            if (value)
                InvalidateBitmap();
            else
                B = null;
            Invalidate();
        }
    }

    private Dictionary<string, Color> Items = new Dictionary<string, Color>();
    public Bloom[] Colors
    {
        get
        {
            List<Bloom> T = new List<Bloom>();
            Dictionary<string, Color>.Enumerator E = Items.GetEnumerator();

            while (E.MoveNext())
            {
                T.Add(new Bloom(E.Current.Key, E.Current.Value));
            }

            return T.ToArray();
        }
        set
        {
            foreach (Bloom B in value)
            {
                if (Items.ContainsKey(B.Name))
                    Items[B.Name] = B.Value;
            }

            InvalidateCustimization();
            ColorHook();
            Invalidate();
        }
    }

    private string _Customization;
    public string Customization
    {
        get { return _Customization; }
        set
        {
            if (value == _Customization)
                return;

            byte[] Data = null;
            Bloom[] Items = Colors;

            try
            {
                Data = Convert.FromBase64String(value);
                for (int I = 0; I <= Items.Length - 1; I++)
                {
                    Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                }
            }
            catch
            {
                return;
            }

            _Customization = value;

            Colors = Items;
            ColorHook();
            Invalidate();
        }
    }

    #endregion

    #region " Private Properties "

    private Size _ImageSize;
    protected Size ImageSize
    {
        get { return _ImageSize; }
    }

    private int _LockWidth;
    protected int LockWidth
    {
        get { return _LockWidth; }
        set
        {
            _LockWidth = value;
            if (!(LockWidth == 0) && IsHandleCreated)
                Width = LockWidth;
        }
    }

    private int _LockHeight;
    protected int LockHeight
    {
        get { return _LockHeight; }
        set
        {
            _LockHeight = value;
            if (!(LockHeight == 0) && IsHandleCreated)
                Height = LockHeight;
        }
    }

    private bool _IsAnimated;
    protected bool IsAnimated
    {
        get { return _IsAnimated; }
        set
        {
            _IsAnimated = value;
            InvalidateTimer();
        }
    }

    #endregion


    #region " Property Helpers "

    protected Pen GetPen(string name)
    {
        return new Pen(Items[name]);
    }
    protected Pen GetPen(string name, float width)
    {
        return new Pen(Items[name], width);
    }

    protected SolidBrush GetBrush(string name)
    {
        return new SolidBrush(Items[name]);
    }

    protected Color GetColor(string name)
    {
        return Items[name];
    }

    protected void SetColor(string name, Color value)
    {
        if (Items.ContainsKey(name))
            Items[name] = value;
        else
            Items.Add(name, value);
    }
    protected void SetColor(string name, byte r, byte g, byte b)
    {
        SetColor(name, Color.FromArgb(r, g, b));
    }
    protected void SetColor(string name, byte a, byte r, byte g, byte b)
    {
        SetColor(name, Color.FromArgb(a, r, g, b));
    }
    protected void SetColor(string name, byte a, Color value)
    {
        SetColor(name, Color.FromArgb(a, value));
    }

    private void InvalidateBitmap()
    {
        if (Width == 0 || Height == 0)
            return;
        B = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
        G = Graphics.FromImage(B);
    }

    private void InvalidateCustimization()
    {
        MemoryStream M = new MemoryStream(Items.Count * 4);

        foreach (Bloom B in Colors)
        {
            M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
        }

        M.Close();
        _Customization = Convert.ToBase64String(M.ToArray());
    }

    private void InvalidateTimer()
    {
        if (DesignMode || !DoneCreation)
            return;

        if (_IsAnimated)
        {
            ThemeShare.AddAnimationCallback(DoAnimation);
        }
        else
        {
            ThemeShare.RemoveAnimationCallback(DoAnimation);
        }
    }
    #endregion


    #region " User Hooks "

    protected abstract void ColorHook();
    protected abstract void PaintHook();

    protected virtual void OnCreation()
    {
    }

    protected virtual void OnAnimation()
    {
    }

    #endregion


    #region " Offset "

    private Rectangle OffsetReturnRectangle;
    protected Rectangle Offset(Rectangle r, int amount)
    {
        OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
        return OffsetReturnRectangle;
    }

    private Size OffsetReturnSize;
    protected Size Offset(Size s, int amount)
    {
        OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
        return OffsetReturnSize;
    }

    private Point OffsetReturnPoint;
    protected Point Offset(Point p, int amount)
    {
        OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
        return OffsetReturnPoint;
    }

    #endregion

    #region " Center "


    private Point CenterReturn;
    protected Point Center(Rectangle p, Rectangle c)
    {
        CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
        return CenterReturn;
    }
    protected Point Center(Rectangle p, Size c)
    {
        CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
        return CenterReturn;
    }

    protected Point Center(Rectangle child)
    {
        return Center(Width, Height, child.Width, child.Height);
    }
    protected Point Center(Size child)
    {
        return Center(Width, Height, child.Width, child.Height);
    }
    protected Point Center(int childWidth, int childHeight)
    {
        return Center(Width, Height, childWidth, childHeight);
    }

    protected Point Center(Size p, Size c)
    {
        return Center(p.Width, p.Height, c.Width, c.Height);
    }

    protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
    {
        CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
        return CenterReturn;
    }

    #endregion

    #region " Measure "

    private Bitmap MeasureBitmap;
    //TODO: Potential issues during multi-threading.
    private Graphics MeasureGraphics;

    protected Size Measure()
    {
        return MeasureGraphics.MeasureString(Text, Font, Width).ToSize();
    }
    protected Size Measure(string text)
    {
        return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
    }

    #endregion


    #region " DrawPixel "


    private SolidBrush DrawPixelBrush;
    protected void DrawPixel(Color c1, int x, int y)
    {
        if (_Transparent)
        {
            B.SetPixel(x, y, c1);
        }
        else
        {
            DrawPixelBrush = new SolidBrush(c1);
            G.FillRectangle(DrawPixelBrush, x, y, 1, 1);
        }
    }

    #endregion

    #region " DrawCorners "


    private SolidBrush DrawCornersBrush;
    protected void DrawCorners(Color c1, int offset)
    {
        DrawCorners(c1, 0, 0, Width, Height, offset);
    }
    protected void DrawCorners(Color c1, Rectangle r1, int offset)
    {
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
    }
    protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
    {
        DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
    }

    protected void DrawCorners(Color c1)
    {
        DrawCorners(c1, 0, 0, Width, Height);
    }
    protected void DrawCorners(Color c1, Rectangle r1)
    {
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
    }
    protected void DrawCorners(Color c1, int x, int y, int width, int height)
    {
        if (_NoRounding)
            return;

        if (_Transparent)
        {
            B.SetPixel(x, y, c1);
            B.SetPixel(x + (width - 1), y, c1);
            B.SetPixel(x, y + (height - 1), c1);
            B.SetPixel(x + (width - 1), y + (height - 1), c1);
        }
        else
        {
            DrawCornersBrush = new SolidBrush(c1);
            G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
        }
    }

    #endregion

    #region " DrawBorders "

    protected void DrawBorders(Pen p1, int offset)
    {
        DrawBorders(p1, 0, 0, Width, Height, offset);
    }
    protected void DrawBorders(Pen p1, Rectangle r, int offset)
    {
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
    }
    protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
    {
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
    }

    protected void DrawBorders(Pen p1)
    {
        DrawBorders(p1, 0, 0, Width, Height);
    }
    protected void DrawBorders(Pen p1, Rectangle r)
    {
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
    }
    protected void DrawBorders(Pen p1, int x, int y, int width, int height)
    {
        G.DrawRectangle(p1, x, y, width - 1, height - 1);
    }

    #endregion

    #region " DrawText "

    private Point DrawTextPoint;

    private Size DrawTextSize;
    protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
    {
        DrawText(b1, Text, a, x, y);
    }
    protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
    {
        if (text.Length == 0)
            return;

        DrawTextSize = Measure(text);
        DrawTextPoint = Center(DrawTextSize);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y);
                break;
            case HorizontalAlignment.Center:
                G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                break;
            case HorizontalAlignment.Right:
                G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                break;
        }
    }

    protected void DrawText(Brush b1, Point p1)
    {
        if (Text.Length == 0)
            return;
        G.DrawString(Text, Font, b1, p1);
    }
    protected void DrawText(Brush b1, int x, int y)
    {
        if (Text.Length == 0)
            return;
        G.DrawString(Text, Font, b1, x, y);
    }

    #endregion

    #region " DrawImage "


    private Point DrawImagePoint;
    protected void DrawImage(HorizontalAlignment a, int x, int y)
    {
        DrawImage(_Image, a, x, y);
    }
    protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
    {
        if (image == null)
            return;
        DrawImagePoint = Center(image.Size);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
            case HorizontalAlignment.Center:
                G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
            case HorizontalAlignment.Right:
                G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
        }
    }

    protected void DrawImage(Point p1)
    {
        DrawImage(_Image, p1.X, p1.Y);
    }
    protected void DrawImage(int x, int y)
    {
        DrawImage(_Image, x, y);
    }

    protected void DrawImage(Image image, Point p1)
    {
        DrawImage(image, p1.X, p1.Y);
    }
    protected void DrawImage(Image image, int x, int y)
    {
        if (image == null)
            return;
        G.DrawImage(image, x, y, image.Width, image.Height);
    }

    #endregion

    #region " DrawGradient "

    private LinearGradientBrush DrawGradientBrush;

    private Rectangle DrawGradientRectangle;
    protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(blend, DrawGradientRectangle);
    }
    protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(blend, DrawGradientRectangle, angle);
    }

    protected void DrawGradient(ColorBlend blend, Rectangle r)
    {
        DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
        DrawGradientBrush.InterpolationColors = blend;
        G.FillRectangle(DrawGradientBrush, r);
    }
    protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
    {
        DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
        DrawGradientBrush.InterpolationColors = blend;
        G.FillRectangle(DrawGradientBrush, r);
    }


    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(c1, c2, DrawGradientRectangle);
    }
    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(c1, c2, DrawGradientRectangle, angle);
    }

    protected void DrawGradient(Color c1, Color c2, Rectangle r)
    {
        DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
        G.FillRectangle(DrawGradientBrush, r);
    }
    protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
    {
        DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
        G.FillRectangle(DrawGradientBrush, r);
    }

    #endregion

    #region " DrawRadial "

    private GraphicsPath DrawRadialPath;
    private PathGradientBrush DrawRadialBrush1;
    private LinearGradientBrush DrawRadialBrush2;

    private Rectangle DrawRadialRectangle;
    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, width / 2, height / 2);
    }
    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, center.X, center.Y);
    }
    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, cx, cy);
    }

    public void DrawRadial(ColorBlend blend, Rectangle r)
    {
        DrawRadial(blend, r, r.Width / 2, r.Height / 2);
    }
    public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
    {
        DrawRadial(blend, r, center.X, center.Y);
    }
    public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
    {
        DrawRadialPath.Reset();
        DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

        DrawRadialBrush1 = new PathGradientBrush(DrawRadialPath);
        DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
        DrawRadialBrush1.InterpolationColors = blend;

        if (G.SmoothingMode == SmoothingMode.AntiAlias)
        {
            G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
        }
        else
        {
            G.FillEllipse(DrawRadialBrush1, r);
        }
    }


    protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(c1, c2, DrawRadialRectangle);
    }
    protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(c1, c2, DrawRadialRectangle, angle);
    }

    protected void DrawRadial(Color c1, Color c2, Rectangle r)
    {
        DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
        G.FillEllipse(DrawRadialBrush2, r);
    }
    protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
    {
        DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
        G.FillEllipse(DrawRadialBrush2, r);
    }

    #endregion

    #region " CreateRound "

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

}

public static class ThemeShare
{

    #region " Animation "

    private static int Frames;
    private static bool Invalidate;

    private static PrecisionTimer ThemeTimer = new PrecisionTimer();
    //1000 / 50 = 20 FPS
    private const int FPS = 50;

    private const int Rate = 10;
    public delegate void AnimationDelegate(bool invalidate);


    private static List<AnimationDelegate> Callbacks = new List<AnimationDelegate>();
    private static void HandleCallbacks(IntPtr state, bool reserve)
    {
        Invalidate = (Frames >= FPS);
        if (Invalidate)
            Frames = 0;

        lock (Callbacks)
        {
            for (int I = 0; I <= Callbacks.Count - 1; I++)
            {
                Callbacks[I].Invoke(Invalidate);
            }
        }

        Frames += Rate;
    }

    private static void InvalidateThemeTimer()
    {
        if (Callbacks.Count == 0)
        {
            ThemeTimer.Delete();
        }
        else
        {
            ThemeTimer.Create(0, Rate, HandleCallbacks);
        }
    }

    public static void AddAnimationCallback(AnimationDelegate callback)
    {
        lock (Callbacks)
        {
            if (Callbacks.Contains(callback))
                return;

            Callbacks.Add(callback);
            InvalidateThemeTimer();
        }
    }

    public static void RemoveAnimationCallback(AnimationDelegate callback)
    {
        lock (Callbacks)
        {
            if (!Callbacks.Contains(callback))
                return;

            Callbacks.Remove(callback);
            InvalidateThemeTimer();
        }
    }

    #endregion

}

public enum MouseState : byte
{
    None = 0,
    Over = 1,
    Down = 2,
    Block = 3
}

public struct Bloom
{

    public string _Name;
    public string Name
    {
        get { return _Name; }
    }

    private Color _Value;
    public Color Value
    {
        get { return _Value; }
        set { _Value = value; }
    }

    public string ValueHex
    {
        get { return string.Concat("#", _Value.R.ToString("X2", null), _Value.G.ToString("X2", null), _Value.B.ToString("X2", null)); }
        set
        {
            try
            {
                _Value = ColorTranslator.FromHtml(value);
            }
            catch
            {
                return;
            }
        }
    }


    public Bloom(string name, Color value)
    {
        _Name = name;
        _Value = value;
    }
}


class PrecisionTimer : IDisposable
{

    private bool _Enabled;
    public bool Enabled
    {
        get { return _Enabled; }
    }

    private IntPtr Handle;

    private TimerDelegate TimerCallback;
    [DllImport("kernel32.dll", EntryPoint = "CreateTimerQueueTimer")]
    private static extern bool CreateTimerQueueTimer(ref IntPtr handle, IntPtr queue, TimerDelegate callback, IntPtr state, uint dueTime, uint period, uint flags);

    [DllImport("kernel32.dll", EntryPoint = "DeleteTimerQueueTimer")]
    private static extern bool DeleteTimerQueueTimer(IntPtr queue, IntPtr handle, IntPtr callback);

    public delegate void TimerDelegate(IntPtr r1, bool r2);

    public void Create(uint dueTime, uint period, TimerDelegate callback)
    {
        if (_Enabled)
            return;

        TimerCallback = callback;
        bool Success = CreateTimerQueueTimer(ref Handle, IntPtr.Zero, TimerCallback, IntPtr.Zero, dueTime, period, 0);

        if (!Success)
            ThrowNewException("CreateTimerQueueTimer");
        _Enabled = Success;
    }

    public void Delete()
    {
        if (!_Enabled)
            return;
        bool Success = DeleteTimerQueueTimer(IntPtr.Zero, Handle, IntPtr.Zero);

        if (!Success && !(Marshal.GetLastWin32Error() == 997))
        {
            ThrowNewException("DeleteTimerQueueTimer");
        }

        _Enabled = !Success;
    }

    private void ThrowNewException(string name)
    {
        throw new Exception(string.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error()));
    }

    public void Dispose()
    {
        Delete();
    }
}

#endregion
    
#region Helpers ThemeControl, Theme, ThemeContainerControl

public abstract class ThemeControl : Control
{

    #region " Initialization "

    protected Graphics G;
    protected Bitmap B;
    public ThemeControl()
    {
        SetStyle((ControlStyles)139270, true);
        B = new Bitmap(1, 1);
        G = Graphics.FromImage(B);
    }

    public void AllowTransparent()
    {
        SetStyle(ControlStyles.Opaque, false);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    }

    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            Invalidate();
        }
    }
    #endregion

    #region " Mouse Handling "

    protected enum State : byte
    {
        MouseNone = 0,
        MouseOver = 1,
        MouseDown = 2
    }

    protected State MouseState;
    protected override void OnMouseLeave(EventArgs e)
    {
        ChangeMouseState(State.MouseNone);
        base.OnMouseLeave(e);
    }
    protected override void OnMouseEnter(EventArgs e)
    {
        ChangeMouseState(State.MouseOver);
        base.OnMouseEnter(e);
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        ChangeMouseState(State.MouseOver);
        base.OnMouseUp(e);
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            ChangeMouseState(State.MouseDown);
        base.OnMouseDown(e);
    }

    private void ChangeMouseState(State e)
    {
        MouseState = e;
        Invalidate();
    }

    #endregion

    #region " Convienence "

    public abstract void PaintHook();
    protected override sealed void OnPaint(PaintEventArgs e)
    {
        if (Width == 0 || Height == 0)
            return;
        PaintHook();
        e.Graphics.DrawImage(B, 0, 0);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        if (!(Width == 0) && !(Height == 0))
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            Invalidate();
        }
        base.OnSizeChanged(e);
    }

    private bool _NoRounding;
    public bool NoRounding
    {
        get { return _NoRounding; }
        set
        {
            _NoRounding = value;
            Invalidate();
        }
    }

    private Image _Image;
    public Image Image
    {
        get { return _Image; }
        set
        {
            _Image = value;
            Invalidate();
        }
    }
    public int ImageWidth
    {
        get
        {
            if (_Image == null)
                return 0;
            return _Image.Width;
        }
    }
    public int ImageTop
    {
        get
        {
            if (_Image == null)
                return 0;
            return Height / 2 - _Image.Height / 2;
        }
    }

    private Size _Size;
    private Rectangle _Rectangle;
    private LinearGradientBrush _Gradient;

    private SolidBrush _Brush;
    protected void DrawCorners(Color c, Rectangle rect)
    {
        if (_NoRounding)
            return;

        B.SetPixel(rect.X, rect.Y, c);
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c);
        B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c);
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c);
    }

    protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
    {
        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
    }

    protected void DrawText(HorizontalAlignment a, Color c, int x)
    {
        DrawText(a, c, x, 0);
    }
    protected void DrawText(HorizontalAlignment a, Color c, int x, int y)
    {
        if (string.IsNullOrEmpty(Text))
            return;
        _Size = G.MeasureString(Text, Font).ToSize();
        _Brush = new SolidBrush(c);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawString(Text, Font, _Brush, x, Height / 2 - _Size.Height / 2 + y);
                break;
            case HorizontalAlignment.Right:
                G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, Height / 2 - _Size.Height / 2 + y);
                break;
            case HorizontalAlignment.Center:
                G.DrawString(Text, Font, _Brush, Width / 2 - _Size.Width / 2 + x, Height / 2 - _Size.Height / 2 + y);
                break;
        }
    }

    protected void DrawIcon(HorizontalAlignment a, int x)
    {
        DrawIcon(a, x, 0);
    }
    protected void DrawIcon(HorizontalAlignment a, int x, int y)
    {
        if (_Image == null)
            return;
        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawImage(_Image, x, Height / 2 - _Image.Height / 2 + y);
                break;
            case HorizontalAlignment.Right:
                G.DrawImage(_Image, Width - _Image.Width - x, Height / 2 - _Image.Height / 2 + y);
                break;
            case HorizontalAlignment.Center:
                G.DrawImage(_Image, Width / 2 - _Image.Width / 2, Height / 2 - _Image.Height / 2);
                break;
        }
    }

    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        _Rectangle = new Rectangle(x, y, width, height);
        _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
        G.FillRectangle(_Gradient, _Rectangle);
    }
    #endregion

}

public abstract class Theme : ContainerControl
{

    #region " Initialization "

    protected Graphics G;
    public Theme()
    {
        SetStyle((ControlStyles)139270, true);
    }

    private bool ParentIsForm;
    protected override void OnHandleCreated(EventArgs e)
    {
        Dock = DockStyle.Fill;
        ParentIsForm = Parent is System.Windows.Forms.Form;
        if (ParentIsForm)
        {
            if (!(_TransparencyKey == Color.Empty))
                ParentForm.TransparencyKey = _TransparencyKey;
            ParentForm.FormBorderStyle = FormBorderStyle.None;
        }
        base.OnHandleCreated(e);
    }

    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            Invalidate();
        }
    }
    #endregion

    #region " Sizing and Movement "

    private bool _Resizable = true;
    public bool Resizable
    {
        get { return _Resizable; }
        set { _Resizable = value; }
    }

    private int _MoveHeight = 24;
    public int MoveHeight
    {
        get { return _MoveHeight; }
        set
        {
            _MoveHeight = value;
            Header = new Rectangle(7, 7, Width - 14, _MoveHeight - 7);
        }
    }

    private IntPtr Flag;
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (!(e.Button == MouseButtons.Left))
            return;
        if (ParentIsForm)
            if (ParentForm.WindowState == FormWindowState.Maximized)
                return;

        if (Header.Contains(e.Location))
        {
            Flag = new IntPtr(2);
        }
        else if (Current.Position == 0 | !_Resizable)
        {
            return;
        }
        else
        {
            Flag = new IntPtr(Current.Position);
        }

        Capture = false;
        //DefWndProc(Message.Create(Parent.Handle, 161, Flag, null));

        base.OnMouseDown(e);
    }

    private struct Pointer
    {
        public readonly Cursor Cursor;
        public readonly byte Position;
        public Pointer(Cursor c, byte p)
        {
            Cursor = c;
            Position = p;
        }
    }

    private bool F1;
    private bool F2;
    private bool F3;
    private bool F4;
    private Point PTC;
    private Pointer GetPointer()
    {
        PTC = PointToClient(MousePosition);
        F1 = PTC.X < 7;
        F2 = PTC.X > Width - 7;
        F3 = PTC.Y < 7;
        F4 = PTC.Y > Height - 7;

        if (F1 & F3)
            return new Pointer(Cursors.SizeNWSE, 13);
        if (F1 & F4)
            return new Pointer(Cursors.SizeNESW, 16);
        if (F2 & F3)
            return new Pointer(Cursors.SizeNESW, 14);
        if (F2 & F4)
            return new Pointer(Cursors.SizeNWSE, 17);
        if (F1)
            return new Pointer(Cursors.SizeWE, 10);
        if (F2)
            return new Pointer(Cursors.SizeWE, 11);
        if (F3)
            return new Pointer(Cursors.SizeNS, 12);
        if (F4)
            return new Pointer(Cursors.SizeNS, 15);
        return new Pointer(Cursors.Default, 0);
    }

    private Pointer Current;
    private Pointer Pending;
    private void SetCurrent()
    {
        Pending = GetPointer();
        if (Current.Position == Pending.Position)
            return;
        Current = GetPointer();
        Cursor = Current.Cursor;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (_Resizable)
            SetCurrent();
        base.OnMouseMove(e);
    }

    protected Rectangle Header;
    protected override void OnSizeChanged(EventArgs e)
    {
        if (Width == 0 || Height == 0)
            return;
        Header = new Rectangle(7, 7, Width - 14, _MoveHeight - 7);
        Invalidate();
        base.OnSizeChanged(e);
    }

    #endregion

    #region " Convienence "

    public abstract void PaintHook();
    protected override sealed void OnPaint(PaintEventArgs e)
    {
        if (Width == 0 || Height == 0)
            return;
        G = e.Graphics;
        PaintHook();
    }

    private Color _TransparencyKey;
    public Color TransparencyKey
    {
        get { return _TransparencyKey; }
        set
        {
            _TransparencyKey = value;
            Invalidate();
        }
    }

    private Image _Image;
    public Image Image
    {
        get { return _Image; }
        set
        {
            _Image = value;
            Invalidate();
        }
    }
    public int ImageWidth
    {
        get
        {
            if (_Image == null)
                return 0;
            return _Image.Width;
        }
    }

    private Size _Size;
    private Rectangle _Rectangle;
    private LinearGradientBrush _Gradient;

    private SolidBrush _Brush;
    protected void DrawCorners(Color c, Rectangle rect)
    {
        _Brush = new SolidBrush(c);
        G.FillRectangle(_Brush, rect.X, rect.Y, 1, 1);
        G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y, 1, 1);
        G.FillRectangle(_Brush, rect.X, rect.Y + (rect.Height - 1), 1, 1);
        G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), 1, 1);
    }

    protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
    {
        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
    }

    protected void DrawText(HorizontalAlignment a, Color c, int x)
    {
        DrawText(a, c, x, 0);
    }
    protected void DrawText(HorizontalAlignment a, Color c, int x, int y)
    {
        if (string.IsNullOrEmpty(Text))
            return;
        _Size = G.MeasureString(Text, Font).ToSize();
        _Brush = new SolidBrush(c);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawString(Text, Font, _Brush, x, _MoveHeight / 2 - _Size.Height / 2 + y);
                break;
            case HorizontalAlignment.Right:
                G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, _MoveHeight / 2 - _Size.Height / 2 + y);
                break;
            case HorizontalAlignment.Center:
                G.DrawString(Text, Font, _Brush, Width / 2 - _Size.Width / 2 + x, _MoveHeight / 2 - _Size.Height / 2 + y);
                break;
        }
    }

    protected void DrawIcon(HorizontalAlignment a, int x)
    {
        DrawIcon(a, x, 0);
    }
    protected void DrawIcon(HorizontalAlignment a, int x, int y)
    {
        if (_Image == null)
            return;
        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawImage(_Image, x, _MoveHeight / 2 - _Image.Height / 2 + y);
                break;
            case HorizontalAlignment.Right:
                G.DrawImage(_Image, Width - _Image.Width - x, _MoveHeight / 2 - _Image.Height / 2 + y);
                break;
            case HorizontalAlignment.Center:
                G.DrawImage(_Image, Width / 2 - _Image.Width / 2, _MoveHeight / 2 - _Image.Height / 2);
                break;
        }
    }

    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        _Rectangle = new Rectangle(x, y, width, height);
        _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
        G.FillRectangle(_Gradient, _Rectangle);
    }

    #endregion

}

abstract class ThemeContainerControl : ContainerControl
{

    #region " Initialization "

    protected Graphics G;
    protected Bitmap B;
    public ThemeContainerControl()
    {
        SetStyle((ControlStyles)139270, true);
        B = new Bitmap(1, 1);
        G = Graphics.FromImage(B);
    }

    public void AllowTransparent()
    {
        SetStyle(ControlStyles.Opaque, false);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    }

    #endregion
    #region " Convienence "

    public abstract void PaintHook();
    protected override sealed void OnPaint(PaintEventArgs e)
    {
        if (Width == 0 || Height == 0)
            return;
        PaintHook();
        e.Graphics.DrawImage(B, 0, 0);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        if (!(Width == 0) && !(Height == 0))
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            Invalidate();
        }
        base.OnSizeChanged(e);
    }

    private bool _NoRounding;
    public bool NoRounding
    {
        get { return _NoRounding; }
        set
        {
            _NoRounding = value;
            Invalidate();
        }
    }

    private Rectangle _Rectangle;

    private LinearGradientBrush _Gradient;
    protected void DrawCorners(Color c, Rectangle rect)
    {
        if (_NoRounding)
            return;
        B.SetPixel(rect.X, rect.Y, c);
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c);
        B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c);
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c);
    }

    protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
    {
        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
    }

    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        _Rectangle = new Rectangle(x, y, width, height);
        _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
        G.FillRectangle(_Gradient, _Rectangle);
    }
    #endregion

}
#endregion
    
    
static class ConversionFunctions
{
	// By Tedd
	public static Brush ConvertToBrush(int R, int G, int B)
	{
		return new SolidBrush(Color.FromArgb(R, G, B));
	}

	public static Brush ConvertToBrush(Pen Pen)
	{
		return new SolidBrush(Pen.Color);
	}

	public static Brush ConvertToBrush(Color Color)
	{
		return new SolidBrush(Color);
	}

	public static Pen ConvertToPen(int R, int G, int B)
	{
		return new Pen(new SolidBrush(Color.FromArgb(R, G, B)));
	}

	public static Pen ConvertToPen(SolidBrush Brush)
	{
		return new Pen(Brush);
	}

	public static Pen ConvertToPen(Color Color)
	{
		return new Pen(new SolidBrush(Color));
	}
}

[ToolboxItem(false)]
public class AdobeTheme : ThemeContainer154
{

	public enum Alignment : int
	{
		Left = 0,
		Center = 1,
		Right = 2
	}

	#region "Properties"

	private Alignment textAlign;
	public Alignment TextAlignment {
		get { return textAlign; }
		set {
			textAlign = value;
			Invalidate();
		}
	}

	private Color textColor;
	public override Color ForeColor {
		get { return textColor; }
		set {
			textColor = value;
			Invalidate();
		}
	}

	#endregion

	public AdobeTheme()
	{
		//MoveHeight = 19;
		TransparencyKey = Color.Fuchsia;
		BackColor = Color.FromArgb(68, 68, 68);
		this.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
		ForeColor = Color.White;
	}

	protected override void ColorHook()
	{
		//Void
	}

	protected override void PaintHook()
	{
		G.Clear(BackColor);

		//Top bar
		G.FillRectangle(ConversionFunctions.ConvertToBrush(51, 51, 51), 0, 0, Width, 37);
		G.DrawLine(ConversionFunctions.ConvertToPen(31, 31, 31), 0, 37, Width, 37);
		G.DrawLine(ConversionFunctions.ConvertToPen(60, 60, 60), 0, 38, Width, 38);

		//Middle
		G.FillRectangle(ConversionFunctions.ConvertToBrush(68, 68, 68), 1, 39, Width - 2, Height - 41);

		//Bottom bar
		G.FillRectangle(ConversionFunctions.ConvertToBrush(51, 51, 51), 1, Height - 37, Width, 37);
		G.DrawLine(ConversionFunctions.ConvertToPen(31, 31, 31), 0, Height - 37, Width, Height - 37);
		G.DrawLine(ConversionFunctions.ConvertToPen(60, 60, 60), 0, Height - 38, Width, Height - 38);

        //Title
        
        switch (textAlign) {
			case Alignment.Left:
				//Left
				DrawText(Brushes.Black, Text, HorizontalAlignment.Left, 10, 20);
				DrawText(ConversionFunctions.ConvertToBrush(ForeColor), Text, HorizontalAlignment.Left, 8, 18);
				break;
			case Alignment.Center:
				//Center
				DrawText(Brushes.Black, Text, HorizontalAlignment.Center, 2, 20);
				DrawText(ConversionFunctions.ConvertToBrush(ForeColor), Text, HorizontalAlignment.Center, 0, 18);
				break;
			case Alignment.Right:
				//Right   
				DrawText(Brushes.Black, Text, HorizontalAlignment.Right, 10, 20);
				DrawText(ConversionFunctions.ConvertToBrush(ForeColor), Text, HorizontalAlignment.Right, 8, 18);
				break;
		}

		//Border
		DrawBorders(Pens.Black);
		DrawBorders(Pens.Gray, 1);

		//Rounding
		switch (Parent.FindForm().FormBorderStyle) {
			case FormBorderStyle.None:
				DrawCorners(Color.Fuchsia);
				break;
			default:
				DrawCorners(Color.Black);
				break;
		}

	}
}

}
