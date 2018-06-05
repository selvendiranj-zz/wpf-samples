using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfModelViewDemoApplication.Model
{
    public class StudentsModel : ObservableCollection<Student>
    {
        private static object _threadLock = new Object();
        private static StudentsModel current = null;

        public static StudentsModel Current
        {
            get
            {
                lock (_threadLock)
                if (current == null)
                    {
                        current = new StudentsModel();
                    }
                return current;
            }
        }

        private StudentsModel()
        {

            Random rd = new Random();
            for (int Idex = 1; Idex <= 5; Idex++)
            {
                string Name = "Student Name No. " + Idex.ToString();
                uint Score = System.Convert.ToUInt16(60 + rd.NextDouble() * 40);
                DateTime TimeAdded = System.DateTime.Now;
                string Comment = "This student is added @ " + TimeAdded.ToString();

                Student aStudent = new Student(Name, Score, TimeAdded, Comment);
                Add(aStudent);
            }
        }

        public void AddAStudent(String Name, uint Score, DateTime TimeAdded, string Comment)
        {
            Student aNewStudent = new Student(Name, Score, TimeAdded, Comment);
            Add(aNewStudent);
        }
    }
}
