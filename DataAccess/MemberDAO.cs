using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class MemberDAO
    {

        AssignmentContext db = new AssignmentContext();
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public Member GetMemberByAccount(string email, string password) => db.Members.Where(m => m.Email.Equals(email) && m.Password.Equals(password)).FirstOrDefault();

        public IEnumerable<Member> GetMemberList()
        {
            var members = new List<Member>();
            List<Member> FList = new List<Member>();
            try
            {
                using var context = new AssignmentContext();
                members = context.Members.ToList();
                for (int i = 1; i <= members.Count; i++)
                {
                    if (members[i - 1].Status == 1) { FList.Add(members[i - 1]); }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;

        }

        public Member GetMemberByID(int MemberID)
        {
            Member mem = null;
            try
            {
                using var context = new AssignmentContext();

                mem = context.Members.SingleOrDefault(m=>m.MemberId==MemberID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return mem;
        }

        
        public void AddNew(Member member)
        {
            try
            {
                Member mem = GetMemberByID(member.MemberId);
                if (mem == null)
                {
                    using var context = new AssignmentContext();
                    context.Members.Add(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
      


        public void Update(Member member)
        {

            try
            {
                Member mem = GetMemberByID(member.MemberId);
                if (mem != null)
                {
                    using var context = new AssignmentContext();
                    context.Members.Update(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       
        
        public void Remove(int MemberId)
        {
            try
            {
                Member mem = GetMemberByID(MemberId);
                if (mem != null)
                {
                    using (AssignmentContext db = new AssignmentContext())
                    {
                        Member member = db.Members.Where(d => d.MemberId == MemberId).First();
                        member.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
    }
}
