//选项卡
$(function(){
	$(".yScrollListTitle table td").click(function  () {
		var index=$(this).index(".yScrollListTitle table td");
		$(this).addClass("yth1click").siblings().removeClass("yth1click");
		$($(".yScrollListInList")[index]).show().siblings().hide();
	})
})