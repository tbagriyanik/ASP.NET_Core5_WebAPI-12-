using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hesaplamaController : ControllerBase
    {
        public string[] hepsi = new string[] { "birinci", "ikinci", "üçüncü" };


        [HttpGet]
        public string[] TumListe()
        {
            return hepsi;
        }

        [HttpGet("{sira}")]
        public string BiriniGetir(string sira)
        {
            int gelen;
            if (int.TryParse(sira, out gelen))
            {
                if (gelen >= 0 && gelen < 3) return hepsi[gelen];
            }

            return "Sayısal girilmedi veya eleman bulunamadı!";
        }

        [HttpGet("{a}/{b}")]
        public string Ekle(string a, string b)
        {
            float sonuc1, sonuc2;
            if (float.TryParse(a, out sonuc1) && float.TryParse(b, out sonuc2))
            {
                float sonuc = sonuc1 + sonuc2;
                return sonuc.ToString();
            }
            else
            {
                return "Sayısal girilmedi!";
            }
        }
    }
}
