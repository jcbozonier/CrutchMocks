using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace MiniMock
{
    public class Mockery
    {
        public static T Mock<T>()
        {
            var assemblyName = new AssemblyName();
            assemblyName.Name = "mockedAssembly";
            var assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("tmpModule");

            var typeBuilder = moduleBuilder.DefineType("MockedFoo", 
                                                       TypeAttributes.Public | TypeAttributes.Class,
                                                       null,
                                                       new[] { typeof(T) });

            var mockType = typeof (T);
            var methods = mockType.GetMethods();

            if (methods.Count() > 0)
            {
                foreach (var methodInfo in methods)
                {
                    var firstMethodName = methodInfo.Name;
                    Type[] parameterTypes = null;

                    if(_MethodHasParameters(methodInfo))
                    {
                        parameterTypes = _GetParamterTypes(methodInfo);
                    }

                    if (_MethodReturnsValue(methodInfo))
                    {
                        _GenerateMethodWithReturnNoParams(methodInfo, typeBuilder, firstMethodName, parameterTypes);
                    }
                    else
                    {
                        _GenerateMethodNoReturnNoParams(typeBuilder, firstMethodName);
                    }
                }
            }

            var mockedType = typeBuilder.CreateType();
            var mockedObject = Activator.CreateInstance(mockedType);

            return (T) mockedObject;
        }

        private static Type[] _GetParamterTypes(MethodInfo methodInfo)
        {
            var parameterList = methodInfo.GetParameters();
            if (parameterList == null) 
                return null;
            
            var result = parameterList.Select(x => x.ParameterType).ToArray();
            return result;
        }

        private static bool _MethodHasParameters(MethodInfo methodInfo)
        {
            return methodInfo.GetParameters().Count() > 0;
        }

        private static void _GenerateMethodNoReturnNoParams(TypeBuilder typeBuilder, string firstMethodName)
        {
            var methodBuilder = typeBuilder.DefineMethod(
                firstMethodName,
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof (void),
                null);
            var methodIL = methodBuilder.GetILGenerator();

            methodIL.Emit(OpCodes.Nop);
            methodIL.Emit(OpCodes.Ret);
        }

        private static void _GenerateMethodWithReturnNoParams(MethodInfo methodInfo, TypeBuilder typeBuilder, string firstMethodName, Type[] parameterTypes)
        {
            var returnType = methodInfo.ReturnType;
            var methodBuilder = typeBuilder.DefineMethod(
                firstMethodName,
                MethodAttributes.Public | MethodAttributes.Virtual,
                returnType,
                parameterTypes);
            methodBuilder.InitLocals = true;
            var methodIL = methodBuilder.GetILGenerator();

            methodIL.DeclareLocal(returnType);
            methodIL.Emit(OpCodes.Nop);
            methodIL.Emit(OpCodes.Ldloc_0);
            methodIL.Emit(OpCodes.Ret);
        }

        private static bool _MethodReturnsValue(MethodInfo methodInfo)
        {
            return methodInfo.ReturnType != typeof(void);
        }
    }
}
