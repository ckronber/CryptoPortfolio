using CryptoPortfolio.Data;
using CryptoPortfolio.Models;
using System.Collections.Generic;
using System.Linq;

namespace CryptoPortfolio.Services
{
    public class CryptoPurchaseService
    {
        public bool CreatePurchase(CryptoPurchaseCreate model)
        {
            var entity = new CryptoPurchase()
            {
                DateAdded = model.DateAdded,
                PortfolioId = model.PortfolioId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Purchases.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CryptoPurchaseList> GetPurchases()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Purchases.Select(e => new CryptoPurchaseList
                {
                    PurchaseId = e.PurchaseId,
                    PortfolioId = e.PortfolioId,
                    CryptoInfo = e.CryptoInfo,
                    DateAdded = e.DateAdded,
                });
                return query.ToList();
            }
        }

        public CryptoPurchaseDetails GetPurchaseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Purchases.Single(e => e.PurchaseId == id);

                return
                    new CryptoPurchaseDetails
                    {
                        PurchaseId = query.PurchaseId,
                        PortfolioId = query.PortfolioId,
                        PurchaseDate = query.DateAdded,
                        CryptoInfo = query.CryptoInfo.Select(e => new CryptoInfo()
                        {
                            CryptoId = e.CryptoId,
                            CryptoName = e.CryptoName,
                            Amount = e.Amount,
                            CurrentPrice = e.CurrentPrice,
                            PurchasePrice = e.PurchasePrice,
                            Gain = e.Gain,
                            GainPercent = e.GainPercent,
                            PurchaseDate = e.PurchaseDate,
                            TotalValue = e.TotalValue
                        }).ToList()
                    };
            }

        }


        public bool UpdatePurchase(CryptoPurchaseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Purchases.Single(e => e.PurchaseId == model.PurchaseId);

                entity.PortfolioId = model.PortfolioId;
                entity.DateAdded = model.DateAdded;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePurchase(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Purchases.Single(e => e.PurchaseId == id);

                ctx.Purchases.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
