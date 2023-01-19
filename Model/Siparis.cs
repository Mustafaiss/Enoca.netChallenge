using System.ComponentModel.DataAnnotations.Schema;

namespace Enoca.netChallenge.Entities
{
    public class Siparis
    {
        public int Id { get; set; }
        public string Siparisverenad { get; set;}
        public string Siparistarihi { get; set; }
        public Firma Firma { get; set; }
        public int FirmaId { get; set; }
        public int UrunId { get; set; } 
    }
}
