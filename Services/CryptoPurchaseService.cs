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
                Name = model.Name,
                PurchaseAmount = model.PurchaseAmount,
                PurchaseDate = model.PurchaseDate,
                PurchasePrice = model.PurchasePrice
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
                    Name = e.Name,
                    PurchaseAmount = e.PurchaseAmount,
                    PurchaseDate = e.PurchaseDate,
                    PurchasePrice = e.PurchasePrice
                });

                return query.ToArray();
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
                        Name = query.Name,
                        PurchaseDate = query.PurchaseDate,
                        PurchaseAmount = query.PurchaseAmount,
                        PurchasePrice = query.PurchasePrice,
                        CryptoInfo = query.CryptoInfo,
                    };
            }
        }

        public bool UpdatePurchase(CryptoPurchaseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Purchases.Single(e => e.PurchaseId == model.PurchaseId);

                entity.Name = model.Name;
                entity.PurchaseAmount = model.PurchaseAmount;
                entity.PurchasePrice = model.PurchasePrice;
                entity.PurchaseDate = model.PurchaseDate;

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
