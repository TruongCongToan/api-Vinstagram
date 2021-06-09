using System;
using System.Collections.Generic;
using System.Text;
using MISA.BL.Exceptions;
using MISA.Common.Entities;

namespace MISA.BL
{
   public class CommentBL:BaseBL<Comment>
    {
        protected override void Validate(Comment entity)
        {
            throw new GuardException<Comment>("O zê", entity as Comment);
        }
    }
}
