﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Blog.Core.Data.Entities;
using Blog.Core.Data.Migrations;
using Blog.Core.Paging;
using Blog.Models;
using MarkdownSharp;

namespace Blog
{
    public class MvcApplication : HttpApplication
    {
        private readonly Markdown _markdown = new Markdown();

        protected void Application_Start()
        {
            AutoMapper();


            Mapper.AssertConfigurationIsValid();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new Configuration());
        }

        private void AutoMapper()
        {

            Mapper.CreateMap<BlogEntry, Entry>()
                .ForMember(entry => entry.Content, 
                    expression => expression.ResolveUsing(source => _markdown.Transform(source.Content)))                .ForMember(entry => entry.Summary,
                    expression => expression.ResolveUsing(source => _markdown.Transform(source.Summary)));

            //Mapper.CreateMap<BlogEntry, Entry>()
            //    .ForMember(entry => entry.Summary,
            //        expression => expression.ResolveUsing(source => _markdown.Transform(source.Summary)));

            Mapper.CreateMap<PagedList<BlogEntry>, PagedList<Entry>>()
                .AfterMap((entitiy, viewModel) => Mapper.Map<List<BlogEntry>, List<Entry>>(entitiy, viewModel));
        }
    }


}