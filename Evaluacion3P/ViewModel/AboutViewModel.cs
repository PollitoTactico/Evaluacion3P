using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Evaluacion3P.ViewModel
{
    public class AboutViewModel : BaseViewModel
    {
        private string _userName;
        private string _userReason;
        private string _savedReason;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string UserReason
        {
            get => _userReason;
            set => SetProperty(ref _userReason, value);
        }

        public string SavedReason
        {
            get => _savedReason;
            set => SetProperty(ref _savedReason, value);
        }

        public ICommand SaveReasonCommand { get; }

        public AboutViewModel()
        {
            SaveReasonCommand = new Command(SaveReason);
        }

        private void SaveReason()
        {
            SavedReason = $"A mi, {UserName}, me gusta este personaje porque {UserReason}";
        }
    }
}
