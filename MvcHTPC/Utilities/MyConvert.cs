using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using static MvcHTPC.Models.DbModels.DbStaticEnums;

namespace MvcHTPC.Utilities
{
    public static class MyConvert
    {
        public static HiddenState ToHiddenState(string state)
        {
            HiddenState t_state;
            Enum.TryParse(state, out t_state);
            return t_state;
        }
    }
}