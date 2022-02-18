using BitcoinBeach.Data;
using BitcoinBeach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinBeach.Services
{
    public class ReservationService
    {
        private readonly Guid _userId;

        public ReservationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReservation(ReservationCreate model)
        {
            var entity =
                new Reservation()
                {
                    OwnerId = _userId,
                    ProfileId = model.ProfileId,
                    UnitId = model.UnitId,
                    ReservationStartDate = model.ReservationStartDate,
                    ReservationEndDate = model.ReservationEndDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reservations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReservationListItem> GetReservations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reservations
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ReservationListItem
                                {
                                    ReservationId = e.ReservationId,
                                    ReservationStartDate = e.ReservationStartDate,
                                    ReservationEndDate = e.ReservationEndDate,
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
