using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repository;
using DataAccess.DataAccess;

namespace eStore.Controllers
{
    public class MemberController : Controller
    {
        IMemberRepository memberRepository = new MemberRepository();
        // GET: MemberController
        public ActionResult Index()
        {
            var model = memberRepository.GetMembers();
            return View(model);
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMemberByID(id);
            if(member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                memberRepository.InsertMember(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var member = memberRepository.GetMemberByID(id);
            if( member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member member)
        {
            if(id != member.MemberId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                memberRepository.UpdateMember(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            var member = memberRepository.GetMemberByID(id);
            if(member == null)
            {
                return NotFound();
            }
            memberRepository.DeleteMember(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
