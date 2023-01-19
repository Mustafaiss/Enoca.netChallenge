using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enoca.netChallenge.Entities
{
    public class Urunler
    {
        public int Id { get; set; }
        public string Urunadi { get; set; }
        public int stok { get; set; }
        public int fiyat { get; set; }
        [JsonIgnore]
        public Firma Firma { get; set; }
        public int FirmaId { get; set; }

    }
}
