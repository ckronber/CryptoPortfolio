using CryptoInfo.Models;
using CryptoPortfolio.Data;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CryptoInfoService
    {
        public bool CreateCryptoInfo(CryptoInfoCreate model)
        {
            var entity = new CryptoInfo()
            {
                CryptoName = model.CryptoName,
                Currency = model.Currency,
                Price = model.Price,
                PurchaseId = model.PurchaseId,
                Amount = model.Amount,
                TotalValue = model.TotalValue

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CryptoInfos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CryptoInfoList> GetCryptoInfo()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CryptoInfos.Select(e => new CryptoInfoList
                {
                    CryptoName = e.CryptoName,
                    Price = e.Price,
                    Currency = e.Currency
                });

                return query.ToArray();
            }
        }

        public CryptoInfoDetails GetCryptoInfoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CryptoInfos.Single(e => e.CryptoId == id);

                return
                    new CryptoInfoDetails
                    {
                        CryptoName = query.CryptoName,
                        Amount = query.Amount,
                        Currency = query.Currency,
                        Price = query.Price,
                        TotalValue  = query.TotalValue
                    };
            }
        }

        public bool UpdateCryptoInfo(CryptoInfoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CryptoInfos.Single(e => e.CryptoId == model.CryptoId);

                entity.CryptoName = model.CryptoName;
                entity.Currency = model.Currency;
                entity.Amount = model.Amount;
                entity.PurchaseId = model.PurchaseId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CryptoInfos.Single(e => e.CryptoId == id);

                ctx.CryptoInfos.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
