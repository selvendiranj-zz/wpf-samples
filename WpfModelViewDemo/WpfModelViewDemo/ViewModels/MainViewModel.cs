using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfModelViewDemoApplication.Commands;
using WpfModelViewDemoApplication.Models;

namespace WpfModelViewDemoApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private DelegateCommand _exitCommand;
        private DelegateCommand _AddStudentCommand;

        #region Constructor

        public StudentsModel Students { get; set; }
        public string StudentNameToAdd { get; set; }
        public int StudentScoreToAdd { get; set; }


        public MainViewModel()
        {
            Students = StudentsModel.Current;
        }

        #endregion

        public ICommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                {
                    _exitCommand = new DelegateCommand(param => Exit());
                }
                return _exitCommand;
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        public ICommand AddStudentCommand
        {
            get
            {
                if (_AddStudentCommand == null)
                {
                    _AddStudentCommand = new DelegateCommand(param => AddStudent());
                }

                return _AddStudentCommand;
            }
        }

        private void AddStudent()
        {
            StudentNameToAdd.Trim();

            StringBuilder SB = new StringBuilder();
            if (StudentNameToAdd == "")
            {
                SB.Remove(0, SB.Length);
                SB.Append("Please type in a name for the student.");
                throw new ArgumentException(SB.ToString());
            }

            if (StudentNameToAdd.Length < 10)
            {
                SB.Remove(0, SB.Length);
                SB.Append("We only take students whose name is longer than ");
                SB.Append("10 characters.");
                throw new ArgumentException(SB.ToString());
            }
            if ((StudentScoreToAdd < 60) || (StudentScoreToAdd > 100))
            {
                SB.Remove(0, SB.Length);
                SB.Append("We only take students " +
                          "whose score is between 60 and 100. ");
                SB.Append("Please give a valid score");
                throw new ArgumentException(SB.ToString());
            }

            DateTime Now = DateTime.Now;
            SB.Remove(0, SB.Length);
            SB.Append("Student ");
            SB.Append(StudentNameToAdd);
            SB.Append(" is added @ ");
            SB.Append(Now.ToString());

            Students.AddAStudent(StudentNameToAdd,
                StudentScoreToAdd, Now, SB.ToString());
        }
    }
}
