// ReSharper disable InconsistentNaming
using MiniMock.Mocking;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class When_executing_a_mocked_method_that_has_no_return_or_parameters
    {
        private IFoo MockedObject;

        [Test]

        public void It_should_be_callable()
        {
            MockedObject.Bar();
        }

        [SetUp]
        public void Setup()
        {
            MockedObject = Mockery.Mock<IFoo>();
        }

        public interface IFoo
        {
            void Bar();
        }
    }
}
