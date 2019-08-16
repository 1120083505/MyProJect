
//金额图片
function monpic() {
    var strDir = "/content/upload"; //文件保存路径  
    var maxFileSize = 1024 * 1024 * 30; //文件最大限制1G
    var b = 0;
    var name;
    $("#Moneypic").uploadify({
        'uploader': '/Scripts/jquery.uploadify-v2.1.4/uploadify.swf',
        'script': '/Scripts/jquery.uploadify-v2.1.4/UploadHandler.ashx', //引用Handler
        'buttonImg': '/Content/images/chooseimg.png', //选择文件按钮
        'cancelImg': '/Scripts/jquery.uploadify-v2.1.4/cancel.gif', //取消上传按钮
        'width': 100, //按钮宽度
        'height': 100, //按钮高度
        'wmode': 'transparent', //使浏览按钮的flash背景文件透明
        'folder': strDir, //上传路径
        'auto': true, //是否自动上传
        'multi': true, //是否多文件上传
        'fileExt': '*.gif;*.jpg;*.jpeg;*.png',
        'fileDesc': '请选择图片',
        'sizeLimit': maxFileSize,
        'simUploadLimit': 6, //同时上传文件数
        'async': false,
        'onSelect': function (e, queueId, fileObj) {
            if (fileObj.size > maxFileSize) {
                alert("你所选择的文件大小超过限制！");
            }
            $("#FileName").val(fileObj.name + ";" + $("#FileName").val());
            $("#FileType").val(fileObj.type + ";" + $("#FileType").val());
            name = fileObj.name;
        }, onAllComplete: function () {
            var ss = document.getElementById("FileUrl").value;
            var str = path1.replace($("#FileUrl").val(), '').split(';');
            for (var i = 0; i < str.length; i++) {
                if (str[i] != "")
                    getQulityImg_1(str[i], i + b, name);
            }
            $("#FileUrl").val(path1 + ss);
        },
        onComplete: function (event, queueID, fileObj, response) {
            var returnjson = "[";
            returnjson += response.substr(0, response.length - 1);
            returnjson += "]";
            var js = $.parseJSON(returnjson);
            path1 += js[0].src + ";";

        }, onSelectOnce: function () {
            if (b == 0) {
                var list = $("#uploadifyQueue").html();
                $("div").detach("#uploadifyQueue");
                $("#list").html("<div id=\"uploadifyQueue\" class=\"uploadifyQueue\">" + list + "</div>");
            }
            b++;
            path1 = "";
        }
    });
}
function getQulityImg_1(m, count, imgname) {
    var str = $("#img").html();
    var img = "<div id='d" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px'>"
        + "<img src=" + m  + " style='width:100px;height:100px' onclick=\"showimg(this.src)\"> \n"
        //+ "<label>" + imgname + "</label>"
        + "<input type=\"button\"   style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        + " onclick=\"deleteDetailImg_1('" + m + "','d" + count + "','" + imgname + "')\"/>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#img").html(str + img);
}
//删除图片
function deleteDetailImg_1(a, c, d) {
    layer.confirm('您确定要删除吗？', {
        btn: ['确定', '取消'] //按钮
    }, function () {
        document.getElementById("" + c).style.display = "none";
        //将图片路径从PublicityImg中取消
        var s = $("#FileUrl").val().replace(a + ";", "");
        $("#FileUrl").val(s);
        var ss = $("#FileName").val().replace(d + ";", "");
        $("#FileName").val(ss);
        //var sss = $("#").val().replace("", "");
        //$("#").val(sss);
        //var memo = document.getElementById("FMemo").value;
        //$("#FMemo").val(a + memo + ";");
        path1 = s;
        $.ajax({
            url: "/Road/Safeguard/DelImg",
            type: "POST",
            data: { url: a },
            success: function () {
                layer.msg('删除成功', {
                    time: 1000,
                });
            }
        });
    });
}
function showimg(src) {
    layer.open({
        type: 1,
        title: false,
        closeBtn: 0,
        area: ['50%', '50%'],
        skin: 'layui-layer-nobg', //没有背景色
        shadeClose: true,
        content: "<img  style=\"width:100%;height:100%\" src=\"" + src + "\"/>"
    });
}


//视频
function Movie() {
    var strDir = "/content/upload"; //文件保存路径  
    var maxFileSize = 1024 * 1024 * 30; //文件最大限制1G
    var b = 0;
    var videoname;
    $("#MovieMoneypic").uploadify({
        'uploader': '/Scripts/jquery.uploadify-v2.1.4/uploadify.swf',
        'script': '/Scripts/jquery.uploadify-v2.1.4/UploadHandler.ashx', //引用Handler
        'buttonImg': '/Content/images/chooseimg.png', //选择文件按钮
        'cancelImg': '/Scripts/jquery.uploadify-v2.1.4/cancel.gif', //取消上传按钮
        'width': 100, //按钮宽度
        'height': 100, //按钮高度
        'wmode': 'transparent', //使浏览按钮的flash背景文件透明
        'folder': strDir, //上传路径
        'auto': true, //是否自动上传
        'multi': true, //是否多文件上传
        'fileExt': '*.mp4;*.avi;*.mkv',
        'fileDesc': '请选择视频',
        'sizeLimit': maxFileSize,
        'simUploadLimit': 1, //同时上传文件数
        'async': false,
        'onSelect': function (e, queueId, fileObj) {
            if (fileObj.size > maxFileSize) {
                alert("你所选择的文件大小超过限制！");
            }
            videoname = fileObj.name;
            $("#MovieFileName").val(fileObj.name + ";" + $("#MovieFileName").val());
            $("#MovieFileType").val(fileObj.type + ";" + $("#MovieFileType").val());
        }, onAllComplete: function () {
            var ss = document.getElementById("MovieFileUrl").value;
            var str = path3.replace($("#MovieFileUrl").val(), '').split(';');
            for (var i = 0; i < str.length; i++) {
                if (str[i] != "")
                    getQulityImg_2(str[i], i + b, videoname);
            }
            $("#MovieFileUrl").val(path3 + ss);
        },
        onComplete: function (event, queueID, fileObj, response) {
            var returnjson = "[";
            returnjson += response.substr(0, response.length - 1);
            returnjson += "]";
            var js = $.parseJSON(returnjson);
            path3 += js[0].src + ";";

        }, onSelectOnce: function () {
            if (b == 0) {
                var list = $("#uploadifyQueue").html();
                $("div").detach("#uploadifyQueue");
                $("#list").html("<div id=\"uploadifyQueue\" class=\"uploadifyQueue\">" + list + "</div>");
            }
            b++;
            path3 = "";
        }
    });
}
function getQulityImg_2(m, count, moviename) {
    var str = $("#Movieimg").html();

    var img = "<div id='dd" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px'>"
        //+ "<img src=" + m + " style='width:80px;height:60px'>"
        + "<a onclick=\"ShowMovie('" + m + "'); \">" + moviename + "</a>"
        + "<input type=\"button\"   style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        + " onclick=\"deleteDetailImg_2('" + m + "','dd" + count + "','" + moviename + "')\"/>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Movieimg").html(str + img);
}
//显示视频
function ShowMovie(src) {
    layer.open({
        type: 2,
        title: false,
        shadeClose: true,
        shade: 0.3,
        maxmin: true, //开启最大化最小化按钮 
        area: ['400px', '300px'],
        content: '/Burst/TrafficAccident/ShowMovie?src=' + src
    });
}
//删除视频
function deleteDetailImg_2(a, c, d) {
    var pic = $("#hidDe" + a).val();
    layer.confirm('您确定要删除吗？', {
        btn: ['确定', '取消'] //按钮
    }, function () {
        document.getElementById("" + c).style.display = "none";
        //将图片路径从PublicityImg中取消
        var s = $("#MovieFileUrl").val().replace(a + ";", "");
        $("#MovieFileUrl").val(s);
        var ss = $("#MovieFileName").val().replace(d + ";", "");
        $("#MovieFileName").val(ss);
        path3 = s;
        $.ajax({
            url: "/Road/Safeguard/DelImg",
            type: "POST",
            data: { url: a },
            success: function () {
                layer.msg('删除成功', {
                    time: 1000,
                });
            }
        });
        //var memo = document.getElementById("FMemo").value;
        //$("#FMemo").val(a + memo + ";");
        layer.msg('删除成功', {
            time: 1000,
        });
    });
}



//音频
function video() {
    var strDir = "/content/upload"; //文件保存路径  
    var maxFileSize = 1024 * 1024 * 30; //文件最大限制1G
    var b = 0;
    var viname;
    $("#ViedoMoneypic").uploadify({
        'uploader': '/Scripts/jquery.uploadify-v2.1.4/uploadify.swf',
        'script': '/Scripts/jquery.uploadify-v2.1.4/UploadHandler.ashx', //引用Handler
        'buttonImg': '/Content/images/chooseimg.png', //选择文件按钮
        'cancelImg': '/Scripts/jquery.uploadify-v2.1.4/cancel.gif', //取消上传按钮
        'width': 100, //按钮宽度
        'height': 100, //按钮高度
        'wmode': 'transparent', //使浏览按钮的flash背景文件透明
        'folder': strDir, //上传路径
        'auto': true, //是否自动上传
        'multi': true, //是否多文件上传
        'fileExt': '*.mp3;*.wma;*.RAW;*WAV;*.AAC',
        'fileDesc': '请选择音频',
        'sizeLimit': maxFileSize,
        'simUploadLimit': 6, //同时上传文件数
        'async': false,
        'onSelect': function (e, queueId, fileObj) {
            if (fileObj.size > maxFileSize) {
                alert("你所选择的文件大小超过限制！");
            }
            $("#ViedoFileName").val(fileObj.name + ";" + $("#ViedoFileName").val());
            $("#ViedoFileType").val(fileObj.type + ";" + $("#ViedoFileType").val());
            viname = fileObj.name;
        }, onAllComplete: function () {
            var ss = document.getElementById("ViedoFileUrl").value;
            var str = path2.replace($("#ViedoFileUrl").val(), '').split(';');
            for (var i = 0; i < str.length; i++) {
                if (str[i] != "")
                    getQulityImg(str[i], i + b, viname);
            }
            $("#ViedoFileUrl").val(path2 + ss);
        },
        onComplete: function (event, queueID, fileObj, response) {
            var returnjson = "[";
            returnjson += response.substr(0, response.length - 1);
            returnjson += "]";
            var js = $.parseJSON(returnjson);
            path2 += js[0].src + ";";

        }, onSelectOnce: function () {
            if (b == 0) {
                var list = $("#uploadifyQueue").html();
                $("div").detach("#uploadifyQueue");
                $("#list").html("<div id=\"uploadifyQueue\" class=\"uploadifyQueue\">" + list + "</div>");
            }
            b++;
            path2 = "";
        }
    });
}
function getQulityImg(m, count, videoname) {
    var str = $("#Viedoimg").html();
    //alert();
    var img = "<div id='ddd" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px;'>"
        //+ "<img src=" + m + " style='width:80px;height:60px'>"
        + "<a onclick=\"ListenMusic('" + m + "'); \">" + videoname + "</a>"
        + "<input type=\"button\"   style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        + " onclick=\"deleteDetailImg('" + m + "','ddd" + count + "','" + videoname + "')\"/>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Viedoimg").html(str + img);
}
//音频
function ListenMusic(src) {
    layer.open({
        type: 2,
        title: false,
        shadeClose: true,
        shade: 0.3,
        maxmin: true, //开启最大化最小化按钮 
        area: ['400px', '300px'],
        content: '/Burst/TrafficAccident/ListenMusic?src=' + src
    });
}
//删除音频
function deleteDetailImg(a, c, d) {
    var pic = $("#hidDe" + a).val();
    layer.confirm('您确定要删除吗？', {
        btn: ['确定', '取消'] //按钮
    }, function () {
        document.getElementById("" + c).style.display = "none";
        //将图片路径从PublicityImg中取消
        var s = $("#ViedoFileUrl").val().replace(a + ";", "");
        $("#ViedoFileUrl").val(s);
        var ss = $("#ViedoFileName").val().replace(d + ";", "");
        $("#ViedoFileName").val(ss);
        path3 = s;
        $.ajax({
            url: "/Road/Safeguard/DelImg",
            type: "POST",
            data: { url: a },
            success: function () {
                layer.msg('删除成功', {
                    time: 1000,
                });
            }
        });
        layer.msg('删除成功', {
            time: 1000,
        });
    });
}


function video3() {
    showvs2();
    var strDir = "/content/upload"; //文件保存路径  
    var maxFileSize = 1024 * 1024 * 30; //文件最大限制1G
    var b = 0;
    var name;
    $("#xingzheng").uploadify({
        'uploader': '/Scripts/jquery.uploadify-v2.1.4/uploadify.swf',
        'script': '/Scripts/jquery.uploadify-v2.1.4/UploadHandler.ashx', //引用Handler
        'buttonImg': '/Content/images/chooseimg.png', //选择文件按钮
        'cancelImg': '/Scripts/jquery.uploadify-v2.1.4/cancel.gif', //取消上传按钮
        'width': 100, //按钮宽度
        'height': 100, //按钮高度
        'wmode': 'transparent', //使浏览按钮的flash背景文件透明
        'folder': strDir, //上传路径
        'auto': true, //是否自动上传
        'multi': true, //是否多文件上传
        'fileExt': '*.gif;*.jpg;*.jpeg;*.png',
        'fileDesc': '请选择图片',
        'sizeLimit': maxFileSize,
        'simUploadLimit': 6, //同时上传文件数
        'async': false,
        'onSelect': function (e, queueId, fileObj) {
            if (fileObj.size > maxFileSize) {
                alert("你所选择的文件大小超过限制！");
            }
            $("#ViedoFileName3").val(fileObj.name + ";" + $("#ViedoFileName3").val());
            $("#ViedoFileType3").val(fileObj.type + ";" + $("#ViedoFileType3").val());
            name = fileObj.name;
        }, onAllComplete: function () {
            var ss = document.getElementById("ViedoFileUrl3").value;
            var str = path1.replace($("#ViedoFileUrl3").val(), '').split(';');
            for (var i = 0; i < str.length; i++) {
                if (str[i] != "")
                    getQulityImg_3(str[i], i + b, name);
            }
            $("#ViedoFileUrl3").val(path1 + ss);
        },
        onComplete: function (event, queueID, fileObj, response) {
            var returnjson = "[";
            returnjson += response.substr(0, response.length - 1);
            returnjson += "]";
            var js = $.parseJSON(returnjson);
            path1 += js[0].src + ";";

        }, onSelectOnce: function () {
            if (b == 0) {
                var list = $("#uploadifyQueue").html();
                $("div").detach("#uploadifyQueue");
                $("#list").html("<div id=\"uploadifyQueue\" class=\"uploadifyQueue\">" + list + "</div>");
            }
            b++;
            path1 = "";
        }
    });
}
function getQulityImg_3(m, count, imgname) {
    var str = $("#Viedoimg3").html();
    var img = "<div id='d" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px'>"
        + "<img src=" + m + " style='width:100px;height:100px' onclick=\"showimg(this.src)\"> \n"
        //+ "<label>" + imgname + "</label>"
        + "<input type=\"button\"   style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        + " onclick=\"deleteDetailImg_3('" + m + "','d" + count + "','" + imgname + "')\"/>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Viedoimg3").html(str + img);
}
//删除图片
function deleteDetailImg_3(a, c, d) {
    layer.confirm('您确定要删除吗？', {
        btn: ['确定', '取消'] //按钮
    }, function () {
        document.getElementById("" + c).style.display = "none";
        //将图片路径从PublicityImg中取消
        var s = $("#ViedoFileUrl3").val().replace(a + ";", "");
        $("#ViedoFileUrl3").val(s);
        var ss = $("#ViedoFileName3").val().replace(d + ";", "");
        $("#ViedoFileName3").val(ss);
        //var sss = $("#").val().replace("", "");
        //$("#").val(sss);
        //var memo = document.getElementById("FMemo").value;
        //$("#FMemo").val(a + memo + ";");
        path1 = s;
        $.ajax({
            url: "/Road/Safeguard/DelImg",
            type: "POST",
            data: { url: a },
            success: function () {
                layer.msg('删除成功', {
                    time: 1000,
                });
            }
        });
    });
}
//显示修改前的内容
function showvs2() {
    var imgurl3 = $("#ViedoFileUrl3").val().split(';');
    var imgname3 = $("#ViedoFileName3").val().split(';');
    for (var i = 0; i < imgurl3.length; i++) {
        if (imgurl3[i] != "")
            getQulityImg_3(imgurl3[i], i, imgname3[i]);
    }
}

