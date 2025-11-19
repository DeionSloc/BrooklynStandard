using System;

namespace BrooklynStandard.Controllers;

public class UploadFileController
{
    public string Upload(IFormFile file)
    {
        List<string> validExtentions = new List<string>() { ".jpg", ".png", ".pdf", ".docx"};
        string extention = Path.GetExtension(file.FileName);
        if (!validExtentions.Contains(extention))
        {
            return $"Extension is not valid ({string.Join(',',validExtentions)})";
        }

        long size = file.Length;
        if(size > (5 * 1024 * 1024))
        return "Maximum file size can not exceed 5MB";

        string fileName = Guid.NewGuid().ToString() + extention;
        string path = Path.Combine(Directory.GetCurrentDirectory(),"Uploads");
        using FileStream stream = new FileStream(Path.Combine(path,fileName), FileMode.Create);
        file.CopyTo(stream);
        return fileName;   
    }
}
