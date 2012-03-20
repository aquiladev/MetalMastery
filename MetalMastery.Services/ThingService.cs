using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Core.Web;
using MetalMastery.Services.Interfaces;

namespace MetalMastery.Services
{
    public class ThingService : BaseEntityService<Thing>, IThingService
    {
        private readonly IRepository<Thing> _thingRepository;
        private readonly IRepository<ThingState> _thingStateRepository;

        public ThingService(IRepository<Thing> thingRepository, IRepository<ThingState> thingStateRepository)
            : base(thingRepository)
        {
            _thingRepository = thingRepository;
            _thingStateRepository = thingStateRepository;
        }

        public override void Update(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException("thing");
            }

            var things = _thingRepository.Find(x => x.Id == thing.Id);
            var thingRep = things == null
                               ? null
                               : things.FirstOrDefault();

            if (thingRep == null)
            {
                throw new InvalidOperationException("Thing didn't found");
            }

            thingRep.Name = thing.Name;
            thingRep.Description = thing.Description;
            thingRep.ImageRes = thing.ImageRes;
            thingRep.Image1 = thing.Image1;
            thingRep.Image2 = thing.Image2;
            thingRep.Rating = thing.Rating;
            thingRep.Price = thing.Price;
            thingRep.ShowForAll = thing.ShowForAll;
            thingRep.ShowOnHome = thing.ShowOnHome;
            thingRep.Comment = thing.Comment;
            thingRep.FormatId = thing.FormatId;
            thingRep.MaterialId = thing.MaterialId;
            thingRep.StateId = thing.StateId;

            _thingRepository.SaveChanges();
        }

        public override IPagedList<Thing> GetAll(int pageIndex, int pageSize)
        {
            return new PagedList<Thing>(
                GetOrderedThings()
                    .ToList(),
                pageIndex,
                pageSize);
        }

        public IPagedList<Thing> GetPublishedThings(int pageIndex, int pageSize)
        {
            return new PagedList<Thing>(
                GetOrderedThings()
                    .Join(_thingStateRepository.Table, t => t.StateId, s => s.Id, (t, s) => new {t, s})
                    .Where(x => x.t.ShowForAll
                                && (x.s.Name == States.Completed.ToString()
                                    || x.s.Name == States.Sale.ToString()))
                    .Select(z => z.t)
                    .ToList(),
                pageIndex,
                pageSize
                );
        }

        #region private methods

        private IEnumerable<Thing> GetOrderedThings()
        {
            return _thingRepository
                .Table
                .OrderByDescending(a => a.CreateDate)
                .ToList()
                .Select(a => new Thing
                {
                    Id = a.Id,
                    CreateDate = a.CreateDate,
                    Name = a.Name,
                    Description = a.Description.GetPreviewText(),
                    ImageRes = a.ImageRes,
                    StateId = a.StateId,
                    ShowForAll = a.ShowForAll
                });
        }

        #endregion
    }
}
