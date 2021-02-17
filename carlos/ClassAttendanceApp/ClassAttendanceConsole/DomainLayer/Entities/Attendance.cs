﻿namespace DomainLayer.Entities
{
    public class Attendance
    {
        public Class Class { get; private set; }
        public Student Student { get; private set; }
        public AttendanceStatus Status { get; private set; }

        public Attendance(Class @class, Student student, AttendanceStatus status)
        {
            Class = @class;
            Student = student;
            Status = status;
        }

        public void SetStatus(AttendanceStatus status)
        {
            Status = status;
        }
    }
}