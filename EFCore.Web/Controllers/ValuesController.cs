﻿using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EFCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context;
        public ValuesController(HeroiContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            var listHeroi = _context.Herois
                            .Where(h => EF.Functions.Like(h.Nome, $"%{nome}%"))
                            .OrderByDescending(h => h.Id)
                            .LastOrDefault();
            //var listHeroi = (from heroi in _context.Herois
            //                 where heroi.Nome.Contains(nome)
            //                 select heroi).ToList();
            return Ok(listHeroi);
        }

        // GET api/values/5
        [HttpGet("AddRange")]
        public ActionResult<string> AddRange(string nameHero)
        {
            _context.AddRange(
                new Heroi { Nome = "Capitao América" },
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Viuva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitã Marvel" }
                );
            _context.SaveChanges();
            return Ok();
            // var heroi = new Heroi { Nome = nameHero };
            // var listHeroi = _context.Herois
            //                .Where(h => h.Id == 3).FirstOrDefault();
            // heroi.Nome = "Homem Aranha";

            //// _context.Herois.Add(heroi);




            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois
                                .Where(x => x.Id == id)
                                .Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }
    }
}