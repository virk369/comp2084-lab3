using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// add reference to access the database
using System.Web.ModelBinding;

namespace Lesson6_COMP2084
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getStudents();
        }

        protected void getStudents()
        {
            // conn 
            var conn = new ContosoEntities();

            // run the query
            var Students = from s in conn.Students
                           select s;

            // display the results
            grdStudents.DataSource = Students.ToList();
            grdStudents.DataBind();

        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 gridIndex = e.RowIndex;

            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[gridIndex].Value);

            // connecting to the db
            var conn = new ContosoEntities();

            // deleting the student
            Student s = new Student();
            s.StudentID = StudentID;
            conn.Students.Attach(s);
            conn.Students.Remove(s);
            conn.SaveChanges();

            // refreshing the page
            getStudents();
        }
    }
}