using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Moodle.DAL
{

    

    public class MoodlePackage
    {
        // Originele code Fouad Abouchehatan 
        // Aangepast foor Nikos vanden Broek
        public static string MoodleURL { set; get; }
        string service = "";
        List<KeyValuePair<string, string>> parameters;

        // Stel service in
        public MoodlePackage(String service)
        {
            this.service = service;
            parameters = new List<KeyValuePair<string, string>>();
        }

        // Voeg Input Parameters toe
        public void AddParameter(string key, string value)
        {
            parameters.Add(new KeyValuePair<string, string>(key, value));
        }

        /// <summary>
        /// Send package.
        /// </summary>
        /// <returns>JSON string.</returns>
        public String Send()
        {
            string output = "";
            string param_string = "";

            foreach (KeyValuePair<string, string> dx in parameters)
                param_string += dx.Key + "=" + dx.Value + "&";

            byte[] buffer = Encoding.ASCII.GetBytes(param_string);
            string lex = "http://" + MoodleURL + service + "?" + param_string;


            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(lex);
            WebReq.Method = WebRequestMethods.Http.Post;
            WebReq.ContentType = "application/x-www-form-urlencoded";

            WebReq.ContentLength = buffer.Length;
            using (Stream PostData = WebReq.GetRequestStream())
                PostData.Write(buffer, 0, buffer.Length);

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            using (StreamReader reader = new StreamReader(WebResp.GetResponseStream()))
                output = reader.ReadToEnd();

            return output;

        }
    }


    public class Assignment
    {
        /// <summary>
        /// Request a list of assingments in a course from Moodle.
        /// </summary>
        /// <param name="token">Moodle token.</param>
        /// <param name="courseId">Id of course</param>
        /// <returns>List of assignments in a course</returns>
        public static List<Moodle.BLL.Assignment> GetAllAssingmentInCourse(string token, int courseId)
        {
            List<BLL.Assignment> assignments = new List<BLL.Assignment>();


            MoodlePackage pAssignment = new MoodlePackage("/webservice/rest/server.php");
            pAssignment.AddParameter("wstoken", token);
            pAssignment.AddParameter("wsfunction", "mod_assign_get_assignments");
            pAssignment.AddParameter("moodlewsrestformat", "json");
            pAssignment.AddParameter("courseids[0]", "" + courseId);
            JObject jCourses = new JObject();

            try
            {
                jCourses = JObject.Parse(pAssignment.Send());

                //If warning isn't empty, throw error with warning
                if (!jCourses["warnings"].ToString().Equals("[]"))
                {
                    throw new Exception("mod_assign_get_assignments: " + jCourses["warnings"][0]);
                }

               JObject jAssignments = (JObject)jCourses["courses"][0];
                


                foreach (JObject c in jAssignments["assignments"])
                {
                    BLL.Assignment a = new BLL.Assignment(c);
                    assignments.Add(a);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            return assignments;
        }

    }

    public class Token
    {
        /// <summary>
        /// Request a web service token from Moodle.
        /// </summary>
        /// <param name="accountName">Acount name of service account.</param>
        /// <param name="password">Password of service account.</param>
        /// <param name="service">Name of service.</param>
        /// <returns>Token string.</returns>
        public static string RequestTokenForService(string accountName, string password, string service)
        {
            string token = "";

            MoodlePackage pToken = new Moodle.DAL.MoodlePackage("/login/token.php");
            pToken.AddParameter("username", accountName);
            pToken.AddParameter("password", password);
            pToken.AddParameter("service", service);

            JObject jToken = new JObject();
            try
            {
                jToken = JObject.Parse(pToken.Send());

                token = (string)jToken["token"];

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return token;
        }
    }

    public class Grade
    {
        /// <summary>
        /// Get the grade of a student with id for an assignment with id.
        /// </summary>
        /// <param name="token">Moodle token.</param>
        /// <param name="assignmentId">Id of assignment.</param>
        /// <param name="studentId">Id of student.</param>
        /// <returns>Decimal grade for assignment.</returns>
        public static double GetGradeOfStudentForAssignment(string token, int studentId, int assignmentId)
        {
            double grade = -1;

            MoodlePackage pGrade = new MoodlePackage("/webservice/rest/server.php");
            pGrade.AddParameter("wstoken", token);
            pGrade.AddParameter("wsfunction", "mod_assign_get_grades");
            pGrade.AddParameter("moodlewsrestformat", "json");
            pGrade.AddParameter("assignmentids[0]", "" + assignmentId);

            JObject jAssignments = new JObject();

            try
            {
                jAssignments = JObject.Parse(pGrade.Send());

                if (!jAssignments["assignments"].HasValues)
                {
                    throw new Exception(jAssignments["warnings"].ToString());
                }

                JObject jGrades = (JObject)jAssignments["assignments"][0];


                foreach (JObject g in jGrades["grades"])
                {
                    if (Convert.ToInt32((string)g["userid"]) == studentId)
                    {
                        string score = (string)g["grade"];
                        // Turn database string into double (12.34000 => 1234000)
                        grade = Convert.ToDouble(score);
                        // Devide to get actual grade (1234000 => 12.34)
                        grade /= 100000;

                        return grade;
                    }
                    
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return grade;
        }

    }

    public class User
    {
        /// <summary>
        /// Get id of Student by email adress.
        /// </summary>
        /// <param name="token">Moodle token.</param>
        /// <param name="email">Email adress of student.</param>
        /// <returns>Id of student.</returns>
        public static int GetUserIdByEmail(string token, string email)
        {
            int id = -1;

            Moodle.DAL.MoodlePackage pUser = new Moodle.DAL.MoodlePackage("/webservice/rest/server.php");
            pUser.AddParameter("wstoken", token);
            pUser.AddParameter("wsfunction", "core_user_get_users_by_field");
            pUser.AddParameter("moodlewsrestformat", "json");
            pUser.AddParameter("field", "email");
            pUser.AddParameter("values[0]", email);

            try
            {
                JArray jUser = JArray.Parse(pUser.Send());
                id = Convert.ToInt32(jUser[0]["id"]);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return id;
        }
    }

    public class Course
    {
        /// <summary>
        /// Get a list of enrolled courses by student id.
        /// </summary>
        /// <param name="token">Moodle token.</param>
        /// <param name="userId">Id of student.</param>
        /// <returns>List of enrolled courses.</returns>
        public static List<BLL.Course> GetUserEnrolledCourses(string token, int userId)
        {
            List<BLL.Course> courses = new List<BLL.Course>();

            Moodle.DAL.MoodlePackage pCourse =
                new Moodle.DAL.MoodlePackage("/webservice/rest/server.php");
            pCourse.AddParameter("wstoken", token);
            pCourse.AddParameter("wsfunction", "core_enrol_get_users_courses");
            pCourse.AddParameter("moodlewsrestformat", "json");
            pCourse.AddParameter("userid", "" + userId);

            try
            {
                JArray jCourses = JArray.Parse(pCourse.Send());
                foreach (JObject c in jCourses)
                {
                    BLL.Course course = new BLL.Course(c);
                    courses.Add(course);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }

            return courses;
        }
    }
}
