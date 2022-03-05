using InsaatAPI.Dao;
      
using InsaatAPI.Models;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;



namespace InsaatAPI.Controllers
{
    [Route("/")]

    public class ContentController : ControllerBase
    {
        ContentDao content = new ContentDao();

        [HttpGet]
        [Route("getcitylist")]
        public string GetCityList()
        {
            return content.GetCityList();
        }

        [HttpPost]
        [Route("postcity")]
        [Consumes("application/json")]
        public async Task<string> PostCity([FromBody] City req)
        {
            return await content.PostCity(req);
        }
        [HttpPut]
        [Route("putcity")]
        [Consumes("application/json")]
        public async Task<string> PutCity([FromBody] City req)
        {
            return await content.PutCity(req);
        }
        [HttpDelete]
        [Route("deletecity")]
        [Consumes("application/json")]
        public async Task<string> DeleteCity([FromBody] City req)
        {
            return await content.DeleteCity(req);
        }
        [HttpGet]
        [Route("getflattypelist")]
        public async Task<string> GetFlatTypeList()
        {
            return await content.GetFlatTypeList();
        }
    }
}
