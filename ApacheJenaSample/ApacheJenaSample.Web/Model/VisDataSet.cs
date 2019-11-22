// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApacheJenaSample.Web.Model
{
    public class VisDataSet
    {
        [JsonProperty("nodes")]
        public List<VisNode> Nodes { get; set; }

        [JsonProperty("edges")]
        public List<VisEdge> Edges { get; set; }
    }
}
