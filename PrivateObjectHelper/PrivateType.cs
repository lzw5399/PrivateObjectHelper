// Decompiled with JetBrains decompiler
// Type: Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType
// Assembly: Microsoft.VisualStudio.TestPlatform.TestFramework.Extensions, Version=14.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 8BE6613E-1946-4EBE-9141-645F044E7008
// Assembly location: C:\Users\11301\source\repos\NetFrameworkTestEverything\packages\MSTest.TestFramework.1.2.0\lib\net45\Microsoft.VisualStudio.TestPlatform.TestFramework.Extensions.dll

using System;
using System.Globalization;
using System.Reflection;

namespace PrivateObjectExtension
{
    /// <summary>此类表示专用访问器功能的私有类。</summary>
    public class PrivateType
    {
        /// <summary>绑定到所有内容</summary>
        private const BindingFlags BindToEveryThing = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
        /// <summary>包装的类型。</summary>
        private Type type;

        /// <summary>
        /// 初始化包含私有类型的 <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType" /> 类的新实例。
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <param name="typeName">其完全限定的名称 </param>
        public PrivateType(string assemblyName, string typeName)
        {
            ArgumentHelper.CheckParameterNotNullOrEmpty(assemblyName, nameof(assemblyName), string.Empty);
            ArgumentHelper.CheckParameterNotNullOrEmpty(typeName, nameof(typeName), string.Empty);
            this.type = Assembly.Load(assemblyName).GetType(typeName, true);
        }

        /// <summary>
        /// 初始化 <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType" /> 类的新实例，
        /// 该类包含类型对象中的
        /// 私有类型</summary>
        /// <param name="type">要创建的包装类型。</param>
        public PrivateType(Type type)
        {
            if (type == (Type)null)
                throw new ArgumentNullException(nameof(type));
            this.type = type;
        }

        /// <summary>获取引用的类型</summary>
        public Type ReferencedType
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>调用静态成员</summary>
        /// <param name="name">InvokeHelper 的成员的名称</param>
        /// <param name="args">调用的参数</param>
        /// <returns>调用的结果</returns>
        public object InvokeStatic(string name, params object[] args)
        {
            return this.InvokeStatic(name, (Type[])null, args, CultureInfo.InvariantCulture);
        }

        /// <summary>调用静态成员</summary>
        /// <param name="name">InvokeHelper 的成员的名称</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" />参数编号、顺序和类型的对象数组</param>
        /// <param name="args">调用的参数</param>
        /// <returns>调用的结果</returns>
        public object InvokeStatic(string name, Type[] parameterTypes, object[] args)
        {
            return this.InvokeStatic(name, parameterTypes, args, CultureInfo.InvariantCulture);
        }

        /// <summary>调用静态成员</summary>
        /// <param name="name">InvokeHelper 的成员的名称</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" />参数编号、顺序和类型的对象数组</param>
        /// <param name="args">调用的参数</param>
        /// <param name="typeArguments">与泛型参数的类型对应的类型数组。</param>
        /// <returns>调用的结果</returns>
        public object InvokeStatic(
          string name,
          Type[] parameterTypes,
          object[] args,
          Type[] typeArguments)
        {
            return this.InvokeStatic(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, parameterTypes, args, CultureInfo.InvariantCulture, typeArguments);
        }

        /// <summary>调用静态方法</summary>
        /// <param name="name">成员名称</param>
        /// <param name="args">调用的参数</param>
        /// <param name="culture">区域性</param>
        /// <returns>调用的结果</returns>
        public object InvokeStatic(string name, object[] args, CultureInfo culture)
        {
            return this.InvokeStatic(name, (Type[])null, args, culture);
        }

        /// <summary>调用静态方法</summary>
        /// <param name="name">成员名称</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" />参数编号、顺序和类型的对象数组</param>
        /// <param name="args">调用的参数</param>
        /// <param name="culture">区域性信息</param>
        /// <returns>调用的结果</returns>
        public object InvokeStatic(
          string name,
          Type[] parameterTypes,
          object[] args,
          CultureInfo culture)
        {
            return this.InvokeStatic(name, BindingFlags.InvokeMethod, parameterTypes, args, culture);
        }

        /// <summary>调用静态方法</summary>
        /// <param name="name">成员名称</param>
        /// <param name="bindingFlags">其他调用特性</param>
        /// <param name="args">调用的参数</param>
        /// <returns>调用的结果</returns>
        public object InvokeStatic(string name, BindingFlags bindingFlags, params object[] args)
        {
            return this.InvokeStatic(name, bindingFlags, (Type[])null, args, CultureInfo.InvariantCulture);
        }

        /// <summary>调用静态方法</summary>
        /// <param name="name">成员名称</param>
        /// <param name="bindingFlags">其他调用特性</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" />参数编号、顺序和类型的对象数组</param>
        /// <param name="args">调用的参数</param>
        /// <returns>调用的结果</returns>
        public object InvokeStatic(
          string name,
          BindingFlags bindingFlags,
          Type[] parameterTypes,
          object[] args)
        {
            return this.InvokeStatic(name, bindingFlags, parameterTypes, args, CultureInfo.InvariantCulture);
        }

        /// <summary>调用静态方法</summary>
        /// <param name="name">成员名称</param>
        /// <param name="bindingFlags">其他调用特性</param>
        /// <param name="args">调用的参数</param>
        /// <param name="culture">区域性</param>
        /// <returns>调用的结果</returns>
        public object InvokeStatic(
          string name,
          BindingFlags bindingFlags,
          object[] args,
          CultureInfo culture)
        {
            return this.InvokeStatic(name, bindingFlags, (Type[])null, args, culture);
        }

        /// <summary>调用静态方法</summary>
        /// <param name="name">成员名称</param>
        /// <param name="bindingFlags">其他调用特性</param>
        /// 
        ///             /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" />参数编号、顺序和类型的对象数组</param>
        /// <param name="args">调用的参数</param>
        /// <param name="culture">区域性</param>
        /// <returns>调用的结果</returns>
        public object InvokeStatic(
          string name,
          BindingFlags bindingFlags,
          Type[] parameterTypes,
          object[] args,
          CultureInfo culture)
        {
            return this.InvokeStatic(name, bindingFlags, parameterTypes, args, culture, (Type[])null);
        }

        /// <summary>调用静态方法</summary>
        /// <param name="name">成员名称</param>
        /// <param name="bindingFlags">其他调用特性</param>
        /// 
        ///             /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" />参数编号、顺序和类型的对象数组</param>
        /// <param name="args">调用的参数</param>
        /// <param name="culture">区域性</param>
        /// <param name="typeArguments">与泛型参数的类型对应的类型数组。</param>
        /// <returns>调用的结果</returns>
        public object InvokeStatic(
          string name,
          BindingFlags bindingFlags,
          Type[] parameterTypes,
          object[] args,
          CultureInfo culture,
          Type[] typeArguments)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            if (parameterTypes == null)
                return this.InvokeHelperStatic(name, bindingFlags | BindingFlags.InvokeMethod, args, culture);
            MethodInfo method = this.type.GetMethod(name, bindingFlags | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Static, (Binder)null, parameterTypes, (ParameterModifier[])null);
            if (method == (MethodInfo)null)
                throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, FrameworkMessages.PrivateAccessorMemberNotFound, (object)name));
            try
            {
                if (method.IsGenericMethodDefinition)
                    return method.MakeGenericMethod(typeArguments).Invoke((object)null, bindingFlags, (Binder)null, args, culture);
                return method.Invoke((object)null, bindingFlags, (Binder)null, args, culture);
            }
            catch (TargetInvocationException ex)
            {
                throw;
            }
        }

        /// <summary>获取静态数组中的元素</summary>
        /// <param name="name">数组名称</param>
        /// <param name="indices">
        /// 一个 32 位整数的一维数组，表示指定要获取的
        /// 元素位置的索引。例如，要访问 a[10][11]，则索引为 {10,11}
        /// </param>
        /// <returns>指定位置处的元素</returns>
        public object GetStaticArrayElement(string name, params int[] indices)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.GetStaticArrayElement(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, indices);
        }

        /// <summary>设置静态数组的成员</summary>
        /// <param name="name">数组名称</param>
        /// <param name="value">要设置的值</param>
        /// <param name="indices">
        /// 一个 32 位整数的一维数组，表示指定要设置的
        /// 元素位置的索引。例如，要访问 a[10][11]，则数组为 {10,11}
        /// </param>
        public void SetStaticArrayElement(string name, object value, params int[] indices)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            this.SetStaticArrayElement(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, value, indices);
        }

        /// <summary>获取静态数组中的元素</summary>
        /// <param name="name">数组名称</param>
        /// <param name="bindingFlags">其他 InvokeHelper 特性</param>
        /// <param name="indices">
        /// 一个 32 位整数的一维数组，表示指定要获取的
        /// 元素位置的索引。例如，要访问 a[10][11]，则数组为 {10,11}
        /// </param>
        /// <returns>指定位置处的元素</returns>
        public object GetStaticArrayElement(
          string name,
          BindingFlags bindingFlags,
          params int[] indices)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return ((Array)this.InvokeHelperStatic(name, BindingFlags.GetField | BindingFlags.GetProperty | bindingFlags, (object[])null, CultureInfo.InvariantCulture)).GetValue(indices);
        }

        /// <summary>设置静态数组的成员</summary>
        /// <param name="name">数组名称</param>
        /// <param name="bindingFlags">其他 InvokeHelper 特性</param>
        /// <param name="value">要设置的值</param>
        /// <param name="indices">
        /// 一个 32 位整数的一维数组，表示指定要设置的
        /// 元素位置的索引。例如，要访问 a[10][11]，则数组为 {10,11}
        /// </param>
        public void SetStaticArrayElement(
          string name,
          BindingFlags bindingFlags,
          object value,
          params int[] indices)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            ((Array)this.InvokeHelperStatic(name, BindingFlags.Static | BindingFlags.GetField | BindingFlags.GetProperty | bindingFlags, (object[])null, CultureInfo.InvariantCulture)).SetValue(value, indices);
        }

        /// <summary>获取静态字段</summary>
        /// <param name="name">字段名称</param>
        /// <returns>静态字段。</returns>
        public object GetStaticField(string name)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.GetStaticField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
        }

        /// <summary>设置静态字段</summary>
        /// <param name="name">字段名称</param>
        /// <param name="value">调用的参数</param>
        public void SetStaticField(string name, object value)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            this.SetStaticField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, value);
        }

        /// <summary>使用指定的 InvokeHelper 属性获取静态字段</summary>
        /// <param name="name">字段名称</param>
        /// <param name="bindingFlags">其他调用特性</param>
        /// <returns>静态字段。</returns>
        public object GetStaticField(string name, BindingFlags bindingFlags)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.InvokeHelperStatic(name, BindingFlags.Static | BindingFlags.GetField | bindingFlags, (object[])null, CultureInfo.InvariantCulture);
        }

        /// <summary>使用绑定属性设置静态字段</summary>
        /// <param name="name">字段名称</param>
        /// <param name="bindingFlags">其他 InvokeHelper 特性</param>
        /// <param name="value">调用的参数</param>
        public void SetStaticField(string name, BindingFlags bindingFlags, object value)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            this.InvokeHelperStatic(name, BindingFlags.SetField | bindingFlags | BindingFlags.Static, new object[1]
            {
        value
            }, CultureInfo.InvariantCulture);
        }

        /// <summary>获取静态字段或属性</summary>
        /// <param name="name">字段或属性的名称</param>
        /// <returns>静态字段或属性。</returns>
        public object GetStaticFieldOrProperty(string name)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.GetStaticFieldOrProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
        }

        /// <summary>设置静态字段或属性</summary>
        /// <param name="name">字段或属性的名称</param>
        /// <param name="value">要设置到字段或属性的值</param>
        public void SetStaticFieldOrProperty(string name, object value)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            this.SetStaticFieldOrProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, value);
        }

        /// <summary>使用指定的 InvokeHelper 属性获取静态字段或属性</summary>
        /// <param name="name">字段或属性的名称</param>
        /// <param name="bindingFlags">其他调用特性</param>
        /// <returns>静态字段或属性。</returns>
        public object GetStaticFieldOrProperty(string name, BindingFlags bindingFlags)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.InvokeHelperStatic(name, BindingFlags.Static | BindingFlags.GetField | BindingFlags.GetProperty | bindingFlags, (object[])null, CultureInfo.InvariantCulture);
        }

        /// <summary>使用绑定属性设置静态字段或属性</summary>
        /// <param name="name">字段或属性的名称</param>
        /// <param name="bindingFlags">其他调用特性</param>
        /// <param name="value">要设置到字段或属性的值</param>
        public void SetStaticFieldOrProperty(string name, BindingFlags bindingFlags, object value)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            this.InvokeHelperStatic(name, BindingFlags.SetField | BindingFlags.SetProperty | bindingFlags | BindingFlags.Static, new object[1]
            {
        value
            }, CultureInfo.InvariantCulture);
        }

        /// <summary>获取静态属性</summary>
        /// <param name="name">字段或属性的名称</param>
        /// <param name="args">调用的参数</param>
        /// <returns>静态属性。</returns>
        public object GetStaticProperty(string name, params object[] args)
        {
            return this.GetStaticProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, args);
        }

        /// <summary>设置静态属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">要设置到字段或属性的值</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        public void SetStaticProperty(string name, object value, params object[] args)
        {
            this.SetStaticProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, value, (Type[])null, args);
        }

        /// <summary>设置静态属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">要设置到字段或属性的值</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示索引属性的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        public void SetStaticProperty(string name, object value, Type[] parameterTypes, object[] args)
        {
            this.SetStaticProperty(name, BindingFlags.SetProperty, value, parameterTypes, args);
        }

        /// <summary>获取静态属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="bindingFlags">其他调用特性。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <returns>静态属性。</returns>
        public object GetStaticProperty(string name, BindingFlags bindingFlags, params object[] args)
        {
            return this.GetStaticProperty(name, BindingFlags.Static | BindingFlags.GetProperty | bindingFlags, (Type[])null, args);
        }

        /// <summary>获取静态属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="bindingFlags">其他调用特性。</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示索引属性的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <returns>静态属性。</returns>
        public object GetStaticProperty(
          string name,
          BindingFlags bindingFlags,
          Type[] parameterTypes,
          object[] args)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            if (parameterTypes == null)
                return this.InvokeHelperStatic(name, bindingFlags | BindingFlags.GetProperty, args, (CultureInfo)null);
            PropertyInfo property = this.type.GetProperty(name, bindingFlags | BindingFlags.Static, (Binder)null, (Type)null, parameterTypes, (ParameterModifier[])null);
            if (property == (PropertyInfo)null)
                throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, FrameworkMessages.PrivateAccessorMemberNotFound, (object)name));
            return property.GetValue((object)null, args);
        }

        /// <summary>设置静态属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="bindingFlags">其他调用特性。</param>
        /// <param name="value">要设置到字段或属性的值</param>
        /// <param name="args">索引属性的可选索引值。索引属性的索引以零为基础。对于非索引属性此值应为 null。 </param>
        public void SetStaticProperty(
          string name,
          BindingFlags bindingFlags,
          object value,
          params object[] args)
        {
            this.SetStaticProperty(name, bindingFlags, value, (Type[])null, args);
        }

        /// <summary>设置静态属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="bindingFlags">其他调用特性。</param>
        /// <param name="value">要设置到字段或属性的值</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示索引属性的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        public void SetStaticProperty(
          string name,
          BindingFlags bindingFlags,
          object value,
          Type[] parameterTypes,
          object[] args)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            if (parameterTypes != null)
            {
                PropertyInfo property = this.type.GetProperty(name, bindingFlags | BindingFlags.Static, (Binder)null, (Type)null, parameterTypes, (ParameterModifier[])null);
                if (property == (PropertyInfo)null)
                    throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, FrameworkMessages.PrivateAccessorMemberNotFound, (object)name));
                property.SetValue((object)null, value, args);
            }
            else
            {
                object[] args1 = new object[(args != null ? args.Length : 0) + 1];
                args1[0] = value;
                args?.CopyTo((Array)args1, 1);
                this.InvokeHelperStatic(name, bindingFlags | BindingFlags.SetProperty, args1, (CultureInfo)null);
            }
        }

        /// <summary>调用静态方法</summary>
        /// <param name="name">成员名称</param>
        /// <param name="bindingFlags">其他调用特性</param>
        /// <param name="args">调用的参数</param>
        /// <param name="culture">区域性</param>
        /// <returns>调用的结果</returns>
        private object InvokeHelperStatic(
          string name,
          BindingFlags bindingFlags,
          object[] args,
          CultureInfo culture)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            try
            {
                return this.type.InvokeMember(name, bindingFlags | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Static, (Binder)null, (object)null, args, culture);
            }
            catch (TargetInvocationException ex)
            {
                throw;
            }
        }
    }
}
