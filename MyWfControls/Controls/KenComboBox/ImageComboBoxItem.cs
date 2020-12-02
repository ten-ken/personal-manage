using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWfControls.Controls.KenComboBox
{
    public class ImageComboBoxItem
    {
        private string _text;
        /// <summary>
        /// 文本属性
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private string _value;
        /// <summary>
        /// 选择项的值
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private int _imageIndex;
        /// <summary>
        /// 定义图象索引属性
        /// </summary>
        public int ImageIndex
        {
            get { return _imageIndex; }
            set { _imageIndex = value; }
        }

        #region 构造函数
        public ImageComboBoxItem()
        {
            _text = "";
            _imageIndex = -1;
        }
        public ImageComboBoxItem(string text)
        {
            _text = text;
            _imageIndex = -1;
        }
        public ImageComboBoxItem(string text, int imageIndex)
        {
            _text = text;
            _imageIndex = imageIndex;
        }
        public ImageComboBoxItem(string text, int imageIndex, string value)
        {
            _text = text;
            _imageIndex = imageIndex;
            _value = value;
        }
        #endregion
        public override string ToString()
        {
            return _text;
        }
    }
}
