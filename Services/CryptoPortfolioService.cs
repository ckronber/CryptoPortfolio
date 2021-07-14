using CryptoPortfolio.Data;
using System.Collections.Generic;
using System.Linq;
using CryptoPortfolio.Models;

namespace CryptoPortfolio.Services
{
    public class CryptoPortfolioService
    {
        public bool CreatePortfolio(CryptoPortfolioCreate model)
        {
            var entity = new Portfolio()
            {
                Name = model.Name,
                BullBear = model.BullBear,
                CryptoUser_UserId = model.CryptoUser_UserId,
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Portfolios.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CryptoPortfolioList> GetPortfolio()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Portfolios.Select(e => new CryptoPortfolioList
                {
                    PortfolioId = e.PortfolioId,
                    Name = e.Name,
                    BullBear = e.BullBear,
                    CryptoUser = e.CryptoUser,
                });

                return query.ToArray();
            }
        }

        public CryptoPortfolioDetails GetPortfolioById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Portfolios.Single(e => e.PortfolioId == id);

                return
                    new CryptoPortfolioDetails
                    {
                        PortfolioId = entity.PortfolioId,
                        Name = entity.Name,
                        BullBear = entity.BullBear,
                        CryptoUser = entity.CryptoUser,
                        CryptoPurchase = entity.CryptoPurchase.Select(cp => new CryptoPurchase
                        {
                            PurchaseId = cp.PurchaseId,
                            DateAdded = cp.DateAdded,
                            TotalCryptoValue = cp.getTotalCryptoValue(),
                        }).ToList()

                        
                    };
            }
        }

        public bool UpdatePortfolio(CryptoPortfolioEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Portfolios.Single(e => e.PortfolioId == model.PortfolioId);

                entity.Name = model.Name;
                entity.BullBear = model.BullBear;
                entity.CryptoUser_UserId = model.CryptoUser_UserId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePortfolio(int id)
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
