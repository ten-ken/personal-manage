using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.attr;

namespace personal_manage.Models.entity
{
    [TableName("CODE_PROJECT_TEMPLATE_CONFIG_INFO")]
    public class CodeProjectTemplateConfigInfo
    {
        

        [PrimaryKey("ID")]
        public int ID { set; get; }

        [Verify(18, "模板名称", false,Pattern = "^[A-Z][a-zA-Z]{0,15}")]
        [TableField("TEMPLATE_NAME")]
        public string TemplateName { set; get; }

        [Verify(100, "模板路径", false)]
        [TableField("TEMPLATE_PATH")]
        public string TemplatePath { set; get; }


        [Verify(-1, "模板内容", false, Nullable = false)]
        [TableField("TEMPLATE_CONTENT")]
        public string TemplateContent { set; get; }

        [Verify(-1, "叠加名", false, Nullable = true)]
        [TableField("OVERLAY_NAME")]
        public string OverlayName { set; get; }

        [Verify(-1, "后缀名", false, Nullable = false)]
        [TableField("SUFFIX")]
        public string Suffix { set; get; }


        [TableField("PROJECT_ID")]
        public int ProjectId { set; get; }


        [TableField("CREATE_USER")]
        public string CREATE_USER { set; get; }

        [TableField("UPDATE_TIME")]
        public string UPDATE_TIME { set; get; }

        [TableField("UPDATE_USER")]
        public string UPDATE_USER { set; get; }

    }
}
