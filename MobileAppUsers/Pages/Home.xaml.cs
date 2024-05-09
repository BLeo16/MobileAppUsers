using APIConsumer;
using MobileAppUsers.Models;

namespace MobileAppUsers.Pages;

public partial class Home : ContentPage
{
    private string ApiUrl = "https://apiusersbleo.onrender.com/api/Users";
    private User LoggedInUser { get; set; }

    public Home(User loggedInUser)
    {
        InitializeComponent();
        LoggedInUser = loggedInUser;
        ShowUsername();
    }

    private void ShowUsername()
    {
        lblUserLogged.Text = $"Welcome, {LoggedInUser.username}!";
    }
    private async void BtnLogout_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void BtnListUsers_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListUsers());
    }

    private async void BtnSearch_Clicked(object sender, EventArgs e)
    {
        try
        {

            string username = txtSearch.Text;


            if (string.IsNullOrEmpty(username))
            {
                await DisplayAlert("Error", "Please enter a username.", "OK");
                return;
            }


            User user = await Crud<User>.Read_byName(ApiUrl, username);


            if (user != null)
            {

                lblUserId.Text = user.id.ToString();
                lblUsername.Text = user.username;


                userInfoLayout.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Error", "User not found.", "OK");

                lblUserId.Text = string.Empty;
                lblUsername.Text = string.Empty;
                userInfoLayout.IsVisible = false;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
    private async void BtnEdit_Clicked(object sender, EventArgs e)
    {

        int userId = Convert.ToInt32(lblUserId.Text);
        await Navigation.PushAsync(new EditPage(userId));
        lblUserId.Text = string.Empty;
        lblUsername.Text = string.Empty;
        userInfoLayout.IsVisible = false;
    }

    private async void BtnDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            
            int userId = Convert.ToInt32(lblUserId.Text);

            await Crud<User>.Delete(ApiUrl, userId);

            await DisplayAlert("Success", "User deleted successfully", "OK");

            lblUserId.Text = string.Empty;
            lblUsername.Text = string.Empty;
            userInfoLayout.IsVisible = false;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

}