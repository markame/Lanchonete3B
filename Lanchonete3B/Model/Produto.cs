using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json; 
using System.Threading.Tasks;
using System.Text.Json;

namespace Lanchonete3B.Model
{
    public  class Produto
    {
        private const string BaseUrl = "https://minioapi.doppelganger.com.br/cactus-image/";
        private readonly HttpClient _httpClient;

        private int id;
        private string nome;
        private string descricao;
        private decimal preco;
        private int ativo;
        private string imagem;



        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public decimal Preco { get => preco; set => preco = value; }
        public int Ativo { get => ativo; set => ativo = value; }
        public string Imagem { get => imagem; set => imagem = value; }

        public string ImagemUrl => $"{BaseUrl}{Imagem}";


        public Produto()
        {
            _httpClient = new HttpClient();
        }


        public async Task<ObservableCollection<Produto>> getAllProduto(string endPoint)
        {
            try
            {
                var produtos = await _httpClient.GetFromJsonAsync<ObservableCollection<Produto>>(endPoint);
                return produtos ?? new ObservableCollection<Produto>();

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao obter produtos: {ex.Message}");
                return new ObservableCollection<Produto>();
            }
        }



        public async Task<bool> addNewProduto(Produto produto)
        {
            try
            {
                var json = JsonSerializer.Serialize(produto);
                var content = new StringContent(json, Encoding.UTF8,"application/json");
                var response = await _httpClient.PostAsync("produtos",content);
                return response.IsSuccessStatusCode;
            }catch(Exception e)
            {
                Console.WriteLine($"Erro{e.Message}");
                return false;
            }
        }
    }
}
