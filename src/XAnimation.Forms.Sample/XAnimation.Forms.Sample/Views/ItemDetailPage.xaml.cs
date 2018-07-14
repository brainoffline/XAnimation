using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAnimation.Forms.Sample.Models;
using XAnimation.Forms.Sample.ViewModels;

namespace XAnimation.Forms.Sample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        private readonly ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text        = "Item 1",
                Description = "This is an item description."
            };

            viewModel      = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}
