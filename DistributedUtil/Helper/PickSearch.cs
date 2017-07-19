using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DistributedUtil.Helper
{
    public class PickSearch
    {
        public static string[] PickHopeArea(string hopeArea)
        {
            string[] hopeAreaList = hopeArea.Split(new char[] { ',' }, 5);
            if (hopeAreaList.Length == 0)
                return new string[2] { null, null };

            string province = string.Empty, city = string.Empty;

            foreach (string area in hopeAreaList)
            {
                if (area.Length >= 4)
                    province += area.Substring(0, area.Length - 3) + ",";
                else
                    city += area + ",";
            }

            if (!string.IsNullOrEmpty(province))
                province = province.Remove(province.Length - 1, 1);
            if (!string.IsNullOrEmpty(city))
                city = city.Remove(city.Length - 1, 1);

            string[] pickArea = new string[2] { province, city };
            return pickArea;
        }

        public static string[] PickHopeWork(string hopeWork)
        {
            string[] hopeWorkList = hopeWork.Split(new char[] { ',' }, 5, StringSplitOptions.RemoveEmptyEntries);
            if (hopeWorkList.Length == 0)
                return new string[2] { null, null };

            string worktype = string.Empty, job = string.Empty;

            foreach (string work in hopeWorkList)
            {
                if (Convert.ToInt32(work) <= 30)
                    worktype += work + ",";
                else
                    job += work + ",";
            }

            if (!string.IsNullOrEmpty(worktype))
                worktype = worktype.Remove(worktype.Length - 1, 1);
            if (!string.IsNullOrEmpty(job))
                job = job.Remove(job.Length - 1, 1);

            string[] pickWork = new string[2] { worktype, job };
            return pickWork;
        }
    }
}
