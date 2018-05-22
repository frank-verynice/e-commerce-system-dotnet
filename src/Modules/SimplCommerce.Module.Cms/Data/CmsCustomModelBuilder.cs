﻿using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Cms.Data
{
    public class CmsCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasData(
                new Menu(1) { Name = "Customer Services", IsPublished = true, IsSystem = true },
                new Menu(2) { Name = "Information", IsPublished = true, IsSystem = true }
                );

            modelBuilder.Entity<EntityType>().HasData(
                new EntityType("Page") { RoutingController = "Page", RoutingAction = "PageDetail", IsMenuable = true }
                );

            modelBuilder.Entity<Widget>().HasData(
                new Widget("HtmlWidget") { Name = "Html Widget", ViewComponentName = "HtmlWidget", CreateUrl = "widget-html-create", EditUrl = "widget-html-edit" },
                new Widget("CarouselWidget") { Name = "Carousel Widget", ViewComponentName = "CarouselWidget", CreateUrl = "widget-carousel-create", EditUrl = "widget-carousel-edit" },
                new Widget("SpaceBarWidget") { Name = "SpaceBar Widget", ViewComponentName = "SpaceBarWidget", CreateUrl = "widget-spacebar-create", EditUrl = "widget-spacebar-edit" }
                );
        }
    }
}
