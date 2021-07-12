using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using CryptoPortfolio.Models;

namespace CryptoPortfolio.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserAdd model)
        {
            var entity = new CryptoUser()
            {
                LogId = _userId,
                PreferredExchange = model.PreferredExchange,
                FirstName = model.FirstName,
                LastName = model.LastName,
                TradeMoney = model.TradeMoney,
                Currency = model.Currency
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CryptoUsers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserList> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CryptoUsers.Select(e => new UserList
                {
                    UserId = e.UserId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Currency = e.Currency,
                    TradeMoney = e.TradeMoney,
                    PreferredExchange = e.PreferredExchange,
                });

                return query.ToArray();
            }
        }

        public UserDetails GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CryptoUsers.Single(e => e.LogId == _userId && e.UserId == id);

                return
                    new UserDetails
                    {
                        UserId = query.UserId,
                        LogId = query.LogId,
                        PreferredExchange = query.PreferredExchange,
                        FirstName = query.FirstName,
                        LastName = query.LastName,
                        TradeMoney = query.TradeMoney,
                        Currency = query.Currency
                    };
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CryptoUsers.Single(e => e.LogId == _userId && e.UserId == model.UserId);

                entity.UserId = model.UserId;
                entity.PreferredExchange = model.PreferredExchange;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.TradeMoney = model.TradeMoney;
                entity.PreferredExchange = model.PreferredExchange;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CryptoUsers.Single(e => e.LogId == _userId && e.UserId == id);

                ctx.CryptoUsers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
