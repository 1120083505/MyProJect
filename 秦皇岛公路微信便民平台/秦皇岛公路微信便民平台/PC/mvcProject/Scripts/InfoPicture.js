
//金额图片
function monpic() {
    Show();
}
function getQulityImg_1(m, count, imgname) {
    var str = $("#img").html();
    var img = "<div id='d" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px'>"
        + "<img src=" + m.replace(";", "") + " style='width:80px;height:60px' onclick=\"showimg(this.src)\"> \n"
        //+ "<label>" + imgname + "</label>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#img").html(str + img);
}
function showimg(src) {
    layer.open({
        type: 1,
        title: false,
        closeBtn: 0,
        area: '516px',
        skin: 'layui-layer-nobg', //没有背景色
        shadeClose: true,
        content: "<img style=\"width:100%;height:100%\" src='" + src + "' />"
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
}
function getQulityImg_2(m, count, moviename) {
    var str = $("#Movieimg").html();

    var img = "<div id='dd" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px'>"
        //+ "<img src=" + m + " style='width:80px;height:60px'>"
        + "<a onclick=\"ShowMovie('" + m.replace(";", "") + "'); \">" + moviename + "</a>"
        //+ "<input type=\"button\"   style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        //+ " onclick=\"deleteDetailImg_2('" + m + "','dd" + count + "','" + moviename + "')\"/>"
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
}
function getQulityImg(m, count, videoname) {
    var str = $("#Viedoimg").html();
    //alert();
    var img = "<div id='ddd" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px;'>"
        //+ "<img src=" + m + " style='width:80px;height:60px'>"
        + "<a onclick=\"ListenMusic('" + m.replace(";", "") + "'); \">" + videoname + "</a>"
        //+ "<input type=\"button\"   style=\"width:12px;height:12px;border:none; background-image:url(/Content/images/close.jpg);\""
        //+ " onclick=\"deleteDetailImg('" + m.replace(";", "") + "','ddd" + count + "','" + videoname + "')\"/>"
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


function Show1() {
    var url = $("#ViedoFileUrl3").val().split(';');
    var name = $("#ViedoFileName3").val().split(';');
    for (var i = 0; i < url.length; i++) {
        if (url[i] != "")
            getQulityImg_1(url[i], i, name[i]);
    }
}








function getQulityImg3(m, count, videoname3) {
    var str = $("#Viedoimg3").html();
    
    var img = "<div id='ddddd" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px;'>"
         //+ "<img src=" + m + " style='width:100px;height:100px'onclick=\"showimg(this.src)\"> \n"
          + "<img src=" + m+ " style='width:80px;height:60px' onclick=\"showimg(this.src)\"> \n"
        
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Viedoimg3").html(str + img);
}
function showimg1(src) {
    
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
//显示修改前的内容
function showvs2() {
    var imgurl3 = $("#ViedoFileUrl3").val().split(';');
    var imgname3 = $("#ViedoFileName3").val().split(';');
    for (var i = 0; i < imgurl3.length; i++) {
        if (imgurl3[i] != "")
            getQulityImg3(imgurl3[i], i, imgname3[i]);
    }
}


function getQulityImg4(m, count, videoname4) {
    var str = $("#Viedoimg4").html();
    var img = "<div id='ddddd" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px;'>"
         //+ "<img src=" + m + " style='width:100px;height:100px'onclick=\"showimg(this.src)\"> \n"
          //+ "<img src=" + m + " style='width:80px;height:60px' onclick=\"showimg(this.src)\"> \n"
           + "<a onclick=\"ListenMusic('" + m.replace(";", "") + "'); \">" + videoname4 + "</a>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Viedoimg4").html(str + img);
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

function getQulityImg5(m, count, moviename) {
    var str = $("#Viedoimg5").html();
    
    var img = "<div id='ddddd" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px;'>"
         //+ "<img src=" + m + " style='width:100px;height:100px'onclick=\"showimg(this.src)\"> \n"
          //+ "<img src=" + m+ " style='width:80px;height:60px' onclick=\"showimg(this.src)\"> \n"
         + "<a onclick=\"ShowMovie('" + m.replace(";", "") + "'); \">" + moviename + "</a>"
        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Viedoimg5").html(str + img);
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



function getQulityfile_1(m, count, imgname) {
    var str = $("#Dimfile").html();
    var img = "<div id='v" + count + "' class='Settlerefund' name='" + m + "' style='float:left;margin-left:5px'>"
        //+ "<img src=" + m + " style='width:100px;height:100px' > \n"
        + "<label onclick=\"downfile('" + m + "')\">" + imgname + "</label>"

        + "<input type=\"hidden\" id=hidDe" + m + " value =\"" + m + "\" />"
        + "</div>";
    $("#Dimfile").html(str + img);
}
//显示修改前的内容
function showfile() {
    var DimFileUrl1 = $("#DimFileUrl1").val().split(';');
    var DimFileName1 = $("#DimFileName1").val().split(';');
    for (var i = 0; i < DimFileUrl1.length; i++) {
        if (DimFileUrl1[i] != "")
            getQulityfile_1(DimFileUrl1[i], i, DimFileName1[i]);
    }
}




function downfile(src) {
    window.open("/App/Version/DownLoadRes?url=" + src);
}
