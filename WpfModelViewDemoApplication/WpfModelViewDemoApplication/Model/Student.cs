using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfModelViewDemoApplication.Model
{
    public class Student
    {
        public string Name { get; set; }
        public uint Score { get; set; }
        public DateTime TimeAdded { get; set; }
        public string Comment { get; set; }

        public Student()
        {
            this.Name = string.Empty;
            this.Score = uint.MinValue;
            this.TimeAdded = DateTime.Now;
            this.Comment = string.Empty;
        }

        public Student(string Name, uint Score, DateTime TimeAdded, string Comment)
        {
            this.Name = Name;
            this.Score = Score;
            this.TimeAdded = TimeAdded;
            this.Comment = Comment;
        }
    }
}
