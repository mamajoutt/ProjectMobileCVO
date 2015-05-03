using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Moodle.BLL
{

    public class Deadline
    {
        public DateTime Date { get; set; }
        public List<Moodle.BLL.Assignment> Assignments { get; set; }

        public Deadline()
        {
            Assignments = new List<Assignment>();
        }
    }

    public class Assignment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
		public string Name { get; set; }  
        public DateTime DueDate { get; set; }
        public DateTime AllowSubmissionsFromDate { get; set; }
		public int MaxGrade { get; set; }
        public DateTime TimeModified { get; set; }
		public DateTime CutOffDate { get; set; }
		public int MaxAttempts { get; set; }
        public string UserScore { get; set; } 

        public Assignment(JObject jSon)
        {
            this.Id = Convert.ToInt32(jSon["id"]);
            this.CourseId = Convert.ToInt32(jSon["course"]);
            this.Name = (string)jSon["name"];
            int unixTimeDueDate = Convert.ToInt32((string)jSon["duedate"]);
            this.DueDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimeDueDate);
            int unixTimeAllowSubmissionsFromDate = Convert.ToInt32((string)jSon["duedate"]);
            this.AllowSubmissionsFromDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimeAllowSubmissionsFromDate);
            this.MaxGrade = Convert.ToInt32((string)jSon["grade"]);
            int unixTimeTimeModified = Convert.ToInt32((string)jSon["duedate"]);
            this.TimeModified = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimeTimeModified);
            int unixTimeCutOffDate = Convert.ToInt32((string)jSon["cutoffdate"]);
            this.CutOffDate = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimeCutOffDate);
            this.MaxAttempts = Convert.ToInt32( (string)jSon["maxattempts"]);
        }
    }

    public class Course
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<Moodle.BLL.Assignment> Assignments { get; set; }

        public Course(JObject jSon)
        {
            this.Id = Convert.ToInt32(jSon["id"]);
            this.ShortName = (string)jSon["shortname"];
            this.FullName = (string)jSon["fullname"];
        }
    }
}
