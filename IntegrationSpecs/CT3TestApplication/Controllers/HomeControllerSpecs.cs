using CT3Application.Web.Controllers;
using CT3Application.Web.Data;
using CT3Application.Web.Models;
using IntegrationSpecs.TestHelpers;
using NUnit.Framework;
using Should;
using SpecsFor;
using SpecsFor.Helpers.Web.Mvc;
using System;
using System.Data.Entity.Migrations;
using System.Web.Mvc;

namespace IntegrationSpecs.CT3TestApplication.Controllers
{
    public class HomeControllerSpecs
    {
        public class when_when_getting_a_list_of_tasks :
            SpecsFor<HomeController>, INeedDatabase
        {
            public ApplicationDbContext Database { get; set; }

            protected override void Given()
            {
                //Database = new ApplicationDbContext(CommonHelper.GetConnectionString(System.AppDomain.CurrentDomain.GetData("isUsedForSpecs") != null && (bool)System.AppDomain.CurrentDomain.GetData("isUsedForSpecs")));
                for (var i = 0; i < 5; i++)
                {
                    task t = new task()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Task " + i,
                        Description = "Dummy task " + i
                    };

                    Database.tasks.AddOrUpdate(t);
                }

                Database.SaveChanges();
            }

            private ActionResult _result;

            protected override void When()
            {
                _result = SUT.Index();
            }

            [Test]
            public void then_it_returns_tasks()
            {
                _result.ShouldRenderDefaultView()
                    .WithModelType<TaskSummaryViewModel[]>()
                    .Length.ShouldEqual(5);
            }

        }
    }
}
