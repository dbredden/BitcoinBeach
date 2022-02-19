using BitcoinBeach.Data;
using BitcoinBeach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Services
{
    public class UnitService
    {
        private readonly Guid _userId;

        public UnitService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUnit(UnitCreate model)
        {
            var entity =
                new Unit()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    Address = model.Address,
                    Price = model.Price,
                    Guests = model.Guests,
                    Beds = model.Beds,
                    Bathrooms = model.Bathrooms
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Units.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UnitListItem> GetUnits()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Units
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new UnitListItem
                                {
                                    UnitId = e.UnitId,
                                    Title = e.Title,
                                    Address = e.Address,
                                    Price = e.Price,
                                    Guests = e.Guests,
                                    Beds = e.Beds,
                                    Bathrooms = e.Bathrooms
                                }
                        );
                return query.ToArray();
            }
        }

        public UnitDetail GetUnitById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Units
                        .Single(e => e.UnitId == id && e.OwnerId == _userId);
                    return
                        new UnitDetail
                        {
                            Title = entity.Title,
                            Description = entity.Description,
                            Address = entity.Address,
                            Price = entity.Price,
                            Guests = entity.Guests,
                            Beds = entity.Beds,
                            Bathrooms = entity.Bathrooms
                        };
            }
        }

        public bool UpdateUnit(UnitEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Units
                        .Single(e => e.UnitId == model.UnitId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Address = model.Address;
                entity.Price = model.Price;
                entity.Guests = model.Guests;
                entity.Beds = model.Beds;
                entity.Bathrooms = model.Bathrooms;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUnit(int unitId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Units
                        .Single(e => e.UnitId == unitId && e.OwnerId == _userId);

                ctx.Units.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
