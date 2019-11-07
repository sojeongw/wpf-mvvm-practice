using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_itemscontrol.Models;

namespace wpf_mvvm_itemscontrol.ViewModels
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

        public void AddPerson()
        {
            DataAccess dataAccess = new DataAccess();
            int maxId = 0;

            // DataAccess 있는 people의 리스트 중 가장 큰 id를 불러옴
            if (People.Count > 0)
            {
                maxId = People.Max(x => x.PersonId); 
            }

            // 새로운 person을 추가함
            People.Add(dataAccess.GetPerson(maxId + 1));
        }

        public void RemovePerson()
        {
            DataAccess dataAccess = new DataAccess();

            // 지울 사람이 없으면 아무 것도 하지 않음
            if (People.Count == 0)
            {
                return;
            }
            // 현재 출력된 people 중 랜덤으로 뽑아 삭제
            PersonModel randomPerson = dataAccess.GetRandomItem(People.ToArray());
            People.Remove(randomPerson);
        }
    }
}
