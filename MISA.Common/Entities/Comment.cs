using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Entities
{
  public class Comment
    {
        public Guid CommentId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? PostId { get; set; }
        public string CommentContent { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
