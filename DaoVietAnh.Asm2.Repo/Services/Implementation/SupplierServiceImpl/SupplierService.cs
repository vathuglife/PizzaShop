using AutoMapper;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.SupplierServiceImpl
{
    public class SupplierService : ISupplierService
    {
        private IUnitOfWork? _unitOfWork;
        private List<Supplier>? _suppliers;
        private List<SupplierDTO>? _supplierDTOs;
        private Mapper? _mapper;
        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeObjects();
        }
        public List<SupplierDTO> GetSuppliers()
        {
            GetAllSuppliers();
            MapSuppliersToSupplierDTOs();
            return _supplierDTOs!;
        }
        private void GetAllSuppliers()
        {
            _suppliers = _unitOfWork!.SupplierRepository!.Get().ToList();
        }
        private void MapSuppliersToSupplierDTOs()
        {
            foreach (var supplier in _suppliers!)
            {
                SupplierDTO supplierDTO = _mapper!.Map<SupplierDTO>(supplier);
                _supplierDTOs!.Add(supplierDTO);

            }
        }
        private void InitializeObjects()
        {
            
            _mapper = new Mapper(SupplierMapper.SupplierToSupplierDTOMap());
            _supplierDTOs = new List<SupplierDTO>();
        }
    }

}
