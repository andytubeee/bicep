// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bicep.Core;
using Bicep.Core.SemanticModel;
using Bicep.LanguageServer.CompilationManager;
using Bicep.LanguageServer.Completions;
using Bicep.LanguageServer.Utils;
using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;

namespace Bicep.LanguageServer.Handlers
{
    public class BicepCompletionHandler : CompletionHandler
    {
        private readonly ICompilationManager compilationManager;

        public BicepCompletionHandler(ICompilationManager compilationManager)
            : base(CreateRegistrationOptions())
        {
            this.compilationManager = compilationManager;
        }

        public override Task<CompletionList> Handle(CompletionParams request, CancellationToken cancellationToken)
        {
            var completions = GetKeywordCompletions()
                .Concat(GetSymbolCompletions(request));
            return Task.FromResult(new CompletionList(completions, isIncomplete: false));
        }

        public override Task<CompletionItem> Handle(CompletionItem request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request);
        }

        public override bool CanResolve(CompletionItem value)
        {
            return false;
        }

        private static CompletionRegistrationOptions CreateRegistrationOptions() => new CompletionRegistrationOptions
        {
            DocumentSelector = DocumentSelectorFactory.Create(),
            AllCommitCharacters = new Container<string>(),
            ResolveProvider = false,
            TriggerCharacters = new Container<string>()
        };

        private IEnumerable<CompletionItem> GetKeywordCompletions()
        {
            yield return CreateKeywordCompletion(LanguageConstants.ParameterKeyword);
            yield return CreateKeywordCompletion(LanguageConstants.VariableKeyword);
            yield return CreateKeywordCompletion(LanguageConstants.ResourceKeyword);
            yield return CreateKeywordCompletion(LanguageConstants.OutputKeyword);
        }

        private IEnumerable<CompletionItem> GetSymbolCompletions(CompletionParams request)
        {
            var context = this.compilationManager.GetCompilation(request.TextDocument.Uri);
            if (context == null)
            {
                return Enumerable.Empty<CompletionItem>();
            }

            var model = context.Compilation.GetSemanticModel();

            return GetAccessibleSymbols(model)
                .Select(sym => sym.ToCompletionItem());
        }

        private IEnumerable<Symbol> GetAccessibleSymbols(SemanticModel model)
        {
            var accessibleSymbols = new Dictionary<string, Symbol>();

            // local function
            void AddAccessibleSymbols(IDictionary<string, Symbol> result, IEnumerable<Symbol> symbols)
            {
                foreach (var declaration in symbols)
                {
                    if (result.ContainsKey(declaration.Name) == false)
                    {
                        result.Add(declaration.Name, declaration);
                    }
                }
            }

            AddAccessibleSymbols(accessibleSymbols, model.Root.AllDeclarations
                .Where(decl => !(decl is OutputSymbol)));

            AddAccessibleSymbols(accessibleSymbols, model.Root.ImportedNamespaces
                .SelectMany(ns => ns.Descendants.OfType<FunctionSymbol>()));

            return accessibleSymbols.Values;
        }

        private static CompletionItem CreateKeywordCompletion(string keyword) =>
            new CompletionItem
            {
                Kind = CompletionItemKind.Keyword,
                Label = keyword,
                InsertTextFormat = InsertTextFormat.PlainText,
                InsertText = keyword,
                CommitCharacters = new Container<string>(" "),
                Detail = keyword
            };
    }
}
