using APIConsumer;
using MobileAppUsers.Models;

namespace MobileAppUsers.Pages;

public partial class SignUp : ContentPage
{
    private string ApiUrl = "https://apiusersbleo.onrender.com/api/Users";
    public SignUp()
	{
		InitializeComponent();
	}

    private void cmdBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private async void cmdSignUp_Clicked(object sender, EventArgs e)
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
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}