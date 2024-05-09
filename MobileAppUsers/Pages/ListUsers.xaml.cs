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

    private void btnCreate_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreatePage());
    }
}