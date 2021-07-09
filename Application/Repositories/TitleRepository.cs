using TurnerTitles.Application.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnerTitles.Domain.Entities;
using TurnerTitles.Infrastructure;

namespace TurnerTitles.Application.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly TitlesContext _ctx;

        public TitleRepository(TitlesContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Title> GetAll()
        {
            return (from t in _ctx.Titles
                    join a in _ctx.Awards on t.TitleId equals a.TitleId
                    join o in _ctx.OtherNames on t.TitleId equals o.TitleId
                    join s in _ctx.StoryLines on t.TitleId equals s.TitleId
                    join tg in _ctx.TitleGenres on t.TitleId equals tg.TitleId
                    join tp in _ctx.TitleParticipants on t.TitleId equals tp.TitleId
                    select t).Take(10);              
        }

        public Title GetTitleByName(string name)
        {
            return _ctx.Titles.FirstOrDefault(x => x.TitleName == name);
        }

        public int Save()
        {
            return _ctx.SaveChanges();
        }
    }
}
