var obj = mInterfaceName;
jQuery.extend({
    openCamaraAndPics: function () {
        //调用拍照或者从相册选择
        obj.openCamara();
    },
    toastShort: function (toast) {
        //弹出Toast
        obj.toastShort(toast);
    },
    getLocation: function () {
        //获取经纬度
        return obj.getLocalInfo();
    },
    getVersion: function () {
        // 获取版本号
        return obj.getVersion();
    },
    getSystemCurrentDate: function () {
        // 获取系统时间
        return obj.getSystemCurrentDate();
    },
    getUniqueID: function () {
        // 获取手机机器码
        return obj.getUniqueID();
    },
    targetNewUrl: function (action) {
        // 跳转进入指定界面
        obj.jumpIntoTheSpecifiedInterface(action);
    },
    hasBrowser: function () {
        // 判断手机是否安装有浏览器
        obj.hasBrowser();
    },
    isPhoneNo: function (tel) {
        return obj.isMobileTel(tel);
    }
});
