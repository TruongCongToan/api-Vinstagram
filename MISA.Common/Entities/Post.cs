using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Entities
{
  public  class Post
    {
        public Guid PostId { get; set; }
        public string ImageName { get; set; }
        public string PostContent { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }

    }
}
