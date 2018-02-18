using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityOne.Models
{


    public class UserMenu
    {

        public int menuId { get; set; }
        public string menuTitle { get; set; }
        public Nullable<int> menuParentId { get; set; }
        public string menuLink { get; set; }
        public bool isActive { get; set; }

        public List<UserMenu> menmenu = new List<UserMenu>();

    }
}