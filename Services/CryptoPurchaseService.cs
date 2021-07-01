using CryptoPortfolio.Data;
using CryptoPortfolio.Models;
using Models.CryptoPortfolio;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CryptoPurchaseService
    {
        public bool CreatePortfolio(CryptoPortfolioCreate model)
        {
            var entity = new CryptoPurchase()
            {
                Name = model.Name,
                BullBear = model.BullBear
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Portfolios.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CryptoPortfolioList> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Portfolios.Select(e => new CryptoPortfolioList
                {
                    PortfolioId = e.PortfolioId,
                    Name = e.Name,
                    BullBear = e.BullBear
                });

                return query.ToArray();
            }
        }

        public CryptoPortfolioDetails GetPortfolioById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Portfolios.Single(e => e.PortfolioId == id);

                return
                    new CryptoPortfolioDetails
                    {
                        PortfolioId = query.PortfolioId,

                    };
            }
        }

        public bool UpdateNote(CryptoPortfolioEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Portfolios.Single(e => e.PortfolioId == model.PortfolioId);

                entity.Name = model.Name;
                entity.BullBear = model.BullBear;
                entity.TopCrypto = model.TopCrypto;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Portfolios.Single(e => e.PortfolioId == id);

                ctx.Portfolios.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
