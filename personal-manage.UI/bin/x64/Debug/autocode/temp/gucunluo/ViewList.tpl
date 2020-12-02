<!doctype html>

<%@ page contentType="text/html;charset=utf-8" %>
<%@ include file="../../../../layout/base_list.jsp" %>
<!-- BEGIN BODY -->
<body class="bodyStyle header-bg">
<!--查询条件-->
<div class="row">
    <div class="col-md-12">
        <div class="portlet light">
            <div class="portlet-body form">
                <!--  查询条件 一定要加上id="searchForm"-->
                <div class="form-horizontal" id="searchForm">
                    <div class="form-group">
                        <label class="control-label col-md-1">XXXX</label>
                        <div class="col-md-2">
                            <input class="form-control" id="XXXX" name="XXXX"
                                   placeholder="请输入XX查询"/>
                        </div>
                        <div class="col-md-3">
                            <button class="btn blue m-icon btn-square" id="btnSearch">
                                <i class="fa fa-search"></i> 查询
                            </button>
                            <button class="btn blue m-icon btn-square" id="btnClear">
                                <i class="fa fa-undo"></i> 重置
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!--列表-->
<div class="row">
    <div class="col-md-12">
        <div class="portlet light">
            <div class="portlet-body">
                <table class="layui-hide" id="listTable" lay-filter="listTable"></table>
                <script type="text/html" id="toolbarTable">
                    <div class="layui-btn-container">
                                    <button class="btn green-meadow m-icon btn-square" lay-event="add">
                                        <i class="fa fa-plus"></i> 新增
                                    </button>
                                    <button class="btn red-flamingo m-icon btn-square" lay-event="deletemany">
                                        <i class="fa fa-trash-o"></i> 批量删除
                                    </button>
                    </div>
                </script>
                <script type="text/html" id="barTable">
                        <a href='javascript:;' class='table_operate'>
                            <i class='fa fa-edit font-blue' title='修改' lay-event="edit"></i>
                        </a>
                        <a href='javascript:;' class='table_operate'>
                            <i class='fa fa-trash-o font-red-flamingo' title='删除' lay-event="delete"></i>
                        </a>
                </script>
            </div>
        </div>
    </div>
</div>

<!-- END CORE PLUGINS -->
<script>
    var grid = new LayDataTable();
    $(function () {
        // 初期化按钮事件
        initButton();
        // 初期化table
        initTable();
    });

    function initTable() {
        grid.init({
            elem: '#listTable'
            , url: ctx + "/${moduleName}/${classMiniName}/list.jiangqiao"
            , toolbar: "#toolbarTable"
            , cellMinWidth: 80
            , cols: [[
                {type: 'checkbox', fixed: 'left', unresize: true}
                , {
                    fixed: 'left',
                    title: '操作',
                    width: 160,
                    toolbar: '#barTable',
                    align: "center",
                    sort: false,
                    unresize: true
                }
                <#list records as rec>
                , {field: '${rec.property}', title: '${rec.comment}', sort: false, width: 200}
                </#list>
            ]],
            initSort: {
                field: 'id' //排序字段，对应 cols 设定的各字段名
                , type: 'asc' //排序方式  asc: 升序、desc: 降序、null: 默认排序
            }

        });
        layui.use('table', function () {
            table = layui.table;
            //头工具栏事件
            table.on('toolbar(listTable)', function (obj) {
                var checkStatus = table.checkStatus(obj.config.id);
                switch (obj.event) {
                    case 'add':
                        //新增
                        var url = ctx + "/view/module/erp/pm/procedure/procedure_update.jsp";
                        dialog.show(url, "${tablecomment}添加");
                        break;
                    case 'deletemany':
                        //批量删除
                        var data = checkStatus.data;
                        if (data.length == 0) {
                            dialog.warn("请至少选择一条数据");
                            return;
                        }
                        var ids = [];
                        for (var i = 0; i < data.length; i++) {
                            ids.push(data[i].id);
                        }
                        deleteRow(ids.join(','));
                        break;
                }
            });

            //监听行工具事件
            table.on('tool(listTable)', function (obj) {
                var data = obj.data;
                if (obj.event === 'delete') {
                    deleteRow(data.id)
                } else if (obj.event === 'edit') {
                    edit(data.id)
                }
            });

        });
    }

    //初期化按钮事件
    function initButton() {
        // 查询
        $("#btnSearch").click(function () {
            grid.search();
        });
        // 重置
        $("#btnClear").click(function () {
            grid.reset();
        });
    }

    // 修改
    function edit(id) {
        var url = ctx + "/${moduleName}/${classMiniName}/updateInit.jiangqiao?id=" + id;
        dialog.show(url, "${tablecomment}修改");
    }

    // 删除
    function deleteRow(id) {
        dialog.confirm("确定要删除吗？", function () {
            $.kcppcajax(ctx + "/${moduleName}/${classMiniName}/delete.jiangqiao",
                {id: id},
                function (msg) {//msg为返回的数据，在这里做数据绑定
                    if (msg.success) {
                        dialog.success(msg.message, function () {
                            grid.searchPageNotChange();
                        });
                    } else {
                        dialog.warn(msg.message);
                    }
                });
        });
    }
    
</script>
<!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>