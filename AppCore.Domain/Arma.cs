namespace AppCore.Domain
{
    public class Arma
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Heroi Heroi { get; set; } // relação com heroi
        public int HeroiId { get; set; }

    }
}
