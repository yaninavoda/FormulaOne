﻿using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        public IDriverRepository Drivers { get; }
        public IAchievementsRepository Achievements {  get; }

        public UnitOfWork(
            AppDbContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger  = loggerFactory.CreateLogger("logs");

            Drivers = new DriverRepository(context, logger);
            Achievements = new AchievementsRepository(context, logger);
        }
        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
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
                _context?.Dispose();   
            }
        }
    }
}
