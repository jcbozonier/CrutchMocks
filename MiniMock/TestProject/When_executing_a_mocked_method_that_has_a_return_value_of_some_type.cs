using System;
using MiniMock;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class When_executing_a_mocked_method_that_has_a_return_value_of_null_and_multiple_parameters
    {
        private IFoo MockedObject;
        private object ReturnedValue;

        [Test]

        public void It_should_return_the_default_value()
        {
            Assert.That(ReturnedValue, Is.EqualTo(null));
        }

        [SetUp]
        public void Setup()
        {
            MockedObject = Mockery.Mock<IFoo>();
            Because();
        }

        private void Because()
        {
            ReturnedValue = MockedObject.Bar(3, 6);
        }

        public interface IFoo
        {
            IDisposable Bar(int x, object y);
        }
    }

    [TestFixture]
    public class When_executing_a_mocked_method_that_has_a_return_value_of_null_and_parameters
    {
        private IFoo MockedObject;
        private object ReturnedValue;

        [Test]
        public void It_should_return_the_default_value()
        {
            Assert.That(ReturnedValue, Is.EqualTo(null));
        }

        [SetUp]
        public void Setup()
        {
            MockedObject = Mockery.Mock<IFoo>();
            Because();
        }

        private void Because()
        {
            ReturnedValue = MockedObject.Bar(2);
        }

        public interface IFoo
        {
            object Bar(int param1);
        }
    }

    [TestFixture]
    public class When_executing_a_mocked_method_that_has_a_return_value_of_null
    {
        private IFoo MockedObject;
        private object ReturnedValue;

        [Test]

        public void It_should_return_the_default_value()
        {
            Assert.That(ReturnedValue, Is.EqualTo(null));
        }

        [SetUp]
        public void Setup()
        {
            MockedObject = Mockery.Mock<IFoo>();
            Because();
        }

        private void Because()
        {
            ReturnedValue = MockedObject.Bar();
        }

        public interface IFoo
        {
            IDisposable Bar();
        }
    }

    [TestFixture]
    public class When_executing_a_mocked_method_that_has_a_return_value_of_type_bool
    {
        private IFoo MockedObject;
        private bool ReturnedValue;

        [Test]

        public void It_should_return_the_default_value()
        {
            Assert.That(ReturnedValue, Is.EqualTo(false));
        }

        [SetUp]
        public void Setup()
        {
            MockedObject = Mockery.Mock<IFoo>();
            Because();
        }

        private void Because()
        {
            ReturnedValue = MockedObject.Bar();
        }

        public interface IFoo
        {
            bool Bar();
        }
    }

    [TestFixture]
    public class When_executing_a_mocked_method_that_has_a_return_value_of_type_int
    {
        private IFoo MockedObject;
        private int ReturnedValue;

        [Test]

        public void It_should_return_the_default_value()
        {
            Assert.That(ReturnedValue, Is.EqualTo(0));
        }

        [SetUp]
        public void Setup()
        {
            MockedObject = Mockery.Mock<IFoo>();
            Because();
        }

        private void Because()
        {
            ReturnedValue = MockedObject.Bar();
        }

        public interface IFoo
        {
            int Bar();
        }
    }
}
