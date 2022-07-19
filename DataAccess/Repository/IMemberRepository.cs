using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int MemberID);
        public Member GetMemberByAccount(string email, string password);
        void InsertMember(Member member);
        void DeleteMember(int MemberID);
        void UpdateMember(Member member);
    }
}
