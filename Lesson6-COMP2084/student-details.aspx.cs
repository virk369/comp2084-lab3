using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// reference the model binding library
using System.Web.ModelBinding;

namespace Lesson6_COMP2084
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //connecting
                    var conn = new ContosoEntities();
                    var objStu = (from s in conn.Students
                                  where s.StudentID == StudentID
                                  select s).FirstOrDefault();

                    // send to the form
                    txtLastName.Text = objStu.LastName;
                    txtFirstMidName.Text = objStu.FirstMidName;
                    txtEnrollmentDate.Text = objStu.EnrollmentDate.ToString("yyyy-MM-dd");
                }
            }
        }

        protected void btnSaveStudent_Click(object sender, EventArgs e)
        {
            Int32 StudentId = 0;

            if(!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
            {
                StudentId = Convert.ToInt32(Request.QueryString["StudentID"]);
            }
            // connect
            var conn = new ContosoEntities();

            // use the student class to create a new object
            Student s = new Student();

            // fill the properties of the new student object
            s.LastName = txtLastName.Text;
            s.FirstMidName = txtFirstMidName.Text;
            s.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);


            // save the new object
            if(StudentId == 0)
            {
                conn.Students.Add(s);
            }

            else
            {
                s.StudentID = StudentId;
                conn.Students.Attach(s);
                conn.Entry(s).State = System.Data.Entity.EntityState.Modified;
            }
            
            conn.SaveChanges();

            // redirect
            Response.Redirect("students.aspx");
        }
    }
}