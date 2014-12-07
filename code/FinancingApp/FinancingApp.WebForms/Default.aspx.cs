using FinancingApp.DataAcess.DBFirst;
using FinancingApp.Model.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinancingApp.WebForms
{
    public partial class _Default : Page
    {
        VendorRepository vendorRepository = null;

     
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Button1.Text = "New Button";

            string hiddenvalue = HttpContext.Current.Application["ApplicationVersion"].ToString();
            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer() { FirstName = "Nivedh", LastName = "Rao" });
            //customers.Add(new Customer() { FirstName = "Tej", LastName = "Tej2" });
            //customers.Add(new Customer() { FirstName = "Adhithya", LastName = "Adhi" });
            //customers.Add(new Customer() { FirstName = "Jaswanth", LastName = "Jash" });

            //this.GridView1.DataSource = customers;

            //this.GridView1.DataBind();
            //HttpApplicationState state = new HttpApplicationState();

            //string versioon = state["ApplicationVersion"];

            if (Session["MyData"] != null)
            {
                var apps = Session["MyData"] as List<Application>;
                apps.Add(new Application() { ApplicationId = 1, CreatedDate = System.DateTime.Today, EmployeeId = 2 });
            }


        }

       

        protected void Page_Load(object sender, EventArgs e)
        {

           // Response.Write("5. This is Load event ");

            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer() { FirstName = "Nivedh", LastName = "Rao" });
            //customers.Add(new Customer() { FirstName = "Tej", LastName = "Tej2" });
            //customers.Add(new Customer() { FirstName = "Adhithya", LastName = "Adhi" });
            //customers.Add(new Customer() { FirstName = "Jaswanth", LastName = "Jash" });

            if (!Page.IsPostBack)
            {
                vendorRepository = new VendorRepository();
                this.GridView1.DataSource = vendorRepository.GetVendors();

                this.GridView1.DataBind();

                ViewState["MyKey"] = "testing";
                this.HiddenField1.Value = "testing";

                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie.Value = "Praneeth";
                Response.Cookies.Add(cookie);


            }
            else
            {
                string viewStateValue = this.ViewState["MyKey"].ToString();

                string cookie = Request.Cookies["UserInfo"].Value;


            }

            if (Request.QueryString["firstname"] != null)
            {
                string querystring = Request.QueryString["firstname"].ToString();
            }

            if (Session["MyData"] == null)
            {
                var app = new Application() { ApplicationId = 1, CreatedDate = System.DateTime.Today, EmployeeId = 2 };
                var list = new List<Application>();
                list.Add(app);
                Session["MyData"] = list;
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Response.Write("6. This is  On Load event ");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("6. This is  On PreRender event ");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {

        }

    }
}