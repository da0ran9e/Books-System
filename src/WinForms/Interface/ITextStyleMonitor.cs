﻿using System.Collections.Generic;

namespace WinForms
{
    public interface ITextStyleMonitor
    {
        void Init(string strText);
        void OnSelectionChanged(TextManager textManager, int nStart, int nLen);
        void OnTextChanged(TextManager textManager, List<TextHistoryRecord> thrs);
        TextStyleRange GetStyleFromCharIndex(int nIndex);
    }
}
