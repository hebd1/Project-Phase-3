using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
  [Authorize(Roles = "Student")]
  public class StudentController : CommonController
  {

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Catalog()
    {
      return View();
    }

    public IActionResult Class(string subject, string num, string season, string year)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      return View();
    }

    public IActionResult Assignment(string subject, string num, string season, string year, string cat, string aname)
    {
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      ViewData["season"] = season;
      ViewData["year"] = year;
      ViewData["cat"] = cat;
      ViewData["aname"] = aname;
      return View();
    }


    public IActionResult ClassListings(string subject, string num)
    {
      System.Diagnostics.Debug.WriteLine(subject + num);
      ViewData["subject"] = subject;
      ViewData["num"] = num;
      return View();
    }


    /*******Begin code to modify********/

    /// <summary>
    /// Returns a JSON array of the classes the given student is enrolled in.
    /// Each object in the array should have the following fields:
    /// "subject" - The subject abbreviation of the class (such as "CS")
    /// "number" - The course number (such as 5530)
    /// "name" - The course name
    /// "season" - The season part of the semester
    /// "year" - The year part of the semester
    /// "grade" - The grade earned in the class, or "--" if one hasn't been assigned
    /// </summary>
    /// <param name="uid">The uid of the student</param>
    /// <returns>The JSON array</returns>
    public IActionResult GetMyClasses(string uid)
    {
            using (db)
            {
                var query = from eg in db.EnrollmentGrades
                            where eg.UId == uid
                            join cl in db.Classes on eg.ClassId equals cl.ClassId
                            join co in db.Courses on cl.CourseId equals co.CourseId
                            select new
                            {
                                subject = co.DeptAbbreviation,
                                number = co.Number,
                                name = co.Name,
                                season = cl.Season,
                                year = cl.Year,
                                grade = eg.Grade == "" ? "--" : eg.Grade
                            };

                return Json(query.ToArray());
            }
   
    }

    /// <summary>
    /// Returns a JSON array of all the assignments in the given class that the given student is enrolled in.
    /// Each object in the array should have the following fields:
    /// "aname" - The assignment name
    /// "cname" - The category name that the assignment belongs to
    /// "due" - The due Date/Time
    /// "score" - The score earned by the student, or null if the student has not submitted to this assignment.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="uid"></param>
    /// <returns>The JSON array</returns>
    public IActionResult GetAssignmentsInClass(string subject, int num, string season, int year, string uid)
    {
            using (db)
            {
                // Holds all assignments for given class
                var query1 = from co in db.Courses
                             where co.DeptAbbreviation == subject && co.Number == num
                             join cl in db.Classes on co.CourseId equals cl.CourseId
                             where cl.Season == season && cl.Year == year
                             join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                             join a in db.Assignments on ac.CategoryId equals a.CategoryId
                             select a;
                // Join assignments with matching student submissions left join
                var query2 = from q in query1
                             join s in db.Submissions on new
                             {
                                 A = q.AssignmentId,
                                 B = uid
                             } equals new
                             {
                                 A = s.AssignmentId,
                                 B = s.UId
                             } into joined
                             from j in joined.DefaultIfEmpty()
                             select new
                             {
                                 aname = q.Name,
                                 cname = q.Category.Name,
                                 due = q.DueDate,
                                 score = j == null ? null : (uint?)j.Score
                             };

                return Json(query2.ToArray());

            }

        }



    /// <summary>
    /// Adds a submission to the given assignment for the given student
    /// The submission should use the current time as its DateTime
    /// You can get the current time with DateTime.Now
    /// The score of the submission should start as 0 until a Professor grades it
    /// If a Student submits to an assignment again, it should replace the submission contents
    /// and the submission time (the score should remain the same).
	/// Does *not* automatically reject late submissions.
    /// </summary>
    /// <param name="subject">The course subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
    /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
    /// <param name="category">The name of the assignment category in the class</param>
    /// <param name="asgname">The new assignment name</param>
    /// <param name="uid">The student submitting the assignment</param>
    /// <param name="contents">The text contents of the student's submission</param>
    /// <returns>A JSON object containing {success = true/false}.</returns>
    public IActionResult SubmitAssignmentText(string subject, int num, string season, int year, 
      string category, string asgname, string uid, string contents)
    {
            try
            {
                using (db)
                {
                    // Holds the given assignment
                    var query1 = from co in db.Courses
                                 where co.DeptAbbreviation == subject && co.Number == num
                                 join cl in db.Classes on co.CourseId equals cl.CourseId
                                 where cl.Season == season && cl.Year == year
                                 join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                                 where ac.Name == category
                                 join a in db.Assignments on ac.CategoryId equals a.CategoryId
                                 where a.Name == asgname
                                 select a;


                    var query2 = from q in query1
                                  join s in db.Submissions on q.AssignmentId equals s.AssignmentId
                                  where s.UId == uid
                                  select s;
                    // student hasn't submitted assignment yet
                    if (!query2.Any())
                    {
                        Submissions s = new Submissions();
                        s.TimeStamp = DateTime.Now;
                        s.Score = 0;
                        s.Contents = contents;
                        s.UId = uid;
                        s.AssignmentId = query1.First().AssignmentId;
                        db.Submissions.Add(s);

                    }
                    // student already submitted, update timestamp and contents
                    else
                    {
                        query2.FirstOrDefault().TimeStamp = DateTime.Now;
                        query2.FirstOrDefault().Contents = contents;
                    }

                    db.SaveChanges();
                    return Json(new { success = true });

                }
            } catch (Exception e)
            {
                return Json(new { success = false });
            }
           

           
    }

    
    /// <summary>
    /// Enrolls a student in a class.
    /// </summary>
    /// <param name="subject">The department subject abbreviation</param>
    /// <param name="num">The course number</param>
    /// <param name="season">The season part of the semester</param>
    /// <param name="year">The year part of the semester</param>
    /// <param name="uid">The uid of the student</param>
    /// <returns>A JSON object containing {success = {true/false},
	/// false if the student is already enrolled in the Class.</returns>
    public IActionResult Enroll(string subject, int num, string season, int year, string uid)
    {
            try
            {
                using (db)
                {
                    // Holds given class
                    var query1 = from co in db.Courses
                                 where co.DeptAbbreviation == subject && co.Number == num
                                 join cl in db.Classes on co.CourseId equals cl.CourseId 
                                 where cl.Year == year && cl.Season == season select cl;

                    // Holds EnrollmentGrade if student is enrolled
                    var query2 = from q in query1 join eg in db.EnrollmentGrades on q.ClassId equals eg.ClassId
                                where eg.UId == uid
                                select eg;

                    // Student not enrolled in this class
                    if (!query2.Any())
                    {
                        EnrollmentGrades eg = new EnrollmentGrades();
                        eg.UId = uid;
                        eg.ClassId = query1.First().ClassId;
                        eg.Grade = "";
                        db.EnrollmentGrades.Add(eg);
                        db.SaveChanges();
                        return Json(new { success = true });
                    }
                    // Student already enrolled
                    else
                    {
                        return Json(new { success = false });
                    }
                }
            } catch
            {
                return Json(new { success = false });
            }
            

                
    }



    /// <summary>
    /// Calculates a student's GPA
    /// A student's GPA is determined by the grade-point representation of the average grade in all their classes.
    /// Assume all classes are 4 credit hours.
    /// If a student does not have a grade in a class ("--"), that class is not counted in the average.
    /// If a student does not have any grades, they have a GPA of 0.0.
    /// Otherwise, the point-value of a letter grade is determined by the table on this page:
    /// https://advising.utah.edu/academic-standards/gpa-calculator-new.php
    /// </summary>
    /// <param name="uid">The uid of the student</param>
    /// <returns>A JSON object containing a single field called "gpa" with the number value</returns>
    public IActionResult GetGPA(string uid)
    {
            using (db)
            {
                var query = from eg in db.EnrollmentGrades where eg.UId == uid select eg.Grade;
                // Student has no grades
                if (!query.Any())
                {
                    return Json(new { gpa = 0.0 });
                }

                double gpa = 0.0;
                int total_courses = 0;
                foreach (var grade in query.ToList())
                {
                    total_courses += 1;
                    switch (grade)
                    {
                        case "A":
                            gpa += 4.0;
                            break;
                        case "A-":
                            gpa += 3.7;
                            break;
                        case "B+":
                            gpa += 3.3;
                            break;
                        case "B":
                            gpa += 3.0;
                            break;
                        case "B-":
                            gpa += 2.7;
                            break;
                        case "C+":
                            gpa += 2.3;
                            break;
                        case "C":
                            gpa += 2.0;
                            break;
                        case "C-":
                            gpa += 1.7;
                            break;
                        case "D+":
                            gpa += 1.3;
                            break;
                        case "D":
                            gpa += 1.0;
                            break;
                        case "D-":
                            gpa += 0.7;
                            break;
                        case "E":
                            gpa += 0.0;
                            break;
                        // no grade
                        default:
                            total_courses -= 1;
                            break;
                    }

                }
                gpa /= total_courses;
                return Json(new { gpa = gpa });
            }

               
    }

    /*******End code to modify********/

  }
}