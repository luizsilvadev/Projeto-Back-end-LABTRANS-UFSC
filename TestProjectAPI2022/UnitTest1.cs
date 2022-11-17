using Entities.Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace TestProjectAPI2022
{
    [TestClass]
    public class UnitTest1
    {

        public static string Token { get; set; }

        [TestMethod]
        public async Task TestMethod1()
        {
            var result = await ChamaApiPost("https://localhost:7197/api/ListBooking");

            var listaMessage = JsonConvert.DeserializeObject<Booking[]>(result).ToList();

            Assert.IsTrue(listaMessage.Any());
        }

        public async Task GetToken()
        {

            string urlApiGeraToken = "https://localhost:7197/api/CreateTokenIdentity";

            using (var cliente = new HttpClient())
            {
                string login = "luizprofissional@hotmail.com";
                string senha = "@DevNetCore123";
                var dados = new
                {
                    email = login,
                    senha = senha,
                    cpf = "string"
                };
                string JsonObjeto = JsonConvert.SerializeObject(dados);

                var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");

                var resultado = await cliente.PostAsync(urlApiGeraToken, content);

                if (resultado.IsSuccessStatusCode)
                {
                    var tokenJson = await resultado.Content.ReadAsStringAsync();
                    Token = JsonConvert.DeserializeObject(tokenJson).ToString();
                }

            }
        }

        public async Task<string> ChamaApiGet(string url)
        {
            await GetToken(); // Gerar token
            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var response = await cliente.GetStringAsync(url);

                    return response;
                }
            }

            return null;

        }

        public async Task<string> ChamaApiPost(string url, object dados = null)
        {

            string JsonObjeto = dados != null ? JsonConvert.SerializeObject(dados) : "";
            var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");

            await GetToken(); // Gerar token
            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var response = await cliente.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = await response.Content.ReadAsStringAsync();

                        return retorno;
                    }
                }
            }

            return null;

        }

    }
}