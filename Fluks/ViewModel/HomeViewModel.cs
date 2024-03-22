using Fluks.Core;

namespace Fluks.ViewModel
{
    class HomeViewModel : ObservableObject
    {
        public HomeViewModel HomeVm { get; set; }
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; } 
        }
        public HomeViewModel() { }
    }
}
