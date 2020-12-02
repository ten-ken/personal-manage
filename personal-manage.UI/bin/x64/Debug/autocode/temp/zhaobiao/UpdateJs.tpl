var initUrl = "/${moduleName}/rest/${classMiniName?replace('_','')}/";
var addUrl = "/${moduleName}/rest/${classMiniName?replace('_','')}/save";
var updateUrl = "/${moduleName}/rest/${classMiniName?replace('_','')}/update";
var addFormData = new Vue({
	el: '#addFormData',
	data: {
		item: {},
		//list:[],
	},
	mounted(){

	},
	methods: {
	}
});
$(function() {
	initSelectList();
	initData();
});
function initSelectList(){
	/** $.jyajax(
        getUrl('/business/rest/cmcdictionarydetails/listByDictionaryId'),
			["ZB001"],
			function(msg) {
				if (msg.successful) {
					addFormData.list = msg.resultValue['ZB001']
				}
				initData()
	}, "post", "json", true); **/
}
function initData() {
	var id = getQueryString("id");
	if (id != null && id != '') {
		$.jyajax(getUrl(initUrl + id), {},
			function(msg) {
				if (msg.successful) {
					addFormData.item = msg.resultValue;
					initForm();
				} else {
					dialog.warn(msg.resultHint);
				}
			}, "get", "json", true);
	} else {
		initForm();
	}
}
function initForm() {
	layui.use(['form', 'layedit', 'laydate'], function() {
		var form = layui.form,
			layer = layui.layer,
			layedit = layui.layedit,
			laydate = layui.laydate;
		form.render("select")
		//监听提交
		form.on('submit(dataSave)', function(data) {
			var url = getUrl(addUrl);
			if (!isEmpty(data.field.id)) {
				url = getUrl(updateUrl);
			}
			var dataMain = data.field;
			dialog.confirm("确定要保存吗？",function(){
				$.jyajax(url,
						dataMain,
						function(msg) {
							if (msg.successful) {
								dialog.success(msg.resultHint,
									function() {
										parent.grid.searchPageNotChange();
										dialog.parentclose();
									}
								);
							} else {
								dialog.warn(msg.resultHint);
							}
						}, "post", "json", true);
			})
			return false;
		});
	});
}