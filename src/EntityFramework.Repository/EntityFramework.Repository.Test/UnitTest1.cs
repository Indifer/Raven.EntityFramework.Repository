﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EntityFramework.Extensions;

namespace EntityFramework.Repository.Test
{
    /// <summary>
    /// UnitTest1 的摘要说明
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var context = new CarContext();
                var testContext = new EFRepository<Car, int>(context);

                var all = context.Car.ToList();

                var cart = testContext.Get(all.First().ID);
            }
            catch 
            { 

            }
        }

        [TestMethod]
        public void TestUpdate()
        {
            using (CarContext context = new CarContext())
            {
                var testContext = new EFRepository<Car, int>(context);

                var car = context.Car.AsNoTracking().AsQueryable().ToList();
                //context.Car.Where(x => x.ID == 1).Update(x => new Car { CarPrice = 12 });

                //testContext.Update(x => x.ID == 1, x => new Car { CarPrice = 12 });
                context.SaveChanges();
            }
        }

    }
}
