using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateObjectExtension
{
    /// <summary>帮助程序。</summary>
    internal static class ArgumentHelper
    {
        /// <summary>非 null 的检查参数。</summary>
        /// <param name="param">参数。</param>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="message">消息。</param>
        /// <exception cref="T:System.ArgumentNullException"> Throws argument null exception when parameter is null. </exception>
        internal static void CheckParameterNotNull(object param, string parameterName, string message)
        {
            if (param == null)
                throw new ArgumentNullException(parameterName, message);
        }

        /// <summary>不为 null 或不为空的检查参数。</summary>
        /// <param name="param">参数。</param>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="message">消息。</param>
        /// <exception cref="T:System.ArgumentException"> Throws ArgumentException when parameter is null. </exception>
        internal static void CheckParameterNotNullOrEmpty(
          string param,
          string parameterName,
          string message)
        {
            if (string.IsNullOrEmpty(param))
                throw new ArgumentException(message, parameterName);
        }
    }
}
