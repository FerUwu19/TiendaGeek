using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriumController : ControllerBase
    {
        private ICategoriumService _categoriumService;

        public CategoriumController(ICategoriumService categoriumService)
        {
            this._categoriumService = categoriumService;
        }

        // GET: api/<CategoriumController>
        [HttpGet]
        public IEnumerable<CategoriumModel> Get()
        {
            return _categoriumService.Get();
        }

        // GET api/<CategoriumController>/5
        [HttpGet("{id}")]
        public CategoriumModel Get(int id)
        {
            return _categoriumService.Get(id);
        }

        // POST api/<CategoriumController>
        [HttpPost]
        public CategoriumModel Post([FromBody] CategoriumModel categorium)
        {
            _categoriumService.Add(categorium);
            return categorium;
        }

        // PUT api/<CategoriumController>/5
        [HttpPut("{id}")]
        public CategoriumModel Put(int id, [FromBody] CategoriumModel categorium)
        {
            _categoriumService.Update(categorium);
            return categorium;
        }

        // DELETE api/<CategoriumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoriumModel categorium = new CategoriumModel { CodigoCategoria = id };
            _categoriumService.Remove(categorium);
        }
    }
}
