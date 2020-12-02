using System.Windows.Forms;

namespace personal_manage.Common.vo
{
    /// <summary>
    ///  datagridview 行上传附件的属性
    /// </summary>
   
    public class GridViewUploadProp
    {
        public DataGridView ListDataGriddView { get; set; }

        public string CurrentRelatedPage { get; set; }

        public string AttachType { get; set; }

        public string Filter { get; set; }

        public string SelectDataId { get; set; }

        public string RelatedKey { get; set; }

        public int ColumnIndex { get; set; }

        public string TableName { get; set; }

        public GridViewUploadProp(ref DataGridView listDataGriddView, string currentRelatedPage, string attachType, string filter, string selectDataId, string relatedKey, int columnIndex, string tableName)
        {
            ListDataGriddView = listDataGriddView;
            CurrentRelatedPage = currentRelatedPage;
            AttachType = attachType;
            Filter = filter;
            SelectDataId = selectDataId;
            RelatedKey = relatedKey;
            ColumnIndex = columnIndex;
            TableName = tableName;
        }

        public GridViewUploadProp()
        {
        }

    }
}
