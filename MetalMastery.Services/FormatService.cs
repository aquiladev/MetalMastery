using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;

namespace MetalMastery.Services
{
    public class FormatService : BaseEntityService<Format>, IFormatService
    {
        private readonly IRepository<Format> _formatRepository;

        public FormatService(IRepository<Format> formatRepository)
            : base(formatRepository)
        {
            _formatRepository = formatRepository;
        }

        public override void Update(Format format)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            var formats = _formatRepository.Find(x => x.Id == format.Id);
            var formatRep = formats == null
                ? null
                : formats.FirstOrDefault();

            if (formatRep == null)
            {
                throw new InvalidOperationException("Format didn't found");
            }

            formatRep.Name = format.Name;

            _formatRepository.SaveChanges();
        }

        public List<Format> GetAll()
        {
            return _formatRepository
                .Table
                .OrderBy(t => t.Name)
                .ToList();
        }
    }
}
