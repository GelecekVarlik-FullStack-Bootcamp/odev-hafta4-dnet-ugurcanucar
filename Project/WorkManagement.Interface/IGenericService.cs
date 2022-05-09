using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Base;
using WorkManagement.Entity.IBase;

namespace WorkManagement.Interface
{
    public interface IGenericService<T, TDto> where T : IEntityBase where TDto : IDtoBase
    {

        IResponse<List<TDto>> GetAll(); 
        IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression);
        IResponse<TDto> Find(int id);
        IResponse<TDto> Add(TDto item,bool saveChanges=true);
        Task<IResponse<TDto>> AddAsync(TDto item,bool saveChanges=true); 
        IResponse<TDto> Update(TDto item, bool saveChanges = true);
        Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true);
        IResponse<bool> DeleteById(int id, bool saveChanges = true);
        Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true);
        IResponse<IQueryable<TDto>> GetQueryable();
        void Save();











    }
}
