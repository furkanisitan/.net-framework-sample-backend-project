﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Aspects.Postsharp.TransactionAspects;
using Shop.Business.Tests.Db.EntityFramework.Configuration;
using Shop.Entities.Concrete;
using System;
using System.Linq;

namespace Shop.Business.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class TransactionScopeAspectTests
    {
        private ShopBusinessTestContext _context;

        [TestInitialize]
        public void InitDatabase()
        {
            _context = new ShopBusinessTestContext();
            _context.Database.Initialize(true);
        }

        [TestMethod]
        public void TestEntityFrameworkTransactionMethod()
        {
            try { EntityFrameworkTransactionMethod(); }
            catch { /* ignored */ }
            Assert.AreEqual(0, _context.Categories.Count());
        }

        [TransactionScopeAspect]
        private void EntityFrameworkTransactionMethod()
        {
            _context.Categories.Add(new Category { Name = "category1", });
            _context.SaveChanges();
            throw new Exception("test exception");
        }
    }
}
