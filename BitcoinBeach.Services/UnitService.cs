﻿using BitcoinBeach.Data;
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
                                }
                        );
                return query.ToArray();
            }
        }

    }
}
