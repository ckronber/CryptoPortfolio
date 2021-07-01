using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using User.Models;

namespace Services
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
                LogId = _userId

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CryptoUsers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserList> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CryptoUsers.Where(e => e.LogId == _userId).Select(e => new UserList
                {
                    UserId = e.UserId,
                    PreferredExchange = e.PreferredExchange
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
                        LogId = query.LogId,
                        UserId = query.UserId,
                        PreferredExchange = query.PreferredExchange
                    };
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CryptoUsers.Single(e => e.UserId == model.UserId && e.LogId == _userId);

                entity.UserId = model.UserId;
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
