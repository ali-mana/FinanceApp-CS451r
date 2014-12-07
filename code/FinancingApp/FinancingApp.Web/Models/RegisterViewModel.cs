
using FinancingApp.Model.DbFirst;
using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace FinancingApp.Web.Models
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }




        public Customer Customer { get; set; }

        public FinancingApp.Model.DbFirst.Address Address { get; set; }


        [Display(Name = "Phone")]
        public string Phone { get; set; }

     /*   public EnumHelper.UserType SelectedUserType { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem>  UserTypes
        {
            get
            {
                IEnumerable<EnumHelper.UserType> userTypes = Enum.GetValues(typeof(EnumHelper.UserType)).Cast<EnumHelper.UserType>();


                List<System.Web.Mvc.SelectListItem> selectListItems = new List<System.Web.Mvc.SelectListItem>();
                foreach(var item in userTypes)
                {
                    selectListItems.Add(new System.Web.Mvc.SelectListItem() { Text = item.ToString(), Value = ((int)item).ToString() });
                }

                return selectListItems;
            }
        }
        */
        public string Vendor { get; set; }
    }
}