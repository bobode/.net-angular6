using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ng6.Controllers
{
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        private Models.SCIContext db;

       
        public MembersController(Models.SCIContext _db) { this.db = _db; }

        [HttpPost("getmembers")]
        public JsonResult getMembers()
        {

            var result = db.Members.Select(x => new
            {
                Address1 = x.Address1,
                ChapterPaidThru = x.ChapterPaidThru,
                City = x.City,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id,
                IsActive = x.IsActive,
                Lat = x.Lat,
                Lon = x.Lon,
                MembershipType = x.MembershipType,
                MemberSince = x.MemberSince,
                SciMemberId = x.SciMemberId,
                SciPaidThru = x.SciPaidThru,
                oldKey = x.OldKey,
                Notes = x.Notes,
                phone = x.Phone,
                phone2 = x.Phone2,
                Source = x.Source,
                State = x.State,
                zip = x.Zip



            }).OrderBy(x => x.LastName).ToList();

            return new JsonResult(result);
        }
    }

}



