//using FinalProject.DTO;
//using FinalProject.Store;
//using Microsoft.AspNetCore.Mvc;
//using MongoDB.Driver;
//using System.Text;


//namespace FinalProject.Controllers
//{
//    public class DijkstraController : ControllerBase
//    {

//    }
//}
using FinalProject.DTO;
using FinalProject.Interfaces;
using FinalProject.Store;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DijkstraController : ControllerBase
    {
        private readonly Dijkstra _algorithmFunction;
        private ILandmarkFunction lMongo;
        public DijkstraController(Dijkstra algorithmFunction,ILandmarkFunction lMongo)
        {
            _algorithmFunction = algorithmFunction;
            this.lMongo= lMongo ;
        }

        [HttpGet]
        public ActionResult Get(string id)
        {   
            //Landmark l = new Landmark();//---------------------------------------אמור להיות המבנה של הלקוח
            Landmark ln = lMongo.Get(id);
             
            //var g = new Graph();
            //g.buildGraph(l);
            // Dijkstra.InitailGraph(l,s);
            return null;
        }

        //[HttpGet]
        //public IActionResult CalculateDistances()
        //{
        //    // Example graph representation (node, (neighbor node, weight))
        //    Dictionary<string, Dictionary<string, string>> graph = new Dictionary<string, Dictionary<string, string>>
        //{
        //    {"0", new Dictionary<string, string>{{"1", "4" }, {"2", "8"}}},
        //    {"1", new Dictionary<string, string>{{"2", "2"}, {"3","5" }}},
        //    {"2", new Dictionary<string, string>{{"4", "3"}}},
        //    {"3", new Dictionary<string, string>{{"4","7"}}},
        //    {"4", new Dictionary<string, string>()}
        //};
        //    string example = "example";

        //    // Calculate distances from node 0 using Dijkstra's algorithm
        //    Dictionary<int, int> distances = DijkstraF(graph, example);

        //    // Return the computed distances
        //    return Ok(distances);
        //}
    }
}

