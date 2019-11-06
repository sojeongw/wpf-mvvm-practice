using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_practice.Models;

namespace wpf_mvvm_practice.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Wang";
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<Models.PersonModel>();
        // one individual person who are selected
        private PersonModel _selectedPerson;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Tim",LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "Sojeong",LastName = "Wang" });
            People.Add(new PersonModel { FirstName = "Sue",LastName = "Storm" });
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                // 이 부분까지 해줘야 textbox 내용에 따라 변경됨
                NotifyOfPropertyChange(() => FirstName);
                // FirstName이 바뀌면 full도 바뀜
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        // public bool CanClearText(string firstName, string lastName) => !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);
        // more readable
        public bool CanClearText(string firstName,string lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearText(string firstName,string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
    }
}
