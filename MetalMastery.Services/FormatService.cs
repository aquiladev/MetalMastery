using System;
using System.Linq;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public class FormatService : IFormatService
    {
        private readonly IRepository<Format> _formatRepository;

        public FormatService(IRepository<Format> formatRepository)
        {
            _formatRepository = formatRepository;
        }

        public IPagedList<Format> GetAllFormats(int pageIndex, int pageSize)
        {
            return new PagedList<Format>(_formatRepository
                                           .Table
                                           .ToList(),
                                       pageIndex,
                                       pageSize);
        }

        public void DeleteFormat(Format format)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            _formatRepository.Delete(format);
            _formatRepository.SaveChanges();
        }

        public void InsertFormat(Format format)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            _formatRepository.Insert(format);
            _formatRepository.SaveChanges();
        }

        public void UpdateFormat(Format format)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            var users = _formatRepository.Find(x => x.Id == format.Id);
            var userRep = users == null
                ? null
                : users.FirstOrDefault();

            if (userRep != null)
            {
                userRep.Name = format.Name;

                _formatRepository.SaveChanges();
            }
        }

        public Format GetFormatById(Guid id)
        {
            if (id.Equals(default(Guid)))
            {
                throw new ArgumentNullException("id");
            }

            var user = _formatRepository.Find(u => u.Id == id);
            return user == null
                ? null
                : user.FirstOrDefault();
        }
    }
}
