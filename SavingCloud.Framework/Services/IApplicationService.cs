﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud.Application
{
    /// <summary>
    /// This interface must be implemented by all application services to identify them by convention.
    /// </summary>
    public interface IApplicationService : ITransientDependency
    {

    }
}
