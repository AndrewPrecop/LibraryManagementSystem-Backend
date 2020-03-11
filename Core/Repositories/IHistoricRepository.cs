using Core.Entities;
using System.Collections.Generic;

namespace Core.Repositories
{
    public interface IHistoricRepository
    {
        void AddHistoricItem(HistoricItem historicItem);
        List<HistoricItem> GetAll();
    }
}
