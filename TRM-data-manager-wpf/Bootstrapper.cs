using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TRM_data_manager_wpf.Helpers;
using TRM_data_manager_wpf.Library.Api;
using TRM_data_manager_wpf.Library.Models;
using TRM_data_manager_wpf.ViewModels;

namespace TRM_data_manager_wpf
{
    // set up caliburn micro
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }
        protected override void Configure()
        {
            // simple container를 요청하면 자기 자신의 instance를 보낸다.
            _container.Instance(_container);

            // 윈도우를 관리 + event 메시지를 듣고 pass 하는 클래스를 하나의 인스턴스로 관리한다. 실제 DI를 하는 부분.
            _container
                .Singleton<IWindowManager,WindowManager>()
                .Singleton<IEventAggregator,EventAggregator>()
                .Singleton<ILoggedInUserModel, LoggedInUserModel>()
                .Singleton<IAPIHelper, APIHelper>();

            // 애플리케이션의 모든 type을 받아온 뒤 class 타입이면서 ViewModel로 끝나는 이름을 가지는 것만 List로 만든다.
            // List가 되었으니 foreach를 이용해 지금 내 컨테이너에 요청이 들어올 때마다 인터페이스를 만들고 연결한다.
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }
        protected override void OnStartup(object sender,StartupEventArgs e)
        {
            // view가 아닌 view model. 캘리번이 자동으로 이어준다.
            DisplayRootViewFor<ShellViewModel>();
        }
        protected override object GetInstance(Type service,string key)
        {
            return _container.GetInstance(service,key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
