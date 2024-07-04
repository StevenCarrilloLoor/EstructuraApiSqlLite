using MBaqueroPTres.Models;
using MBaqueroPTres.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MBaqueroPTres.ViewModels
{
    public class MBQuoteViewModel : INotifyPropertyChanged
    {
        private MBQuote _model;
        public MBQuote Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        public ICommand ComandoCargarQuote { get; }
        public ICommand ComandoGuardarQuote { get; }
        public ICommand ComandoEliminarQuote { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        //Constructor
        public MBQuoteViewModel()
        {
            Model = new MBQuote();

            ComandoCargarQuote = new Command(async () => await CargarQuote());

        }
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Método para cargar una cita desde la API
        private async Task CargarQuote()
        {
            BreakingBadRepo repo = new BreakingBadRepo("BRBA.DB");

            List<MBQuote> quotes = await repo.RetornaQuotesBRBA();
            MBQuote quote = quotes.FirstOrDefault();
            if (quote != null)
            {
                Model.quote = quote.quote;
                Model.author = quote.author;
            }

            OnPropertyChanged(nameof(Model));
        }

        // Método para borrar una cita de la base de datos SQLite
        private async Task EliminarQuote(MBQuote quote)
        {
            if (quote != null)
            {

            }
        }
    }
}
