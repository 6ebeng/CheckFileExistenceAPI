using CheckFileExistenceAPI.Models.Data;
using CheckFileExistenceAPI.Models.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Web;

namespace CheckFileExistenceAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReadFiles : ControllerBase
    {

        [Route("dirs")]
        [HttpGet]

        public IActionResult GetAllFilesInAPath([FromBody] dirPath path)
        {
            
            if (path == null)
            {
                return NoContent();
            }
            var tempPath = HttpUtility.UrlDecode(path.ToString());
            if (!Directory.Exists(tempPath))
            {
                return NotFound("Directory doesnt exist");
            }

            string jsonString = JsonSerializer.Serialize(GetFile.GetFileDirs(tempPath));
            return Ok(jsonString);
        }


    }
    public class dirPath
    {
        String path { get; set; }
    }


        [Route("api/[controller]")]
        [ApiController]

        public class WriteFiles : ControllerBase
        {

            [Route("setdir")]

            [HttpPost]

            public IActionResult WriteAllFilesInAPath([FromBody] DirPayload payload)
            {

                var tempPath = HttpUtility.UrlEncode(payload.pathObj.ToString());
                if (tempPath == null)
                {
                    return NoContent();
                }
                if (!Directory.Exists(tempPath))
                {
                    return NotFound("directory doesnt exist");
                }

                var result = SetDirInfo.CreateAllDirs(payload);
                return Ok("Successfully all dirs were created");
            }
        }
    

}

