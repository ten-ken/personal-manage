using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWfControls.Controls.KenButton
{

   
    public enum ControlState
    {
        Normal,
        Hover,
        Pressed
    }
    public enum RoundStyle
    {
        None,
        Top,
        Bottom,
        Left,
        Right,
        All
    }
    public class GraphicsPathHelper
    {
        #region 建立带有圆角样式的路径
        /// <summary>
        /// 建立带有圆角样式的路径
        /// </summary>
        /// <param name="rect">用来建立路径的矩形</param>
        /// <param name="radius">圆角半径</param>
        /// <param name="style"></param>
        /// <param name="correction"></param>
        /// <returns></returns>
        public static GraphicsPath CreatePath(
        Rectangle rect, int radius, RoundStyle style, bool correction)
        {
            GraphicsPath path = new GraphicsPath();
            int radiusCorrection = correction ? 1 : 0;
            switch (style)
            {
                case RoundStyle.None:
                    path.AddRectangle(rect);
                    break;
                case RoundStyle.All:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(
                    rect.Right - radius - radiusCorrection,
                    rect.Y,
                    radius,
                    radius,
                    270,
                    90);
                    path.AddArc(
                    rect.Right - radius - radiusCorrection,
                    rect.Bottom - radius - radiusCorrection,
                    radius,
                    radius, 0, 90);
                    path.AddArc(
                    rect.X,
                    rect.Bottom - radius - radiusCorrection,
                    radius,
                    radius,
                    90,
                    90);
                    break;
                case RoundStyle.Left:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddLine(
                    rect.Right - radiusCorrection, rect.Y,
                    rect.Right - radiusCorrection, rect.Bottom - radiusCorrection);
                    path.AddArc(
                    rect.X,
                    rect.Bottom - radius - radiusCorrection,
                    radius,
                    radius,
                    90,
                    90);
                    break;
                case RoundStyle.Right:
                    path.AddArc(
                    rect.Right - radius - radiusCorrection,
                    rect.Y,
                    radius,
                    radius,
                    270,
                    90);
                    path.AddArc(
                    rect.Right - radius - radiusCorrection,
                    rect.Bottom - radius - radiusCorrection,
                    radius,
                    radius,
                    0,
                    90);
                    path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
                    break;
                case RoundStyle.Top:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(
                    rect.Right - radius - radiusCorrection,
                    rect.Y,
                    radius,
                    radius,
                    270,
                    90);
                    path.AddLine(
                    rect.Right - radiusCorrection, rect.Bottom - radiusCorrection,
                    rect.X, rect.Bottom - radiusCorrection);
                    break;
                case RoundStyle.Bottom:
                    path.AddArc(
                    rect.Right - radius - radiusCorrection,
                    rect.Bottom - radius - radiusCorrection,
                    radius,
                    radius,
                    0,
                    90);
                    path.AddArc(
                    rect.X,
                    rect.Bottom - radius - radiusCorrection,
                    radius,
                    radius,
                    90,
                    90);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    break;

            }
            path.CloseFigure();

            return path;
        }
        #endregion
    }


    public class KenButton : Button
    {
        private Color _baseColor = Color.FromArgb(51, 161, 224);//基颜色
        private ControlState _controlState;//控件状态
        private int _imageWidth = 18;
        private RoundStyle _roundStyle = RoundStyle.All;//圆角
        private int _radius = 8; //圆角半径

        public KenButton() : base()
        {
            this.SetStyle(
            ControlStyles.UserPaint | //控件自行绘制，而不使用操作系统的绘制
            ControlStyles.AllPaintingInWmPaint | //忽略擦出的消息，减少闪烁。
            ControlStyles.OptimizedDoubleBuffer |//在缓冲区上绘制，不直接绘制到屏幕上，减少闪烁。
            ControlStyles.ResizeRedraw | //控件大小发生变化时，重绘。
            ControlStyles.SupportsTransparentBackColor, true);//支持透明背景颜色
        }
        #region 属性
        [DefaultValue(typeof(Color), "51, 161, 224")]
        public Color BaseColor
        {
            get { return _baseColor; }
            set
            {
                _baseColor = value;
                base.Invalidate();
            }
        }
        [DefaultValue(18)]//默认值为18px，最小12px
        public int ImageWidth
        {
            get { return _imageWidth; }
            set
            {
                if (value != _imageWidth)
                {
                    _imageWidth = value < 12 ? 12 : value;
                    base.Invalidate();
                }
            }
        }
        [DefaultValue(typeof(RoundStyle), "1")]//默认全部都是圆角
        public RoundStyle RoundStyle
        {
            get { return _roundStyle; }
            set
            {
                if (_roundStyle != value)
                {
                    _roundStyle = value;
                    base.Invalidate();
                }
            }
        }
        [DefaultValue(8)]//设置圆角半径，默认值为8，最小值为4px
        public int Radius
        {
            get { return _radius; }
            set
            {
                if (_radius != value)
                {
                    _radius = value < 4 ? 4 : value;
                    base.Invalidate();
                }
            }
        }
        public ControlState ControlState //控件的状态
        {
            get { return _controlState; }
            set
            {
                if (_controlState != value)
                {
                    _controlState = value;
                    base.Invalidate();
                }
            }
        }
        #endregion

        #region 鼠标对应的几个事件
        protected override void OnMouseEnter(EventArgs e)//鼠标进入时
        {
            base.OnMouseEnter(e);
            ControlState = ControlState.Hover;//正常
        }
        protected override void OnMouseLeave(EventArgs e)//鼠标离开
        {
            base.OnMouseLeave(e);
            ControlState = ControlState.Normal;//正常
        }
        protected override void OnMouseDown(MouseEventArgs e)//鼠标按下
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)//鼠标左键且点击次数为1
            {
                ControlState = ControlState.Pressed;//按下的状态
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)//鼠标弹起
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (ClientRectangle.Contains(e.Location))//控件区域包含鼠标的位置
                {
                    ControlState = ControlState.Hover;
                }
                else
                {
                    ControlState = ControlState.Normal;
                }
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);

            Graphics g = e.Graphics;
            Rectangle imageRect;//图像区域
            Rectangle textRect;//文字区域

            this.CalculateRect(out imageRect, out textRect);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color baseColor;
            Color borderColor;
            Color innerBorderColor = this._baseColor;//Color.FromArgb(200, 255, 255, 255); ;

            if (Enabled)
            {
                switch (ControlState)
                {
                    case ControlState.Hover:
                        baseColor = GetColor(_baseColor, 0, -35, -24, -30);
                        borderColor = _baseColor;
                        break;
                    case ControlState.Pressed:
                        baseColor = GetColor(_baseColor, 0, -35, -24, -9);
                        borderColor = _baseColor;
                        break;
                    default:
                        baseColor = _baseColor;
                        borderColor = _baseColor;
                        break;
                }
            }
            else
            {
                baseColor = SystemColors.ControlDark;
                borderColor = SystemColors.ControlDark;
            }

            this.RenderBackgroundInternal(
            g,
            ClientRectangle,
            baseColor,
            borderColor,
            innerBorderColor,
            RoundStyle,
            Radius,
            0.0f,
            false,
            true,
            LinearGradientMode.Vertical);

            if (Image != null)
            {
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.DrawImage(Image, imageRect, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel);
            }
            TextRenderer.DrawText(g, Text, Font, textRect, ForeColor, GetTextFormatFlags(TextAlign, RightToLeft == RightToLeft.Yes));
        }

        private TextFormatFlags GetTextFormatFlags(ContentAlignment alignment, bool rightToleft)
        {
            TextFormatFlags flags = TextFormatFlags.WordBreak |
            TextFormatFlags.SingleLine;
            if (rightToleft)
            {
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            }

            switch (alignment)
            {
                case ContentAlignment.BottomCenter:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleCenter:
                    flags |= TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleLeft:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                case ContentAlignment.MiddleRight:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.TopCenter:
                    flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopLeft:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
            }
            return flags;
        }

        protected virtual int CheckRectWidth
        {
            get { return 12; }
        }
        private static readonly ContentAlignment RightAlignment = ContentAlignment.TopRight | ContentAlignment.BottomRight | ContentAlignment.MiddleRight;
        private static readonly ContentAlignment LeftAlignment = ContentAlignment.TopLeft | ContentAlignment.BottomLeft | ContentAlignment.MiddleLeft;

        private void CalculateRect(out Rectangle circleRect, out Rectangle textRect)
        {
            ContentAlignment CheckAlign = ContentAlignment.MiddleLeft;

            circleRect = new Rectangle(
            0, 0, CheckRectWidth, CheckRectWidth);
            textRect = Rectangle.Empty;
            bool bCheckAlignLeft = (int)(LeftAlignment & CheckAlign) != 0;
            bool bCheckAlignRight = (int)(RightAlignment & CheckAlign) != 0;
            bool bRightToLeft = (RightToLeft == RightToLeft.Yes);

            if ((bCheckAlignLeft && !bRightToLeft) ||
            (bCheckAlignRight && bRightToLeft))
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopRight:
                    case ContentAlignment.TopLeft:
                        circleRect.Y = 2;
                        break;
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.MiddleLeft:
                        circleRect.Y = (Height - CheckRectWidth) / 2;
                        break;
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.BottomLeft:
                        circleRect.Y = Height - CheckRectWidth - 2;
                        break;
                }

                circleRect.X = 1;

                textRect = new Rectangle(
                circleRect.Right + 2,
                0,
                Width - circleRect.Right - 4,
                Height);
            }
            else if ((bCheckAlignRight && !bRightToLeft) || (bCheckAlignLeft && bRightToLeft))
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopRight:
                        circleRect.Y = 2;
                        break;
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleRight:
                        circleRect.Y = (Height - CheckRectWidth) / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomRight:
                        circleRect.Y = Height - CheckRectWidth - 2;
                        break;
                }

                circleRect.X = Width - CheckRectWidth - 1;

                textRect = new Rectangle(
                2, 0, Width - CheckRectWidth - 6, Height);
            }
            else
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopCenter:
                        circleRect.Y = 2;
                        textRect.Y = circleRect.Bottom + 2;
                        textRect.Height = Height - CheckRectWidth - 6;
                        break;
                    case ContentAlignment.MiddleCenter:
                        circleRect.Y = (Height - CheckRectWidth) / 2;
                        textRect.Y = 0;
                        textRect.Height = Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        circleRect.Y = Height - CheckRectWidth - 2;
                        textRect.Y = 0;
                        textRect.Height = Height - CheckRectWidth - 6;
                        break;
                }

                circleRect.X = (Width - CheckRectWidth) / 2;

                textRect.X = 2;
                textRect.Width = Width - 4;
            }
        }


        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;
            if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }

            return Color.FromArgb(a, r, g, b);
        }


        internal void RenderBackgroundInternal(
        Graphics g,
        Rectangle rect,
        Color baseColor,
        Color borderColor,
        Color innerBorderColor,
        RoundStyle style,
        int roundWidth,//圆角半径
        float basePosition,
        bool drawBorder,
        bool drawGlass,
        LinearGradientMode mode)
        {
            if (drawBorder)//是否画边框
            {
                rect.Width--;
                rect.Height--;
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 0, 0, 0);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 0, 0, 0);

                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, basePosition, basePosition, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                if (style != RoundStyle.None)
                {
                    using (GraphicsPath path = GraphicsPathHelper.CreatePath(rect, roundWidth, style, true))
                    {
                        g.FillPath(brush, path);
                    }

                    if (baseColor.A > 80)
                    {
                        Rectangle rectTop = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            rectTop.Height = (int)(rectTop.Height * basePosition);
                        }
                        else
                        {
                            rectTop.Width = (int)(rect.Width * basePosition);
                        }
                        using (GraphicsPath pathTop = GraphicsPathHelper.CreatePath(rectTop, roundWidth, RoundStyle.All, false))
                        {
                            using (SolidBrush brushAlpha =
                            new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                            {
                                g.FillPath(brushAlpha, pathTop);
                            }
                        }
                    }

                }
            }
        }

    }
   
}
