﻿using ApplicationCore.Interfaces;
using Core.Dto.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Presenters
{
    public sealed class GetCartPresenter : IOutputPort<GetCartResponse>
    {
        public CartindexViewModel CartindexViewModel { get; }

        public GetCartPresenter()
        {
            CartindexViewModel = new CartindexViewModel();
        }

        public void Handle(GetCartResponse response)
        {
            CartindexViewModel.Lines = response.Lines;
        }
    }
}