<%@ page contentType="text/html;charset=utf-8" %>
<%@ include file="../../../../layout/base_addupdate.jsp" %>
<%@taglib uri="http://java.sun.com/jsp/jstl/functions" prefix="fn" %>
<body class="bodyStyle">
<div class="portlet box green">
    <div class="portlet-body form">
        <!-- BEGIN FORM-->
        <form action="#" class="form-horizontal" id="addOrUpdateForm" enctype="multipart/form-data">
            <input type="hidden" id="id" name="id" value="${className}.id">
            <div class="form-body">
                <h3 class="form-section">${tablecomment}</h3>
                 <#list groups as gp>
                <div class="row">
                       <#list gp as record>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label col-md-3">${record.comment}<span class="required">* </span></label>
                                <div class="col-md-8">
                                    <div class="input-icon check right">
                                        <i class="fa"></i>
                                         <#if record.property =="remark">
                                              <textarea class="form-control" rows="2" name="${record.property}" id="${record.property}"> ${"$"}{entity.${record.property}${"}"}</textarea>
                                         </#if>
										 
                                         <#if record.property !="remark">
                                               <input type="text" id="${record.property}" class="form-control" placeholder="${record.comment}" name="${record.property}" value="${"$"}{entity.${record.property}${"}"}">
                                         </#if>
                                    </div>
                                </div>
                            </div>
                        </div>
                       </#list>
                </div>
                </#list>
                <div class="form-actions">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-offset-5 col-md-7">
                                    <button type="submit" class="btn green btn-square"><i class="fa fa-save"></i> 保存
                                    </button>
                                    <button type="button" class="btn default btn-square"
                                            onclick="dialog.parentclose();"><i
                                            class="fa fa-close"></i> 关闭
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
        <!-- END FORM-->
    </div>
</div>

<script>

</script>
<script>
    $(function(){
           formCheck();
           //initCombobox();
       });

       //下拉框
       function initCombobox() {
           $.kcppcajax(ctx + "/${moduleName}/${classMiniName}/dataDropBox.jiangqiao",//要访问的后台地址
               null,
               function(msg) {
                   $("XX").html("");
                   $("XX").select2("val","");
               }
           );
       }

       function formCheck() {
           $("#addOrUpdateForm").validate({
               rules: {
                <#list records as rec>
                   ${rec.property}:{
                       required:true
                   },
                 </#list>
               },
               submitHandler: function (form) {
                 var queryString =$("#addOrUpdateForm").formSerialize();
                 //doing check code
                 $.kcppcajax(ctx + "/${moduleName}/${classMiniName}/saveOrUpdate.jiangqiao",queryString,
                               function (msg) {//msg为返回的数据，在这里做数据绑定
                               if (msg.success) {
                                   dialog.success(msg.message,
                               function () {
                                   parent.grid.searchPageNotChange();
                                   dialog.parentclose();
                              }
                    );
                  } else {
                        dialog.warn(msg.message);
                    }
                 });
               }
           });
       }

</script>

<!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>