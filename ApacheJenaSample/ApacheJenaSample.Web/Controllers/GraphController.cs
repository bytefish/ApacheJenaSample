// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Mvc;
using ApacheJenaSample.Web.Services;
using ApacheJenaSample.Web.Model;
using System;

namespace ApacheJenaSample.Web.Controllers
{
    [Controller]
    [Route("api/graph")]
    public class GraphController : ControllerBase
    {
        private readonly IGraphService service;

        public GraphController(IGraphService service)
        {
            this.service = service;
        }

        [HttpGet("query")]
        public ActionResult<VisDataSet> Query(string sparqlEndpoint, string sparqlQuery)
        {
            if(!Uri.TryCreate(sparqlEndpoint, UriKind.RelativeOrAbsolute, out Uri endpointUri))
            {
                return BadRequest();
            }

            var result = service.Query(endpointUri, sparqlQuery);

            return Ok(result);
        }
    }
}
