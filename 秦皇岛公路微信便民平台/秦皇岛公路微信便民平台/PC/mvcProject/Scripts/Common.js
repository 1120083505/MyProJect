//公用
//Grid自适应窗体变化
$(function () {
    $('#SearchPanel').panel({
        title: '查询条件',
        iconCls: 'icon-search',
        closable: false,
        collapsible: false
    });
    $(window).resize(function () {
        resizeFun();
    });
});
function resizeFun() {
    $('#List').datagrid('resize', {
        width: $(window).width() - 12,
        height: SetGridHeightSub()
    }).datagrid('resize', {
        width: $(window).width() - 12,
        height: SetGridHeightSub()
    });
    $('#SearchPanel').panel('resize', {
        width: $(window).width() - 10
    }).panel('resize', {
        width: $(window).width() - 10
    });
}
//填充下拉框
function FillCombo(urlStr, Ids) {
    $.ajax({
        url: urlStr,
        type: "Post",
        dataType: "json",
        async: false,
        success: function (data) {
            $(Ids).combobox({
                methord: 'post',
                data: data.rows,
                valueField: 'Id',
                textField: 'Name'
            });
        }
    });

}
//省市区联动
function AddressCombox(p, c, a) {
    var id = "";
    FillCombo("/address/province/getItems", p);
    $(p).combobox({
        onSelect: function () {
            id = $(p).combobox("getValue");
            FillCombo("/address/city/getItems/" + id, c);
        }
    });
    $(c).combobox({
        onSelect: function () {
            id = $(c).combobox("getValue");
            FillCombo("/address/area/getItems/" + id, a);
        }
    });

}
//保留2位小数 3.14159 =3.14
function changeTwoDecimal(x) {
    if (x == "Infinity") {
        return;
    }
    var f_x = parseFloat(x);
    if (isNaN(f_x)) {
        return
    } else {
        var f_x = Math.round(x * 100) / 100;
        var s_x = f_x.toString();
        var pos_decimal = s_x.indexOf('.');
        if (pos_decimal < 0) {
            pos_decimal = s_x.length;
            s_x += '.';
        }
        while (s_x.length <= pos_decimal + 2) {
            s_x += '0';
        }
        return s_x;
    }
}
//替换是否图片
function OkOrNo_Img(value) {
    if (value * 1 == 1) { return "<img src='/content/icons/ok.png' />"; }
    else { return "<img src='/content/icons/icon/bullet_cross.png' />"; }
}
//格式化时间
function isDate_yyyyMMdd(str) {
    var reg = /^([0-9]{1,4})(-|\/)([0-9]{1,2})\2([0-9]{1,2})$/;
    var r = str.match(reg);
    if (r == null) return false;
    var d = new Date(r[1], r[3] - 1, r[4]);
    var newstr = d.getFullYear() + r[2] + (d.getMonth() + 1) + r[2] + d.getDate();
    var yyyy = parseInt(r[1], 10);
    var mm = parseInt(r[3], 10);
    var dd = parseInt(r[4], 10);
    var compstr = yyyy + r[2] + mm + r[2] + dd;
    return newstr == compstr;
}
$(document).ready(function () {

    $(".requiredStar").appendTo(".required");
    $("#btnSearch").click(function () {
        if ($("#SearchPanel").is(":hidden")) {
            $("#sp").show();
            $(this).linkbutton({
                text: "隐藏查询条件",
                iconCls: "icon-zoom_out"
            });
        }
        else {
            $("#sp").hide();
            $(this).linkbutton({
                text: "设置查询条件",
                iconCls: "icon-zoom_in"
            });
        }
        resizeFun();
    });
    //print Query
    $("#SearchPanel form").after("<span><a href=\"#\" id=\"BtnQuery\"></a>&nbsp;<a href=\"#\" id=\"BtnClear\"></a></span>");
    //查询框
    $("#SearchPanel span").not("#SearchPanel a span").not("#SearchPanel span span").css("display", "block").css("float", "left").css("padding", "2px").css("margin-left", "5px");
    //-------
    $("#sp").hide().css("margin-bottom", "2px");
    $("#BtnQuery").linkbutton({
        text: "查询",
        iconCls: "icon-search"
    });
    $("#BtnClear").linkbutton({
        text: "清空",
        iconCls: "icon-arrow_refresh"
    });
    $("#BtnClear").click(function () {
        $("#SearchPanel form").form("clear");
        $(':radio[name="searchtype"]').eq(0).attr("checked", true);
    });
    $("#ExportMenu .menu-item").click(function () {
        var url = $(this).attr("url");
        var queryStr = $('#sp form').serialize();
        queryStr = decodeURIComponent(queryStr, true);
        queryStr = escape(queryStr);
        window.open(url + '&queryStr=' + queryStr, '_blank');
    });
    //移除下拉框重复属性（移除代码生成器生成的验证控件所带的验证）
    $("#btnSave").click(function () {
        $(".combo-f").removeClass("easyui-validatebox").removeClass("validatebox-text");
    });
});
