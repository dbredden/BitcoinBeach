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

        public ReservationDetail GetReservationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reservations
                        .Single(e => e.ReservationId == id && e.OwnerId == _userId);
                return
                    new ReservationDetail
                    {
                        ReservationId = entity.ReservationId,
                        ProfileId = entity.ProfileId,
                        UnitId = entity.UnitId,
                        ReservationStartDate = entity.ReservationStartDate,
                        ReservationEndDate = entity.ReservationEndDate
                    };
            }
        }

        public bool UpdateReservation(ReservationEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reservations
                        .Single(e => e.ReservationId == model.ReservationId && e.OwnerId == _userId);

                entity.ReservationId = model.ReservationId;
                entity.ProfileId = model.ProfileId;
                entity.UnitId = model.UnitId;
                entity.ReservationStartDate = model.ReservationStartDate;
                entity.ReservationEndDate = model.ReservationEndDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReservation(int reservationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reservations
                        .Single(e => e.ReservationId == reservationId && e.OwnerId == _userId);

                ctx.Reservations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
