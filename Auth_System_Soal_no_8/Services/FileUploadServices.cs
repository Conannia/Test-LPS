using Auth_System_Soal_no_8.Intefaces;
using Auth_System_Soal_no_8.Models;
using NuGet.Protocol;

namespace Auth_System_Soal_no_8.Services
{
    public class FileUploadServices : IFileUpload2
    {
        public async Task<bool> UploadFile(IFormFile file)
        {
            string path = string.Empty;
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "AllFiles"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using(var filestream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create) )
                    {
                        await filestream.CopyToAsync(filestream);
                    }
                }
                return true;
            } catch (Exception ex)
            {
                throw new Exception("File could not be uploaded", ex);
            }
        }
    }
}
