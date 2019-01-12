using System;
using MES.Entity;

namespace MES.Core
{
    public class MyEvent : EventArgs
    {
        /// <summary>
        /// 主窗体是否关闭
        /// </summary>
        public bool IsWindowShow { set; get; }

        /// <summary>
        /// 语言：1、中文，2、英文
        /// </summary>
        public int Culture { set; get; }

        /// <summary>
        /// 登录的用户
        /// </summary>
        public User LoginUser { set; get; }

        /// <summary>
        /// 登录结果
        /// </summary>
        public bool LoginResult { set; get; }

        /// <summary>
        /// 检测结果
        /// </summary>
        public object QCResult { set; get; }

        /// <summary>
        /// 人工干预
        /// </summary>
        public string ManualInfo { set; get; }

        /// <summary>
        /// 是否修改最终结果
        /// </summary>
        public bool IfUpdateResult { set; get; }

        /// <summary>
        /// 过程条码
        /// </summary>
        public string BarCode { set; get; }

        /// <summary>
        /// 进度条数值
        /// </summary>
        public int Step { set; get; }

        /// <summary>
        /// 是否隐藏点检中心
        /// </summary>
        public bool HideSpotForm { set; get; }

        /// <summary>
        /// 是否焊接完成
        /// </summary>
        public bool WeldSuccess { set; get; }

    }
}
