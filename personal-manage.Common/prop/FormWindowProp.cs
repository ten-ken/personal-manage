using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_manage.Common.prop
{
    /// <summary>
    /// 
    ///  备注 :拓展属性值 需要跟form 属性一致
    /// </summary>
    public class FormWindowProp
    {
        //窗口最大化
        private  bool maximizeBox = true;

        //窗口最小化
        private bool minimizeBox = true;

        /// <summary>
        /// 边框样式
        /// 
        /// None：将窗口设置为无边框、无标题栏。用户无法改变窗口的大小，也无法改变窗口显示的位置；
        /// FixedSingle：将窗口设置为固定的单框（窄框），用户无法用鼠标拖动边框改变窗口的大小，但可以通过最大化按钮将窗口最大化、最小化按钮将最小化；
        ///Fixed3D：将窗口设置为固定框，3D风格，用户无法用鼠标拖动边框改变窗口的大小，但可以通过最大化按钮将窗口最大化、最小化按钮将最小化。窗口的工作区具有凹陷3D效果；
        ///FixedDialog：将窗口设置为固定框，对话框风格，用户无法用鼠标拖动边框改变窗口的大小，但可以通过最大化按钮将窗口最大化、最小化按钮将最小化；
        /// FixedToolWindow：将窗口设置为固定框，工具窗口风格，用户无法用鼠标拖动边框改变窗口的大小；工具窗口风格的特点是：标题栏高度比较小，且只有关闭按钮
        /// </summary>
        public FormBorderStyle FormBorderStyle { get; set; }


        public FormWindowProp()
        {
        }



        /// <summary>
        /// 最大化 最小化设置
        /// </summary>
        /// <param name="maximizeBox"></param>
        /// <param name="minimizeBox"></param>
        /// <param name="borderStyle">边框样式</param>
        public FormWindowProp(bool maximizeBox, bool minimizeBox, FormBorderStyle borderStyle)
        {
            this.maximizeBox = maximizeBox;
            this.minimizeBox = minimizeBox;
            FormBorderStyle = borderStyle;
        }

        public bool MaximizeBox { get => maximizeBox; set => maximizeBox = value; }
        public bool MinimizeBox { get => minimizeBox; set => minimizeBox = value; }
    }
}
