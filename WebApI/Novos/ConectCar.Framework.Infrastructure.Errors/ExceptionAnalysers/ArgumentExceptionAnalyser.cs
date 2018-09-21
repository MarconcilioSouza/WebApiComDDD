using ConectCar.Framework.Infrastructure.Errors.Resources;
using System;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers
{
    /// <summary>
    /// Analisador padrão de ArgumentException.
    /// </summary>
    public class ArgumentExceptionAnalyser : ExceptionAnalyserBase<ArgumentException>
    {
        /// <summary>
        /// Analisa ArgumentException.
        /// </summary>
        /// <param name="ex">ArgumentException.</param>
        /// <returns>Mensagens de erro.</returns>
        protected override string[] GetErrorMessagesFromException(ArgumentException ex)
        {            
            return new[] { String.Format(ErrorResource.ArgumentExceptionAnalyserMessage, ex.ParamName, ex.Message) };
        }
        
    }    
}
