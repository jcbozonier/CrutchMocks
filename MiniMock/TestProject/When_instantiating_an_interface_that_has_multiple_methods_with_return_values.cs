using MiniMock.Mocking;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace TestProject
{
    [TestFixture]
    public class When_executing_a_method_that_returns_an_int_on_a_mocked_object_with_mutliple_methods
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
            object Foo();
        }
    }

    [TestFixture]
    public class When_executing_a_method_that_returns_an_obj_on_a_mocked_object_with_mutliple_methods
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
            ReturnedValue = MockedObject.Foo();
        }

        public interface IFoo
        {
            int Bar();
            object Foo();
        }
    }
}
