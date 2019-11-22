// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;

namespace ApacheJenaSample.Web.Model
{
    public class VisNode
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("group")]
        public long? Group { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    };
}
