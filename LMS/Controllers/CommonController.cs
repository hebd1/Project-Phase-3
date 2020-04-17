using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS.Models.LMSModels;
using System.Collections;

namespace LMS.Controllers
{
    public class CommonController : Controller
    {

        /*******Begin code to modify********/
        
        protected Team31LMSContext db;

        public CommonController()
        {
            db = new Team31LMSContext();
        }
  

        public void UseLMSContext(Team31LMSContext ctx)
        {
            db = ctx;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        


        /// <summary>
        /// Retreive a JSON array of all departments from the database.
        /// Each object in the array should have a field called "name" and "subject",
        /// where "name" is the department name and "subject" is the subject abbreviation.
        /// </summary>
        /// <returns>The JSON array</returns>
        public IActionResult GetDepartments()
        {
            
            // You may have to cast serial to a (uint)
            using (db)
            {
                var query = from d in db.Departments select new { name = d.DeptName, subject = d.DeptAbbreviation };
                return Json(query.ToArray());
            }
            
        }



        /// <summary>
        /// Returns a JSON array representing the course catalog.
        /// Each object in the array should have the following fields:
        /// "subject": The subject abbreviation, (e.g. "CS")
        /// "dname": The department name, as in "Computer Science"
        /// "courses": An array of JSON objects representing the courses in the department.
        ///            Each field in this inner-array should have the following fields:
        ///            "number": The course number (e.g. 5530)
        ///            "cname": The course name (e.g. "Database Systems")
        /// </summary>
        /// <returns>The JSON array</returns>
        public IActionResult GetCatalog()
        {
            using (db)
            {
                var query = from d in db.Departments select d;
                var result = new ArrayList();
                foreach (var dept in query.ToList())
                {
                    
                    var query2 = from c in db.Courses
                                 where c.DeptAbbreviation == dept.DeptAbbreviation
                                 select new
                                 {
                                     number = c.Number,
                                     cname = c.Name
                                 };

                    result.Add(new 
                    {
                        subject = dept.DeptAbbreviation,
                        dname = dept.DeptName,
                        courses = query2.ToArray()
                    });
                }
                
                return Json(result.ToArray());
            }
        }

        /// <summary>
        /// Returns a JSON array of all class offerings of a specific course.
        /// Each object in the array should have the following fields:
        /// "season": the season part of the semester, such as "Fall"
        /// "year": the year part of the semester
        /// "location": the location of the class
        /// "start": the start time in format "hh:mm:ss"
        /// "end": the end time in format "hh:mm:ss"
        /// "fname": the first name of the professor
        /// "lname": the last name of the professor
        /// </summary>
        /// <param name="subject">The subject abbreviation, as in "CS"</param>
        /// <param name="number">The course number, as in 5530</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetClassOfferings(string subject, int number)
        {
            using (db)
            {
                var query = from course in db.Courses
                            where course.DeptAbbreviation == subject && course.Number == number
                            join c in db.Classes on course.CourseId equals c.CourseId
                            join u in db.Users on c.UId equals u.UId
                            select new
                            {
                                season = c.Season,
                                year = c.Year,
                                location = c.Location,
                                start = c.StartTime,
                                end = c.EndTime,
                                fname = u.FirstName,
                                lname = u.LastName
                            };
                return Json(query.ToArray());

            }

        }

        /// <summary>
        /// This method does NOT return JSON. It returns plain text (containing html).
        /// Use "return Content(...)" to return plain text.
        /// Returns the contents of an assignment.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment in the category</param>
        /// <returns>The assignment contents</returns>
        public IActionResult GetAssignmentContents(string subject, int num, string season, int year, string category, string asgname)
        {
            using (db)
            {
                var query = from c in db.Courses
                            where c.DeptAbbreviation == subject && c.Number == num
                            join cl in db.Classes on c.CourseId equals cl.CourseId
                            where cl.Season == season && cl.Year == year
                            join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                            where ac.Name == category
                            join a in db.Assignments on ac.CategoryId equals a.CategoryId
                            where a.Name == asgname
                            select a;
                return Content(query.ToList()[0].Contents);

            }

        }


        /// <summary>
        /// This method does NOT return JSON. It returns plain text (containing html).
        /// Use "return Content(...)" to return plain text.
        /// Returns the contents of an assignment submission.
        /// Returns the empty string ("") if there is no submission.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment in the category</param>
        /// <param name="uid">The uid of the student who submitted it</param>
        /// <returns>The submission text</returns>
        public IActionResult GetSubmissionText(string subject, int num, string season, int year, string category, string asgname, string uid)
        {
            using (db)
            {
                var query = from c in db.Courses
                            where c.DeptAbbreviation == subject && c.Number == num
                            join cl in db.Classes on c.CourseId equals cl.CourseId
                            where cl.Year == year && cl.Season == season
                            join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                            where ac.Name == category
                            join a in db.Assignments on ac.CategoryId equals a.CategoryId
                            where a.Name == asgname
                            join s in db.Submissions on a.AssignmentId equals s.AssignmentId
                            where s.UId == uid
                            select s;

                return Content(query.ToList()[0].Contents);

            }
        }


        /// <summary>
        /// Gets information about a user as a single JSON object.
        /// The object should have the following fields:
        /// "fname": the user's first name
        /// "lname": the user's last name
        /// "uid": the user's uid
        /// "department": (professors and students only) the name (such as "Computer Science") of the department for the user. 
        ///               If the user is a Professor, this is the department they work in.
        ///               If the user is a Student, this is the department they major in.    
        ///               If the user is an Administrator, this field is not present in the returned JSON
        /// </summary>
        /// <param name="uid">The ID of the user</param>
        /// <returns>
        /// The user JSON object 
        /// or an object containing {success: false} if the user doesn't exist
        /// </returns>
        public IActionResult GetUser(string uid)
        {
            using (db)
            {
                try
                {
                    var result = new ArrayList();
                    var query = (from u in db.Users where u.UId == uid select u).First();
                    var squery = from s in db.Students where s.UId == uid join d in db.Departments on s.DeptAbbreviation equals d.DeptAbbreviation select d;
                    var pquery = from p in db.Professors where p.UId == uid join d in db.Departments on p.DeptAbbreviation equals d.DeptAbbreviation select d;
                    var aquery = from a in db.Admins where a.UId == uid select a;
                    if (squery.Any())
                    {
                        result.Add(new
                        {
                            fname = query.FirstName,
                            lname = query.LastName,
                            uid = query.UId,
                            department = squery.First().DeptName
                        });
                    }
                    else if (pquery.Any())
                    {
                        result.Add(new
                        {
                            fname = query.FirstName,
                            lname = query.LastName,
                            uid = query.UId,
                            department = pquery.First().DeptName
                        });

                    }
                    else if (aquery.Any())
                    {
                        result.Add(new
                        {
                            fname = query.FirstName,
                            lname = query.LastName,
                            uid = query.UId,
                        });

                    }
                    return Json(result[0]);
                } catch (Exception e)
                {
                    return Json(new { success = false });
                }
                


            }

               
        }


        /*******End code to modify********/

    }
}