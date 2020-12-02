/*using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace personal_manage.Common.util
{
    public static class FormTransform
    {
        public static void TransformSize(Form frm, int newWidth, int newHeight)
        {
            TransformSize(frm, new Size(newWidth, newHeight));
        }

        public static void TransformSize(Control ctl, int newWidth, int newHeight)
        {
            TransformSize(ctl, new Size(newWidth, newHeight));
        }

        public static void TransformSize(object frm, Size newSize)
        {
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(RunTransformation);
            Thread transformThread = new Thread(threadStart);
            transformThread.Start(new object[] { frm, newSize });
        }

        private delegate void RunTransformationDelegate(object paramaters);
        private static void RunTransformation(object parameters)
        {
            //Form boder = (Form)((object[])parameters)[0];
            Panel boder = (Panel)((object[])parameters)[0];
            if (boder.InvokeRequired)
            {
                RunTransformationDelegate del = new RunTransformationDelegate(RunTransformation);
                boder.Invoke(del, parameters);
            }
            else
            {
                //动画的变量参数
                double FPS = 300.0;
                long interval = (long)(Stopwatch.Frequency / FPS);
                long ticks1 = 0;
                long ticks2 = 0;

                //传进来的新的窗体的大小
                Size size = (Size)((object[])parameters)[1];

                double xDiff = Math.Abs(boder.Width - size.Width);
                double yDiff = Math.Abs(boder.Height - size.Height);

                int step = 10;

                int xDirection = boder.Width < size.Width ? 1 : -1;
                int yDirection = boder.Height < size.Height ? 1 : -1;

                int xStep = step * xDirection;
                int yStep = step * yDirection;

                //要调整的窗体的宽度是否在步长之内
                bool widthOff = IsWidthOff(boder.Width, size.Width, xStep);
                //要调整的窗体的高度是否在步长之内
                bool heightOff = IsHeightOff(boder.Height, size.Height, yStep);


                while (widthOff || heightOff)
                {
                    //获取当前的时间戳
                    ticks2 = Stopwatch.GetTimestamp();
                    //允许调整大小仅在有足够的时间来刷新窗体的时候
                    if (ticks2 >= ticks1 + interval)
                    {
                        //调整窗体的大小
                        if (widthOff)
                            boder.Width += xStep;

                        if (heightOff)
                            boder.Height += yStep;

                        widthOff = IsWidthOff(boder.Width, size.Width, xStep);
                        heightOff = IsHeightOff(boder.Height, size.Height, yStep);

                        //允许窗体刷新
                        Application.DoEvents();

                        //保存当前的时间戳
                        ticks1 = Stopwatch.GetTimestamp();
                    }

                    Thread.Sleep(1);
                }

            }
        }

        private static bool IsWidthOff(int currentWidth, int targetWidth, int step)
        {
            //目标宽度与当前宽度是否在步长之内，如果是，返回false
            if (Math.Abs(currentWidth - targetWidth) <= Math.Abs(step)) return false;

            return (step > 0 && currentWidth < targetWidth) ||
                   (step < 0 && currentWidth > targetWidth);
        }

        private static bool IsHeightOff(int currentHeight, int targetHeight, int step)
        {
            //目标高度与当前高度是否在步长之内，如果是，返回false
            if (Math.Abs(currentHeight - targetHeight) <= Math.Abs(step)) return false;

            return (step > 0 && currentHeight < targetHeight) ||
                   (step < 0 && currentHeight > targetHeight);
        }
    }
}
*/