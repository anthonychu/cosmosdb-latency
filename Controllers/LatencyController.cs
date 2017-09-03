using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;

namespace cosmosdb_latency.Pages
{
    [Route("api/[controller]")]
    public class LatencyController
    {        
        private readonly IDocumentClient documentClient;

        public LatencyController(IDocumentClient documentClient)
        {
            this.documentClient = documentClient;
        }

        public async Task<object> Get()
        {
            var sw = Stopwatch.StartNew();
            var result = await documentClient.CreateDocumentAsync("/dbs/test/colls/test", new { date = DateTimeOffset.UtcNow });
            var timeTaken = sw.ElapsedMilliseconds;
            var resource = result.Resource;
            var endpoint = documentClient.WriteEndpoint.ToString();
            return new
            { 
                timeTaken,
                resource,
                endpoint
            };
        }
    }
}