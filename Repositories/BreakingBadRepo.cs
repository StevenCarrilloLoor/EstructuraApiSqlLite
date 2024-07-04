using MBaqueroPTres.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MBaqueroPTres.Repositories
{
    public class BreakingBadRepo
    {
        public string _dbPath;
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<MBQuote>();
        }

        //Constructor
        public BreakingBadRepo(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<MBQuote> RetonaListadoQuotes()
        {
            return conn.Table<MBQuote>().ToList();
        }

        // Método para guardar la cita en la base de datos SQLite
        public void GuardarQuote(MBQuote quote)
        {
            conn.Insert(quote);
        }

        public void EliminarQuote(MBQuote quote)
        {
            conn.Delete(quote);
        }

        public async Task<List<MBQuote>> RetornaQuotesBRBA()
        {
            HttpClient client = new HttpClient();
            string url = "https://api.breakingbadquotes.xyz/v1/quotes/5";
            var response = client.GetAsync(url);
            string response_json = await response.Result.Content.ReadAsStringAsync();

            List<MBQuote> mBQuotes = JsonConvert.DeserializeObject<List<MBQuote>>(response_json);

            return mBQuotes;
        }
    }
}
