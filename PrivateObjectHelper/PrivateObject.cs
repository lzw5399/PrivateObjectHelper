using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace PrivateObjectExtension
{
    public class PrivateObject
    {
        private static BindingFlags constructorFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance;
        private const BindingFlags BindToEveryThing = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        private object target;
        private Type originalType;
        private Dictionary<string, LinkedList<MethodInfo>> methodCache;

        /// <summary>
        /// 初始化 <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject" /> 类的新实例，
        /// 该类包含已存在的私有类对象
        /// </summary>
        /// <param name="obj"> 充当访问私有成员的起点的对象</param>
        /// <param name="memberToAccess">非关联化字符串 using，指向要以 m_X.m_Y.m_Z 形式检索的对象</param>
        public PrivateObject(object obj, string memberToAccess)
        {
            ArgumentHelper.CheckParameterNotNull(obj, nameof(obj), string.Empty);
            PrivateObject.ValidateAccessString(memberToAccess);
            PrivateObject privateObject = obj as PrivateObject ?? new PrivateObject(obj);
            string str = memberToAccess;
            char[] chArray = new char[1] { '.' };
            foreach (string name in str.Split(chArray))
                privateObject = new PrivateObject(privateObject.InvokeHelper(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.GetProperty, (object[])null, CultureInfo.InvariantCulture));
            this.target = privateObject.target;
            this.originalType = privateObject.originalType;
        }

        /// <summary>
        /// 初始化包装
        /// 指定类型的 <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject" /> 类的新实例。
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <param name="typeName">完全限定名称</param>
        /// <param name="args">要传递到构造函数的参数</param>
        public PrivateObject(string assemblyName, string typeName, params object[] args)
          : this(assemblyName, typeName, (Type[])null, args)
        {
        }

        /// <summary>
        /// 初始化包装
        /// 指定类型的 <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject" /> 类的新实例。
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <param name="typeName">完全限定名称</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示供构造函数获取的参数编号、顺序和类型的对象</param>
        /// <param name="args">要传递到构造函数的参数</param>
        public PrivateObject(
          string assemblyName,
          string typeName,
          Type[] parameterTypes,
          object[] args)
          : this(Type.GetType(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0}, {1}", (object)typeName, (object)assemblyName), false), parameterTypes, args)
        {
            ArgumentHelper.CheckParameterNotNull((object)assemblyName, nameof(assemblyName), string.Empty);
            ArgumentHelper.CheckParameterNotNull((object)typeName, nameof(typeName), string.Empty);
        }

        /// <summary>
        /// 初始化包装
        /// 指定类型的 <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject" /> 类的新实例。
        /// </summary>
        /// <param name="type">要创建的对象的类型</param>
        /// <param name="args">要传递到构造函数的参数</param>
        public PrivateObject(Type type, params object[] args)
          : this(type, (Type[])null, args)
        {
            ArgumentHelper.CheckParameterNotNull((object)type, nameof(type), string.Empty);
        }

        /// <summary>
        /// 初始化包装
        /// 指定类型的 <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject" /> 类的新实例。
        /// </summary>
        /// <param name="type">要创建的对象的类型</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示供构造函数获取的参数编号、顺序和类型的对象</param>
        /// <param name="args">要传递到构造函数的参数</param>
        public PrivateObject(Type type, Type[] parameterTypes, object[] args)
        {
            ArgumentHelper.CheckParameterNotNull((object)type, nameof(type), string.Empty);
            object obj;
            if (parameterTypes != null)
            {
                ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, (Binder)null, parameterTypes, (ParameterModifier[])null);
                if (constructor == (ConstructorInfo)null)
                    throw new ArgumentException(FrameworkMessages.PrivateAccessorConstructorNotFound);
                try
                {
                    obj = constructor.Invoke(args);
                }
                catch (TargetInvocationException ex)
                {
                    throw;
                }
            }
            else
                obj = Activator.CreateInstance(type, PrivateObject.constructorFlags, (Binder)null, args, (CultureInfo)null);
            this.ConstructFrom(obj);
        }

        /// <summary>
        /// 初始化包装
        /// 给定对象的 <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject" /> 类的新实例。
        /// </summary>
        /// <param name="obj">要包装的对象</param>
        public PrivateObject(object obj)
        {
            ArgumentHelper.CheckParameterNotNull(obj, nameof(obj), string.Empty);
            this.ConstructFrom(obj);
        }

        /// <summary>
        /// 初始化包装
        /// 给定对象的 <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject" /> 类的新实例。
        /// </summary>
        /// <param name="obj">要包装的对象</param>
        /// <param name="type">PrivateType 对象</param>
        public PrivateObject(object obj, PrivateType type)
        {
            ArgumentHelper.CheckParameterNotNull((object)type, nameof(type), string.Empty);
            this.target = obj;
            this.originalType = type.ReferencedType;
        }

        /// <summary>获取或设置目标</summary>
        public object Target
        {
            get
            {
                return this.target;
            }
            set
            {
                ArgumentHelper.CheckParameterNotNull(value, nameof(Target), string.Empty);
                this.target = value;
                this.originalType = value.GetType();
            }
        }

        /// <summary>获取基础对象的类型</summary>
        public Type RealType
        {
            get
            {
                return this.originalType;
            }
        }

        private Dictionary<string, LinkedList<MethodInfo>> GenericMethodCache
        {
            get
            {
                if (this.methodCache == null)
                    this.BuildGenericMethodCacheForType(this.originalType);
                return this.methodCache;
            }
        }

        /// <summary>返回目标对象的哈希代码</summary>
        /// <returns>表示目标对象的哈希代码的 int</returns>
        public override int GetHashCode()
        {
            return this.target.GetHashCode();
        }

        /// <summary>等于</summary>
        /// <param name="obj">要与其比较的对象</param>
        /// <returns>如果对象相等，则返回 true。</returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (typeof(PrivateObject) == obj?.GetType())
                return this.target.Equals(((PrivateObject)obj).target);
            return false;
        }

        /// <summary>调用指定方法</summary>
        /// <param name="name">方法名称</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <returns>方法调用的结果</returns>
        public object Invoke(string name, params object[] args)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.Invoke(name, (Type[])null, args, CultureInfo.InvariantCulture);
        }

        /// <summary>调用指定方法</summary>
        /// <param name="name">方法名称</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示供方法获取的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <returns>方法调用的结果</returns>
        public object Invoke(string name, Type[] parameterTypes, object[] args)
        {
            return this.Invoke(name, parameterTypes, args, CultureInfo.InvariantCulture);
        }

        /// <summary>调用指定方法</summary>
        /// <param name="name">方法名称</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示供方法获取的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <param name="typeArguments">与泛型参数的类型对应的类型数组。</param>
        /// <returns>方法调用的结果</returns>
        public object Invoke(string name, Type[] parameterTypes, object[] args, Type[] typeArguments)
        {
            return this.Invoke(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, parameterTypes, args, CultureInfo.InvariantCulture, typeArguments);
        }

        /// <summary>调用指定方法</summary>
        /// <param name="name">方法名称</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <param name="culture">区域性信息</param>
        /// <returns>方法调用的结果</returns>
        public object Invoke(string name, object[] args, CultureInfo culture)
        {
            return this.Invoke(name, (Type[])null, args, culture);
        }

        /// <summary>调用指定方法</summary>
        /// <param name="name">方法名称</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示供方法获取的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <param name="culture">区域性信息</param>
        /// <returns>方法调用的结果</returns>
        public object Invoke(string name, Type[] parameterTypes, object[] args, CultureInfo culture)
        {
            return this.Invoke(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, parameterTypes, args, culture);
        }

        /// <summary>调用指定方法</summary>
        /// <param name="name">方法名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <returns>方法调用的结果</returns>
        public object Invoke(string name, BindingFlags bindingFlags, params object[] args)
        {
            return this.Invoke(name, bindingFlags, (Type[])null, args, CultureInfo.InvariantCulture);
        }

        /// <summary>调用指定方法</summary>
        /// <param name="name">方法名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示供方法获取的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <returns>方法调用的结果</returns>
        public object Invoke(
          string name,
          BindingFlags bindingFlags,
          Type[] parameterTypes,
          object[] args)
        {
            return this.Invoke(name, bindingFlags, parameterTypes, args, CultureInfo.InvariantCulture);
        }

        /// <summary>调用指定方法</summary>
        /// <param name="name">方法名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <param name="culture">区域性信息</param>
        /// <returns>方法调用的结果</returns>
        public object Invoke(
          string name,
          BindingFlags bindingFlags,
          object[] args,
          CultureInfo culture)
        {
            return this.Invoke(name, bindingFlags, (Type[])null, args, culture);
        }

        /// <summary>调用指定方法</summary>
        /// <param name="name">方法名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示供方法获取的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <param name="culture">区域性信息</param>
        /// <returns>方法调用的结果</returns>
        public object Invoke(
          string name,
          BindingFlags bindingFlags,
          Type[] parameterTypes,
          object[] args,
          CultureInfo culture)
        {
            return this.Invoke(name, bindingFlags, parameterTypes, args, culture, (Type[])null);
        }

        /// <summary>调用指定方法</summary>
        /// <param name="name">方法名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示供方法获取的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <param name="culture">区域性信息</param>
        /// <param name="typeArguments">与泛型参数的类型对应的类型数组。</param>
        /// <returns>方法调用的结果</returns>
        public object Invoke(
          string name,
          BindingFlags bindingFlags,
          Type[] parameterTypes,
          object[] args,
          CultureInfo culture,
          Type[] typeArguments)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            if (parameterTypes == null)
                return this.InvokeHelper(name, bindingFlags | BindingFlags.InvokeMethod, args, culture);
            bindingFlags |= BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            MethodInfo methodInfo = this.originalType.GetMethod(name, bindingFlags, (Binder)null, parameterTypes, (ParameterModifier[])null);
            if (methodInfo == (MethodInfo)null && typeArguments != null)
                methodInfo = this.GetGenericMethodFromCache(name, parameterTypes, typeArguments, bindingFlags, (ParameterModifier[])null);
            if (methodInfo == (MethodInfo)null)
                throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, FrameworkMessages.PrivateAccessorMemberNotFound, (object)name));
            try
            {
                if (methodInfo.IsGenericMethodDefinition)
                    return methodInfo.MakeGenericMethod(typeArguments).Invoke(this.target, bindingFlags, (Binder)null, args, culture);
                return methodInfo.Invoke(this.target, bindingFlags, (Binder)null, args, culture);
            }
            catch (TargetInvocationException ex)
            {
                throw;
            }
        }

        /// <summary>使用每个维度的子脚本数组获取数组元素</summary>
        /// <param name="name">成员名称</param>
        /// <param name="indices">数组的索引</param>
        /// <returns>元素数组。</returns>
        public object GetArrayElement(string name, params int[] indices)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.GetArrayElement(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, indices);
        }

        /// <summary>使用每个维度的子脚本数组设置数组元素</summary>
        /// <param name="name">成员名称</param>
        /// <param name="value">要设置的值</param>
        /// <param name="indices">数组的索引</param>
        public void SetArrayElement(string name, object value, params int[] indices)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            this.SetArrayElement(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, value, indices);
        }

        /// <summary>使用每个维度的子脚本数组获取数组元素</summary>
        /// <param name="name">成员名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="indices">数组的索引</param>
        /// <returns>元素数组。</returns>
        public object GetArrayElement(string name, BindingFlags bindingFlags, params int[] indices)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return ((Array)this.InvokeHelper(name, BindingFlags.GetField | bindingFlags, (object[])null, CultureInfo.InvariantCulture)).GetValue(indices);
        }

        /// <summary>使用每个维度的子脚本数组设置数组元素</summary>
        /// <param name="name">成员名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="value">要设置的值</param>
        /// <param name="indices">数组的索引</param>
        public void SetArrayElement(
          string name,
          BindingFlags bindingFlags,
          object value,
          params int[] indices)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            ((Array)this.InvokeHelper(name, BindingFlags.GetField | bindingFlags, (object[])null, CultureInfo.InvariantCulture)).SetValue(value, indices);
        }

        /// <summary>获取字段</summary>
        /// <param name="name">字段名称</param>
        /// <returns>字段。</returns>
        public object GetField(string name)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }

        /// <summary>设置字段</summary>
        /// <param name="name">字段名称</param>
        /// <param name="value">要设置的值</param>
        public void SetField(string name, object value)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            this.SetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, value);
        }

        /// <summary>获取字段</summary>
        /// <param name="name">字段名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <returns>字段。</returns>
        public object GetField(string name, BindingFlags bindingFlags)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.InvokeHelper(name, BindingFlags.GetField | bindingFlags, (object[])null, CultureInfo.InvariantCulture);
        }

        /// <summary>设置字段</summary>
        /// <param name="name">字段名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="value">要设置的值</param>
        public void SetField(string name, BindingFlags bindingFlags, object value)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            this.InvokeHelper(name, BindingFlags.SetField | bindingFlags, new object[1]
            {
        value
            }, CultureInfo.InvariantCulture);
        }

        /// <summary>获取字段或属性</summary>
        /// <param name="name">字段或属性的名称</param>
        /// <returns>字段或属性。</returns>
        public object GetFieldOrProperty(string name)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.GetFieldOrProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }

        /// <summary>设置字段或属性</summary>
        /// <param name="name">字段或属性的名称</param>
        /// <param name="value">要设置的值</param>
        public void SetFieldOrProperty(string name, object value)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            this.SetFieldOrProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, value);
        }

        /// <summary>获取字段或属性</summary>
        /// <param name="name">字段或属性的名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <returns>字段或属性。</returns>
        public object GetFieldOrProperty(string name, BindingFlags bindingFlags)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            return this.InvokeHelper(name, BindingFlags.GetField | BindingFlags.GetProperty | bindingFlags, (object[])null, CultureInfo.InvariantCulture);
        }

        /// <summary>设置字段或属性</summary>
        /// <param name="name">字段或属性的名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="value">要设置的值</param>
        public void SetFieldOrProperty(string name, BindingFlags bindingFlags, object value)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            this.InvokeHelper(name, BindingFlags.SetField | BindingFlags.SetProperty | bindingFlags, new object[1]
            {
        value
            }, CultureInfo.InvariantCulture);
        }

        /// <summary>获取属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <returns>属性。</returns>
        public object GetProperty(string name, params object[] args)
        {
            return this.GetProperty(name, (Type[])null, args);
        }

        /// <summary>获取属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示索引属性的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <returns>属性。</returns>
        public object GetProperty(string name, Type[] parameterTypes, object[] args)
        {
            return this.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, parameterTypes, args);
        }

        /// <summary>设置属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">要设置的值</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        public void SetProperty(string name, object value, params object[] args)
        {
            this.SetProperty(name, (Type[])null, value, args);
        }

        /// <summary>设置属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示索引属性的参数编号、顺序和类型的对象。</param>
        /// <param name="value">要设置的值</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        public void SetProperty(string name, Type[] parameterTypes, object value, object[] args)
        {
            this.SetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, value, parameterTypes, args);
        }

        /// <summary>获取属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <returns>属性。</returns>
        public object GetProperty(string name, BindingFlags bindingFlags, params object[] args)
        {
            return this.GetProperty(name, bindingFlags, (Type[])null, args);
        }

        /// <summary>获取属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示索引属性的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        /// <returns>属性。</returns>
        public object GetProperty(
          string name,
          BindingFlags bindingFlags,
          Type[] parameterTypes,
          object[] args)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            if (parameterTypes == null)
                return this.InvokeHelper(name, bindingFlags | BindingFlags.GetProperty, args, (CultureInfo)null);
            PropertyInfo property = this.originalType.GetProperty(name, bindingFlags, (Binder)null, (Type)null, parameterTypes, (ParameterModifier[])null);
            if (property == (PropertyInfo)null)
                throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, FrameworkMessages.PrivateAccessorMemberNotFound, (object)name));
            return property.GetValue(this.target, args);
        }

        /// <summary>设置属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="value">要设置的值</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        public void SetProperty(
          string name,
          BindingFlags bindingFlags,
          object value,
          params object[] args)
        {
            this.SetProperty(name, bindingFlags, value, (Type[])null, args);
        }

        /// <summary>设置属性</summary>
        /// <param name="name">属性名称</param>
        /// <param name="bindingFlags">由一个或多个以下对象组成的位掩码: <see cref="T:System.Reflection.BindingFlags" /> 指定如何执行搜索。</param>
        /// <param name="value">要设置的值</param>
        /// <param name="parameterTypes">表示供方法调用的<see cref="T:System.Type" /> 表示索引属性的参数编号、顺序和类型的对象。</param>
        /// <param name="args">要传递到成员以调用的参数。</param>
        public void SetProperty(
          string name,
          BindingFlags bindingFlags,
          object value,
          Type[] parameterTypes,
          object[] args)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            if (parameterTypes != null)
            {
                PropertyInfo property = this.originalType.GetProperty(name, bindingFlags, (Binder)null, (Type)null, parameterTypes, (ParameterModifier[])null);
                if (property == (PropertyInfo)null)
                    throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, FrameworkMessages.PrivateAccessorMemberNotFound, (object)name));
                property.SetValue(this.target, value, args);
            }
            else
            {
                object[] args1 = new object[(args != null ? args.Length : 0) + 1];
                args1[0] = value;
                args?.CopyTo((Array)args1, 1);
                this.InvokeHelper(name, bindingFlags | BindingFlags.SetProperty, args1, (CultureInfo)null);
            }
        }

        /// <summary>验证访问字符串</summary>
        /// <param name="access"> 访问字符串</param>
        private static void ValidateAccessString(string access)
        {
            ArgumentHelper.CheckParameterNotNull((object)access, nameof(access), string.Empty);
            if (access.Length == 0)
                throw new ArgumentException(FrameworkMessages.AccessStringInvalidSyntax);
            string str1 = access;
            char[] chArray = new char[1] { '.' };
            foreach (string str2 in str1.Split(chArray))
            {
                if (str2.Length != 0)
                {
                    if (str2.IndexOfAny(new char[3] { ' ', '\t', '\n' }) == -1)
                        continue;
                }
                throw new ArgumentException(FrameworkMessages.AccessStringInvalidSyntax);
            }
        }

        /// <summary>调用成员</summary>
        /// <param name="name">成员名称</param>
        /// <param name="bindingFlags">其他特性</param>
        /// <param name="args">调用的参数</param>
        /// <param name="culture">区域性</param>
        /// <returns>调用的结果</returns>
        private object InvokeHelper(
          string name,
          BindingFlags bindingFlags,
          object[] args,
          CultureInfo culture)
        {
            ArgumentHelper.CheckParameterNotNull((object)name, nameof(name), string.Empty);
            try
            {
                return this.originalType.InvokeMember(name, bindingFlags, (Binder)null, this.target, args, culture);
            }
            catch (TargetInvocationException ex)
            {
                throw;
            }
        }

        private void ConstructFrom(object obj)
        {
            ArgumentHelper.CheckParameterNotNull(obj, nameof(obj), string.Empty);
            this.target = obj;
            this.originalType = obj.GetType();
        }

        private void BuildGenericMethodCacheForType(Type t)
        {
            this.methodCache = new Dictionary<string, LinkedList<MethodInfo>>();
            foreach (MethodInfo method in t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (method.IsGenericMethod || method.IsGenericMethodDefinition)
                {
                    LinkedList<MethodInfo> linkedList;
                    if (!this.GenericMethodCache.TryGetValue(method.Name, out linkedList))
                    {
                        linkedList = new LinkedList<MethodInfo>();
                        this.GenericMethodCache.Add(method.Name, linkedList);
                    }
                    linkedList.AddLast(method);
                }
            }
        }

        /// <summary>从当前私有类型中提取最合适的泛型方法签名。</summary>
        /// <param name="methodName">要在其中搜索签名缓存的方法的名称。</param>
        /// <param name="parameterTypes">与要在其中进行搜索的参数类型对应的类型数组。</param>
        /// <param name="typeArguments">与泛型参数的类型对应的类型数组。</param>
        /// <param name="bindingFlags"><see cref="T:System.Reflection.BindingFlags" /> 以进一步筛选方法签名。</param>
        /// <param name="modifiers">参数的修饰符。</param>
        /// <returns>methodinfo 实例。</returns>
        private MethodInfo GetGenericMethodFromCache(
          string methodName,
          Type[] parameterTypes,
          Type[] typeArguments,
          BindingFlags bindingFlags,
          ParameterModifier[] modifiers)
        {
            LinkedList<MethodInfo> methodCandidates = this.GetMethodCandidates(methodName, parameterTypes, typeArguments, bindingFlags, modifiers);
            MethodInfo[] array = new MethodInfo[methodCandidates.Count];
            methodCandidates.CopyTo(array, 0);
            if (parameterTypes == null || parameterTypes.Length != 0)
                return RuntimeTypeHelper.SelectMethod(bindingFlags, (MethodBase[])array, parameterTypes, modifiers) as MethodInfo;
            for (int index = 0; index < array.Length; ++index)
            {
                if (!RuntimeTypeHelper.CompareMethodSigAndName((MethodBase)array[index], (MethodBase)array[0]))
                    throw new AmbiguousMatchException();
            }
            return RuntimeTypeHelper.FindMostDerivedNewSlotMeth((MethodBase[])array, array.Length) as MethodInfo;
        }

        private LinkedList<MethodInfo> GetMethodCandidates(
          string methodName,
          Type[] parameterTypes,
          Type[] typeArguments,
          BindingFlags bindingFlags,
          ParameterModifier[] modifiers)
        {
            LinkedList<MethodInfo> linkedList1 = new LinkedList<MethodInfo>();
            LinkedList<MethodInfo> linkedList2 = (LinkedList<MethodInfo>)null;
            if (!this.GenericMethodCache.TryGetValue(methodName, out linkedList2))
                return linkedList1;
            foreach (MethodInfo methodInfo1 in linkedList2)
            {
                bool flag = true;
                if (methodInfo1.GetGenericArguments().Length == typeArguments.Length)
                {
                    MethodInfo methodInfo2 = methodInfo1;
                    ParameterInfo[] parameters = methodInfo2.GetParameters();
                    if (parameters.Length == parameterTypes.Length)
                    {
                        if ((bindingFlags & BindingFlags.ExactBinding) != BindingFlags.Default)
                        {
                            int num = 0;
                            foreach (ParameterInfo parameterInfo in parameters)
                            {
                                Type parameterType = parameterTypes[num++];
                                if (parameterInfo.ParameterType.ContainsGenericParameters)
                                {
                                    if (parameterInfo.ParameterType.IsArray != parameterType.IsArray)
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                                else if (parameterInfo.ParameterType != parameterType)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                                linkedList1.AddLast(methodInfo2);
                        }
                        else
                            linkedList1.AddLast(methodInfo2);
                    }
                }
            }
            return linkedList1;
        }
    }
}
