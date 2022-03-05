using InsaatAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsaatAPI.Dao.Abstract
{
    public interface IContent
    {
        string GetCityList();
        Task<string> PostCity([FromBody] City req);

    }
}
