$(function () {
    $('#tab_menu-tabrefresh').click(function () {
        /*重新设置该标签 */
        var url = $(".tabs-panels .panel").eq($('.tabs-selected').index()).find("iframe").attr("src");
        $(".tabs-panels .panel").eq($('.tabs-selected').index()).find("iframe").attr("src", url);
    });
    //在新窗口打开该标签
    $('#tab_menu-openFrame').click(function () {
        var url = $(".tabs-panels .panel").eq($('.tabs-selected').index()).find("iframe").attr("src");
        window.open(url);
    });
    //关闭当前
    $('#tab_menu-tabclose').click(function () {
        var currtab_title = $('.tabs-selected .tabs-inner span').text();
        if (currtab_title != '首页') {
            $('#mainframe').tabs('close', currtab_title);
        }
        if ($(".tabs li").length == 0) {
            //open menu
            $(".layout-button-right").trigger("click");
        }
    });
    //全部关闭
    $('#tab_menu-tabcloseall').click(function () {
        $(".tabs li").each(function (index, obj) {
            //获取所有可关闭的选项卡
            var tab = $(".tabs-closable", this).text();
            $(".easyui-tabs").tabs('close', tab);
        });
        //open menu
        $(".layout-button-right").trigger("click");
    });
    //关闭除当前之外的TAB
    $('#tab_menu-tabcloseother').click(function () {
        var currtab_title = $('.tabs-selected .tabs-inner span').text();
        $(".tabs li").each(function (index, obj) {
            //获取所有可关闭的选项卡
            var tab = $(".tabs-closable", this).text();
            if (tab != currtab_title) {
                $(".easyui-tabs").tabs('close', tab);
            }
        });
    });
    //关闭当前右侧的TAB
    $('#tab_menu-tabcloseright').click(function () {
        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            $.messager.alert('提示', '前面没有了!', 'warning');
            return false;
        }
        nextall.each(function (i, n) {
            if ($('a.tabs-close', $(n)).length > 0) {
                var t = $('a:eq(0) span', $(n)).text();
                $('#mainframe').tabs('close', t);
            }
        });
        return false;
    });
    //关闭当前左侧的TAB
    $('#tab_menu-tabcloseleft').click(function () {

        var prevall = $('.tabs-selected').prevAll();
        if (prevall.length == 0) {
            $.messager.alert('提示', '后面没有了!', 'warning');
            return false;
        }
        prevall.each(function (i, n) {
            if ($('a.tabs-close', $(n)).length > 0) {
                var t = $('a:eq(0) span', $(n)).text();
                $('#mainframe').tabs('close', t);
            }
        });
        return false;
    });

});
$(function () {
    /*为选项卡绑定右键*/
    $(".tabs li").live('contextmenu', function (e) {
        /*选中当前触发事件的选项卡 */
        var subtitle = $(this).text();

        $('#mainframe').tabs('select', subtitle);
        //显示快捷菜单
        $('#tab_menu').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var item = $('#tab_menu').menu('findItem', '关闭');
        if (subtitle == "首页") {
            $('#tab_menu').menu('disableItem', item.target);
        } else {
            $('#tab_menu').menu('enableItem', item.target);
        }
        return false;
    });
    //样式
    $("#btnTheme").click(function (e) {
        $('#Themes').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
    });
    //提交
    $(".theme").click(function () {
        var themename=$(this).attr("value");
        $.ajax({
            url: "/home/SetTheme",
            data: { themename: themename },
            type:"POST",
            success: function (data) {
                if (data.Status == 1) {
                    window.location.reload();
                }
            }
        });
    });
});

function frameReturnByClose() {
    $("#modalwindow").window('close');
}
function frameReturnByMes(mes) {
    $.messageBox5s('提示', mes);
}