namespace AppCore.Domain
{
    public class IdentidadeSecreta
    {

        public int Id { get; set; }
        public int nomeReal { get; set; }
        //colocando nosso relacionamento de Heroi aqui na classe
        public int HeroiId { get; set; }
        public int Heroi { get; set; }

    }
}
