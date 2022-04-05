using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Models
{

    public enum AdminLevelEnum :int
    {
        //管理者
        admin = 0,
        //主管
        manager = 1,
        //員工
        employee = 2
    }
}