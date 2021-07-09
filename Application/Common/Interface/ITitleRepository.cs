using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnerTitles.Domain.Entities;

namespace TurnerTitles.Application.Common.Interface
{
    public interface ITitleRepository
    {
        IEnumerable<Title> GetAll();
        Title GetTitleByName(string name);
        int Save();
    }
}
