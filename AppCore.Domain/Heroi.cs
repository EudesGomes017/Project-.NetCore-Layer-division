using System.Collections.Generic;

namespace AppCore.Domain
{
    public class Heroi
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        //colocando nossa identidade na nossa classe Heroi
        public IdentidadeSecreta Identidade { get; set; }

        //agora um heroi esta para varias batalhas
        public List<HeroiBatalha> heroisBatalhas { get; set; }

    }
}
