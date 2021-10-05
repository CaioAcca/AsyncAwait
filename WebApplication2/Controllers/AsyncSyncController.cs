using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class AsyncSyncController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/[controller]/sync/{id}")]
        public IEnumerable<string> GetSync(int id)
        {
            Debug.WriteLine($"{id} Sync Start {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            Debug.WriteLine($"{id} Sync End {Thread.CurrentThread.ManagedThreadId}");
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/[controller]/async/{id}")]
        public async Task<IEnumerable<string>> GetAsync(int id)
        {
            Debug.WriteLine($"{id} Async Start {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(5000);
            Debug.WriteLine($"{id} Async End {Thread.CurrentThread.ManagedThreadId}");
            return new string[] { "value1", "value2" };
        }
    }
}
