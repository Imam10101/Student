using System;
using System.Collections.Generic;

namespace Student.Models
{
    public partial class StudentInfo
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public int StudentId { get; set; }
        public string BatchId { get; set; } = null!;
        public string Round { get; set; } = null!;
    }
}
