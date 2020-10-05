using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agenda.BLL;
using Agenda.Entity;

namespace Agenda.Site
{
    public partial class _Default : Page
    {
        private void print(List<Example> listado)
        {
            foreach (Example example in listado)
            {
                Response.Write(string.Concat("Id: ", example.id.ToString(), "Value: ", example.value));
                Response.Write(string.Concat("<BR/>"));
                Response.Write("--------------------------------------");
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IExampleBusiness business = new MemoryExampleBusiness((List<Example>)Application["lstExample"]);

            Example example = business.GetExampleByID(new Example { id = 3 });
            print(business.GetListExampleByFilter(new ExampleFilter { value = "example2" }));


            business.Insert(new Example() { value = "test" });

            example.value = "test2";
            business.Update(example);

            Example exampleDelete = business.GetExampleByID(new Example { id = 2 });
            business.Delete(exampleDelete);


            print(business.GetListExampleByFilter(new ExampleFilter()));
        }




    }
}