using BitcoinBeach.Data;
using BitcoinBeach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Services
{
    public class ProfileService
    {
        private readonly Guid _userId;

        public ProfileService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProfile(ProfileCreate model)
        {
            var profileType = new ProfileType();
            profileType.type = model.AccountType;

            var entity =
                new Profile()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    ProfileType = profileType
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProfileListItem> GetProfiles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Profiles
                        .Select(
                            e =>
                                new ProfileListItem
                                {
                                    ProfileId = e.ProfileId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Email = e.Email,
                                    PhoneNumber = e.PhoneNumber,
                                    ProfileType = e.ProfileType
                                }
                        );

                return query.ToArray();
            }
        }

        public ProfileDetail GetProfileById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.ProfileId == id && e.OwnerId == _userId);
                    return
                        new ProfileDetail
                        {
                            ProfileId = entity.ProfileId,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Email = entity.Email,
                            PhoneNumber = entity.PhoneNumber,
                            ProfileType = entity.ProfileType
                        };
            }
        }

        public bool UpdateProfile(ProfileEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.ProfileId == model.ProfileId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.PhoneNumber = model.PhoneNumber;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProfile(int ProfileId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.ProfileId == ProfileId && e.OwnerId == _userId);

                ctx.Profiles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
