using Microsoft.AspNetCore.Mvc;

namespace MemoryLeakSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemoryLeakController : ControllerBase
    {
        private readonly Worker _worker;

        public MemoryLeakController(Worker worker)
        {
            _worker = worker;
        }

        [HttpGet(Name = "MemoryLeak")]
        public string Get(bool leak)
        {
            for (int i = 0; i < 1000; i++)
            {
                _worker.DoWork(!leak);
            }
            return $"Did work with leak = {leak}";
        }
    }
}
