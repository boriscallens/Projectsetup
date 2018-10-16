using System;
using Microsoft.AspNetCore.Mvc;

namespace ProjectSetup.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController: ControllerBase
    {
        // GET api/labels/nl-BE
        [HttpGet("{cultureIsoString}")]
        public ActionResult<string> Get(string cultureIsoString)
        {
            throw new NotImplementedException();
        }
    }
}
