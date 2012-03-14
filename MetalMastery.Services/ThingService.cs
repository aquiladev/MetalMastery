using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;

namespace MetalMastery.Services
{
    public class ThingService : BaseEntityService<Thing>, IThingService
    {
        private readonly IRepository<Thing> _thingRepository;
        private readonly IStateService _stateService;

        public ThingService(IRepository<Thing> thingRepository, IStateService stateService)
            : base(thingRepository)
        {
            _thingRepository = thingRepository;
            _stateService = stateService;
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
                throw new InvalidOperationException("Tag didn't found");
            }

            thingRep.Name = thing.Name;
            thingRep.Description = thing.Description;
            thingRep.ImageRes = thing.ImageRes;
            thingRep.Image1 = thing.Image1;
            thingRep.Image2 = thing.Image2;
            thingRep.Rating = thing.Rating;
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

        public IPagedList<Thing> GetPublishedCompletedThings(int pageIndex, int pageSize)
        {
            Guid completedStateId = _stateService
                .GetStateByName(States.Completed.ToString())
                .Id;

            return new PagedList<Thing>(
                GetOrderedThings()
                    .Where(x => x.ShowForAll
                        && x.StateId == completedStateId)
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
