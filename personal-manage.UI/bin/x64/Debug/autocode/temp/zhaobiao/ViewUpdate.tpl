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
	</head>
	<body class="haveback">
		<div class="addForm">
			<form action="" class="layui-form" id="addFormData">
				<input type="hidden" name="id" id="id" :value="item.id"></input>
				<input type="hidden" name="updateTimeStr" id="updateTimeStr" :value="item.updateTimeStr"></input>
				
				<#list groups as gp>
				<div class="layui-form-item">
				  
				  <#list gp as record>
					<div class="layui-inline">
						<label class="layui-form-label"><span class="required">*</span>${record.comment}：</label>
						<div class="layui-input-inline">
						<#if record.property =="REMARK">
                              <textarea style="width: 300px" placeholder="备注" class="form-control layui-textarea" rows="4" id="remark" name="remark" maxlength="512">{{item.remark}}</textarea>
                         </#if>
										 
                         <#if record.property !="REMARK">
							 <input type="text"   autocomplete="off" id="${record.property}" placeholder="${record.comment}" name="${record.property}" 
							  class="layui-input ken-wz-readonly"  lay-verify="required"   :value="item.${record.property}">
                         </#if>
						
						</div>
					</div>
					
					</#list>
				</div>
				
				</#list>
				
				<!--
					<textarea style="width: 300px" placeholder="备注" class="form-control layui-textarea" rows="4" id="remark" name="remark" maxlength="512">{{item.remark}}</textarea>
					<select class="form-control" name="purchaseType" id="purchaseType"  lay-filter="purchaseType"  lay-verify="selectVerify">
						 <option value="">请选择</option>
						 <option v-for="(i,index) in purchaseTypeList" :key="index" :value="i.dictionaryValue" :selected="item.purchaseType == i.dictionaryValue">{{i.dictionaryDispName}}</option>
					</select>
				-->
				
				<div class="layui-btn-container" style="text-align: center;margin-top: 20px;">
					<button type="submit" class="layui-btn wz-button wz-btn-blue" lay-submit="" lay-filter="dataSave">
						<span class="iconfont icon-baocun"></span>保存
					</button>
					<button type="button" class="layui-btn wz-button wz-btn-grey" onclick="cancelClick()">
						<span class="iconfont icon-quxiao"></span>取消
					</button>
				</div>
				
			</form>
		</div>
		<script type="text/javascript" src="../../../static/js/jquery.min.js"></script>
		<script type="text/javascript" src="../../../static/js/vue.min.js"></script>
		<script type="text/javascript" src="../../../static/plugins/layui/layui.js"></script>
		<script type="text/javascript" src="../../../static/js/jy.ajax.js"></script>
		<script type="text/javascript" src="../../../static/js/jy.layui.js"></script>
		<script type="text/javascript" src="../../../static/js/jy.layer.js"></script>
		<script type="text/javascript" src="../../../static/plugins/dayjs/dayjs.min.js"></script>
		<script type="text/javascript" src="../../../static/js/common.js?v=3"></script>
		<script type="text/javascript" src="../../../conf/config.js"></script>
		<script type="text/javascript" src="../../../static/js/lang.js"></script>
		<script type="text/javascript" src="js/${tablename?lower_case}addupdate.js"></script>

     	<script>

	    </script>
	</body>
</html>

