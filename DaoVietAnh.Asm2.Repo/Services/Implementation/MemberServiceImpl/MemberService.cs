using AutoMapper;
using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Mappers;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.MemberServiceImpl
{
    public class MemberService : IMemberService
    {
        private IUnitOfWork _unitOfWork;
        private IEnumerable<Account>? _members;
        private List<MemberDTO>? _memberDTOs;
        private Mapper? _mapper;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeObjects();
        }
        public async Task<MemberServiceResponse> GetMembers()
        {
            await Task.Run(() => GetAllMembersFromDb());
            MapMembersToMemberDTOs();
            return SuccessMemberRetrievalResult();
        }
        private void InitializeObjects()
        {
            _mapper = new Mapper(AccountMapper.AccountToMemberDTOMap());
            _memberDTOs = new List<MemberDTO>();
        }
        private void GetAllMembersFromDb()
        {
            _members = _unitOfWork.AccountRepository
                .Get(account => account.Type == AccountTypeEnum.MEMBER);   
        }
        private void MapMembersToMemberDTOs()
        {
            foreach(Account member in _members!)
            {
                MemberDTO memberDTO = _mapper!.Map<MemberDTO>(member);
                memberDTO.Type = AccountTypeEnum.MEMBER;
                _memberDTOs!.Add(memberDTO);
            }
        }
        private MemberServiceResponse SuccessMemberRetrievalResult()
        {
            return new MemberServiceResponse()
            {
                Result = MemberServiceEnum.SUCCESS,
                ReturnData = _memberDTOs
            };
        }        
    }
}
