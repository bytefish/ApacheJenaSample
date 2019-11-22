// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Newtonsoft.Json;
using ApacheJenaSample.Web.Model;
using VDS.RDF.Storage;
using VDS.RDF.Query;
using VDS.RDF;
using VDS.RDF.Writing;
using System.Collections.Generic;
using ApacheJenaSample.Web.Utils;
using System;

namespace ApacheJenaSample.Web.Services
{
    public class GraphService : IGraphService
    {
        public VisDataSet Query(Uri endpointUri, string sparqlQuery)
        {
            var endpoint = new SparqlRemoteEndpoint(endpointUri);

            var result = endpoint.QueryWithResultGraph(sparqlQuery);

            return Convert(result);
        }


        private static VisDataSet Convert(IGraph graph)
        {
            var nodes = new SimpleNodeMapper();
            var edges = new List<VisEdge>();

            var triples = graph.Triples;

            foreach (var triple in triples)
            {
                var fromNode = nodes.MapNode(triple.Subject);
                var toNode = nodes.MapNode(triple.Object);

                var edge = new VisEdge
                {
                    From = fromNode.Id,
                    To = toNode.Id,
                    Label = RdfUtils.MakeNodeString(triple.Predicate)
                };

                edges.Add(edge);
            }

            return new VisDataSet
            {
                Nodes = nodes.GetNodes(),
                Edges = edges
            };
        }

    }
}
