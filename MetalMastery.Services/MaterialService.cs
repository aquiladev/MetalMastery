using System;
using System.Linq;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IRepository<Material> _materialRepository;

        public MaterialService(IRepository<Material> materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public IPagedList<Material> GetAllMaterials(int pageIndex, int pageSize)
        {
            return new PagedList<Material>(_materialRepository
                                           .Table
                                           .ToList(),
                                       pageIndex,
                                       pageSize);
        }

        public void DeleteMaterial(Material material)
        {
            if (material == null)
            {
                throw new ArgumentNullException("material");
            }

            _materialRepository.Delete(material);
            _materialRepository.SaveChanges();
        }

        public void InsertMaterial(Material material)
        {
            if (material == null)
            {
                throw new ArgumentNullException("material");
            }

            _materialRepository.Insert(material);
            _materialRepository.SaveChanges();
        }

        public void UpdateMaterial(Material material)
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
        }

        public Material GetMaterialById(Guid id)
        {
            if (id.Equals(default(Guid)))
            {
                throw new ArgumentNullException("id");
            }

            var user = _materialRepository.Find(u => u.Id == id);
            return user == null
                ? null
                : user.FirstOrDefault();
        }
    }
}
