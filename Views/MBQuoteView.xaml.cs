using MBaqueroPTres.ViewModels;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace MBaqueroPTres.Views
{
    public partial class MBQuoteView : ContentPage
    {
        private MBQuoteViewModel _viewModel;

        public MBQuoteView()
        {
            InitializeComponent();

            // Crear una nueva instancia de MBQuoteViewModel
            _viewModel = new MBQuoteViewModel();

            // Establecer el contexto de enlace para la vista
            BindingContext = _viewModel;
        }

        // Sobrescribir el método OnAppearing para cargar los datos cuando la vista aparezca
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Llamar al comando para cargar la cita
            await ExecuteLoadQuoteCommand();
        }

        private async Task ExecuteLoadQuoteCommand()
        {
            if (_viewModel.ComandoCargarQuote.CanExecute(null))
            {
                _viewModel.ComandoCargarQuote.Execute(null);
            }
        }
    }
}
