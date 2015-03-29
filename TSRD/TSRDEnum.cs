using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSRD.Enums
{
    public enum WorkFormType
    {
        維修工單, 維護工單, 安裝工單, 回收工單, 專案工單
    }
    public enum RMAFormStatus
    {
        待送修, 已送修, 待報價, 待匯款, 待返件, 待取件, 已取件
    }
}