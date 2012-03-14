using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;

namespace MetalMastery.Services
{
    public class TagService : BaseEntityService<Tag>, ITagService
    {
        private readonly IRepository<Tag> _tagRepository;

        public TagService(IRepository<Tag> tagRepository)
            : base(tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public override void Update(Tag tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("tag");
            }

            var tags = _tagRepository.Find(x => x.Id == tag.Id);
            var tagRep = tags == null
                ? null
                : tags.FirstOrDefault();

            if (tagRep == null)
            {
                throw new InvalidOperationException("Tag didn't found");
            }

            tagRep.Name = tag.Name;

            _tagRepository.SaveChanges();

        }

        public List<Tag> GetAll()
        {
            return _tagRepository
                .Table
                .OrderBy(t => t.Name)
                .ToList();
        }
    }
}
