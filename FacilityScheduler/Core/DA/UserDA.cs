using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacilityScheduler.Core.DA
{
    public class UserDA
    {
        private static UserDA instance;

        public static UserDA getInstance()
        {
            if (instance == null)
            {
                instance = new UserDA();
            }
            return instance;
        }
    }
}