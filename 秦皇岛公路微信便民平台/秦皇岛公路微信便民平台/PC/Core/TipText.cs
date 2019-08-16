using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    /// <summary>
    /// 默认提示辅助类
    /// </summary>
    public class Tip
    {
        static Core.langHelper langhelper = new Core.langHelper();
        /// <summary>
        /// 未选中任何数据，请选择！
        /// </summary>
        public static string NoSelect = "未选中任何数据，请选择！";
        /// <summary>
        /// 添加成功!
        /// </summary>
        public static string InsertSucceed
        {
            get { return langhelper.GetLangString("tip_OperateSucceed"); }
        }
        /// <summary>
        /// 添加失败!
        /// </summary>
        public static string InsertFail
        {
            get { return langhelper.GetLangString("tip_OperateFail"); }
        }
        /// <summary>
        /// 修改成功!
        /// </summary>
        public static string EditSucceed
        {
            get { return langhelper.GetLangString("tip_OperateSucceed"); }
        }
        /// <summary>
        /// 修改失败!
        /// </summary>
        public static string EditFail
        {
            get { return langhelper.GetLangString("tip_OperateFail"); }
        }
        /// <summary>
        /// 删除成功!
        /// </summary>
        public static string DeleteSucceed
        {
            get { return langhelper.GetLangString("tip_OperateSucceed"); }
        }
        /// <summary>
        /// 删除失败!
        /// </summary>
        public static string DeleteFail
        {
            get { return langhelper.GetLangString("tip_OperateFail"); }
        }
        /// <summary>
        /// 最后一项不允许再进行添加子项！
        /// </summary>
        public static string IsLastNotAllowInsertSon = "最后一项不允许再进行添加子项！";
        /// <summary>
        /// 只能选择模块的最后一项！
        /// </summary>
        public static string OnlyLastModuleCan = "只能选择模块的最后一项！";
        /// <summary>
        /// 确定删除本条记录?
        /// </summary>
        public static string WantDeleteTheSelectedRecords = "确定删除本条记录？";
        /// <summary>
        /// 第一步，需要您选择一个角色再进行操作！
        /// </summary>
        public static string PleaseSelectRoleFrist = "第一步，需要您选择一个角色再进行操作！";
        /// <summary>
        /// 未做任何更改！
        /// </summary>
        public static string NoChange = "未做任何更改！";
        /// <summary>
        /// 保存成功!
        /// </summary>
        public static string SaveSucceed = "保存成功！";
        /// <summary>
        /// 保存失败!
        /// </summary>
        public static string SaveFail = "保存失败！";
        /// <summary>
        /// 获取参数失败!
        /// </summary>
        public static string GetParmError = "获取参数失败！";
        /// <summary>
        /// 文件已经存在,请更换!
        /// </summary>
        public static string FileIsExist = "文件已经存在,请更换！";
        /// <summary>
        /// 操作成功！
        /// </summary>
        public static string OperateSucceed
        {
            get { return langhelper.GetLangString("tip_OperateSucceed"); }
        }
        /// <summary>
        /// 操作失败！
        /// </summary>
        public static string OperateFail
        {
            get { return langhelper.GetLangString("tip_OperateFail"); }
        }
        /// <summary>
        /// 确定还原次数据库?还原之后数据将全部被更换！
        /// </summary>
        public static string WantReturnDateBase = "确定还原次数据库?还原之后数据将全部被更换！";

        /// <summary>
        /// 登录失败！
        /// </summary>
        public static string LoginError = "登录失败！用户名或密码错误！";
    }
}
