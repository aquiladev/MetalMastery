using System;
using System.Linq;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public class TagService : ITagService
    {
        private readonly IRepository<Tag> _tagRepository;

        public TagService(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IPagedList<Tag> GetAllTags(int pageIndex, int pageSize)
        {
            return new PagedList<Tag>(_tagRepository
                                           .Table
                                           .ToList(),
                                       pageIndex,
                                       pageSize);
        }

        public void DeleteTag(Tag tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("tag");
            }

            _tagRepository.Delete(tag);
            _tagRepository.SaveChanges();
        }

        public void InsertTag(Tag tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("tag");
            }

            _tagRepository.Insert(tag);
            _tagRepository.SaveChanges();
        }

        public void UpdateTag(Tag tag)
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
        }

        public Tag GetTagById(Guid id)
        {
            if (id.Equals(default(Guid)))
            {
                throw new ArgumentNullException("id");
            }

            var user = _tagRepository.Find(u => u.Id == id);
            return user == null
                ? null
                : user.FirstOrDefault();
        }
    }
}
