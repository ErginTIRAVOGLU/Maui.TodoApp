using MauiTodoApp.Mobile.Pages;

namespace MauiTodoApp.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ManageToDoPage), typeof(ManageToDoPage));
        }
    }
}
