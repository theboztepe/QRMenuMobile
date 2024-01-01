using QRMenuMobile.DataServices;
using QRMenuMobile.Models;

namespace QRMenuMobile
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestDataServices _restDataServices;
        public MainPage(IRestDataServices restDataServices)
        {
            InitializeComponent();

            _restDataServices = restDataServices;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            string QRCode = "186DEAFD6C274C789A1F2A7D80B532A3";
            var QRMenu = await _restDataServices.GetQRMenu(QRCode);
            if (QRMenu.Success)
            {
                collectionView.ItemsSource = QRMenu.Data.Root;
            }
            else
            {
                collectionView.ItemsSource = new List<Root>();
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
