using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRM_data_manager_wpf.EventModels;

namespace TRM_data_manager_wpf.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent> // 1. listen할 이벤트를 명시한다.
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private SimpleContainer _container;
        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, SimpleContainer container)
        {
            _events = events;
            // 2. 현재 클래스의 인스턴스를 subscribe. IEventAggregator가 이벤트가 발생하면 모든 subscriber에게 알려준다.
            _events.Subscribe(this);    

            _salesVM = salesVM;

            // bootstrapper에서 DI 설정된 container를 가져오면 새로운 인스턴스를 요청할 수 있다.
            _container = container;

            // 로그인할 때마다 container를 가져와 새로운 인스턴스를 덮어씌운다.
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        // 3. LogOnEvent 이벤트가 발생하면 handle 메서드를 실행한다.
        public void Handle(LogOnEvent message)
        {
            // salesView를 호출한다고 해서 loginView를 destroy 하지 않음. 이 클래스에 _loginVM 인스턴스가 존재하기 때문.
            // 이 말은 즉 login view로 다시 돌아가면 아이디와 비밀번호가 그대로 남는다는 뜻이다.
            // _loginVM을 new로 초기화 하는 건 좋지 못한 방법이다. DI를 제대로 활용하는 것이 아니다.
            ActivateItem(_salesVM);
        }

    }
}
