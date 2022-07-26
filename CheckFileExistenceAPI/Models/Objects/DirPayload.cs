using CheckFileExistenceAPI.Controllers;

namespace CheckFileExistenceAPI.Models.Objects
{
    public class DirPayload
    {
        public List<FileFolder> fileStructure { get; set; }
        public Path pathObj { get; set; }
    }
}
