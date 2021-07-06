using CryptoPortfolio.Models;
using CryptoPortfolio.Data;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CryptoPortfolio.Services
{
    public class CryptoInfoService
    {
        public bool CreateCryptoInfo(CryptoInfoCreate model)
        {
            var entity = new CryptoInfo()
            {
                CryptoName = model.CryptoName,
                Currency = model.Currency,
                PurchaseId = model.PurchaseId,
                Amount = model.Amount,
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
                    CryptoId = e.CryptoId,
                    CryptoName = e.CryptoName,
                    Currency = e.Currency,
                });

                return query.ToList();
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

        public bool DeleteCryptoInfo(int id)
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
