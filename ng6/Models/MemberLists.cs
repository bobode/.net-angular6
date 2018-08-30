using System;
using System.Collections.Generic;

namespace ng6.Models
{
    public partial class MemberLists
    {
        public MemberLists()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            MemberMemberLists = new HashSet<MemberMemberLists>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AspNetUsers> AspNetUsers { get; set; }
        public ICollection<MemberMemberLists> MemberMemberLists { get; set; }
    }
}
