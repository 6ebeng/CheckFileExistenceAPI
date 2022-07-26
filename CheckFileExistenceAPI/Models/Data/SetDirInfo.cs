using CheckFileExistenceAPI.Models.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace CheckFileExistenceAPI.Models.Data
{
    public class SetDirInfo
    {

        public static String CreateAllDirs(DirPayload fsPayload)
        {

            foreach (var file in fsPayload.fileStructure)
            {
                if (file.mimeType.ToLower() == "folder")
                {
                    if (file.extention == null)
                    {
                        Directory.CreateDirectory(System.IO.Path.Combine(fsPayload.pathObj.dirPath, file.name));


                    }
                }

                if (file.mimeType.ToLower() == "file")
                {

                    File.Create(System.IO.Path.Combine(fsPayload.pathObj.dirPath, file.name));
                }

            }
            return "Successfully all dirs were created";



        }
    }
}
