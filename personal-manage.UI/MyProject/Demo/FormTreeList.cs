using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_manage.UI.Demo
{
    public partial class FormTreeList : Form
    {
        public FormTreeList()
        {
            InitializeComponent();
        }

        private void FormTreeList_Load(object sender, EventArgs e)
        {
           /* //设置事件
            this.mainTree.AfterSelect += MainTree_AfterSelect;
            //导入
            Image importImg = Properties.Resources.import_32;
            importImg = new Bitmap(importImg, 20, 20);
            this.btnImport.Image = importImg;
            this.btnImport.Click += btnImportProject_Click;

            //设置树的样式
            SetPageStyle();

            LoadData();*/
        }

/*
        private void LoadData()
        {
            try
            {
                this.mainTree.Nodes.Clear();

                List<OsZbPurchaseProjectInfo> lists = GetProjectInfo();

                // 顶级节点
                TreeNode js = new TreeNode();
                js.Tag = "jishu";
                js.Name = "jishu";
                js.Text = "技术文件";
                SetChildNodes(lists, js, 0, 2);

                // 顶级节点
                TreeNode sw = new TreeNode();
                sw.Tag = "shangwu";
                sw.Name = "shangwu";
                sw.Text = "商务文件";
                SetChildNodes(lists, sw, 0, 2);

                // 顶级节点
                TreeNode bzjjn = new TreeNode();
                bzjjn.Tag = "bzjjn";
                bzjjn.Name = "bzjjn";
                bzjjn.Text = "保证金缴纳情况";

                SetChildNodes(lists, bzjjn, 0, 0);

                mainTree.Nodes.AddRange(new TreeNode[] { js, sw, bzjjn });
                //mainTree.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 设置树的样式
        /// </summary>
        private void SetPageStyle()
        {
            //设置树形组件的基础属性
            mainTree.CheckBoxes = false;
            mainTree.FullRowSelect = true;
            mainTree.Indent = 25;
            mainTree.ItemHeight = 30;
            mainTree.LabelEdit = false;
            mainTree.Scrollable = true;
            mainTree.ShowPlusMinus = true;
            mainTree.ShowRootLines = true;
            mainTree.Font = new Font("楷体", 16);
            //
            //mainTree.Width = 360;

            //设置切分器的位置==》即左侧的宽度
            this.splitContainer1.SplitterDistance = pageLeftWidth;
        }


        /// <summary>
        ///  设置节点信息
        /// </summary>
        /// <param name="lists">需要处理的数据源</param>
        /// <param name="parentNode">父节点</param>
        /// <param name="level">当前节点层级</param>
        /// <param name="maxLevel">最大节点层级 初始为0==》【第一节点不计入】</param>
        private void SetChildNodes(List<OsZbPurchaseProjectInfo> lists, TreeNode parentNode, int level, int maxLevel)
        {
            try
            {
                if (level > maxLevel)
                {
                    return;
                }

                TreeNode treeNode = null;

                object tagInfo = parentNode.Tag;
                OsZbPurchaseProjectInfo tagProject = new OsZbPurchaseProjectInfo();

                if (tagInfo is OsZbPurchaseProjectInfo)
                {
                    tagProject = (OsZbPurchaseProjectInfo)tagInfo;
                }

                if (lists.Count > 0)
                {

                    Dictionary<string, string> nodeInfo = new Dictionary<string, string>();
                    //存放二级节点信息
                    List<TreeNode> nextNodes = new List<TreeNode>();

                    string nodeKey = "";
                    string nodeText = "";

                    //自身标记
                    string tag = "";
                    //以父节点信息
                    string pidInfo = "";

                    //选择图标等样式
                    int imageIndex = 0;
                    int selectedImageIndex = 0;

                    foreach (OsZbPurchaseProjectInfo projectInfo in lists)
                    {

                        if (0 == level)//项目
                        {
                            nodeKey = projectInfo.ProjectNo;
                            nodeText = "【" + nodeKey + "】" + projectInfo.ProjectName;
                            imageIndex = 0;
                            selectedImageIndex = 0;
                            pidInfo = "";
                            tag = "";
                        }
                        else if (1 == level)//标
                        {
                            nodeKey = projectInfo.MarkNo;
                            nodeText = "【" + nodeKey + "】" + projectInfo.MarkName;
                            imageIndex = 1;
                            selectedImageIndex = 1;
                            pidInfo = projectInfo.ProjectNo;
                            tag = tagProject.ProjectNo;//标记上级节点是项目 --标 还是啥
                        }
                        else if (2 == level)//包
                        {
                            nodeKey = projectInfo.PackName;
                            //projectInfo.PackNo
                            nodeText = projectInfo.PackName;
                            imageIndex = 2;
                            selectedImageIndex = 2;
                            pidInfo = projectInfo.MarkNo;
                            tag = tagProject.MarkNo;
                        }

                        //下级节点==》是否匹配父节点进行 加入子节点
                        if (!nodeInfo.ContainsKey(nodeKey) && (pidInfo.Equals(tag)))
                        {
                            nodeInfo.Add(nodeKey, "");

                            treeNode = new TreeNode();

                            treeNode.Name = nodeKey;
                            treeNode.Text = nodeText;
                            treeNode.Tag = projectInfo;
                            treeNode.ImageIndex = imageIndex;
                            treeNode.SelectedImageIndex = selectedImageIndex;

                            parentNode.Nodes.Add(treeNode);

                            Console.WriteLine($"父节点:{ parentNode.Name},子节点:{treeNode.Name}");

                            //保留当前节点 作为下一级父节点
                            nextNodes.Add(treeNode);
                        }
                    }
                    //进入下一级节点
                    level++;
                    for (int i = 0; i < nextNodes.Count; i++)
                    {
                        SetChildNodes(lists, nextNodes[i], level, maxLevel);
                    }
                    Console.WriteLine("子节点全部加载完毕");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }



        /// <summary>
        /// 获取已经供应商的项目
        /// </summary>
        /// <returns></returns>
        private List<OsZbPurchaseProjectInfo> GetProjectInfo()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ID,PROJECT_NO,PROJECT_NAME,MARK_NO,MARK_NAME,PACK_NO," +
                "PACK_NAME FROM OS_ZB_PURCHASE_PROJECT_INFO");
            List<OsZbPurchaseProjectInfo> list = SQLiteLibrary.SelectBySql<OsZbPurchaseProjectInfo>(sqliteDbLocation, sqliteDbName, sql.ToString());
            return list;
        }


        private void MainTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView treeView = (TreeView)sender;
            TreeNode selectedNode = treeView.SelectedNode;

            string name = GetTopNode(selectedNode).Name;

            AllNodesStyle(treeView);

            //保证金填写
            if (selectedNode.Level == 1 && "bzjjn".Equals(name))
            {
                selectedNode.BackColor = Color.MediumSpringGreen;
                //selectedNode.Checked = true;

                OsZbPurchaseProjectInfo info = (OsZbPurchaseProjectInfo)selectedNode.Tag;
                FrmBzj frm = new FrmBzj(info);
                frm.WindowState = FormWindowState.Normal;
                frm.Width = this.Width - pageLeftWidth;
                frm.Height = this.Height;
                DialogUtil.ShowTabContent(this.panel3, frm, null);
            }
            //商务文件或
            else if (selectedNode.Level == 3 && ("jishu".Equals(name)
                || "shangwu".Equals(name)))
            {
                selectedNode.BackColor = Color.MediumSpringGreen;
                //selectedNode.Checked = true;

                OsZbPurchaseProjectInfo info = (OsZbPurchaseProjectInfo)selectedNode.Tag;
                FormBstb frm = new FormBstb(info.Id, name);
                frm.WindowState = FormWindowState.Normal;
                frm.Width = this.Width - pageLeftWidth;
                frm.Height = this.Height;
                DialogUtil.ShowTabContent(this.panel3, frm, null);
            }
        }

        /// <summary>
        /// 树的第一层节点
        /// </summary>
        /// <param name="treeView"></param>
        private void AllNodesStyle(TreeView treeView)
        {

            TreeNodeCollection firstNode = treeView.Nodes;
            for (int i = 0; i < firstNode.Count; i++)
            {
                firstNode[i].Checked = false;
                firstNode[i].BackColor = new Color();
                AllNodesStyle(firstNode[i]);
            }


        }

        /// <summary>
        ///  当前节点下的所有字节的
        /// </summary>
        /// <param name="treeNode"></param>
        private void AllNodesStyle(TreeNode treeNode)
        {
            TreeNodeCollection firstNode = treeNode.Nodes;
            for (int i = 0; i < firstNode.Count; i++)
            {
                firstNode[i].Checked = false;
                firstNode[i].BackColor = new Color();
                AllNodesStyle(firstNode[i]);
            }
        }




        /// <summary>
        ///  获取顶级节点
        /// </summary>
        /// <param name="curNode"></param>
        /// <returns></returns>
        private TreeNode GetTopNode(TreeNode curNode)
        {
            TreeNode topNode = curNode.Parent;

            //存在父节点
            if (topNode != null)
            {
                return GetTopNode(topNode);
            }

            return curNode;
        }

        /// <summary>
        /// 没有效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                //演示为绿底白字
                e.Graphics.FillRectangle(Brushes.DarkBlue, e.Node.Bounds);

                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(e.Bounds, 2, 0));
            }
            else
            {
                e.DrawDefault = true;
            }

            if ((e.State & TreeNodeStates.Focused) != 0)
            {
                using (Pen focusPen = new Pen(Color.Black))
                {
                    focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    Rectangle focusBounds = e.Node.Bounds;
                    focusBounds.Size = new Size(focusBounds.Width - 1,
                    focusBounds.Height - 1);
                    e.Graphics.DrawRectangle(focusPen, focusBounds);
                }
            }
        }

 

        private void btnImportProject_Click(object sender, EventArgs e)
        {
            try
            {
                int firstIndex = 2;

                MessageInfo<OsZbPurchaseProjectInfo> messageInfo = ExcelUtil.ReadExcel<OsZbPurchaseProjectInfo>(firstIndex);

                if (messageInfo.ExistError)
                {
                    MessageBox.Show(messageInfo.ErrorInfo,
                               "提示",
                               MessageBoxButtons.OKCancel,
                               MessageBoxIcon.Warning);
                    return;
                }

                // 表中已存在的数据ID集合
                Dictionary<string, string> containDic = new Dictionary<string, string>();
                StringBuilder selectSql = new StringBuilder();
                selectSql.Append("SELECT OS_ZB_PURCHASE_PROJECT_INFO.* FROM OS_ZB_PURCHASE_PROJECT_INFO");

                DataTable dataTable = SQLiteLibrary.selectDataBySql(sqliteDbLocation, sqliteDbName, selectSql.ToString());

                List<OsZbPurchaseProjectInfo> dbLList = DataTableUtils.ToList<OsZbPurchaseProjectInfo>(dataTable);

                foreach (OsZbPurchaseProjectInfo itemInfo in dbLList)
                {
                    if (!containDic.ContainsKey(itemInfo.ProjectNo + "," + itemInfo.MarkNo + "," + itemInfo.PackName))
                    {
                        containDic.Add(itemInfo.ProjectNo + "," + itemInfo.MarkNo + "," + itemInfo.PackName, "");
                    }
                }

                List<OsZbPurchaseProjectInfo> record = messageInfo.Record;

                if (record == null)
                {
                    return;
                }

                StringBuilder errorSbf = new StringBuilder();

                HashSet<string> dbcompare = new HashSet<string>();

                // 表中已存在的数据ID集合
                Dictionary<string, string> excelDic = new Dictionary<string, string>();

                //需要修改的数据
                List<OsZbPurchaseProjectInfo> updateList = new List<OsZbPurchaseProjectInfo>();

                foreach (OsZbPurchaseProjectInfo itemInfo in record)
                {
                    if (itemInfo.BusinessFileWay.Contains("标"))
                    {
                        itemInfo.BusinessFileWay = ConstantVo.KBN_MARK;
                    }
                    else if (itemInfo.BusinessFileWay.Contains("包"))
                    {
                        itemInfo.BusinessFileWay = ConstantVo.KBN_PACK;
                    }


                    if (itemInfo.SkillFileWay.Contains("标"))
                    {
                        itemInfo.SkillFileWay = ConstantVo.KBN_MARK;
                    }
                    else if (itemInfo.SkillFileWay.Contains("包"))
                    {
                        itemInfo.SkillFileWay = ConstantVo.KBN_PACK;
                    }

                    *//* itemInfo.BusinessFileWay = "按包".Equals(itemInfo.BusinessFileWay) ? ConstantVo.KBN_PACK : ConstantVo.KBN_MARK;
                     itemInfo.SkillFileWay = "按包".Equals(itemInfo.SkillFileWay) ? ConstantVo.KBN_PACK : ConstantVo.KBN_MARK;*//*


                    //excel 重复性验证
                    if (!excelDic.ContainsKey(itemInfo.ProjectNo + "," + itemInfo.MarkNo + "," + itemInfo.PackName))
                    {
                        excelDic.Add(itemInfo.ProjectNo + "," + itemInfo.MarkNo + "," + itemInfo.PackName, "");
                    }
                    else
                    {
                        dbcompare.Add("第" + itemInfo.CurExcelIndex + "行,该项目信息在excel中重复\n");
                    }


                    if (containDic.ContainsKey(itemInfo.ProjectNo + "," + itemInfo.MarkNo + "," + itemInfo.PackName))
                    {
                        updateList.Add(itemInfo);
                        //dbcompare.Add("第" + itemInfo.CurExcelIndex + "行,该项目的包数据库中已存在\n");
                    }

                }

                foreach (string str in dbcompare)
                {
                    errorSbf.Append(str);
                    messageInfo.ExistError = true;
                }

                errorSbf.Append(messageInfo.ErrorInfo);
                messageInfo.ErrorInfo = errorSbf.ToString();

                if (messageInfo.ExistError)
                {
                    MessageBox.Show(messageInfo.ErrorInfo,
                                   "提示",
                                   MessageBoxButtons.OKCancel,
                                   MessageBoxIcon.Warning);
                    return;
                }

                record.RemoveAll(it => updateList.Contains(it));//移除集合中匹配项

                if (record.Count > 0)
                {
                    SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, SQLiteSqlUtils.CreateInsertSql(record));
                }

                //修改原数据
                if (updateList.Count > 0)
                {
                    string updateSql = SQLiteSqlUtils.CreateSelectUpdateSql(updateList, new string[] { "businessFileWay", "skillFileWay", "markName" }, new string[] { "projectNo", "markNo", "packName" });
                    SQLiteLibrary.insertData(sqliteDbLocation, sqliteDbName, updateSql);
                }
                MessageBox.Show("导入成功",
                               "提示",
                               MessageBoxButtons.OKCancel,
                               MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入项目文件错误信息：" + ex.Message);
            }

        }*/

    }
}
