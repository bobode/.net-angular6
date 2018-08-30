using System;
using System.Collections.Generic;

namespace ng6.Models
{
    public partial class Members
    {
        public Members()
        {
            MemberMemberLists = new HashSet<MemberMemberLists>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public int SciMemberId { get; set; }
        public string Email { get; set; }
        public int Source { get; set; }
        public string Notes { get; set; }
        public string MembershipType { get; set; }
        public int OldKey { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public DateTime? MemberSince { get; set; }
        public DateTime? SciPaidThru { get; set; }
        public DateTime? ChapterPaidThru { get; set; }
        public bool IsActive { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }

        public ICollection<MemberMemberLists> MemberMemberLists { get; set; }
    }
}
