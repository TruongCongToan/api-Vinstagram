using MISA.DL;
using System;
using System.Collections.Generic;

namespace MISA.BL
{
    public class BaseBL<MISAEntity>
    {

        public IEnumerable<MISAEntity> GetAll()
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.GetAll<MISAEntity>();
        }

        public MISAEntity GetById(Guid id)
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.GetById<MISAEntity>(id);
        }
       
        public int Insert(MISAEntity entity)
        {
            // validate dữ liệu:
            Validate(entity);
            BaseDL baseDL = new BaseDL();
            return baseDL.Insert<MISAEntity>(entity);
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.Update<MISAEntity>(entity, entityId);
        }

        public int Delete(Guid entityId)
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.Delete<MISAEntity>(entityId);
        }
        public IEnumerable<MISAEntity>Search(string m_input)
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.Search<MISAEntity>(m_input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        protected virtual void Validate( MISAEntity entity)
        {

        }
    }
}
