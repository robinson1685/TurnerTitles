using TurnerTitles.Application.Common.Interface;
using TurnerTitles.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurnerTitles.Domain.Entities;
using TurnerTitles.Infrastructure;
using Microsoft.Extensions.Logging;

namespace TurnerTitles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TitlesController : ControllerBase
    {
        private readonly ILogger<TitlesController> _logger;
        private ITitleRepository _titleRepository;
        private readonly TitlesContext _ctx;

        public TitlesController(ITitleRepository titleRepository, TitlesContext ctx, ILogger<TitlesController> logger)
        {
            this._ctx = ctx;
            this._titleRepository = new TitleRepository(_ctx);
            this._logger = logger;
        }

        [HttpGet]
        public IEnumerable<Title> GetTiles()
        {
           return _titleRepository.GetAll();
        }

        [HttpPost]
        public Title GetTitleByName (string name)
        {
            return _titleRepository.GetTitleByName(name);
        }
    }
}
