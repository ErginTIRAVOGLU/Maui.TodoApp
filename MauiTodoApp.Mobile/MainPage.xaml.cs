using MauiTodoApp.Mobile.DataServices;
using MauiTodoApp.Mobile.Models;
using MauiTodoApp.Mobile.Pages;
using System.Diagnostics;

namespace MauiTodoApp.Mobile
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestDataService _dataservice;


        public MainPage(IRestDataService dataService)
        {
            InitializeComponent();
            _dataservice = dataService;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await _dataservice.GetAllTodosAsync();
        }

        async void OnAddToDoClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("---> Add button clicked");
            var navigateParameter = new Dictionary<string, object>
            {
                { nameof(ToDo), new ToDo() }
            };

            await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigateParameter);
        }
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("---> Add changed clicked");
            var navigateParameter = new Dictionary<string, object>
            {
                { nameof(ToDo), e.CurrentSelection.FirstOrDefault() as ToDo }
            };

            await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigateParameter);
        }

    }

}
