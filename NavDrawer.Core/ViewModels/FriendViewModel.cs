using MvvmCross.Core.ViewModels;

namespace NavDrawer.Core.ViewModels
{
    public class FriendViewModel 
        : MvxViewModel
    {
        private string _hello = "MobileX";
        public string Hello
        { 
            get { return _hello; }
            set { SetProperty (ref _hello, value); }
        }
    }
}
