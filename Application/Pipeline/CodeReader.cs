using System.IO;
using System.Threading.Tasks;

namespace Application;

public class CodeReader
{
    public async Task<string> Read(string fileName)
    {
        using var reader = File.OpenText(fileName);
        return await reader.ReadToEndAsync();  
    }
}