using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePump.Models;
using ThePump.Controllers;
using ThePump.Data;
using Microsoft.EntityFrameworkCore;

namespace ThePumpTestNew
{
    [TestClass]
    public class GoalsControllerTest
    {
        [TestMethod]
        public void IndexReturnsResult()
        {
            var controller = new GoalsController(null);

            var result = controller.Index();

            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CreateLoadsCreateView()
        {
            var controller = new GoalsController(null);

            var result = (ViewResult)controller.Create();

            Assert.AreEqual("Create", result.ViewName);


        }

        private ApplicationDbContext _context;

        List<Goal> FitnessGoals = new List<Goal>();

        GoalsController controller;

        [TestInitialize]

        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);

            var Goal = new Goal { Id = 100, FitnessGoal = "Test goal" };
            _context.Goal.Add(Goal);
            _context.SaveChanges();



            FitnessGoals.Add(new Goal { Id = 1, FitnessGoal = "weight lifting", StartingDate = 08122021, FinishingDate = 12082022 });


            FitnessGoals.Add(new Goal { Id = 2, FitnessGoal = "cardio", StartingDate = 21082021, FinishingDate = 21082022 });


            FitnessGoals.Add(new Goal { Id = 3, FitnessGoal = "body weight traing", StartingDate = 12092021, FinishingDate = 11022022 });


            foreach (var g in FitnessGoals)
            {
                _context.Goal.Add(g);


            }
            _context.SaveChanges();

            controller = new GoalsController(_context);

        }

        [TestMethod]

        public void IndexViewLoads()
        {
            var result = controller.Index();
            var viewResult = (ViewResult)result.Result;
            Assert.AreEqual("Index", viewResult.ViewName);
        }

        [TestMethod]

        public void IndexReturnsProductData()
        {
            var result = controller.Create();
            var viewResult = (ViewResult)result;
            Assert.AreEqual("Create", viewResult.ViewName);

        }
        [TestMethod]

        public void IndexReturns()
        {
            var result = controller.Index();
            var viewResult = (ViewResult)result.Result;
            var model = (List<Goal>)viewResult.Model;
            var orderedForms = FitnessGoals.OrderBy(g => g.FitnessGoal).ToList();
            CollectionAssert.AreEqual(orderedForms, model);
        }

        [TestMethod]
        public void DeleteReturnsResult()
        {
            //arrange

            //act
            var result = controller.Delete(null);
            var viewResult = (ViewResult)result.Result;

            var model = (List<Goal>)viewResult.Model;

            //assert
            Assert.AreEqual("index", viewResult.ViewName);
            CollectionAssert.AreEqual(FitnessGoals, model);
        }



    }
}


