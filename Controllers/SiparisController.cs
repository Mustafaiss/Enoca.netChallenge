using Azure.Core;
using Enoca.netChallenge.Entities;
using Enoca.netChallenge.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Enoca.netChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly DataContext _context;

        public SiparisController(DataContext context)
        {
            _context = context;
        }
        //Siparisleri Listeleme 
        [HttpGet]
        public async Task<ActionResult<List<Siparis>>> Get()
        {
            return Ok(await _context.Siparis.ToListAsync());
        }
        //Siparisleri id ile Listeleme 
        [HttpGet("{id}")]
        public async Task<ActionResult<Siparis>> Get(int id)
        {
            var Siparisbul = await _context.Siparis.FindAsync(id);
            if (Siparisbul == null)
                return BadRequest("Siparis Bulunamadı");

            return Ok(Siparisbul);
        }
        /*ÖNEMLİ KISIM: Siparişler öncelikle olarak Firma varlığı kontrolü ve Urun varlığı kontrolü vardır
         * Hata döngüsü ile uyarılar net verilmiştir
         * Ardından İstenilen İzin saat aralığı kontrolü yapılmıştır
        */
        [HttpPost]
        public async Task<ActionResult<List<Siparis>>> AddSiparis(SiparisekleDto Siparis)
        {
            var Sipariskontrol1 = await _context.Firma.FindAsync(Siparis.FirmaId);//Hangi firmadan sipraiş edilmek isteniliyorsa o firmanın Id si alınıyor
            var Sipariskontrol2 = await _context.Urunler.FindAsync(Siparis.UrunId);//Hangi urun siparis edilmek isteniliyorsa o firmanın Id si alınıyor
            if (Sipariskontrol1== null || Sipariskontrol2== null || Sipariskontrol1.Onaydurumu=="False")
            {//Firma ve urun varlık kontrolü
                return BadRequest("Hata" + Environment.NewLine+
                    "Lütfen " + Environment.NewLine+
                    "-Firma varlığını kontrol ediniz" + Environment.NewLine+
                    "-Urun varlığını kontrol ediniz" + Environment.NewLine+
                    "-Firma onay durumunu kontrol ediniz");
            }
            // Zaman kontrolü için ParseExact kullanıldı 
            DateTime Baslangıc = DateTime.ParseExact(Sipariskontrol1.Siparisizinbaslangicsaat,"HH:mm",
                                        CultureInfo.InvariantCulture);
            DateTime bitis = DateTime.ParseExact(Sipariskontrol1.Siparisizinbitissaat,"HH:mm",
                                        CultureInfo.InvariantCulture);
            DateTime Siparisdate = DateTime.ParseExact(Siparis.Siparistarihi, "HH:mm",
                                        CultureInfo.InvariantCulture);
            if (Baslangıc > Siparisdate || bitis < Siparisdate)//Zaman aralığı kontrolü
            {
                return BadRequest("Hata Firmanın izin saati aralığı dışında sipariş verilemez");
            }
            var yenisiparis = new Siparis//Eklenilmesi gerekenlerin siprişlere eklenilmesi
            {
                Siparisverenad = Siparis.Siparisverenad,//Siparişekledto -siparis eslemesi
                Siparistarihi = Siparis.Siparistarihi,
                Firma = Sipariskontrol1,
                UrunId = Siparis.UrunId,
            };
            _context.Siparis.Add(yenisiparis);
            //return await Get(yeniurun.FirmaId);
            await _context.SaveChangesAsync();
            return Ok(await _context.Siparis.ToListAsync());
        }
        //Siparis Sil
        [HttpDelete("{id}")]
        public async Task<ActionResult<Siparis>> SiparisSil(int id)
        {
            var Siparisbul = await _context.Siparis.FindAsync(id);
            if (Siparisbul == null)
                return BadRequest("Siparis Bulunamadı");

            _context.Siparis.Remove(Siparisbul);
            await _context.SaveChangesAsync();
            return Ok(await _context.Siparis.ToListAsync());
        }
    }
}
