
        //保存接口
        internal static string apisaveList = "${classMiniName?replace('_','')}/saveList";

        //删除
        internal static string apiDelete = "${classMiniName?replace('_','')}/delete";

        //更新
        internal static string apiUpdate = "${classMiniName?replace('_','')}/update";
		
		
		
		
		//批量导入
		R r = WebRequestUtil.RequestByPost(apiSave, record);
        if (!r.Successful){
            MessageBox.Show(r.ResultHint, "提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            return;
        }
		
		
		//删除

