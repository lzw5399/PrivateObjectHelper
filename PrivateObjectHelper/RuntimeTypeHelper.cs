// Decompiled with JetBrains decompiler
// Type: Microsoft.VisualStudio.TestTools.UnitTesting.RuntimeTypeHelper
// Assembly: Microsoft.VisualStudio.TestPlatform.TestFramework.Extensions, Version=14.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 8BE6613E-1946-4EBE-9141-645F044E7008
// Assembly location: C:\Users\11301\source\repos\NetFrameworkTestEverything\packages\MSTest.TestFramework.1.2.0\lib\net45\Microsoft.VisualStudio.TestPlatform.TestFramework.Extensions.dll

using System;
using System.Reflection;

namespace PrivateObjectExtension
{
    /// <summary>为泛型方法提供方法签名发现。</summary>
    internal class RuntimeTypeHelper
    {
        /// <summary>比较这两种方法的方法签名。</summary>
        /// <param name="m1">Method1</param>
        /// <param name="m2">Method2</param>
        /// <returns>如果相似则为 true。</returns>
        internal static bool CompareMethodSigAndName(MethodBase m1, MethodBase m2)
        {
            ParameterInfo[] parameters1 = m1.GetParameters();
            ParameterInfo[] parameters2 = m2.GetParameters();
            if (parameters1.Length != parameters2.Length)
                return false;
            int length = parameters1.Length;
            for (int index = 0; index < length; ++index)
            {
                if (parameters1[index].ParameterType != parameters2[index].ParameterType)
                    return false;
            }
            return true;
        }

        /// <summary>从所提供类型的基类型获取层次结构深度。</summary>
        /// <param name="t">类型。</param>
        /// <returns>深度。</returns>
        internal static int GetHierarchyDepth(Type t)
        {
            int num = 0;
            Type type = t;
            do
            {
                ++num;
                type = type.BaseType;
            }
            while (type != (Type)null);
            return num;
        }

        /// <summary>通过提供的信息查找高度派生的类型。</summary>
        /// <param name="match">候选匹配。</param>
        /// <param name="cMatches">匹配数。</param>
        /// <returns>派生程度最高的方法。</returns>
        internal static MethodBase FindMostDerivedNewSlotMeth(
          MethodBase[] match,
          int cMatches)
        {
            int num1 = 0;
            MethodBase methodBase = (MethodBase)null;
            for (int index = 0; index < cMatches; ++index)
            {
                int hierarchyDepth = RuntimeTypeHelper.GetHierarchyDepth(match[index].DeclaringType);
                if (hierarchyDepth == num1)
                {
                    int num2 = methodBase != (MethodBase)null ? 1 : 0;
                    throw new AmbiguousMatchException();
                }
                if (hierarchyDepth > num1)
                {
                    num1 = hierarchyDepth;
                    methodBase = match[index];
                }
            }
            return methodBase;
        }

        /// <summary>
        /// 如果给定了一组与基础条件匹配的方法，则基于
        /// 类型数组选择一个方法。如果没有方法与条件匹配，此方法应
        /// 返回 null。
        /// </summary>
        /// <param name="bindingAttr">绑定规范。</param>
        /// <param name="match">候选匹配</param>
        /// <param name="types">类型</param>
        /// <param name="modifiers">参数修饰符。</param>
        /// <returns>匹配方法。如无匹配则为 null。</returns>
        internal static MethodBase SelectMethod(
          BindingFlags bindingAttr,
          MethodBase[] match,
          Type[] types,
          ParameterModifier[] modifiers)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match));
            Type[] typeArray = new Type[types.Length];
            for (int index = 0; index < types.Length; ++index)
                typeArray[index] = types[index].UnderlyingSystemType;
            types = typeArray;
            if (match.Length == 0)
                return (MethodBase)null;
            int num = 0;
            for (int index1 = 0; index1 < match.Length; ++index1)
            {
                ParameterInfo[] parameters = match[index1].GetParameters();
                if (parameters.Length == types.Length)
                {
                    int index2;
                    for (index2 = 0; index2 < types.Length; ++index2)
                    {
                        Type parameterType = parameters[index2].ParameterType;
                        if (parameterType.ContainsGenericParameters)
                        {
                            if (parameterType.IsArray != types[index2].IsArray)
                                break;
                        }
                        else if (!(parameterType == types[index2]) && !(parameterType == typeof(object)) && !parameterType.IsAssignableFrom(types[index2]))
                            break;
                    }
                    if (index2 == types.Length)
                        match[num++] = match[index1];
                }
            }
            if (num == 0)
                return (MethodBase)null;
            if (num == 1)
                return match[0];
            int index3 = 0;
            bool flag = false;
            int[] numArray = new int[types.Length];
            for (int index1 = 0; index1 < types.Length; ++index1)
                numArray[index1] = index1;
            for (int index1 = 1; index1 < num; ++index1)
            {
                switch (RuntimeTypeHelper.FindMostSpecificMethod(match[index3], numArray, (Type)null, match[index1], numArray, (Type)null, types, (object[])null))
                {
                    case 0:
                        flag = true;
                        break;
                    case 2:
                        flag = false;
                        index3 = index1;
                        break;
                }
            }
            if (flag)
                throw new AmbiguousMatchException();
            return match[index3];
        }

        /// <summary>在提供的两种方法中找到最具有针对性的方法。</summary>
        /// <param name="m1">方法 1</param>
        /// <param name="paramOrder1">方法 1 的参数顺序</param>
        /// <param name="paramArrayType1">参数数组类型。</param>
        /// <param name="m2">方法 2</param>
        /// <param name="paramOrder2">方法 2 的参数顺序</param>
        /// <param name="paramArrayType2">&gt;Paramter 数组类型。</param>
        /// <param name="types">要在其中进行搜索的类型。</param>
        /// <param name="args">参数。</param>
        /// <returns>表示匹配的 int。</returns>
        internal static int FindMostSpecificMethod(
          MethodBase m1,
          int[] paramOrder1,
          Type paramArrayType1,
          MethodBase m2,
          int[] paramOrder2,
          Type paramArrayType2,
          Type[] types,
          object[] args)
        {
            int mostSpecific = RuntimeTypeHelper.FindMostSpecific(m1.GetParameters(), paramOrder1, paramArrayType1, m2.GetParameters(), paramOrder2, paramArrayType2, types, args);
            if (mostSpecific != 0)
                return mostSpecific;
            if (!RuntimeTypeHelper.CompareMethodSigAndName(m1, m2))
                return 0;
            int hierarchyDepth1 = RuntimeTypeHelper.GetHierarchyDepth(m1.DeclaringType);
            int hierarchyDepth2 = RuntimeTypeHelper.GetHierarchyDepth(m2.DeclaringType);
            if (hierarchyDepth1 == hierarchyDepth2)
                return 0;
            return hierarchyDepth1 < hierarchyDepth2 ? 2 : 1;
        }

        /// <summary>在提供的两种方法中找到最具有针对性的方法。</summary>
        /// <param name="p1">方法 1</param>
        /// <param name="paramOrder1">方法 1 的参数顺序</param>
        /// <param name="paramArrayType1">参数数组类型。</param>
        /// <param name="p2">方法 2</param>
        /// <param name="paramOrder2">方法 2 的参数顺序</param>
        /// <param name="paramArrayType2">&gt;参数数组类型。</param>
        /// <param name="types">要在其中进行搜索的类型。</param>
        /// <param name="args">参数。</param>
        /// <returns>表示匹配的 int。</returns>
        internal static int FindMostSpecific(
          ParameterInfo[] p1,
          int[] paramOrder1,
          Type paramArrayType1,
          ParameterInfo[] p2,
          int[] paramOrder2,
          Type paramArrayType2,
          Type[] types,
          object[] args)
        {
            if (paramArrayType1 != (Type)null && paramArrayType2 == (Type)null)
                return 2;
            if (paramArrayType2 != (Type)null && paramArrayType1 == (Type)null)
                return 1;
            bool flag1 = false;
            bool flag2 = false;
            for (int index = 0; index < types.Length; ++index)
            {
                if (args == null || args[index] != Type.Missing)
                {
                    Type c1 = !(paramArrayType1 != (Type)null) || paramOrder1[index] < p1.Length - 1 ? p1[paramOrder1[index]].ParameterType : paramArrayType1;
                    Type c2 = !(paramArrayType2 != (Type)null) || paramOrder2[index] < p2.Length - 1 ? p2[paramOrder2[index]].ParameterType : paramArrayType2;
                    if (!(c1 == c2) && !c1.ContainsGenericParameters && !c2.ContainsGenericParameters)
                    {
                        switch (RuntimeTypeHelper.FindMostSpecificType(c1, c2, types[index]))
                        {
                            case 0:
                                return 0;
                            case 1:
                                flag1 = true;
                                continue;
                            case 2:
                                flag2 = true;
                                continue;
                            default:
                                continue;
                        }
                    }
                }
            }
            if (flag1 == flag2)
            {
                if (!flag1 && p1.Length != p2.Length && args != null)
                {
                    if (p1.Length == args.Length)
                        return 1;
                    if (p2.Length == args.Length)
                        return 2;
                }
                return 0;
            }
            return !flag1 ? 2 : 1;
        }

        /// <summary>在提供的两种类型中找到一种最具针对性的类型。</summary>
        /// <param name="c1">类型 1</param>
        /// <param name="c2">类型 2</param>
        /// <param name="t">定义类型</param>
        /// <returns>表示匹配的 int。</returns>
        internal static int FindMostSpecificType(Type c1, Type c2, Type t)
        {
            if (c1 == c2)
                return 0;
            if (c1 == t)
                return 1;
            if (c2 == t)
                return 2;
            if (c1.IsByRef || c2.IsByRef)
            {
                if (c1.IsByRef && c2.IsByRef)
                {
                    c1 = c1.GetElementType();
                    c2 = c2.GetElementType();
                }
                else if (c1.IsByRef)
                {
                    if (c1.GetElementType() == c2)
                        return 2;
                    c1 = c1.GetElementType();
                }
                else
                {
                    if (c2.GetElementType() == c1)
                        return 1;
                    c2 = c2.GetElementType();
                }
            }
            bool flag1;
            bool flag2;
            if (c1.IsPrimitive && c2.IsPrimitive)
            {
                flag1 = true;
                flag2 = true;
            }
            else
            {
                flag1 = c1.IsAssignableFrom(c2);
                flag2 = c2.IsAssignableFrom(c1);
            }
            if (flag1 == flag2)
                return 0;
            return flag1 ? 2 : 1;
        }
    }
}
