using AutoMapper;
using Managemail.DAL.Entities;
using Managemail.Model.Common.Infrastructure;
using Managemail.Model.Common.Interfaces;
using Managemail.Repository.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managemail.Repository.Implementations
{
    public class EmailHistoryRepository : IEmailHistoryRepository
    {
        public EmailHistoryRepository(ManagemailDbContext managemailDbContext, IMapper mapper)
        {
            ManagemailDbContext = managemailDbContext;
            Mapper = mapper;
        }

        public ManagemailDbContext ManagemailDbContext { get; }
        public IMapper Mapper { get; }

        public async Task<IEnumerable<IEmailHistoryModel>> FindAsync(IOptionsParameters options)
        {
            var list = ManagemailDbContext.EmailHistories.AsQueryable();
            list = await OnIncludeAsync(list, options);
            
            return Mapper.Map<IEnumerable<IEmailHistoryModel>>(await list.ToListAsync());
        }

        private Task<IQueryable<EmailHistory>> OnIncludeAsync(IQueryable<EmailHistory> list, IOptionsParameters options)
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

        public async Task<bool> InsertAsync(IEmailHistoryModel model)
        {
            EmailHistory entity = Mapper.Map<EmailHistory>(model);
            await ManagemailDbContext.AddAsync(entity);
            return await ManagemailDbContext.SaveChangesAsync() == 1; //there is only one that needs to be saved in database so this is only one operation
        }
    }
}
