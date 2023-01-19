using Enoca.netChallenge.Entities;
using Enoca.netChallenge.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.netChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        private readonly DataContext _context;

        public UrunlerController(DataContext context)
        {
            _context = context;
        }
       //Urunleri Listeleme 
        [HttpGet]
        public async Task<ActionResult<List<Urunler>>> Get()
        {
            return Ok(await _context.Urunler.ToListAsync());
        }
        //Urunleri Id^ye göre listeleme
        [HttpGet("{id}")]
        public async Task<ActionResult<Urunler>> Get(int id)
        {
            var Urunbul = await _context.Urunler.FindAsync(id);
            if (Urunbul == null)
                return BadRequest("Urunler Bulunamadı");

            return Ok(Urunbul);
        }
        //Urun ekleme
        [HttpPost]
        public async Task<ActionResult<List<Urunler>>> AddUrunler(UrunekleDto request)//Urunlerdto kullanarak Urun ekleme 
        {
            var Urunekle = await _context.Firma.FindAsync(request.FirmaId);//Firmaya eklenilecek urunun firma kontrolü
            if (Urunekle==null)
            {
                return BadRequest("Firma bulunamadı");
            }
            var yeniurun = new Urunler//Urunler - urunlerdto eşlemesi
            {
                Urunadi=request.Urunadi,
                fiyat = request.Fiyat,
                stok = request.stok,
                Firma = Urunekle
            };
            _context.Urunler.Add(yeniurun);
            await _context.SaveChangesAsync();
            return Ok(await _context.Urunler.ToListAsync());
        }
        //Urun güncelleme
        [HttpPut]
        public async Task<ActionResult<List<Urunler>>> UpdateUrunler(Urunler sorgu)
        {
            var Urunbul = await _context.Urunler.FindAsync(sorgu.Id);
            if (Urunbul == null)
                return BadRequest("Urunler Bulunamadı");
            //Sadece gerekli güncellemeler 
            Urunbul.stok = sorgu.stok;
            Urunbul.fiyat = sorgu.fiyat;
            Urunbul.Urunadi = sorgu.Urunadi;
            await _context.SaveChangesAsync();

            return Ok(await _context.Urunler.ToListAsync());
        }
        //Urun silme
        [HttpDelete("{id}")]
        public async Task<ActionResult<Urunler>> UrunlerSil(int id)
        {
            var Urunbul = await _context.Urunler.FindAsync(id);
            if (Urunbul == null)
                return BadRequest("Urunler Bulunamadı");

            _context.Urunler.Remove(Urunbul);
            await _context.SaveChangesAsync();
            return Ok(await _context.Urunler.ToListAsync());
        }


    }
}
