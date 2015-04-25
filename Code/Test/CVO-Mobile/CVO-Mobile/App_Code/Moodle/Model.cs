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

    }
}
