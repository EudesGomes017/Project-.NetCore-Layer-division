namespace AppCore.Domain
{
    public class HeroiBatalha
    {

        public int HeroiId { get; set; }
        public Heroi Heroi { get; set; } //primeiro relacionamento
        public int BatalhaId { get; set; }
        public Batalha Batalha { get; set; }

    }
}
