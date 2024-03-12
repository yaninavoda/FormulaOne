﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IDriverRepository Drivers { get; }
        IAchievementsRepository Achievements { get; }

        Task<bool> CompleteAsync();
    }
}
