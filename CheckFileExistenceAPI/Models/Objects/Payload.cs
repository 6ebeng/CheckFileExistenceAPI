using CheckFileExistenceAPI.Controllers;

namespace CheckFileExistenceAPI.Models.Objects
{
    public class Payload
    {
        public String name { get; set; }
        public List<Payload>? dirs { get; set; }
        public String extension { get; set; }
        public String mimeType { get; set; }
        public String path { get; set; }

        public Payload(string name, List<Payload>? dirs, string extension, string mimeType, string currentPath)
        {
            this.name = name;
            this.dirs = dirs;
            this.extension = extension;
            this.mimeType = mimeType;
            this.path = currentPath;
        }
    }
    
}
