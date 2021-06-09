using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Interface
{
    public interface iBaseBL<MISAEntity>
    {
        IEnumerable<MISAEntity> GetAll();
        MISAEntity GetById(Guid Id);
        int Insert(MISAEntity entity);
        int Update(MISAEntity entity, Guid Id);
        int Delete(Guid Id);
        IEnumerable<MISAEntity> Search(string input);

    }
}


