using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;

namespace MetalMastery.Services
{
    public class MaterialService : BaseEntityService<Material>, IMaterialService
    {
        private readonly IRepository<Material> _materialRepository;

        public MaterialService(IRepository<Material> materialRepository) 
            : base(materialRepository)
        {
            _materialRepository = materialRepository;
        }
        
        public override void Update(Material material)
        {
            if (material == null)
            {
                throw new ArgumentNullException("material");
            }

            var users = _materialRepository.Find(x => x.Id == material.Id);
            var userRep = users == null
                ? null
                : users.FirstOrDefault();

            if (userRep != null)
            {
                userRep.Name = material.Name;

                _materialRepository.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Material didn't found");
            }
        }

        public List<Material> GetAll()
        {
            return _materialRepository
                .Table
                .OrderBy(t => t.Name)
                .ToList();
        }
    }
}
