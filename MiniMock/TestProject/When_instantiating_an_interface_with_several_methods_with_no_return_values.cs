using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniMock.Mocking;

namespace TestProject
{
    [TestFixture]
    public class When_executing_a_method_on_an_interface_with_several_methods_with_no_return_values
    {
        private IFoo MockedObject;

        [Test]
        public void It_should_execute()
        {

        }

        [SetUp]
        public void Setup()
        {
            MockedObject = Mockery.Mock<IFoo>();
            Because();
        }

        private void Because()
        {
            MockedObject.Foo();
        }

        public interface IFoo
        {
            void Bar();
            void Foo();
        }
    }
}