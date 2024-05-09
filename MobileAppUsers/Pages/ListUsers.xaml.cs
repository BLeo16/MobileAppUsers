using APIConsumer;
using MobileAppUsers.Models;

namespace MobileAppUsers.Pages;

public partial class ListUsers : ContentPage
{
    private string ApiUrl = "https://apiusersbleo.onrender.com/api/Users";
    public ListUsers()
	{
		InitializeComponent();

	}

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadUsers();
    }

    private async Task LoadUsers()
    {
        try
        {
            // Clear existing children
            UsersStackLayout.Children.Clear();

            var users = await Crud<User>.Read(ApiUrl);
            foreach (var user in users)
            {
                var labelId = new Label { Text = user.id.ToString() };
                var label = new Label { Text = user.username };
                UsersStackLayout.Children.Add(labelId);
                UsersStackLayout.Children.Add(label);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void btnCreate_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreatePage());
    }
}