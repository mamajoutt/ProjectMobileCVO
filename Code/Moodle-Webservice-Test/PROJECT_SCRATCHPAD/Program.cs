using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Json;
using Newtonsoft.Json.Linq;
using Moodle;

namespace PROJECT_SCRATCHPAD
{

   

    class Program
    {

        static void Main(string[] args)
        {
            string url = "moodle-cvomobile.rhcloud.com";

            // Get token
            string token = Moodle.Model.RequestTokenForService(url, "cvomobile", "Boerderijm1n#s", "mobile");

            Console.WriteLine("Token: " + token);

            // Get user Id using email
                Console.Write("email: ");
                string email = Console.ReadLine();

                int userid = Moodle.Model.GetUserIdByEmail(url, token, email);
                Console.WriteLine("userid:" + userid);

            // get Courses user is enrolled in

                List<Moodle.BLL.Course> enrolledCourses = Moodle.DAL.Course.GetUserEnrolledCourses(url, token, userid);

                foreach (Moodle.BLL.Course c in enrolledCourses)
                {
                    Console.WriteLine(c.Id + ": " + c.FullName + " (" + c.ShortName + ")");

                    foreach (Moodle.BLL.Assignment ass in Model.AssingmentSelectAll(url, token, c.Id))
                    {
                        //CalendarEvent c = new CalendarEvent(assignment);
                        Console.WriteLine(ass.Id + ": " + ass.Name);

                        //all scores
                        /*foreach (Moodle.BLL.Grade grade in Model.GradeSelectAll(url, token, ass.Id))
                        {
                            Console.WriteLine(grade.UserId + ": " + grade.Score);
                        }*/

                        //only scores of user
                        string userGrade = Model.GradeSelectOne(url, token, ass.Id, userid);

                        Console.WriteLine("Your score: " + (!userGrade.Equals("-1") ? userGrade : "No score yet"));
                        Console.WriteLine();
                    }

                }
            Console.Read();
        }
    }
}
