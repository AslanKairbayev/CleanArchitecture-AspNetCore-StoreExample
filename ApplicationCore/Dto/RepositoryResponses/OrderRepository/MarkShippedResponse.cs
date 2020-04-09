﻿using ApplicationCore.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.RepositoryResponses.OrderRepository
{
    public sealed class MarkShippedResponse : BaseRepositoryResponse
    {
        public MarkShippedResponse(bool success = false) : base(success)
        {
            
        }
    }
}