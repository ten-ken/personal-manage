using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using personal_manage.Common.extendmethods;

namespace personal_manage.Common.util
{
    /// <summary>
    ///  窗体辅助工具  设置值或者封装成实体/list  设置必填样式【红色星号】
    ///  author:swc
    ///  datetime:2020-09-15
    /// </summary>
    public class FormHelp
    {

        /// <summary>
        ///  某个控件下的输入框 、下拉框等封装成实体【实体属性和控件的name要一致】
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mainFormControl"></param>
        public static T GetEntityByControls<T>(Control mainFormControl)
        {
            var controls = mainFormControl.Controls;
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            
            string propName ;

            //控件的值
            string textValue;

            PropertyInfo propertyInfo;
            Type type = typeof(T);

            T entity = Activator.CreateInstance<T>();

            for (int i = 0; i < controls.Count; i++)
            {
                propName = controls[i].Name.UpperCaseFirst();
                textValue = controls[i].Text;
                propertyInfo = type.GetProperty(propName, bindingFlags);

                //时间处理
                if (controls[i] is DateTimePicker)
                {
                    DateTimePicker picker = (DateTimePicker)controls[i];
                    if (picker.Checked)
                    {
                        textValue = picker.Text;
                    }
                    else
                    {
                        textValue = "";
                    }
                }

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(entity, textValue);
                }

            }
            return entity;
        }

        /// <summary>
        ///  控件水平居中显示
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="controls"></param>
        public static void ControlsToXCenter(Control @main, params Control[] controls)
        {
            //Control.ControlCollection controlsChilds;
            for (int i = 0; i < controls.Length; i++)
            {
                int x = (int)(0.5 * (@main.Width - controls[i].Width));
                int y = controls[i].Location.Y;
                controls[i].Location = new Point(x, y);

                //controlsChilds = controls[i].Controls;

               /* //设置内部控件也水平居中
                for (int k = 0; k < controlsChilds.Count; k++)
                {
                    ControlsToXCenter(@main, controlsChilds[k]);
                }*/
               
            }
        }



        /// <summary>
        /// 获取datagridview 的数据 [name与实体的字段名要一致]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridView"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<T> GetListByDataGrid<T>(DataGridView dataGridView)
        {
            List<T> list = new List<T>();
            try
            {
                int rowCount = dataGridView.Rows.Count;

                int columCount = dataGridView.Columns.Count;            
                //BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

                T entity;
                Type type = typeof(T);

                string propName = null, textValue = null;
                PropertyInfo propertyInfo = null;     

                //行
                for (int i = 0; i < rowCount; i++)
                {
                    entity = Activator.CreateInstance<T>();
                    //列
                    for (int k = 0; k < columCount; k++){

                        propName = dataGridView.Columns[k].Name.UpperCaseFirst();
                        textValue = dataGridView.Rows[i].Cells[k].Value != null?dataGridView.Rows[i].Cells[k].ToString():null;
                        propertyInfo = type.GetProperty(propName);//bindingFlags

                        if (propertyInfo != null){
                           propertyInfo.SetValue(entity, textValue);
                        }
                    }

                    list.Add(entity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return list;
        }

        /// <summary>
        /// 给某个区域的控件【通过实体属性值对应】赋值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="mainFormControl"></param>
        public static void SetControlsByEntity<T>(T t, Control mainFormControl)
        {
            //BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            Type type = t.GetType();

            var allControls = mainFormControl.Controls;

            string propName;

            PropertyInfo propertyInfo;

            for (int i = 0; i < allControls.Count; i++)
            {
                if (allControls[i] is TextBox || allControls[i] is DateTimePicker || allControls[i] is ComboBox || allControls[i] is RichTextBox)
                {
                    propName = allControls[i].Name.UpperCaseFirst();
                    propertyInfo = type.GetProperty(propName);

                    if (propertyInfo != null)
                    {
                        object value = propertyInfo.GetValue(t);
                        allControls[i].Text = value != null ? value.ToString() : null;
                    }
                }
            }
        }

        /// <summary>
        ///  设置必填项==》星号样式
        /// </summary>
        /// <param name="mainControl">主区域/主控件 ==》设置的是主控件下的必填项==》最终会生成</param>
        /// <param name="ignoreOrFilter">忽略[true]还是匹配[false] 设置</param>
        /// <param name="offset">偏移量 正数是向右偏移  负数是向左偏移</param>
        /// <param name="anchorCenter">没有锚 位置是相对位置 不随窗口变化而变化</param>
        /// <param name="fiterNames"></param>
        public static void SetRequireLabel(Control mainControl,bool ignoreOrMatch,int offset=-3,bool anchorCenter =true,params string[] fiterNames)
        {
            var controls = mainControl.Controls;

            List<string> fiterList = new List<string>();
            if (fiterNames.Length > 0)
            {
                fiterList = fiterNames.ToList();
            }

            List<Control> controlList = new List<Control>();
            Label label = null;

            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i] is Label )
                {
                    //跳过不需要设置的label
                    if (fiterList.Contains(controls[i].Name) && ignoreOrMatch)//过滤设置
                    {
                        continue;
                    }

                    else if (!fiterList.Contains(controls[i].Name) && !ignoreOrMatch)//匹配设置[匹配不上跳过]
                    {
                        continue;
                    }

                    label = new Label() { ForeColor = Color.Red, Text = "*", Size = new Size(9, 9) };
                    Point locationXy = new Point() { Y = controls[i].Location.Y };
   
                    locationXy.X = controls[i].Location.X + controls[i].Width + offset;
                    label.Location = locationXy;
                    controlList.Add(label);
                }
            }

            if (anchorCenter)
            {
                mainControl.Anchor = AnchorStyles.None;
            }
            mainControl.Controls.AddRange(controlList.ToArray());
        }


    }
}
