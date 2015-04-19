using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Moodle.BLL
{
    public class Grade
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AttemptNumber { get; set; }
        public DateTime TimeModified { get; set; }
        public int Grader { get; set; }
        public string Score { get; set; }

        public Grade(JObject jSon)
        {
            this.Id = Convert.ToInt32((string)jSon["id"]);
            this.UserId = Convert.ToInt32((string)jSon["userid"]);
            this.AttemptNumber = Convert.ToInt32((string)jSon["attemptnumber"]);
            int unixTimeModified = Convert.ToInt32((string)jSon["timemodified"]);
            this.TimeModified = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimeModified);
            this.Grader = Convert.ToInt32((string)jSon["grader"]);
            this.Score = (string)jSon["grade"];
        }
    }

    public class Assignment
    {
        public int Id { get; set; }    //assignment id
        public int Course { get; set; }    //course id
		public string Name { get; set; }  //assignment name
		public int DueDate { get; set; }    //assignment due date
		public int AllowSubmissionsFromDate { get; set; }    //allow submissions from date
		public int Grade { get; set; }    //grade type
		public int TimeModified { get; set; }    //last time assignment was modified
		public int CutOffDate { get; set; }   //date after which submission is not accepted without an extension
		public int MaxAttempts { get; set; }    //maximum number of attempts allowed

        public Assignment(JObject jSon)
        {
            this.Id = Convert.ToInt32(jSon["id"]);
            this.Course = Convert.ToInt32(jSon["course"]);
            this.Name = (string)jSon["name"];
            this.DueDate = Convert.ToInt32( jSon["duedate"]);
            this.AllowSubmissionsFromDate = Convert.ToInt32( (string)jSon["allowsubmissionsfromdate"]);
            this.Grade = Convert.ToInt32( (string)jSon["grade"]);
            this.TimeModified = Convert.ToInt32( (string)jSon["timemodified"]);
            this.CutOffDate = Convert.ToInt32( (string)jSon["cutoffdate"]);
            this.MaxAttempts = Convert.ToInt32( (string)jSon["maxattempts"]);
        }
    }

    public class CalendarEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public string CourseId { get; set; }
        public string GroupId { get; set; }
        public string RepeatId { get; set; }
        public string Modulename { get; set; }
        public string Instance { get; set; }
        public string Eventtype { get; set; }
        public DateTime TimeStart { get; set; }
        public string TimeDuration { get; set; }
        public string Visible { get; set; }
        public string Uuid { get; set; }
        public string Sequence { get; set; }
        public string TimeModified { get; set; }
        public string SubscriptionId { get; set; }

        public CalendarEvent(JObject jObject)
        {
            this.Id = (string)jObject["id"];
            this.Name = (string)jObject["name"];
            this.Description = (string)jObject["description"];
            this.Format = (string)jObject["format"];
            this.CourseId = (string)jObject["courseid"];
            this.GroupId = (string)jObject["groupid"];
            this.RepeatId = (string)jObject["repeatid"];
            this.Modulename = (string)jObject["modulename"];
            this.Instance = (string)jObject["instance"];
            this.Eventtype = (string)jObject["eventtype"];
            string unixStamp = (string)jObject["timestart"];
            this.TimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Convert.ToDouble(unixStamp));
            this.TimeDuration = (string)jObject["timeduration"];
            this.Visible = (string)jObject["visible"];
            this.Uuid = (string)jObject["uuid"];
            this.Sequence = (string)jObject["sequence"];
            this.TimeModified = (string)jObject["timemodified"];
            this.SubscriptionId = (string)jObject["subscriptionid"];
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} \r\n Info:  {2} \r\n  Deadline: {3} {4}", Id, Name, Description, TimeStart.ToLongDateString(), TimeStart.ToShortTimeString());
        }
    }

    public class Course
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }

        public Course(JObject jSon)
        {
            this.Id = Convert.ToInt32(jSon["id"]);
            this.ShortName = (string)jSon["shortname"];
            this.FullName = (string)jSon["fullname"];
        }
    }
}
