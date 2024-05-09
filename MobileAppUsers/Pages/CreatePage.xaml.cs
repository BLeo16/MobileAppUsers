using APIConsumer;
using MobileAppUsers.Models;

namespace MobileAppUsers.Pages;

public partial class CreatePage : ContentPage
{
    private string ApiUrl = "https://apiusersbleo.onrender.com/api/Users";
    public CreatePage()
	{
		InitializeComponent();
	}

	private void btnBack_Clicked(object sender, EventArgs e)
	{
        Navigation.PopAsync();
    }
	private async void btnCreate_Clicked(object sender, EventArgs e)
	{
        try
		{
            User user = new User();
            user.username = txtUsername.Text;
            user.password = txtPassword.Text;

            var result = await Crud<User>.Create(ApiUrl, user);
            if (result != null)
			{
                await DisplayAlert("Success", "User created", "OK");

            }
            else
            {
                await DisplayAlert("Error", "User already exists", "OK");
            }

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error",
    "Username must be unique [5-10 characters]\nPassword must be between 8 and 15 characters.",
    "OK");

        }
    }
}