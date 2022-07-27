using CheckFileExistenceAPI.Models.Objects;

namespace CheckFileExistenceAPI.Models.Data
{
    public class PayloadToDirs
    {
        public static void CreateAllDirs(List<Payload> list)
        {
            foreach (var dir in list)
            {
                if (dir.mimeType.ToLower() == "folder")
                {
                    Directory.CreateDirectory(System.IO.Path.Combine(dir.path, dir.name));
                    CreateAllDirs(dir.dirs);
                }
                else
                {
                    File.Create(System.IO.Path.Combine(dir.path, dir.name));
                }
            }
        }
    }
}
