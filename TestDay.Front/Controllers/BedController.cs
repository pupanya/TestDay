using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestDay.Front.Services;

namespace TestDay.Front.Controllers
{
    [Route("api/[controller]")]
    public class BedController : Controller
    {
        private readonly IBedsService bedsService;
        public BedController(IBedsService bedsService)
        {
            this.bedsService = bedsService;
        }

        [HttpGet]
        public IEnumerable<Bed> Get(BedContainer bedContainer, string search, int take, int skip)
        {
            return bedsService.Get(search, take, skip);
        }
    }

    public class BedContainer
    {
        [BindNever]
        public int Search { get; set; }
        [BindNever]
        public int Take { get; set; }
        [BindNever]
        public int Skip { get; set; }
    }
}