using AutoMapper;
using Managemail.DAL.Entities;
using Managemail.Model.Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Managemail.Repository.Implementations
{
    public class BaseRepository
    {
        public BaseRepository(ManagemailDbContext dbContext, IMapper mapper)
        {
            Mapper = mapper;
            DbContext = dbContext;

        }
        public IMapper Mapper { get; }
        public ManagemailDbContext DbContext { get; }

        public Task<IQueryable<T>> OnIncludeAsync<T>(IQueryable<T> list, IOptionsParameters options) where T : class, new()
        {
            if (options != null && options.Includes.Any())
            {
                foreach (var item in options.Includes)
                {
                    list = list.Include(item);
                }
            }

            return Task.FromResult(list);
        }

        public Task<IOrderedQueryable<T>> OnSorterAsync<T>(IQueryable<T> list, IOptionsParameters options)
        {
            var param = Expression.Parameter(typeof(T));
            if (options != null && options.Sorter.HasValue)
            {
                var sortExpression = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(param, options.Sorter.Value.Key), typeof(object)), param);
                if (options.Sorter.Value.Value == Managemail.Common.Constants.EnumConstant.SortingPairs.Desc)
                {
                    return Task.FromResult(list.OrderByDescending(sortExpression));
                }
                else
                {
                    return Task.FromResult(list.OrderBy(sortExpression));
                }
            }
            else
            {
                var sortExpression = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(param, "Id"), typeof(object)), param);
                return Task.FromResult(list.OrderBy(sortExpression));
            }
        }
    }
}
