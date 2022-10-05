using AppCore.Domain;
using AppCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {

        //readonly, nao precisamos usar o get e set
        public readonly HeroiContext _context;
        public ValueController(HeroiContext context)
        {
            _context = context;
        }

        //Get api/values
        //[HttpGet] opção anterior
        //public ActionResult<IEnumerable<string>> Get()

        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            //pegando o objeto heroi e chamando toList() que retorna um List<Heroi>
            var listHeroi = _context.Herois
                .Where(h => h.Nome.Contains(nome))
                .ToList(); //parte de linq methodos

            /*fo Heroi contido no herois pega para o Heroi*/
            /*  var listHeroi = (from heroi in _context.Herois 
                               where heroi.Nome.Contains(nome)
                               select heroi).ToList(); //utilizando LiNQ Query*/
            return Ok(listHeroi);
        }


        //Get api/values/5
        //insert
        /* [HttpGet("{nameHero}")]
         public ActionResult Get(string nameHero)
         {
             /*quando passamos o nome, estamos fazendo o insert
             var heroi = new Heroi { Nome = nameHero };

                 //primeira forma de fazer um insert
                 _context.Herois.Add(heroi);
                 //segunda forma de fazerum insert
                 //contexto.Add(heroi);
                 _context.SaveChanges();

             return Ok();
         }*/



        //Get api/values/5
        //Update
        //utilizando as duas arbodagens de buscar e salvar
        [HttpGet("Atualizar/{nameHero}")]
        public ActionResult Get(string nameHero)
        {

            var heroi = _context.Herois
                .Where(h => h.Id == 3) //quero atualizar um numero do nosso banco de dados
                .FirstOrDefault(); // vai retorna o primeiro ou o padrão

            heroi.Nome = "Homem Aranha";
            _context.SaveChanges();

            return Ok();
        }


        
        //utilizando as duas arbodagens de buscar e salvar
        [HttpGet("addRange")]
        public ActionResult GetAddRange()
        {

            //vamos adicioanar varios herois via Range de um tipo que ele já conhece
            _context.AddRange(
                new Heroi { Nome = "Capitão América" },
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arquero" }
                );
            _context.SaveChanges();

            return Ok();
        }


        //Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            /*o heroi possui quem eu estou procurando*/
            var heroi = _context.Herois
                                .Where(x => x.Id == id)
                                .Single();

            _context.Herois.Remove(heroi);// nesse momento estamos salvando no nosso contexto
            _context.SaveChanges(); 
        }


    }
}
