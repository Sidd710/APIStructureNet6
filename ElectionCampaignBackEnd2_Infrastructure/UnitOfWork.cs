using ElectionCampaignBackEnd2_Application.Interfaces;
using ElectionCampaignBackEnd2_Application.Repository;
using ElectionCampaignBackEnd2_Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectionCampaignBackEnd2_Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using ElectionCampaignBackEnd2_Application.ModelsDtos;

namespace ElectionCampaignBackEnd2_Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserMasterRepository userMasterRepository { get; }


        public UnitOfWork(ApplicationDbContext context, IUserMasterRepository userMaster)
        {
            _context = context;
            userMasterRepository = userMaster;
        }

        public int Save()
        {
           
           //var abs = string.Format("{0:yyyy-MM-ddTHH:mm:ss.FFFZ}", DateTime.UtcNow);

            foreach (var changedEntity in _context.ChangeTracker.Entries())
            {
                if (changedEntity.Entity is BaseEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.DateCreated = DateTime.UtcNow;
                            entity.CreatedBy = "Amit";
                            break;
                        case EntityState.Modified:
                            entity.DateModified = DateTime.UtcNow;
                            entity.ModifiedBy = "Ravi";
                            break;
                        case EntityState.Deleted:
                            entity.DateModified = DateTime.UtcNow;
                            entity.ModifiedBy = "Ranjeet";
                            break;
                    }
                }
            }

            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

    }
}
