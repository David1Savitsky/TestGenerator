using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    internal static class TestGeneratorScript
    {
        public static async Task Main(string[] args)
        {
            var correctInputFiles = new List<string>();
            correctInputFiles.Add("X:\\Programming\\University\\test\\input2.txt");
            var outputDirectory = "X:\\Programming\\University\\test\\output";
            var readingTaskRestriction = 20;
            var processTaskRestriction = 20;
            var writeTaskRestriction = 20;
            var testGeneratorService = new PipelineService(readingTaskRestriction, processTaskRestriction,
                writeTaskRestriction, outputDirectory);
            await testGeneratorService.Generate(correctInputFiles);
        }
    }
}