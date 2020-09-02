using Bicep.Core.SemanticModel;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;

namespace Bicep.LanguageServer.Completions
{
    public static class SymbolExtensions
    {
        public static CompletionItem? ToCompletionItem(this Symbol symbol)
        {
            return new CompletionItem
            {
                Label = symbol.Name,

            };
        }
    }
}
