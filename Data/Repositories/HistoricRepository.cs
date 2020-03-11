using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Repositories;

namespace Data.Repositories
{
    public class HistoricRepository : IHistoricRepository
    {
        private readonly AppDbContext context;

        public HistoricRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddHistoricItem(HistoricItem historicItem)
        {
            context.Add(historicItem);

            context.SaveChanges();
        }

        public List<HistoricItem> GetAll()
        {
            return context.Historic.ToList();
        }
    }
}
