using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.BaseViewControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BaseActivityIndicator : Frame
	{
		public BaseActivityIndicator ()
		{
			InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                CornerRadius = 5;
                BackgroundColor = Color.LightGray;
            }
        }
	}
}