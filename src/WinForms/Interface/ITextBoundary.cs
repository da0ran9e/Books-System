﻿using System.Collections.Generic;

namespace WinForms
{
    public delegate void EachVoidCallBack(string strText, int nIndex, int nLen);
    public delegate bool EachBoolCallBack(string strText, int nIndex, int nLen);

    public interface ITextBoundary
    {
        List<string> Split(string strText);
        int GetCount(string strText);
        void Each(string strText, EachVoidCallBack callBack);
        void Each(string strText, int nIndex, EachVoidCallBack callBack);
        void Each(string strText, EachBoolCallBack callBack);
        void Each(string strText, int nIndex, EachBoolCallBack callBack);
    }
}
