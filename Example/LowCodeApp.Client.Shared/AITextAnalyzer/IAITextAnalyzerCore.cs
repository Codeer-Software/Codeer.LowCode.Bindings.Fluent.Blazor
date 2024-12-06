using Codeer.LowCode.Blazor.Repository.Data;

namespace LowCodeApp.Client.Shared.AITextAnalyzer
{
    public interface IAITextAnalyzerCore
    {
        Task<ModuleData?> FileToModuleDataAsync(string moduleName, string fileName, StreamContent content);
        Task<ModuleData?> TextToModuleDataAsync(string moduleName, string text);
    }
}
