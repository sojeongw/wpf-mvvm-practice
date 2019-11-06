using Caliburn.Micro;
using System.Windows;
using wpf_mvvm_combobox.ViewModels;

namespace wpf_mvvm_combobox
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
