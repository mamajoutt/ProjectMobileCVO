using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodle
{
    public class Model
    {
        /// <summary>
        /// Get all assignments in course with id.
        /// </summary>
        /// <param name="token">Moodle token.</param>
        /// <param name="courseId">Id of course.</param>
        /// <returns>List of assignments.</returns>
        public static List<Moodle.BLL.Assignment> GetAllAssingmentInCourse(string token, int courseId)
        {
            return DAL.Assignment.GetAllAssingmentInCourse(token, courseId);
        }

        /// <summary>
        /// Get the grade of a student with id for an assignment with id.
        /// </summary>
        /// <param name="token">Moodle token.</param>
        /// <param name="assignmentId">Id of assignment.</param>
        /// <param name="studentId">Id of student.</param>
        /// <returns>Decimal grade for assignment.</returns>
        public static double GetGradeOfStudentForAssignment(string token, int assignmentId, int studentId)
        {
            return DAL.Grade.GetGradeOfStudentForAssignment(token, studentId, assignmentId);
        }

        /// <summary>
        /// Request a token for a service using username and password.
        /// </summary>
        /// <param name="accountName">Account name of service account.</param>
        /// <param name="password">Password of service account.</param>
        /// <param name="service">Name of service.</param>
        /// <returns>Token string.</returns>
        public static string RequestTokenForService(string accountName, string password, string service)
        {
            return DAL.Token.RequestTokenForService(accountName, password, service);
        }

        /// <summary>
        /// Get id of Student by email adress.
        /// </summary>
        /// <param name="token">Moodle token.</param>
        /// <param name="email">Email adress of student.</param>
        /// <returns>Id of student.</returns>
        public static int GetUserIdByEmail(string token, string email)
        {
            return DAL.User.GetUserIdByEmail(token, email);
        }

        /// <summary>
        /// Get a list of enrolled courses by student id.
        /// </summary>
        /// <param name="token">Moodle token.</param>
        /// <param name="userId">Id of student.</param>
        /// <returns>List of enrolled courses.</returns>
        public static List<BLL.Course> GetUserEnrolledCourses(string token, int userId)
        {
            return DAL.Course.GetUserEnrolledCourses(token, userId);
        }

        // Only for testing
        public static List<Moodle.BLL.Deadline> GetDeadlinesInTimespan(List<Moodle.BLL.Course> courses)
        {
            return GetDeadlinesInTimespan(courses, DateTime.Now, 356);
        }

        /// <summary>
        /// Get a list of deadlines from course in a given time period.
        /// </summary>
        /// <param name="courses">List of courses to search in.</param>
        /// <param name="startDate">Start date for time period.</param>
        /// <param name="daysRange">Day range for time period.</param>
        /// <returns>List of deadlines during time period.</returns>
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
                        AddAssingmentToDeadlines(assign, deadlines);

                    }
                }

            }

            // Sort by duedate
            deadlines.Sort((x, y) => x.Date.CompareTo(y.Date));

            return deadlines;
        }

        /// <summary>
        /// Adds an assignment to a list of deadlines. Adds to an existing deadline in the list if a deadline with the same day exists, otherwise creates a new deadline.
        /// </summary>
        /// <param name="assignment">Assingnment to add to the list.</param>
        /// <param name="list">List of deadlines to add to.</param>
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
