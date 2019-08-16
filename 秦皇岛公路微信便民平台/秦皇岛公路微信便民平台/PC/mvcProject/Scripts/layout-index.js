
//建立一个下拉选框
function CreateSelect(module, controller, url) {
    myApp.controller(controller, function ($scope, $http) {
        $.ajax({
            url: url,
            type: "POST",
            async: false,
            success: function (d) {
                $scope.data = d.rows;
            }
        });
    });
}
$(document).ready(function () {
    $("#checkOrNoAll").click(function () {
        if (this.checked) {
            $("input[name='checkList']").attr('checked', true);
            //$("tbody tr").addClass("line_checked");
        } else {
            $("input[name='checkList']").attr('checked', false);
            //$("tbody tr").removeClass("line_checked");
        }
    });
    String.format = function () {
        if (arguments.length == 0)
            return null;
        var str = arguments[0];
        for (var i = 1; i < arguments.length; i++) {
            var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
            str = str.replace(re, arguments[i]);
        }
        return str;
    };
    GetCheckedIds = function () {
        var ids = [];
        $('input[name="checkList"]:checked').each(function () {
            ids.push($(this).val());
        });
        return ids;
    }
    $(".close").click(function () {
        window.parent.closeLayer(0);
    });
});
$.extend({
    UserMobileAgent: function () {
        if (!navigator.userAgent.match(/mobile/i)) {
            return false;

        }
        else {
            return true;
        }
    }
});