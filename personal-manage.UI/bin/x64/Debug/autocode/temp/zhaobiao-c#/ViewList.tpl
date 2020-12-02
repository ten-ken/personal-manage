<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<title></title>
	<meta http-equiv="X-UA-Compatible" content="IE=edge" />
	<meta content="" name="description" />
	<meta content="" name="author" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
	<title></title>
	<link rel="stylesheet" href="../../../static/plugins/layui/css/layui.css" />
	<link rel="stylesheet" href="../../../static/css/common.css" />
	<link rel="stylesheet" href="../../../static/plugins/iconfont/iconfont.css" />
	<link rel="stylesheet" href="../../../static/plugins/zTree/css/zTreeStyle/zTreeStyle.css" />
	<style type="text/css">
		.search-header label{
			width: 150px;
		}
	</style>
</head>
<body>
<div class="ant-breadcrumb">
	<span><span class="ant-breadcrumb-link">xx管理</span><span class="ant-breadcrumb-separator">/</span></span>
	<span><span class="ant-breadcrumb-link">xxxx管理</span><span class="ant-breadcrumb-separator">/</span></span>
	<span><span class="ant-breadcrumb-link">${tablecomment}</span><span class="ant-breadcrumb-separator">/</span></span>
</div>
<input type='hidden' name="menucode" value='${tablename?upper_case}'/>
<div class="top-search-part search-header" id="filter"></div>
<div class="wz-table-container">
	<table class="layui-hide autoCalcTableHeight" id="dataTable" lay-filter="dataTable"></table>
</div>
<script type="text/html" id="barTable">
	<a href='javascript:;'  class='table_operate' lay-event="detail"><i class='fa fa-table  font-blue' title='详情' ></i>详情</a>
	<a href='javascript:;'  class='table_operate' lay-event="edit"><i class='fa fa-table  font-blue' title='修改' ></i>修改</a>
	<a href='javascript:;'  class='table_operate' lay-event="delete"><i class='fa fa-table  font-blue' title='删除' ></i>删除</a>
</script>
<script type="text/html" id="toolbarTable">
	<button class="layui-btn wz-button wz-btn-blue" lay-event="add"><i class="iconfont icon-xinzeng"></i> 新增 </button>
</script>
<script type="text/javascript" src="../../../static/js/jquery.min.js"></script>
<script type="text/javascript" src="../../../static/js/vue.min.js"></script>
<script type="text/javascript" src="../../../static/plugins/layui/layui.js"></script>
<script type="text/javascript" src="../../../static/js/jy.ajax.js"></script>
<script type="text/javascript" src="../../../static/js/jy.layui.js?v=3"></script>
<script type="text/javascript" src="../../../static/js/jy.layer.js"></script>
<script type="text/javascript" src="../../../static/plugins/dayjs/dayjs.min.js"></script>
<script type="text/javascript" src="../../../static/js/common.js"></script>
<script type="text/javascript" src="../../../conf/config.js"></script>
<script type="text/javascript" src="../../../static/js/lang.js"></script>
<script type="text/javascript" src="../../globalfiltercontext.js"></script>
<script type="text/javascript" src="js/${tablename?lower_case}list.js"></script>
</body>
</html>