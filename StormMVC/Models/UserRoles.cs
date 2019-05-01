using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace StormMVC.Models
{
    
    public class SelectedUserRolesModel 
    {
        public UserBLL User { get; set; }
        public RoleBLL Role { get; set; }

        public SelectedUserRolesModel()
        {
            Values = new[]
            {
                new SelectListItem { Value = "Regular User", Text="Regular User" },
                new SelectListItem { Value = "Power User", Text="Power User"},
                new SelectListItem { Value = "Administrator", Text="Administrator" },
            };
        }
        public string[] SelectedValues { get; set; }
        public void SetSelectedValuesFromUser()
        {
            SelectedValues = Role.Role_Type.Split(' ');
            
        }
        public void SetRolesFromSelectedValues()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (string s in SelectedValues)
            {
                sb.Append(s);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            //User.RoleID = sb.ToString();

        }
        public IEnumerable<SelectListItem> Values { get; set; }
    }
}