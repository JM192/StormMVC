namespace StormMVC.Models
{

    using System.Collections.Generic;
    using System.Web.Mvc;
    using BusinessLogicLayer;

    public class SelectedUserRolesModel 
    {
        public UserBLL User { get; set; }
        public RoleBLL Role { get; set; }

        public SelectedUserRolesModel()
        {
            Values = new[]
            {
                new SelectListItem { Value = "RegularUser", Text="RegularUser" },
                new SelectListItem { Value = "PowerUser", Text="PowerUser"},
                new SelectListItem { Value = "Administrator", Text="Administrator" },
            };
        }
        public string[] SelectedValues { get; set; }
        public void SetSelectedValuesFromUser()
        {
            SelectedValues = Role.Role.Split(',');
            
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
        }
        public IEnumerable<SelectListItem> Values { get; set; }
    }
}