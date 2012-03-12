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

            var users = _tagRepository.Find(x => x.Id == tag.Id);
            var userRep = users == null
                ? null
                : users.FirstOrDefault();

            if (userRep != null)
            {
                userRep.Name = tag.Name;

                _tagRepository.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Tag didn't found");
            }
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
