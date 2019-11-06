using Caliburn.Micro;
using System.Windows;
using wpf_mvvm_practice.ViewModels;

namespace wpf_mvvm_practice
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
