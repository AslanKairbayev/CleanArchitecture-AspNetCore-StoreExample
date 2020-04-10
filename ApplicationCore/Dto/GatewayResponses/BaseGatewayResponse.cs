﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.Repository
{
    public abstract class BaseGatewayResponse
    {
        public bool Success { get; }

        protected BaseGatewayResponse(bool success = false)
        {
            Success = success;
        }
    }
}