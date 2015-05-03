using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodle
{
    public class Model
    {
        public static List<Moodle.BLL.Assignment> GetAllAssingmentInCourse(string url, string token, int courseId)
        {
            return DAL.Assignment.GetAllAssingmentInCourse(url, token, courseId);
        }

        public static double GetGradeOfStudentForAssignment(string url, string token, int assignmentId, int userId)
        {
            return DAL.Grade.GetGradeOfStudentForAssignment(url, token, userId, assignmentId);
        }

        public static string RequestTokenForService(string url, string accountName, string password, string service)
        {
            return DAL.Token.RequestTokenForService(url, accountName, password, service);
        }


        public static int GetUserIdByEmail(string url, string token, string email)
        {
            return DAL.User.GetUserIdByEmail(url, token, email);
        }

        public static List<BLL.Course> GetUserEnrolledCourses(string url, string token, int userId)
        {
            return DAL.Course.GetUserEnrolledCourses(url, token, userId);
        }

        public static List<Moodle.BLL.Deadline> GetDeadlinesInTimespan(List<Moodle.BLL.Course> courses)
        {
            return GetDeadlinesInTimespan(courses, DateTime.Now, 356);
        }

        public static List<Moodle.BLL.Deadline> GetDeadlinesInTimespan(List<Moodle.BLL.Course> courses, DateTime startDate, int daysRange)
        {
            List<Moodle.BLL.Deadline> deadlines = new List<Moodle.BLL.Deadline>();

            // start date always start of the day
            startDate = startDate.Date;
            // remove 1 minute to only get requested range
            DateTime endDate = startDate.AddDays(daysRange).AddMinutes(-1);

            foreach (BLL.Course course in courses)
            {

                foreach (BLL.Assignment assign in course.Assignments)
                {
                    // Only upcomming deadlines starting on date for the next x days to come
                    if (assign.DueDate >= startDate && assign.DueDate <= endDate)
                    {
                        //assignments.Add(assign);

                        AddAssingmentToDeadlines(assign, deadlines);

                    }
                }

            }

            // Sort by duedate
            deadlines.Sort((x, y) => x.Date.CompareTo(y.Date));

            return deadlines;
        }

         private static void AddAssingmentToDeadlines(Moodle.BLL.Assignment assignment, List<Moodle.BLL.Deadline> list)
         {
             // See if deadline date already exists
             foreach (Moodle.BLL.Deadline deadline in list)
             {
                 // Only check for actual date, ignore time
                 if (deadline.Date.Date == assignment.DueDate.Date)
                 {
                     deadline.Assignments.Add(assignment);
                     return;
                 }
             }

             // Deadline date doesn't exist
             Moodle.BLL.Deadline d = new BLL.Deadline();
             d.Date = assignment.DueDate;
             d.Assignments.Add(assignment);

             list.Add(d);
         }

    }
}
