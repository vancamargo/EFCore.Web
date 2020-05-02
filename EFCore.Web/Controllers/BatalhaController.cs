using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;

        public BatalhaController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/HeroiBatalha
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Batalha());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/HeroiBatalha/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST: api/HeroiBatalha
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {
                _repo.Add(model);
               if(await _repo.SaveChangeAsync())
                {
                    return Ok("Bazinga");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Salvou");
        }

        // PUT: api/HeroiBatalha/5
        [HttpPut("{id}")]
        //public ActionResult Put(int id, Batalha model)
        //{
        //    try
        //    {

        //        if (_context.
        //            Herois.
        //            AsNoTracking().FirstOrDefault(
        //           h => h.Id == id
        //            ) != null)
        //        {
        //            _context.Update(model);
        //            _context.SaveChanges();
        //            return Ok("feito");
        //        }
        //        return Ok("Não encontrado");

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro: {ex}");
        //    }
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //        try
    //        {
    //            _repo.Delete(model);
    //            if (await _repo.SaveChangeAsync())
    //            {
    //                return Ok("Bazinga");
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest($"Erro: {ex}");
    //        }
    //        return BadRequest("Não Salvou");
    //    }
    //}
}
