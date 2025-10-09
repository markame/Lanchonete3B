using Lanchonete3B.Views;
namespace Lanchonete3B

{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }



        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new Sobre());
        }


        private void entrarbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Principal());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Usuario());
        }
    }
}
