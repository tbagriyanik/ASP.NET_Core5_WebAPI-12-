using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace apiKullan.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string gelen { get; set; } = "-ilk-";

        private const string istekSitesi = "https://localhost:44354/api/hesaplama/"; //sonda / olsun
        static HttpClient client = new HttpClient();

        public static async Task<string> getir1()
        {
            HttpResponseMessage response = await client.GetAsync(istekSitesi);
            HttpContent content = response.Content;
            var sonuc = await content.ReadAsStringAsync();
            return sonuc;
        }

        public static async Task<string> getir2(string indisi)
        {
            HttpResponseMessage response = await client.GetAsync(istekSitesi + indisi);
            HttpContent content = response.Content;

            var sonuc = await content.ReadAsStringAsync();
            return sonuc;
        }

        public static async Task<string> getir3(string a, string b)
        {
            HttpResponseMessage response = await client.GetAsync(istekSitesi + a + "/" + b);
            HttpContent content = response.Content;

            var sonuc = await content.ReadAsStringAsync();
            return sonuc;
        }

        public void OnGet()
        {
            gelen = "Hoşgeldiniz";
        }

        public void OnGetTumu()
        {
            var sonuc = getir1();
            Task.WaitAll(sonuc);
            gelen = sonuc.Result.ToString();
        }

        public void OnPostListeden()
        {
            if (Request.Form["indis"] != "")
            {
                var sonuc = getir2(Request.Form["indis"]);
                Task.WaitAll(sonuc);
                gelen = sonuc.Result.ToString();
            }
            else
            {
                gelen = "Boş giriş yapıldı! (1)";
            }
        }

        public void OnPostHesapla()
        {
            if (Request.Form["a"] != "" || Request.Form["b"] != "")
            {
                var sonuc = getir3(Request.Form["a"], Request.Form["b"]);
                Task.WaitAll(sonuc);
                gelen = sonuc.Result.ToString();
            }
            else
            {
                gelen = "Boş giriş yapıldı! (2)";
            }
        }
    }
}
