$(function () {
    //提示信息
    var lang = {
        "sProcessing": "处理中...",
        "sLengthMenu": "每页显示 _MENU_ 条记录",
        "sZeroRecords": "没有检索到数据",
        "sInfo": "从 _START_ 到 _END_ /共 _TOTAL_ 条数据。",
        "sInfoEmpty": "没有数据",
        "sInfoFiltered": "(由 _MAX_ 条数据中检索)",
        "sInfoPostFix": "",
        "sSearch": "搜索:",
        "sUrl": "",
        "sEmptyTable": "表中数据为空",
        "sLoadingRecords": "载入中...",
        "sInfoThousands": ",",
        "oPaginate": {
            "sFirst": "首页",
            "sPrevious": "上页",
            "sNext": "下页",
            "sLast": "末页",
            "sJump": "跳转"
        },
        "oAria": {
            "sSortAscending": ": 以升序排列此列",
            "sSortDescending": ": 以降序排列此列"
        }
    };

    //初始化表格
    var jobTable = $("#bill_list").dataTable({
        "language": lang,  //提示信息
        autoWidth: false,  //禁用自动调整列宽
        stripeClasses: ["odd", "even"],  //为奇偶行加上样式，兼容不支持CSS伪类的场合
        processing: true,  //隐藏加载提示,自行处理
        serverSide: true,  //启用服务器端分页
        searching: true,  //禁用原生搜索
        "ordering": false,
        orderMulti: false,  //启用多列排序
        order: [],  //取消默认排序查询,否则复选框一列会出现小箭头
        dom: 'lBrtip',//隐藏搜索框
        renderer: "bootstrap",  //渲染样式：Bootstrap和jquery-ui
        pagingType: "simple_numbers",  //分页样式：simple,simple_numbers,full,full_numbers
        columnDefs: [{
            "targets": 'nosort',  //列的样式名
            "orderable": false    //包含上样式名‘nosort’的禁止排序
        }],
        ajax: function (data, callback, settings) {
            //封装请求参数
            var param = {};
            param.limit = data.length;//页面显示记录条数，在页面显示每页显示多少项的时候
            param.start = data.start;//开始的记录序号
            param.page = (data.start / data.length) + 1;//当前页码
            param.draw = data.draw;
            console.log(data);
            //ajax请求数据
            $.ajax({
                type: "GET",
                url: "/ReturnOrder/GetListReturnOrder",
                cache: false,  //禁用缓存
                data: param,  //传入组装的参数
                dataType: "json",
                success: function (result) {
                    console.log(result);
                    //setTimeout仅为测试延迟效果
                    setTimeout(function () {
                        //封装返回数据
                        var returnData = {};
                        returnData.draw = result.draw;//这里直接自行返回了draw计数器,应该由后台返回
                        returnData.recordsTotal = result.recordsTotal;//返回数据全部记录
                        returnData.recordsFiltered = result.recordsTotal;//后台不实现过滤功能，每次查询均视作全部结果
                        returnData.data = result.data;//返回的数据列表
                        console.log(returnData);
                        //调用DataTables提供的callback方法，代表数据已封装完成并传回DataTables进行渲染
                        //此时的数据需确保正确无误，异常判断应在执行此回调前自行处理完毕
                        callback(returnData);
                    }, 200);
                }
            });
        },
        "columns": [

            {
                "data": "billNum",
                "bSortable": false,
                "width": '10%',
            },
            {
                "data": "status",
                "bSortable": false,
                "bSortable": false,
                "width": '10%',
                "render": function (data, type, row) {
                    console.log(data);
                    // status
                    if (data ==20) {
                        return '<small class="label label-success" ><i class="fa fa-clock-o"></i>已审核</small>';
                    } else {
                        return '<small class="label label-default" ><i class="fa fa-clock-o"></i>待审核</small>';
                    }
                }


            },

            {
                "data": "gmtCreate",
                "width": '15%',
                "bSortable": false,
                "render": function (data, type, row) {
                    return data ? moment(new Date(data)).format("YYYY年MM月DD日 HH:mm:ss") : "";
                }
            },
            {
                "data": "gmtModified",
                "bSortable": false,
                "width": '15%',
                "render": function (data, type, row) {
                    return data ? moment(new Date(data)).format("YYYY年MM月DD日 HH:mm:ss") : "";
                }
            },



            {
                "data": "Job_operate",
                "width": '50%',
                "bSortable": false,
                "render": function (data, type, row) {
                    return function () {
                        console.log(row);
                        // status
                        var start_stop = "";
                        if (row.status ==10) {
                            start_stop = '<button class="btn btn-primary Normal job_operate" _type="auditpass" type="button">审核通过 </button>  ';
                        } else {
                            start_stop = '  <button class="btn btn-primary Normal    disabled" _type="auditpass" type="button">审核通过</button> ';
                        }

                        // html
                        tableData['key' + row.id] = row;
                        var html = '<p id="' + row.id + '" >' +
                            start_stop +
                            ' <button class="btn btn-primary Normal job_operate disabled" _type="auditnot" type="button" >不通过</button>  ' +
                            '</p>';
                        return html;
                    };
                }
            }

        ]
    }).api();
    //此处需调用api()方法,否则返回的是JQuery对象而不是DataTables的API对象

    // table data
    var tableData = {};


    //  operate
    $("#bill_list").on('click', '.job_operate', function () {
        var typeName;
        var url;
        var needFresh = false;
    
        var type = $(this).attr("_type");
        if ("auditpass" == type) {
            typeName = "审核通过";
            url = "/ReturnOrder/AuditReturnOrder";
            needFresh = true;
        }  else {
            return;
        }

        var id = $(this).parent('p').attr("id");

        layer.confirm("确定" + typeName + '?', {
            icon: 3,
            title: "系统提示",
            btn: ["确定", "取消"]
        }, function (index) {
            console.log(id);
            $.ajax({
                type: 'POST',
                url: url,
                data: {
                    "id": id
                },
                dataType: "json",
                success: function (data) {
                    //layer.close(index);
                    jobTable.draw(false);
                    layer.msg(data.message, { icon: 1, time: 1500 });
                },
            });
        });
    });

    // add 
    $(".add").click(function () {
        layer.alert("确定模拟新增退货单吗", {
            icon: 3,
            btn: ['确定', '取消'],
            yes: function (j) {

                $.ajax({
                    type: "Post",
                    url: "/ReturnOrder/MockAddReturnOrder",
                    success: function (result) {
                        console.log(result);
                        jobTable.draw(false);
                        layer.msg(result.message, { icon: 1, time: 1500 });
                    }
                });
            }
        });
    });
});