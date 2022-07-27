using CheckFileExistenceAPI.Models.Data;
using CheckFileExistenceAPI.Models.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Web;

namespace CheckFileExistenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadDirs : ControllerBase
    {
        [Route("dirs/{path}")]
        [HttpGet]
        public IActionResult GetAllDirsInAPath([FromRoute] String path)
        {
            if (path == null)
            {
                return NoContent();
            }
            var tempPath = HttpUtility.UrlDecode(path.ToString());
            if (!Directory.Exists(tempPath))
            {
                return NotFound("Directory doesnt exist");
            }else
            {
                string jsonString = JsonSerializer.Serialize(GetFile.GetFileDirs(tempPath));
                return Ok(jsonString);
            }
        }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class CreateDirs : ControllerBase
    {
        [Route("setdirs")]
        [HttpPost]
        public IActionResult WriteAllDirsInAPath([FromBody] List<Payload> payloadList)
        {
            if (ModelState.IsValid)
            {
                PayloadToDirs.CreateAllDirs(payloadList);
                return Ok("Successfully all dirs were created");
            }
            else
            {
                return NoContent();
            }
        }
    }
}