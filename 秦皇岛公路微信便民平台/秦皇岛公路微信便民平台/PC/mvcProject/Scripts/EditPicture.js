
//金额图片
function monpic() {
    Show();
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
    //var str = $(".monpic").html();
    //alert();    
    
    var str = $("#img").html();
    var img = "<div id='d" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px'>"
        + "<img src=" + m.replace(";","") + " style='width:100px;height:100px' onclick=\"showimg(this.src)\"> \n"
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
//显示修改前的原有图片
function Show()
{
    var url = $("#FileUrl").val().split(';');
    var name = $("#FileName").val().split(';');
    for (var i = 0; i < url.length; i++) {
        if (url[i] != "")
            getQulityImg_1(url[i], i, name[i]);
    }
}





//视频
function Movie() {
    ShowMovies();
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
        + "<a onclick=\"ShowMovie('" + m.replace(";", "") + "'); \">" + moviename + "</a>"
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
//显示修改前的原有视频
function ShowMovies()
{
    var movieurl = $("#MovieFileUrl").val().split(';');
    var moviename = $("#MovieFileName").val().split(';');
    for (var i = 0; i < movieurl.length; i++) {
        if (movieurl[i] != "")
            getQulityImg_2(movieurl[i], i, moviename[i]);
    }
}


//音频
function video() {
    ShowViedo();
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
        + "<a onclick=\"ListenMusic('" + m.replace(";", "") + "'); \">" + videoname + "</a>"
        + "<input type=\"button\"   style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        + " onclick=\"deleteDetailImg('" + m.replace(";", "") + "','ddd" + count + "','" + videoname + "')\"/>"
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
//显示修改前的原有音频
function ShowViedo()
{
    var Viedourl = $("#ViedoFileUrl").val().split(';');
    var Viedoname = $("#ViedoFileName").val().split(';');
    for (var i = 0; i < Viedourl.length; i++) {
        if (Viedourl[i] != "")
            getQulityImg(Viedourl[i], i, Viedoname[i]);
    }
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
            var str = path4.replace($("#ViedoFileUrl3").val(), '').split(';');
            for (var i = 0; i < str.length; i++) {
                if (str[i] != "")
                    getQulityImg_3(str[i], i + b, name);
            }
            $("#ViedoFileUrl3").val(path4 + ss);
        },
        onComplete: function (event, queueID, fileObj, response) {
            var returnjson = "[";
            returnjson += response.substr(0, response.length - 1);
            returnjson += "]";
            var js = $.parseJSON(returnjson);
            path4 += js[0].src + ";";

        }, onSelectOnce: function () {
            if (b == 0) {
                var list = $("#uploadifyQueue").html();
                $("div").detach("#uploadifyQueue");
                $("#list").html("<div id=\"uploadifyQueue\" class=\"uploadifyQueue\">" + list + "</div>");
            }
            b++;
            path4 = "";
        }
    });
}
function getQulityImg_3(m, count, imgname) {
    var str = $("#Viedoimg3").html();
    var img = "<div id='d" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px'>"
        + "<img src=" + m + " style='width:100px;height:100px' onclick=\"showimg(this.src)\"> \n"       
        + "<input type=\"button\"   style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        + " onclick=\"deleteDetailImg_3('" + m + "','d" + count + "','" + imgname + "')\"/>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Viedoimg3").html(str + img);
}
//删除图片
function deleteDetailImg_3(a, c, d) {
    alert(a);
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
        path4 = s;
        alert(1);
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


function video4() {
    showvs3();
    var strDir = "/content/upload"; //文件保存路径  
    var maxFileSize = 1024 * 1024 * 30; //文件最大限制1G
    var b = 0;
    var viname;

    $("#jindongkou").uploadify({
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
        'fileExt': '*.wav;*.flac;*.ape;*.wma;*.aac;*.ogg;*.mp3',
        'fileDesc': '请选择文件',
        'sizeLimit': maxFileSize,
        'simUploadLimit': 6, //同时上传文件数
        'async': false,
        'onSelect': function (e, queueId, fileObj) {
            if (fileObj.size > maxFileSize) {
                alert("你所选择的文件大小超过限制！");
            }
            $("#ViedoFileName4").val(fileObj.name + ";" + $("#ViedoFileName4").val());
            $("#ViedoFileType4").val(fileObj.type + ";" + $("#ViedoFileType4").val());
            viname = fileObj.name;
        }, onAllComplete: function () {
            var ss = document.getElementById("ViedoFileUrl4").value;
            var str = path5.replace($("#ViedoFileUrl4").val(), '').split(';');
            for (var i = 0; i < str.length; i++) {
                if (str[i] != "")
                    getQulityImg4(str[i], i + b, viname);
            }
            $("#ViedoFileUrl4").val(path5 + ss);
        },
        onComplete: function (event, queueID, fileObj, response) {
            var returnjson = "[";
            returnjson += response.substr(0, response.length - 1);
            returnjson += "]";
            var js = $.parseJSON(returnjson);
            path5 += js[0].src + ";";

        }, onSelectOnce: function () {
            if (b == 0) {
                var list = $("#uploadifyQueue").html();
                $("div").detach("#uploadifyQueue");
                $("#list").html("<div id=\"uploadifyQueue\" class=\"uploadifyQueue\">" + list + "</div>");
            }
            b++;
            path5 = "";
        }
    });
}
function getQulityImg4(m, count, videoname) {
    var str = $("#Viedoimg4").html();
    //alert();
    var img = "<div id='ddddd" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px;'>"      
        //+ "<label onclick=\"showimg('" + m + "')\">" + videoname + "</label>"
       + "<a onclick=\"ListenMusic('" + m+ "'); \">" + videoname + "</a>"
        + "<input type=\"button\"   style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        + " onclick=\"deleteDetailImg4('" + m + "','ddddd" + count + "','" + videoname + "')\"/>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Viedoimg4").html(str + img);
}
//删除音频
function deleteDetailImg4(a, c, d) {
    var pic = $("#hidDe" + a).val();
    layer.confirm('您确定要删除吗？', {
        btn: ['确定', '取消'] //按钮
    }, function () {
        document.getElementById("" + c).style.display = "none";
        //将图片路径从PublicityImg中取消
        var s = $("#ViedoFileUrl4").val().replace(a + ";", "");
        $("#ViedoFileUrl4").val(s);
        var ss = $("#ViedoFileName4").val().replace(d + ";", "");
        $("#ViedoFileName4").val(ss);
        path5 = s;
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
//显示修改前的内容
function showvs3() {
    var imgurl4 = $("#ViedoFileUrl4").val().split(';');
    var imgname4 = $("#ViedoFileName4").val().split(';');
    for (var i = 0; i < imgurl4.length; i++) {
        if (imgurl4[i] != "")
            getQulityImg4(imgurl4[i], i, imgname4[i]);
    }
}






function video5() {

    showvs4();
    var strDir = "/content/upload"; //文件保存路径  
    var maxFileSize = 1024 * 1024 * 30; //文件最大限制1G
    var b = 0;
    var viname;
    $("#chudongkou").uploadify({
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
        'fileExt': '*.mp4;*.rmvb;*.mkv',
        'fileDesc': '请选择文件',
        'sizeLimit': maxFileSize,
        'simUploadLimit': 6, //同时上传文件数
        'async': false,
        'onSelect': function (e, queueId, fileObj) {
            if (fileObj.size > maxFileSize) {
                alert("你所选择的文件大小超过限制！");
            }
            $("#ViedoFileName5").val(fileObj.name + ";" + $("#ViedoFileName5").val());
            $("#ViedoFileType5").val(fileObj.type + ";" + $("#ViedoFileType5").val());
            viname = fileObj.name;
        }, onAllComplete: function () {
            var ss = document.getElementById("ViedoFileUrl5").value;
            var str = path6.replace($("#ViedoFileUrl5").val(), '').split(';');
            for (var i = 0; i < str.length; i++) {
                if (str[i] != "")
                    getQulityImg5(str[i], i + b, viname);
            }
            $("#ViedoFileUrl5").val(path6 + ss);
        },
        onComplete: function (event, queueID, fileObj, response) {
            var returnjson = "[";
            returnjson += response.substr(0, response.length - 1);
            returnjson += "]";
            var js = $.parseJSON(returnjson);
            path6 += js[0].src + ";";

        }, onSelectOnce: function () {
            if (b == 0) {
                var list = $("#uploadifyQueue").html();
                $("div").detach("#uploadifyQueue");
                $("#list").html("<div id=\"uploadifyQueue\" class=\"uploadifyQueue\">" + list + "</div>");
            }
            b++;
            path6 = "";
        }
    });
}
function getQulityImg5(m, count, moviename) {
    var str = $("#Viedoimg5").html();
    var img = "<div id='dddddd" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px;'>"    
        + "<a onclick=\"ShowMovie('" + m+ "'); \">" + moviename + "</a>"
        + "<input type=\"button\"   style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        + " onclick=\"deleteDetailImg5('" + m + "','dddddd" + count + "','" + moviename + "')\"/>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Viedoimg5").html(str + img);

}
//删除音频
function deleteDetailImg5(a, c, d) {
    var pic = $("#hidDe" + a).val();
    layer.confirm('您确定要删除吗？', {
        btn: ['确定', '取消'] //按钮
    }, function () {
        document.getElementById("" + c).style.display = "none";
        //将图片路径从PublicityImg中取消
        var s = $("#ViedoFileUrl5").val().replace(a + ";", "");
        $("#ViedoFileUrl5").val(s);
        var ss = $("#ViedoFileName5").val().replace(d + ";", "");
        $("#ViedoFileName5").val(ss);
        path6 = s;
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
//显示修改前的内容
function showvs4() {
    var imgurl5 = $("#ViedoFileUrl5").val().split(';');
    var imgname5 = $("#ViedoFileName5").val().split(';');
    for (var i = 0; i < imgurl5.length; i++) {
        if (imgurl5[i] != "")
            getQulityImg5(imgurl5[i], i, imgname5[i]);
    }
}


function Dimmonpic1() {
    Show8();
    var strDir = "/content/upload"; //文件保存路径  
    var maxFileSize = 1024 * 1024 * 30; //文件最大限制1G
    var b = 0;
    var name;
    $("#DimfileMoneypic").uploadify({
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
        'fileExt': '*.*',
        'fileDesc': '请选择图片',
        'sizeLimit': maxFileSize,
        'simUploadLimit': 6, //同时上传文件数
        'async': false,
        'onSelect': function (e, queueId, fileObj) {
            if (fileObj.size > maxFileSize) {
                alert("你所选择的文件大小超过限制！");
            }
            $("#DimFileName1").val(fileObj.name + ";" + $("#DimFileName1").val());
            $("#DimFileType1").val(fileObj.type + ";" + $("#DimFileType1").val());
            name = fileObj.name;
        }, onAllComplete: function () {
            var ss = document.getElementById("DimFileUrl1").value;
            var str = path1.replace($("#DimFileUrl1").val(), '').split(';');
            for (var i = 0; i < str.length; i++) {
                if (str[i] != "")
                    DimgetQulityImg_5(str[i], i + b, name);
            }
            $("#DimFileUrl1").val(path1 + ss);
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
function DimgetQulityImg_5(m, count, imgname) {
    //var str = $(".monpic").html();
    //alert();    
    var str = $("#Dimfile").html();
    //if (str == "") {
    //    return;
    //}
    var img = "<div id='d" + count + ",' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px'>"
        //+ "<img src=" + m + " style='width:100px;height:100px' onclick=\"Dimshowimg(this.src)\"> \n"
        + "<a onclick=\"Dimshowimg('" + m + "'); \">" + imgname + "</a>"
        + "<input type=\"button\" style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        + " onclick=\"DimdeleteDetailImg_5('" + m + "','d" + count + ",','" + imgname + "')\"/>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Dimfile").html(str + img);
}
//删除图片
function DimdeleteDetailImg_5(a, c, d) {
    layer.confirm('您确定要删除吗？', {
        btn: ['确定', '取消'] //按钮
    }, function () {
        document.getElementById("" + c).style.display = "none";
        //将图片路径从PublicityImg中取消
        var s = $("#DimFileUrl1").val().replace(a + ";", "");
        $("#DimFileUrl1").val(s);
        var ss = $("#DimFileName1").val().replace(d + ";", "");
        $("#DimFileName1").val(ss);
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
function Dimshowimg(src) {
    window.open("/App/Version/DownLoadRes?url=" + src);
}
function Show8() {
    var url = $("#DimFileUrl1").val().split(';');
    var name = $("#DimFileName1").val().split(';');
    for (var i = 0; i < url.length; i++) {
        if (url[i] != "")
            DimgetQulityImg_5(url[i], i, name[i]);
    }
}