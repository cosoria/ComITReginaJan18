﻿using System;
using System.Collections.Generic;

namespace Domain
{
    public class Class : Entity
    {

        private readonly List<Topic> _topics = new List<Topic>();
        private readonly List<Attendance> _attendance = new List<Attendance>();

        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public virtual IReadOnlyList<Topic> Topics => _topics;

        // public virtual IReadOnlyList<Attendance> Attendance => _attendance;
        public virtual Course Course { get; private set; }

        protected Class()
        {
        }

        public Class(int id, string title, DateTime startDate, IEnumerable<Topic> topics, Course course) : base(id)
        {
            Title = title;
            StartDate = startDate;
            _topics.AddRange(topics);
            Course = course;
        }

        public Class(string title, DateTime startDate, IEnumerable<Topic> topics, Course course) 
            : this(0, title, startDate, topics, course)
        {
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