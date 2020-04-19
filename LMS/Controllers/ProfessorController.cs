using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Authorize(Roles = "Professor")]
    public class ProfessorController : CommonController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
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

        public IActionResult Categories(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            return View();
        }

        public IActionResult CatAssignments(string subject, string num, string season, string year, string cat)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
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

        public IActionResult Submissions(string subject, string num, string season, string year, string cat, string aname)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            return View();
        }

        public IActionResult Grade(string subject, string num, string season, string year, string cat, string aname, string uid)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            ViewData["uid"] = uid;
            return View();
        }

        /*******Begin code to modify********/


        /// <summary>
        /// Returns a JSON array of all the students in a class.
        /// Each object in the array should have the following fields:
        /// "fname" - first name
        /// "lname" - last name
        /// "uid" - user ID
        /// "dob" - date of birth
        /// "grade" - the student's grade in this class
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetStudentsInClass(string subject, int num, string season, int year)
        {
            using (db)
            {
                var query = from co in db.Courses
                            where co.DeptAbbreviation == subject && co.Number == num
                            join cl in db.Classes on co.CourseId equals cl.CourseId
                            where cl.Season == season && cl.Year == year
                            join eg in db.EnrollmentGrades on cl.ClassId equals eg.ClassId
                            join u in db.Users on eg.UId equals u.UId
                            select new
                            {
                                fname = u.FirstName,
                                lname = u.LastName,
                                uid = u.UId,
                                dob = u.Dob,
                                grade = eg.Grade
                            };
                return Json(query.ToArray());

            }


        }



        /// <summary>
        /// Returns a JSON array with all the assignments in an assignment category for a class.
        /// If the "category" parameter is null, return all assignments in the class.
        /// Each object in the array should have the following fields:
        /// "aname" - The assignment name
        /// "cname" - The assignment category name.
        /// "due" - The due DateTime
        /// "submissions" - The number of submissions to the assignment
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class, 
        /// or null to return assignments from all categories</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentsInCategory(string subject, int num, string season, int year, string category)
        {
            using (db)
            {
                // return assignments in all categories
                if (category == null)
                {
                    var query = from co in db.Courses
                                where co.DeptAbbreviation == subject && co.Number == num
                                join cl in db.Classes on co.CourseId equals cl.CourseId
                                where cl.Season == season && cl.Year == year
                                join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                                join a in db.Assignments on ac.CategoryId equals a.CategoryId
                                select new
                                {
                                    aname = a.Name,
                                    cname = ac.Name,
                                    due = a.DueDate,
                                    submissions = a.Submissions.Count()
                                };
                    return Json(query.ToArray());
                }
                // return assignments from category
                else
                {
                    var query = from co in db.Courses
                                where co.DeptAbbreviation == subject && co.Number == num
                                join cl in db.Classes on co.CourseId equals cl.CourseId
                                where cl.Season == season && cl.Year == year
                                join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                                where ac.Name == category
                                join a in db.Assignments on ac.CategoryId equals a.CategoryId
                                select new
                                {
                                    aname = a.Name,
                                    cname = ac.Name,
                                    due = a.DueDate,
                                    submissions = a.Submissions.Count()
                                };
                    return Json(query.ToArray());
                }
            }

        }


        /// <summary>
        /// Returns a JSON array of the assignment categories for a certain class.
        /// Each object in the array should have the folling fields:
        /// "name" - The category name
        /// "weight" - The category weight
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentCategories(string subject, int num, string season, int year)
        {
            using (db)
            {
                // return assignments in all categories
                var query = from co in db.Courses
                            where co.DeptAbbreviation == subject && co.Number == num
                            join cl in db.Classes on co.CourseId equals cl.CourseId
                            where cl.Season == season && cl.Year == year
                            join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                            select new
                            {
                                name = ac.Name,
                                weight = ac.GradingWeight
                            };
                return Json(query.ToArray());
            }
        }

        /// <summary>
        /// Creates a new assignment category for the specified class.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The new category name</param>
        /// <param name="catweight">The new category weight</param>
        /// <returns>A JSON object containing {success = true/false},
        ///	false if an assignment category with the same name already exists in the same class.</returns>
        public IActionResult CreateAssignmentCategory(string subject, int num, string season, int year, string category, int catweight)
        {
            using (db)
            {
                // return assignments in all categories
                var query = from co in db.Courses
                            where co.DeptAbbreviation == subject && co.Number == num
                            join cl in db.Classes on co.CourseId equals cl.CourseId
                            where cl.Season == season && cl.Year == year
                            join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                            into joined
                            from j in joined.DefaultIfEmpty()
                            where j.Name == category
                            select j;

                /*
                if(!(query.FirstOrDefault().Name == null))
                {
                    return Json(new { success = false });
                }
                else
                {
                    AssignmentCategories ac = new AssignmentCategories();
                    //ac.Class = ;
                    ac.ClassId = query.FirstOrDefault;
                    ac.GradingWeight = (uint)catweight;
                    ac.Name = category;
                    return Json(new { success = true });
                }
                */
                return Json(new { success = false });
            }

        }

        /// <summary>
        /// Creates a new assignment for the given class and category.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The new assignment name</param>
        /// <param name="asgpoints">The max point value for the new assignment</param>
        /// <param name="asgdue">The due DateTime for the new assignment</param>
        /// <param name="asgcontents">The contents of the new assignment</param>
        /// <returns>A JSON object containing success = true/false,
        /// false if an assignment with the same name already exists in the same assignment category.</returns>
        public IActionResult CreateAssignment(string subject, int num, string season, int year, string category, string asgname, int asgpoints, DateTime asgdue, string asgcontents)
        {
            try
            {
                using (db)
                {
                    var query = from co in db.Courses
                                where co.DeptAbbreviation == subject && co.Number == num
                                join cl in db.Classes on co.CourseId equals cl.CourseId
                                where cl.Season == season && cl.Year == year
                                join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                                where ac.Name == category
                                select ac;
                    var query2 = from q in query
                                 join a in db.Assignments on q.CategoryId equals a.CategoryId
                                 where a.Name == asgname
                                 select a;
                    // Assignment with same name already exists
                    if (query2.Any())
                    {
                        return Json(new { success = false });
                    }
                    // Assignment does not yet exist
                    else
                    {
                        Assignments a = new Assignments();
                        a.Contents = asgcontents;
                        a.Name = asgname;
                        a.MaxPoints = (uint)asgpoints;
                        a.CategoryId = query.FirstOrDefault().CategoryId;
                        a.DueDate = asgdue;
                        db.Assignments.Add(a);
                        db.SaveChanges();

                        // update grades of all students in the class
                        var query3 = from co in db.Courses
                                     where co.DeptAbbreviation == subject && co.Number == num
                                     join cl in db.Classes on co.CourseId equals cl.CourseId
                                     where cl.Season == season && cl.Year == year
                                     join eg in db.EnrollmentGrades on cl.ClassId equals eg.ClassId
                                     select eg;
                        foreach (var enrollment in query3.ToList())
                        {
                            enrollment.Grade = calculateGrade(db, subject, num, season, year, category, enrollment.UId);
                        }
                        db.SaveChanges();
                        return Json(new { success = true });


                    }
                }
            }
            catch
            {
                return Json(new { success = false });
            }



        }


        /// <summary>
        /// Gets a JSON array of all the submissions to a certain assignment.
        /// Each object in the array should have the following fields:
        /// "fname" - first name
        /// "lname" - last name
        /// "uid" - user ID
        /// "time" - DateTime of the submission
        /// "score" - The score given to the submission
        /// 
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetSubmissionsToAssignment(string subject, int num, string season, int year, string category, string asgname)
        {
            using (db)
            {
                var query = from co in db.Courses
                            where co.DeptAbbreviation == subject && co.Number == num
                            join cl in db.Classes on co.CourseId equals cl.CourseId
                            where cl.Season == season && cl.Year == year
                            join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                            where ac.Name == category
                            join a in db.Assignments on ac.CategoryId equals a.CategoryId
                            where a.Name == asgname
                            join s in db.Submissions on a.AssignmentId equals s.AssignmentId
                            join u in db.Users on s.UId equals u.UId
                            select new
                            {
                                fname = u.FirstName,
                                lname = u.LastName,
                                uid = u.UId,
                                time = s.TimeStamp,
                                score = s.Score
                            };

                return Json(query.ToArray());
            }

        }


        /// <summary>
        /// Set the score of an assignment submission
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment</param>
        /// <param name="uid">The uid of the student who's submission is being graded</param>
        /// <param name="score">The new score for the submission</param>
        /// <returns>A JSON object containing success = true/false</returns>
        public IActionResult GradeSubmission(string subject, int num, string season, int year, string category, string asgname, string uid, int score)
        {
            try
            {
                using (db)
                {
                    var query = from co in db.Courses
                                where co.DeptAbbreviation == subject && co.Number == num
                                join cl in db.Classes on co.CourseId equals cl.CourseId
                                where cl.Season == season && cl.Year == year
                                select cl;
                    var query2 = (from q in query
                                  join ac in db.AssignmentCategories on q.ClassId equals ac.ClassId
                                  where ac.Name == category
                                  join a in db.Assignments on ac.CategoryId equals a.CategoryId
                                  where a.Name == asgname
                                  join s in db.Submissions on a.AssignmentId equals s.AssignmentId
                                  where s.UId == uid
                                  select s).FirstOrDefault();
                    var query3 = (from q in query
                                  join eg in db.EnrollmentGrades on q.ClassId equals eg.ClassId
                                  where eg.UId == uid
                                  select eg).FirstOrDefault();

                    query2.Score = (uint)score;
                    // update student's grade for class
                    query3.Grade = calculateGrade(db, subject, num, season, year, category, uid);
                    db.SaveChanges();

                    return Json(new { success = true });
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new { success = false });
            }

        }


        /// <summary>
        /// Returns a JSON array of the classes taught by the specified professor
        /// Each object in the array should have the following fields:
        /// "subject" - The subject abbreviation of the class (such as "CS")
        /// "number" - The course number (such as 5530)
        /// "name" - The course name
        /// "season" - The season part of the semester in which the class is taught
        /// "year" - The year part of the semester in which the class is taught
        /// </summary>
        /// <param name="uid">The professor's uid</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetMyClasses(string uid)
        {

            using (db)
            {
                var query = from cl in db.Classes
                            where cl.UId == uid
                            join co in db.Courses on cl.CourseId equals co.CourseId
                            select new
                            {
                                subject = co.DeptAbbreviation,
                                number = co.Number,
                                name = co.Name,
                                season = cl.Season,
                                year = cl.Year
                            };

                return Json(query.ToArray());
            }
        }


        /*******End code to modify********/


        /// <summary>
        /// Returns a letter grade i.e. A- based on the given percentage. 
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public string percentageToGrade(double percentage)
        {
            if (100 >= percentage && percentage >= 93)
            {
                return "A";
            }
            else if (93 > percentage && percentage >= 90)
            {
                return "A-";
            }
            else if (90 > percentage && percentage >= 87)
            {
                return "B+";
            }
            else if (87 > percentage && percentage >= 83)
            {
                return "B";
            }
            else if (83 > percentage && percentage >= 80)
            {
                return "B-";
            }
            else if (80 > percentage && percentage >= 77)
            {
                return "C+";
            }
            else if (77 > percentage && percentage >= 73)
            {
                return "C";
            }
            else if (73 > percentage && percentage >= 70)
            {
                return "C-";
            }
            else if (70 > percentage && percentage >= 67)
            {
                return "D+";
            }
            else if (67 > percentage && percentage >= 63)
            {
                return "D";
            }
            else if (63 > percentage && percentage >= 60)
            {
                return "D-";
            }
            else
            {
                return "E";
            }
        }

        /// <summary>
        /// Calculates and returns the grade for the for the student with the given uid
        /// in the given class. A scaled total of points for each assignment in each
        /// assignment category is used to find the letter grade.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="subject"></param>
        /// <param name="num"></param>
        /// <param name="season"></param>
        /// <param name="year"></param>
        /// <param name="category"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string calculateGrade(Team31LMSContext db, string subject, int num, string season, int year, string category, string uid)
        {

            double scaledTotal = 0.0;
            double weightTotal = 0.0;
            // Holds all the non-empty assignment categories for the given class
            var query = from co in db.Courses
                        where co.DeptAbbreviation == subject && co.Number == num
                        join cl in db.Classes on co.CourseId equals cl.CourseId
                        where cl.Season == season && cl.Year == year
                        join ac in db.AssignmentCategories on cl.ClassId equals ac.ClassId
                        where ac.Assignments.Any()
                        select ac;

            // loop through each category
            foreach (var cat in query.ToList())
            {
                var totalPoints = (from a in db.Assignments
                                   where a.CategoryId == cat.CategoryId
                                   select a).ToList().Sum(x => x.MaxPoints);

                var earnedPoints = (from a in db.Assignments
                                    where a.CategoryId == cat.CategoryId
                                    join s in db.Submissions on a.AssignmentId equals s.AssignmentId
                                    select s).ToList().Sum(x => x.Score);

                double percentage = earnedPoints > 0 ? totalPoints / earnedPoints : 0;
                scaledTotal += percentage * cat.GradingWeight;
                weightTotal += cat.GradingWeight;
            }
            // re-scale bc there is no assignment category weight limit
            double scalingFactor = 100 / weightTotal;
            double totalPercentage = scaledTotal * scalingFactor;
            return percentageToGrade(totalPercentage);


        }

    }
}