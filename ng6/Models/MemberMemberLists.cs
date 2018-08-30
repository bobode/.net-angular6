using System;
using System.Collections.Generic;

namespace ng6.Models
{
    public partial class MemberMemberLists
    {
        public int MemberId { get; set; }
        public int MemberListId { get; set; }

        public Members Member { get; set; }
        public MemberLists MemberList { get; set; }
    }
}
