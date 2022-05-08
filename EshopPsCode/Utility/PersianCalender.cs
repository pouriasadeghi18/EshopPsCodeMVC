using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace EshopPsCode
{
    public static class PersianCalender
    {
       public static string ToShamsi(this DateTime value)
        {
            PersianCalendar persian = new PersianCalendar();

            return persian.GetYear(value)+"/" + persian.GetMonth(value).ToString("00") +"/"+ persian.GetDayOfMonth(value).ToString("00");
        }
    }
}