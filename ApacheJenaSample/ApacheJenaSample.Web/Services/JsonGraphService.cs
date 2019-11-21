// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using Newtonsoft.Json;
using ApacheJenaSample.Web.Model;

namespace ApacheJenaSample.Web.Services
{
    public class JsonGraphService : IGraphService
    {
        private readonly string basePath;

        public JsonGraphService(string basePath)
        {
            this.basePath = basePath;
        }

        public Graph GetGraphSchema(string schemaName)
        {
            var json = GetJson(schemaName);

            return JsonConvert.DeserializeObject<Graph>(json);
        }

        private string GetJson(string schemaName)
        {
            string filename = Path.Combine(basePath, $"{schemaName}.json");

            return File.ReadAllText(filename);
        }

    }
}
