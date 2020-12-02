using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using personal_manage.Common.attr;

namespace personal_manage.Models.entity
{
    [TableName("CODE_PROJECT_INFO")]
    public class CodeProjectInfo{

        [PrimaryKey("ID")]
        public int ID { set; get; }

        [Verify(120, "数据库链接", false)]
        [TableField("DB_URL")]
        // #DB_URL=jdbc:mysql://192.168.0.118:3306/zb_zy
        public string DB_URL { set; get; }

        [Verify(30, "数据库账号", false)]
        [TableField("DB_USERL")]
        //= map2020
        public string DB_USERL { set; get; }

        [Verify(30, "数据库密码", false)]
        [TableField("DB_PWD")]
        // DB_PWD=map2020
        public string DB_PWD { set; get; }

        [Verify(40, "项目名称", false)]
        [TableField("PRO_NAME")]
        // # 项目名称
        public string PRO_NAME { set; get; }

        [Verify(15, "版本",Nullable=true)]
        [TableField("VERSION")]
        // 版本
        public string VERSION { set; get; }

        [Verify(120, "头部", false,Nullable=true)]
        [TableField("TITLE")]
        //TITLE =/**************** 版权所有：************************/
        public string TITLE { set; get; }


        [Verify(20, "作者", false, Nullable = false)]
        [TableField("AUTHOR")]
        // 作者
        public string AUTHOR { set; get; }

        [Verify(-1, "项目位置", false, Nullable = false)]
        [TableField("PRO_SITE")]
        //= E:\\zhaobiao-2020\\zhaobiao
        public string PRO_SITE { set; get; }

        [Verify(50, "顶层包名", false, Nullable = false)]
        [TableField("TOP_LEVEL")]
        //顶层包名 = com.jysoft.ess.zbfz
        public string TOP_LEVEL { set; get; }

        [Verify(20, "模块名", false, Nullable = false)]
        [TableField("MODULE_NAME")]
        // 模块名(多层级直接加上  .[子模块名称]  例如：oa、pm等)
        public string MODULE_NAME { set; get; }

        //实体层相对路径
        [Verify(50, "实体层相对路径", false, Nullable = false)]
        [TableField("Entity_FOLEDR")]
        public string Entity_FOLEDR { set; get; }

        // dao层相对路径
        [Verify(50, "dao层相对路径", false, Nullable = false)]
        [TableField("DAO_FOLEDR")]
        public string DAO_FOLEDR { set; get; }

        //dao实现层相对路径
        [Verify(50, "dao实现层相对路径", false, Nullable = false)]
        [TableField("DAO_IMPL_FOLEDR")]
        public string DAO_IMPL_FOLEDR { set; get; }

        //service实现层相对路径
        [Verify(50, "service实现层相对路径", false, Nullable = false)]
        [TableField("SIMPL_FOLDER")]
        public string SIMPL_FOLDER { set; get; }

        //service层相对路径
        [Verify(50, "service层相对路径", false, Nullable = false)]
        [TableField("SINFE_FOLEDR")]
        public string SINFE_FOLEDR { set; get; }

        //控制层相对路径
        [Verify(50, "controller层相对路径", false, Nullable = false)]
        [TableField("CONTROLLER_FOLEDR")]
        public string CONTROLLER_FOLEDR { set; get; }

        [Verify(35, "页面文件前缀", false, Nullable = true)]
        [TableField("VIEW_SUFFIX")]
        //#java文件存放的根路径 相对项目位置的路径 不是绝对路径 #参考 \\src\\main\java\\
        public string VIEW_SUFFIX { set; get; }


        [Verify(150, "java文件存放相对路径", false, Nullable = true)]
        [TableField("JAVAFODER")]
        //#java文件存放的根路径 相对项目位置的路径 不是绝对路径 #参考 \\src\\main\java\\
        public string JAVAFODER { set; get; }

        [Verify(150, "页面视图存放的相对路径", false, Nullable = true)]
        [TableField("VIEWFOLDER")]
        //#页面视图存放的根路径 相对项目位置的路径 不是绝对路径  # 参考 \\src\\main\\webapp\\view\\module\\
        public string VIEWFOLDER { set; get; }

        //#模板文件存放路径
        [Verify(150, "模板文件存放相对路径", false, Nullable = true)]
        [TableField("TEMPLATE_FOLDER")]
        public string TEMPLATE_FOLDER { set; get; }

        //#需要生成的表名称 英文逗号隔开 TABLENAMES = OS_ZB_MATERIAL_LIST
        [Verify(-1, "需要生成的表名称", false, Nullable = false)]
        [TableField("TABLENAMES")]
        public string TABLENAMES { set; get; }


        //java/c#/pythod文件后缀名
        [Verify(15, "java/c#/pythod文件后缀名", false, Nullable = false)]
        [TableField("HD_SUFFIX")]
        public string HD_SUFFIX { set; get; }

    }
}
