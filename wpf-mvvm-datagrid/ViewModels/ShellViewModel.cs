using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_datagrid.Models;

namespace wpf_mvvm_datagrid.ViewModels
{
    public class ShellViewModel : Screen
    {
        // BindableCollection: 리스트 내용이 업데이트 되면 반영한다.
        public BindableCollection<PersonModel> People { get; set; }

        public ShellViewModel()
        {
            DataAccess da = new DataAccess();
            // 맨 처음 시작부터 데이터를 받아오기 위함
            People = new BindableCollection<PersonModel>(da.GetPeople());
        }
    }
}
