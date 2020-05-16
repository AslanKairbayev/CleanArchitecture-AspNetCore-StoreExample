﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto.UseCaseRequests;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Presenters;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IGetProductsByParamUseCase _getProductsByParamUseCase;
        private readonly GetProductsByParamPresenter _getProductsByParamPresenter;

        public ProductController(IGetProductsByParamUseCase getProductsByParamUseCase, GetProductsByParamPresenter getProductsByParamPresenter)
        {
            _getProductsByParamUseCase = getProductsByParamUseCase;
            _getProductsByParamPresenter = getProductsByParamPresenter;
        }

        [HttpGet("GetProductsByParam")]
        public async Task<IActionResult> Get(string category, int page)
        {
            await _getProductsByParamUseCase.Handle(new GetProductsByParamRequest(page, category), _getProductsByParamPresenter);

            return Ok(_getProductsByParamPresenter.ViewModel);
        }        
    }
}