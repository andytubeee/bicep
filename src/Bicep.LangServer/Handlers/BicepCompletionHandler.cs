// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Threading;
using System.Threading.Tasks;
using Bicep.Core;
using Bicep.LanguageServer.Utils;
using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;

namespace Bicep.LanguageServer.Handlers
{
    public class BicepCompletionHandler : CompletionHandler
    {
        public BicepCompletionHandler() : base(CreateRegistrationOptions())
        {
        }

        public override Task<CompletionList> Handle(CompletionParams request, CancellationToken cancellationToken)
        {
            return Task.FromResult(GetKeywordCompletions());
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

        private CompletionList GetKeywordCompletions()
        {
            return new CompletionList(
                CreateKeywordCompletion(LanguageConstants.ParameterKeyword),
                CreateKeywordCompletion(LanguageConstants.VariableKeyword),
                CreateKeywordCompletion(LanguageConstants.ResourceKeyword),
                CreateKeywordCompletion(LanguageConstants.OutputKeyword));
        }

        private CompletionItem CreateKeywordCompletion(string keyword) =>
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
