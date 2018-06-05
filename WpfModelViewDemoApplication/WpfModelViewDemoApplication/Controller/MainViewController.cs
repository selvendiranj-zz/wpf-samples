using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfModelViewDemoApplication.Model;

using WpfModelViewDemoApplication.Commands;

namespace WpfModelViewDemoApplication.Controller
{
    public class MainViewController : ControllerBase
    {
        private DelegateCommand exitCommand;
        private DelegateCommand _AddStudentCommand;

        #region Constructor

        public StudentsModel Students { get; set; }
        public string StudentNameToAdd { get; set; }
        public uint StudentScoreToAdd { get; set; }

        public MainViewController()
        {
            Students = StudentsModel.Current;
        }

        #endregion

        #region Command

        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                {
                    exitCommand = new DelegateCommand(Exit);
                }
                return exitCommand;
            }
        }

        public ICommand AddStudentCommand
        {
            get
            {
                if (_AddStudentCommand == null)
                {
                    _AddStudentCommand = new DelegateCommand(AddStudent);
                }

                return _AddStudentCommand;
            }
        }

        #endregion

        #region Command Methods

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        private void AddStudent()
        {
            StudentNameToAdd.Trim();

            if (StudentNameToAdd == "")
            {
                throw new ArgumentException("Please type in a name for the student.");
            }

            if (StudentNameToAdd.Length < 10)
            {
                throw new ArgumentException("We only take students whose name is longer than 10 characters.");
            }
            if ((StudentScoreToAdd < 60) || (StudentScoreToAdd > 100))
            {
                throw new ArgumentException("We only take students whose score is between 60 and 100. please give a valid score");
            }

            DateTime Now = DateTime.Now;
            StringBuilder SB = new StringBuilder();
            SB.Append("Student ");
            SB.Append(StudentNameToAdd);
            SB.Append(" is added @ ");
            SB.Append(Now.ToString());

            Students.AddAStudent(StudentNameToAdd, StudentScoreToAdd, Now, SB.ToString());
        }

        #endregion

    }
}
