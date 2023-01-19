using Enoca.netChallenge.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Enoca.netChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly DataContext _context;

       public FirmaController(DataContext context)
        {
            _context = context;
        }
        //Firma çağırma 
        [HttpGet]
        public async Task<ActionResult<List<Firma>>> Get()
        {
            return Ok(await _context.Firma.ToListAsync());
        }
        [HttpGet("{id}")]//İd ile firma çağırma
        public async Task<ActionResult<Firma>> Get(int id)
        {
            var Firmabul =await _context.Firma.FindAsync(id);
            if (Firmabul == null)
                return BadRequest("Firma Bulunamadı");

            return Ok(Firmabul);
        }

        [HttpPost]//firma ekleme
        public async Task<ActionResult<List<Firma>>> AddFirma(Firma firma)
        {
            _context.Firma.Add(firma);
            await _context.SaveChangesAsync();
            return Ok(await _context.Firma.ToListAsync());
        }

        [HttpPut]//firma güncelleme
        public async Task<ActionResult<List<Firma>>> UpdateFirma(Firma sorgu)
        {
            var Firmabul = await _context.Firma.FindAsync(sorgu.Id);
            if (Firmabul == null)
                return BadRequest("Firma Bulunamadı");
            //Sadece istenilen güncellemeler yapıplıyor (Zaman/Onay durum)
            Firmabul.Onaydurumu = sorgu.Onaydurumu;
            Firmabul.Siparisizinbitissaat = sorgu.Siparisizinbitissaat;
            Firmabul.Siparisizinbaslangicsaat = sorgu.Siparisizinbaslangicsaat;
            await _context.SaveChangesAsync();

            return Ok(await _context.Firma.ToListAsync());
        }
       //Firma silme
        [HttpDelete("{id}")]
        public async Task<ActionResult<Firma>> FirmaSil(int id)
        {
            var Firmabul = await _context.Firma.FindAsync(id);
            if (Firmabul == null)
                return BadRequest("Firma Bulunamadı");

            _context.Firma.Remove(Firmabul);
            await _context.SaveChangesAsync();

            return Ok(await _context.Firma.ToListAsync());
        }


    }
}
