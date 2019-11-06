using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_combobox.Models;

namespace wpf_mvvm_combobox.ViewModels
{
    public class ShellViewModel : Screen
    {
        // BindableCollection: 리스트 내용이 업데이트 되면 반영한다.
        public BindableCollection<PersonModel> People { get; set; }

        private PersonModel _selectedPerson;

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set 
            { 
                _selectedPerson = value;
                // 선택한 주소를 해당 person에 계속 정해두고 싶다면 39라인에 추가로 여기까지 정의해준다.
                SelectedAddress = value.PrimaryAddress;
                NotifyOfPropertyChange(() => SelectedPerson );
            }
        }

        private AddressModel _seletedAddress;

        public AddressModel SelectedAddress
        {
            get { return _seletedAddress; }
            set
            {
                _seletedAddress = value;
                // set 할 때만 정의된다.
                SelectedPerson.PrimaryAddress = value;
                NotifyOfPropertyChange(() => SelectedAddress);
            }

        }

        public ShellViewModel()
        {
            DataAccess da = new DataAccess();
            People = new BindableCollection<PersonModel>(da.GetPeople());
        }
    }
}
