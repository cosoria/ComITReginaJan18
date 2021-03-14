using System;
using System.Collections.Generic;

namespace ClassAttendance.Domain
{
    public class Class : IEntity
    {

        private readonly List<Topic> _topics = new List<Topic>();
        private readonly List<Attendance> _attendance = new List<Attendance>();

        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public IReadOnlyList<Topic> Topics => _topics;
        public IReadOnlyList<Attendance> Attendance => _attendance;
        public Course Course { get; private set; }

        public Class(int id, string title, DateTime startDate, IEnumerable<Topic> topics, Course course)
        {
            Id = id;
            Title = title;
            StartDate = startDate;
            _topics.AddRange(topics);
            Course = course;
        }

        public void StartClass()
        {
            foreach (var student in Course.Students)
            {
                _attendance.Add(new Attendance(this, student, AttendanceStatus.Unknown));
            }
        }

        public void AddAttendance(Attendance attendance)
        {
            _attendance.Add(attendance);
        }

        public void UpdateAttendance(Attendance attendance)
        {
            var target = _attendance.Find(a => a.Student.LastName == attendance.Student.LastName);
            
            if (target == null)
            {
                throw new InvalidOperationException("Student was not found");
            }

            target.SetStatus(attendance.Status);
        }

        public void AddTopic(Topic topic)
        {
            if (topic == null)
            {
                throw new ArgumentNullException("topic");
            }

            if (SystemTime.Now <= StartDate)
            {
                _topics.Add(topic);
            }
        }

        public void RemoveTopic(Topic topic)
        {
            if (topic == null)
            {
                throw new ArgumentNullException("topic");
            }

            if (SystemTime.Now > StartDate)
            {
                throw new InvalidOperationException("this class has already happen, can not change the past");
            }

            _topics.Remove(topic);
        }

        public string PrintSummary()
        {
            return Title;
        }

        public string PrintDetails()
        {
            return $"{Title} Start:{StartDate}";
        }

        public override string ToString()
        {
            return PrintSummary();
        }
    }
}