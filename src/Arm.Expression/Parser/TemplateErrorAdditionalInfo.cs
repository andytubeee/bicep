// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using Newtonsoft.Json;

namespace Arm.Expression.Parser
{
    /// <summary>
    /// The template error additional information instance.
    /// </summary>
    public class TemplateErrorAdditionalInfo
    {
        /// <summary>
        /// Gets or sets the line number of the error.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public int LineNumber { get; set; }

        /// <summary>
        /// Gets or sets the line position of the error.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public int LinePosition { get; set; }

        /// <summary>
        /// Gets or sets the path of error.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateErrorAdditionalInfo"/> class.
        /// </summary>
        public TemplateErrorAdditionalInfo()
        {
            this.LineNumber = default(int);
            this.LinePosition = default(int);
            this.Path = string.Empty;
        }
    }
}
