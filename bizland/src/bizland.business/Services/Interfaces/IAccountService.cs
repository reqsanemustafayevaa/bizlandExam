﻿using bizland.business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Services.Interfaces
{
    public interface IAccountService
    {
        Task Login(loginViewModel loginView);
    }
}
