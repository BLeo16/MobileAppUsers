using APIConsumer;
using MobileAppUsers.Models;
using MobileAppUsers.Pages;
using MobileAppUsers.Utilities;

namespace MobileAppUsers
{
    public partial class MainPage : ContentPage
    {
        private string ApiUrl = APIConstants.ApiUrl;

        public MainPage()
        {
            InitializeComponent();
        }
        private async void cmdLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.username = txtUsername.Text;
                user.password = txtPassword.Text;

                var result = await Crud<User>.Login(ApiUrl, user); // Esperar la tarea

                if (result != null)
                {
                    await DisplayAlert("Success", "Login Successful", "OK");

                    var homePage = new Home(result);
                    await Navigation.PushAsync(homePage);
                }
                else
                {
                    await DisplayAlert("Error", "Login Failed", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Login Failed", "OK");
            }
        }

        private async void cmdRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
               var signUpPage = new SignUp();
                await Navigation.PushAsync(signUpPage);

            }catch(Exception ex)
            {
                await DisplayAlert("Error", null, "OK");
            }
        }
    }

}
