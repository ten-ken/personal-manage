using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.Common.prop;

namespace personal_manage.Common.util
{

    /// <summary>
    /// 弹窗工具
    /// </summary>
    public class DialogUtil
    {
        private static int widthDefault = 500;

        private static int heightDefault = 300;

        /// <summary>
        /// 宽减少
        /// </summary>
        private static int widthReduceDefault = 150;

        /// <summary>
        /// 高减少
        /// </summary>
        private static int heightReduceDefault = 30;



        public static void ShowDialog(Form form, Form owner,FormWindowProp formWindowProp)
        {
            ShowDialog(form, owner, widthDefault, heightDefault, false, formWindowProp,false);
        }

        /// <summary>
        /// 显示当前窗口关闭 原窗口
        /// </summary>
        /// <param name="openForm">需要打开的窗口</param>
        /// <param name="closeForm">需要关闭的窗口</param>
        public static void ShowAndClose(Form @openForm,Form @closeForm)
        {
            @closeForm.Hide();
            @openForm.ShowDialog();
            @closeForm.Close();
        }

        /// <summary>
        ///  弹窗--宽度设置宽高
        /// </summary>
        /// <param name="form"></param>
        /// <param name="owner"></param>
        public static void ShowDialog(Form form, Form owner, bool cancelBorder, FormWindowProp formWindowProp)
        {
            ShowDialog(form, owner, widthDefault, heightDefault, cancelBorder, formWindowProp, false);
        }

        public static void ShowDialog(Form form, Form owner, int width, int height, FormWindowProp formWindowProp)
        {
            ShowDialog(form, owner, width, height, false,  formWindowProp, false);
        }

      

        /// <summary>
        ///  弹窗--随着父窗口设置高宽  高宽在父窗口的基础进行减少
        /// </summary>
        /// <param name="form"></param>
        /// <param name="owner"></param>
        /// <param name="formWindowProp"></param>
        public static void ShowWithPWin(Form form, Form owner, FormWindowProp formWindowProp)
        {
            ShowDialog(form, owner, widthReduceDefault, heightReduceDefault, false,  formWindowProp, true);
        }

        /// <summary>
        /// 弹窗-- 随着父窗口设置高宽  高宽在父窗口的基础进行减少
        /// </summary>
        /// <param name="form"></param>
        /// <param name="owner"></param>
        /// <param name="formWindowProp"></param>
        public static void ShowWithPWin(Form form, Form owner, bool cancelBorder, FormWindowProp formWindowProp)
        {
            ShowDialog(form, owner, widthReduceDefault, heightReduceDefault, cancelBorder,  formWindowProp, true);
        }

        /// <summary>
        ///  弹窗--随着父窗口设置高宽  高宽在父窗口的基础进行减少
        /// </summary>
        /// <param name="form"></param>
        /// <param name="owner"></param>
        /// <param name="formWindowProp"></param>
        public static void ShowWithPWin(Form form, Form owner, int width, int height, FormWindowProp formWindowProp)
        {
            ShowDialog(form, owner, width, height, false,  formWindowProp, true);
        }



        /// <summary>
        ///  弹窗的公共方法
        /// </summary>
        /// <param name="form">弹窗的窗口</param>
        /// <param name="owner">父窗口 可以为null</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="cancelBorder">是否取消边框</param>
        /// <param name="formWindowProp">其他属性扩展</param>
        /// <param name="resizeByPWin">是否根据父窗口设置【减】宽高</param>
        public static void ShowDialog(Form form, Form owner, int width, int height, bool cancelBorder, FormWindowProp formWindowProp, bool resizeByPWin)
        {
            try
            {
                //是否取消边框
                if (cancelBorder)
                {
                    form.FormBorderStyle = FormBorderStyle.None;
                }
                form.StartPosition = FormStartPosition.CenterParent;
                form.WindowState = FormWindowState.Normal;
                if (owner != null)
                {
                    form.Owner = owner;
                    form.Width = !resizeByPWin ? width : owner.Width - width;
                    form.Height = !resizeByPWin ? height : owner.Height - height;
                }
                else
                {
                    form.Width = width;
                    form.Height = height;
                }

                if (formWindowProp != null)
                {
                    ObjectUtil.CopyPop(formWindowProp, ref form);
                }
                form.ShowDialog();//显示*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }



        /// <summary>
        ///  页面显示 非 弹窗功能
        /// </summary>
        /// <param name="form">窗口</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="formWindowProp">其他属性扩展</param>
        /// <param name="resizeByPWin">是否根据父窗口设置【减】宽高</param>
        public static void Show(Form form, int width, int height, FormWindowProp formWindowProp)
        {
            try
            {               
                form.StartPosition = FormStartPosition.CenterScreen;
                form.WindowState = FormWindowState.Normal;

                if (width > 0)
                {
                    form.Width = width;
                }
                if (height > 0)
                {
                    form.Height = height;
                }

                if (formWindowProp != null)
                {
                    ObjectUtil.CopyPop(formWindowProp, ref form);
                }
                form.ShowDialog();//显示*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        ///   页面显示 非 弹窗功能
        /// </summary>
        /// <param name="form"></param>
        /// <param name="formWindowProp"></param>
        public static void Show(Form form, FormWindowProp formWindowProp)
        {
            Show(form,0,0,formWindowProp);
        }

        /// <summary>
        ///   页面显示 非 弹窗功能
        /// </summary>
        /// <param name="form"></param>
        /// <param name="formWindowProp"></param>
        public static void Show(Form form)
        {
            Show(form, 0, 0, null);
        }


        /// <summary>
        /// 显示tab里面 窗体内容[用于tab切换]
        /// </summary>
        /// <param name="tabPage"></param>
        /// <param name="curForm"></param>
        /// <param name="formWindowProp"></param>
        public static void ShowTabContent(Control tabPage, Form curForm, FormWindowProp formWindowProp,bool handSubForm)
        {
            //
            tabPage.Controls.Clear();//清空右边Panel中的窗体
            curForm.FormBorderStyle = FormBorderStyle.None;//不显示标题栏的关闭最大化按钮
            curForm.TopLevel = false;//设置是子窗体不是顶级窗体

            //自定义窗体样式 ==》可覆盖默认样式
            if (formWindowProp != null){
                ObjectUtil.CopyPop(formWindowProp, ref curForm);
            }
            curForm.WindowState = FormWindowState.Maximized;//窗口最大化
            curForm.Dock = DockStyle.Fill;//内容完全填充
            tabPage.Controls.Add(curForm);//tabControl展示该内容             
            curForm.Show();//显示
            if (handSubForm)
            {
                SetSubFormControls(curForm);
            }
        }


        public static void ShowTabContent(Control tabPage, Form curForm, FormWindowProp formWindowProp)
        {
            ShowTabContent(tabPage, curForm, formWindowProp, false);
        }


        /// <summary>
        ///  设置 子窗口的弹窗为全填充 最大化
        /// </summary>
        /// <param name="control"></param>
        private static void SetSubFormControls(Control control)
        {
            Control.ControlCollection controls = control.Controls;
            if (controls != null)
            {
                for (int i = 0; i < controls.Count; i++)
                {
                    if (controls[i] is Form)
                    {
                        ShowTabContent(control, (Form)controls[i], null);
                    }
                    SetSubFormControls(controls[i]);
                }
            }
        }



    }
}
