﻿// ReSharper disable InconsistentNaming
using MiniMock.Mocking;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class When_instantiating_an_empty_interface
    {
        private object MockedObject;

        [Test]
        public void It_should_return_an_object_of_the_same_type()
        {
            Assert.That(MockedObject is IFoo);
        }

        [SetUp]
        public void Setup()
        {
            MockedObject = Mockery.Mock<IFoo>();
        }

        public interface IFoo
        {

        }
    }
}
