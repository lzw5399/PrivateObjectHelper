using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace PrivateObjectExtension
{
    /// <summary>一个强类型资源类，用于查找已本地化的字符串等。</summary>
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [DebuggerNonUserCode]
    [CompilerGenerated]
    internal class FrameworkMessages
    {
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        internal FrameworkMessages()
        {
        }

        /// <summary>返回此类使用的缓存的 ResourceManager 实例。</summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (FrameworkMessages.resourceMan == null)
                    FrameworkMessages.resourceMan = new ResourceManager("Microsoft.VisualStudio.TestTools.UnitTesting.Resources.FrameworkMessages", typeof(FrameworkMessages).GetTypeInfo().Assembly);
                return FrameworkMessages.resourceMan;
            }
        }

        /// <summary>
        ///   使用此强类型资源类为所有资源查找替代
        ///   当前线程的 CurrentUICulture 属性。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return FrameworkMessages.resourceCulture;
            }
            set
            {
                FrameworkMessages.resourceCulture = value;
            }
        }

        /// <summary>查找类似于“访问字符串具有无效语法。”的已本地化字符串。</summary>
        internal static string AccessStringInvalidSyntax
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AccessStringInvalidSyntax), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“预期集合包含 {1} 个 &lt;{2}&gt; 的匹配项。实际集合包含 {3} 个匹配项。{0}”的已本地化字符串。
        /// </summary>
        internal static string ActualHasMismatchedElements
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(ActualHasMismatchedElements), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“找到了重复项: &lt;{1}&gt;。{0}”的已本地化字符串。</summary>
        internal static string AllItemsAreUniqueFailMsg
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AllItemsAreUniqueFailMsg), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“预期为: &lt;{1}&gt;。实际值的大小写有所不同: &lt;{2}&gt;。{0}”的已本地化字符串。
        /// </summary>
        internal static string AreEqualCaseFailMsg
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AreEqualCaseFailMsg), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“预期值 &lt;{1}&gt; 和实际值 &lt;{2}&gt; 之间的预期差异应不大于 &lt;{3}&gt;。{0}”的已本地化字符串。
        /// </summary>
        internal static string AreEqualDeltaFailMsg
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AreEqualDeltaFailMsg), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“预期为: &lt;{1} ({2})&gt;。实际为: &lt;{3} ({4})&gt;。{0}”的已本地化字符串。
        /// </summary>
        internal static string AreEqualDifferentTypesFailMsg
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AreEqualDifferentTypesFailMsg), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“预期为: &lt;{1}&gt;。实际为: &lt;{2}&gt;。{0}”的已本地化字符串。
        /// </summary>
        internal static string AreEqualFailMsg
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AreEqualFailMsg), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“预期值 &lt;{1}&gt; 和实际值 &lt;{2}&gt; 之间的预期差异应大于 &lt;{3}&gt;。{0}”的已本地化字符串。
        /// </summary>
        internal static string AreNotEqualDeltaFailMsg
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AreNotEqualDeltaFailMsg), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“预期为除 &lt;{1}&gt;外的任何值。实际为: &lt;{2}&gt;。{0}”的已本地化字符串。
        /// </summary>
        internal static string AreNotEqualFailMsg
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AreNotEqualFailMsg), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“不要向 AreSame() 传递值类型。转换为对象的值永远不会相同。请考虑使用 AreEqual()。{0}”的已本地化字符串。
        /// </summary>
        internal static string AreSameGivenValues
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AreSameGivenValues), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“{0} 失败。{1}”的已本地化字符串。</summary>
        internal static string AssertionFailed
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AssertionFailed), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“不支持具有 UITestMethodAttribute 的异步 TestMethod。请删除异步或使用 TestMethodAttribute。” 的已本地化字符串。
        /// </summary>
        internal static string AsyncUITestMethodNotSupported
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(AsyncUITestMethodNotSupported), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“这两个集合都为空。{0}”的已本地化字符串。</summary>
        internal static string BothCollectionsEmpty
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(BothCollectionsEmpty), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“这两个集合包含相同元素。”的已本地化字符串。</summary>
        internal static string BothCollectionsSameElements
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(BothCollectionsSameElements), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“这两个集合引用指向同一个集合对象。{0}”的已本地化字符串。</summary>
        internal static string BothCollectionsSameReference
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(BothCollectionsSameReference), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“这两个集合包含相同的元素。{0}”的已本地化字符串。</summary>
        internal static string BothSameElements
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(BothSameElements), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“{0}({1})”的已本地化字符串。</summary>
        internal static string CollectionEqualReason
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(CollectionEqualReason), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于 "(null)" 的已本地化字符串。</summary>
        internal static string Common_NullInMessages
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(Common_NullInMessages), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“(对象)”的已本地化字符串。</summary>
        internal static string Common_ObjectString
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(Common_ObjectString), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“字符串“{0}”不包含字符串“{1}”。{2}。”的已本地化字符串。</summary>
        internal static string ContainsFail
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(ContainsFail), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“{0} ({1})”的已本地化字符串。</summary>
        internal static string DataDrivenResultDisplayName
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(DataDrivenResultDisplayName), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“Assert.Equals 不应用于断言。请改用 Assert.AreEqual 和重载。”的已本地化字符串。
        /// </summary>
        internal static string DoNotUseAssertEquals
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(DoNotUseAssertEquals), FrameworkMessages.resourceCulture);
            }
        }

        internal static string DynamicDataIEnumerableNull
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(DynamicDataIEnumerableNull), FrameworkMessages.resourceCulture);
            }
        }

        internal static string DynamicDataValueNull
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(DynamicDataValueNull), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“集合中的元素数目不匹配。预期为: &lt;{1}&gt;。实际为: &lt;{2}&gt;。{0}”的已本地化字符串。
        /// </summary>
        internal static string ElementNumbersDontMatch
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(ElementNumbersDontMatch), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“索引 {0} 处的元素不匹配。”的已本地化字符串。</summary>
        internal static string ElementsAtIndexDontMatch
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(ElementsAtIndexDontMatch), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“索引 {1} 处的元素不是预期类型。预期类型为: &lt;{2}&gt;。实际类型为: &lt;{3}&gt;。{0}”的已本地化字符串。
        /// </summary>
        internal static string ElementTypesAtIndexDontMatch
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(ElementTypesAtIndexDontMatch), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“索引 {1} 处的元素为 (null)。预期类型: &lt;{2}&gt;。{0}”的已本地化字符串。
        /// </summary>
        internal static string ElementTypesAtIndexDontMatch2
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(ElementTypesAtIndexDontMatch2), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“字符串“{0}”不以字符串“{1}”结尾。{2}。”的已本地化字符串。</summary>
        internal static string EndsWithFail
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(EndsWithFail), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“参数无效 - EqualsTester 不能使用 null。”的已本地化字符串。</summary>
        internal static string EqualsTesterInvalidArgs
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(EqualsTesterInvalidArgs), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“无法将类型 {0} 的对象转换为 {1}。”的本地化字符串。</summary>
        internal static string ErrorInvalidCast
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(ErrorInvalidCast), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“引用的内部对象不再有效。”的已本地化字符串。</summary>
        internal static string InternalObjectNotValid
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(InternalObjectNotValid), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“参数 {0} 无效。{1}。”的已本地化字符串。</summary>
        internal static string InvalidParameterToAssert
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(InvalidParameterToAssert), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“属性 {0} 具有类型 {1}；预期类型为 {2}。”的已本地化字符串。</summary>
        internal static string InvalidPropertyType
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(InvalidPropertyType), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“{0} 预期类型: &lt;{1}&gt;。实际类型: &lt;{2}&gt;。”的已本地化字符串。
        /// </summary>
        internal static string IsInstanceOfFailMsg
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(IsInstanceOfFailMsg), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“字符串“{0}”与模式“{1}”不匹配。{2}。”的已本地化字符串。</summary>
        internal static string IsMatchFail
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(IsMatchFail), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“错误类型: &lt;{1}&gt;。实际类型: &lt;{2}&gt;。{0}”的已本地化字符串。
        /// </summary>
        internal static string IsNotInstanceOfFailMsg
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(IsNotInstanceOfFailMsg), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“字符串“{0}”与模式“{1}”匹配。{2}。”的已本地化字符串。</summary>
        internal static string IsNotMatchFail
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(IsNotMatchFail), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“未指定 DataRowAttribute。DataTestMethodAttribute 至少需要一个 DataRowAttribute。”的已本地化字符串。
        /// </summary>
        internal static string NoDataRow
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(NoDataRow), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“未引发异常。预期为 {1} 异常。{0}”的已本地化字符串。</summary>
        internal static string NoExceptionThrown
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(NoExceptionThrown), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“参数 {0} 无效。值不能为 null。{1}。”的已本地化字符串。</summary>
        internal static string NullParameterToAssert
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(NullParameterToAssert), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“不同元素数。”的已本地化字符串。</summary>
        internal static string NumberOfElementsDiff
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(NumberOfElementsDiff), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于
        ///      “找不到具有指定签名的构造函数。可能需要重新生成专用访问器，
        ///      或者成员可能为专用且在基类上进行了定义。如果后者为 true，则需将定义成员的类型传递到
        ///      PrivateObject 的构造函数中。”
        ///    的已本地化字符串。
        /// </summary>
        internal static string PrivateAccessorConstructorNotFound
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(PrivateAccessorConstructorNotFound), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于
        ///      “找不到指定成员({0})。可能需要重新生成专用访问器，
        ///      或者成员可能为专用且在基类上进行了定义。如果后者为 true，则需将定义成员的类型
        ///      传递到 PrivateObject 的构造函数中。”
        ///   的已本地化字符串。
        /// </summary>
        internal static string PrivateAccessorMemberNotFound
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(PrivateAccessorMemberNotFound), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“字符串“{0}”不以字符串“{1}”开头。{2}。”的已本地化字符串。</summary>
        internal static string StartsWithFail
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(StartsWithFail), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“预期异常类型必须是 System.Exception 或派生自 System.Exception 的类型。”的已本地化字符串。
        /// </summary>
        internal static string UTF_ExpectedExceptionTypeMustDeriveFromException
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(UTF_ExpectedExceptionTypeMustDeriveFromException), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“(由于出现异常，未能获取 {0} 类型异常的消息。)”的已本地化字符串。</summary>
        internal static string UTF_FailedToGetExceptionMessage
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(UTF_FailedToGetExceptionMessage), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“测试方法未引发预期异常 {0}。{1}”的已本地化字符串。</summary>
        internal static string UTF_TestMethodNoException
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(UTF_TestMethodNoException), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“测试方法未引发异常。预期测试方法上定义的属性 {0} 会引发异常。”的已本地化字符串。</summary>
        internal static string UTF_TestMethodNoExceptionDefault
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(UTF_TestMethodNoExceptionDefault), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>查找类似于“测试方法引发异常 {0}，但预期为异常 {1}。异常消息: {2}”的已本地化字符串。</summary>
        internal static string UTF_TestMethodWrongException
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(UTF_TestMethodWrongException), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似于“测试方法引发异常 {0}，但预期为异常 {1} 或从其派生的类型。异常消息: {2}”的已本地化字符串。
        /// </summary>
        internal static string UTF_TestMethodWrongExceptionDerivedAllowed
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(UTF_TestMethodWrongExceptionDerivedAllowed), FrameworkMessages.resourceCulture);
            }
        }

        /// <summary>
        ///    查找类似于“引发异常 {2}，但预期为异常 {1}。{0}
        /// 异常消息: {3}
        /// 堆栈跟踪: {4}”的已本地化字符串。
        ///  </summary>
        internal static string WrongExceptionThrown
        {
            get
            {
                return FrameworkMessages.ResourceManager.GetString(nameof(WrongExceptionThrown), FrameworkMessages.resourceCulture);
            }
        }
    }
}
