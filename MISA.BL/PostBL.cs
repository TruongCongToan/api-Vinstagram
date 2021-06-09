using System;
using MISA.Common.Entities;
using System.Collections.Generic;
using System.Text;
using MISA.BL.Exceptions;

namespace MISA.BL
{
   public class PostBL:BaseBL<Post>
    {
        protected override void Validate(Post entity)
        {
            throw new GuardException<Post>("O zê", entity as Post);
        }
    }
}
