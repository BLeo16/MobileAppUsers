using APIConsumer;
using MobileAppUsers.Models;
using MobileAppUsers.Pages;

namespace MobileAppUsers
{
    public partial class MainPage : ContentPage
    {
        //private string ApiUrl = "https://localhost:32770/api/Users";
        private string ApiUrl = "https://apiusersbleo.onrender.com/api/Users";

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
                await DisplayAlert("Error", ex.Message, "OK");
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
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

}
