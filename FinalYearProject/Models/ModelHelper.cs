﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalYearProject.Models
{
    public class ModelHelper
    {
        public static List<SelectListItem> ToSelectItemList(dynamic values)

        {
            List<SelectListItem> templist = null;
            if (values != null)
            {
                templist = new List<SelectListItem>();
                foreach (var v in values)
                {
                    templist.Add(new SelectListItem { Text = v.Name, Value = Convert.ToString(v.Id) });
                }
                templist.TrimExcess();
            }
            return templist;
        }
    }
}