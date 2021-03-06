/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ParisCoffee.Droid"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ParisCoffee.Core;

namespace ParisCoffee.Droid.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
		private ListViewModel _listViewModel;

		public ListViewModel ListViewModel {
			get{ return _listViewModel = _listViewModel ?? ServiceLocator.Current.GetInstance<ListViewModel> (); }
		}

		private DetailViewModel _detailViewModel;

		public DetailViewModel DetailViewModel {
			get{ return _detailViewModel = _detailViewModel ?? ServiceLocator.Current.GetInstance<DetailViewModel> (); }
		}

		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator ()
		{
			ServiceLocator.SetLocatorProvider (() => SimpleIoc.Default);


			SimpleIoc.Default.Register<IDbProvider, DbProvider> ();
			SimpleIoc.Default.Register<IApiClientFactory, ApiClientFactory> ();
			SimpleIoc.Default.Register<ICoffeeShopService, CoffeeShopService> ();
			SimpleIoc.Default.Register<IFavoriteService, FavoriteService> ();


			SimpleIoc.Default.Register<ListViewModel> ();
		}


        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}