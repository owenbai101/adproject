using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team4_Ad
{
    public class EmployeeHomeController
    {
        public static List<ItemCategory> ListCategory()
        {
            using (LastADEntities entities = new LastADEntities())
            {
                return entities.ItemCategories.ToList<ItemCategory>();
            }

        }

        public static List<ItemList> ListItemCategory(int catid)
        {
            using (LastADEntities entities = new LastADEntities())
            {
                return entities.ItemLists.Where(p => p.CategoryId == catid).ToList<ItemList>();
            }

        }

        public static List<ItemList> GetAllItemlist()
        {
            using (LastADEntities entities = new LastADEntities())
            {
                return entities.ItemLists.ToList<ItemList>();
            }

        }
        public static List<string> GetItemname()
        {

            List<String> list = new List<string>();
            foreach (ItemList p in GetAllItemlist())
            {
                list.Add(p.Description);
            }
            return list;

        }



    }
}