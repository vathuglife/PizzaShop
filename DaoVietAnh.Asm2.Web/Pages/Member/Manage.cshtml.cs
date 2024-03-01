using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Payload.Request;
using DaoVietAnh.Asm2.Repo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DaoVietAnh.Asm2.Web.Pages.Member
{
    public class ManageModel : PageModel
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; } = 15;
        public List<MemberDTO>? MemberDTOs;
        private IMemberService _memberService;

        public ManageModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public async Task OnGet()
        {
            var result = await Task.Run(() =>
                _memberService.GetMembers()
            );
            MemberDTOs = (List<MemberDTO>)result.ReturnData!;
        }      
    }
}
