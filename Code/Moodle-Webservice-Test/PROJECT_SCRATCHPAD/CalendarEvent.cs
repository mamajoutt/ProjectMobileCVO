using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PROJECT_SCRATCHPAD
{
    class CalendarEvent
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
}
