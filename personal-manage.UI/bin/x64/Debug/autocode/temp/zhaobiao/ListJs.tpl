// 新增修改
var toAddUpdateUrl = getWebURL("/pages/${moduleName}/${classMiniName?replace('_','')}/${classMiniName?replace('_','')}addupdate.html");
// 详情
var toDetailUrl = getWebURL("/pages/${moduleName}/${classMiniName?replace('_','')}/${classMiniName?replace('_','')}detail.html");
// 删除
var delUrl = "/${moduleName}/rest/${classMiniName?replace('_','')}/delete";
// 查询URL
var searchUrl = "/${moduleName}/rest/${classMiniName?replace('_','')}/listPage";
// 导出URL
var exportUrl = "/${moduleName}/rest/${classMiniName?replace('_','')}/exportPageData"
var ifameName;
var grid = new LayDataTable();
var indexLayer;
$(function() {
	$("#filter").append(loadfilter($("input[name='menucode']").val()))
    autoCalcHeight();
	// 初期化按钮事件
	initButton();
	// 初期化table
	initTable();
});

//初期化按钮事件
function initButton() {
	layui.use('form', function () {
        var $ = layui.jquery,
            form = layui.form;
        // 查询
        $("#search").click(function () {
            grid.search();
        });
        // 查询
        $("#clear").click(function () {
            grid.reset();
        });
    })
}
$(window).resize(function() {
	resizeLayer(indexLayer);
});
// table初始化
function initTable() {
	grid.init({
		elem: '#dataTable',
		url: getUrl(searchUrl),
		toolbar: "#toolbarTable",
		cellMinWidth: 80,
		cols: [
			[{
					fixed: 'left',
					title: '操作',
					width: 150,
					toolbar: '#barTable',
					align: "center",
					sort: false,
					unresize: true
				},
				{
					title: "序号",
					width: 80,
					type:"numbers",
					fixed: 'left'
				},
				<#list records as rec>
                , {field: '${rec.property}', title: '${rec.comment}',align:'center', sort: false, width: 200}
                </#list>
			]
		],
	});

	layui.use('table', function() {
		table = layui.table;
		//头工具栏事件
		table.on('toolbar(dataTable)', function(obj) {
			var checkStatus = table.checkStatus(obj.config.id);
			switch (obj.event) {
			case 'add':
	            dialog.show(toAddUpdateUrl, " ${tablecomment}管理新增");
	            break;
			case 'exports':
                grid.exportExcel(getUrl(exportUrl));
                break;
			}

		});


		//监听行工具事件
		table.on('tool(dataTable)', function(obj) {
			var data = obj.data;
			if (obj.event === 'edit') {
				edit(data.id)
			} else if (obj.event === 'detail') {
				detail(data.id)
			} else if (obj.event === 'delete') {
				deleteData(data.id,data.updateTimeStr)
			} else if (obj.event === 'exportExcel') {
				exportExcel(data.id,data.forcastYear)
			}
		});
	});
}

function exportExcel(){
	window.location.href = getUrl(exportExcelUrl) + "&id=" + id + "&forcastYear=" + forcastYear;
}


layui.use('element', function() {
	var $ = layui.jquery,
		element = layui.element; //Tab的切换功能，切换事件监听等，需要依赖element模块
	element.on('tab(headTab)', function() {
		$("#tabIndex").val(this.getAttribute('data-index'));
		grid.search();
	});
});
// 更新
function edit(id) {
	var url = toAddUpdateUrl + "?id=" + id + "&rnd=" + new Date().getTime();
	indexLayer = dialog.show(url, " ${tablecomment}管理修改");
}
// 详情
function detail(id) {
	var url = toDetailUrl + "?id=" + id + "&rnd=" + new Date().getTime();
	indexLayer = dialog.show(url, " ${tablecomment}管理详情");
}
//删除
function deleteData(id,updateTimes) {
	dialog.confirm("确定要删除吗？", function() {
		$.jyajax(getUrl(delUrl),
				{ids:id,updateTimes:updateTimes},
				function(msg) {
					if (msg.successful) {
						dialog.success(msg.resultHint,
							function() {
								grid.search();
								//refreshParentData();
								dialog.parentclose();
							}
						);
					} else {
						dialog.warn(msg.resultHint);
					}
				}, "post", "json", false);
	});
}
