using System.IO;
using System.Threading.Tasks;

namespace Application;

public class CodeWriter
{
    public async Task Write(string path, string fileContent)
    {
        using var writer = new StreamWriter(path);
        await writer.WriteAsync(fileContent);    
    }
}