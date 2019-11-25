using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApacheJenaSample.Web.Model;

namespace ApacheJenaSample.Web.Services
{
    public class MockGraphService : IGraphService
    {
        public VisDataSet Query(Uri endpointUri, string sparqlQuery)
        {
            return new VisDataSet
            {
                Nodes = new List<VisNode>
                {
                    new VisNode {Id = 1, Label = "Node 1"},
                    new VisNode {Id = 2, Label = "Node 2"},
                    new VisNode {Id = 3, Label = "Node 3"},
                    new VisNode {Id = 4, Label = "Node 4"},
                    new VisNode {Id = 5, Label = "Node 5"}
                },
                Edges = new List<VisEdge>
                {
                    new VisEdge {From = 1, To = 3},
                    new VisEdge {From = 1, To = 2},
                    new VisEdge {From = 2, To = 4},
                    new VisEdge {From = 2, To = 5},
                    new VisEdge {From = 3, To = 3}
                }
            };
        }
    }
}