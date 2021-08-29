﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ECommerceSystem.Profile.Services;
using ECommerceSystem.Web.Models;
using Microsoft.AspNetCore.Http;

namespace ECommerceSystem.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductListModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _httpContextAccessor= Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }
        public ProductListModel(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }

        internal object GetProducts(DataTablesAjaxRequestModel dataTableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var data = _productService.GetProducts(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] { "Name", "Price"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Price.ToString(),
                            record.Id.ToString()
                        }
                    ).ToArray()
            };

        }

        internal void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
