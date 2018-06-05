using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfModelViewDemoApplication.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime TimeAdded { get; set; }
        public string Comment { get; set; }

        public Student(string Name, int Score, DateTime TimeAdded, string Comment)
        {
            this.Name = Name;
            this.Score = Score;
            this.TimeAdded = TimeAdded;
            this.Comment = Comment;
        }
    }
}
