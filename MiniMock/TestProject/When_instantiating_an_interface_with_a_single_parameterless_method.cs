// ReSharper disable InconsistentNaming
using MiniMock.Mocking;

namespace TestProject
{
    [TestFixture]
    public class When_instantiating_an_interface_with_a_single_parameterless_method
    {
        private IFoo MockedObject;

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
            void Bar();
        }
    }
}
