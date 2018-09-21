using ConectCar.Framework.Infrastructure.Errors.Resources;
using System;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers
{
    /// <summary>
    /// Analisador padrão de ArgumentOutOfRangeException.
    /// </summary>
    public class ArgumentOutOfRangeExceptionAnalyser : ExceptionAnalyserBase<ArgumentOutOfRangeException>
    {
        /// <summary>
        /// Analisa ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="ex">ArgumentOutOfRangeException.</param>
        /// <returns>Mensagens de erro.</returns>
        protected override string[] GetErrorMessagesFromException(ArgumentOutOfRangeException ex)
        {                 
            return new[] { String.Format(ErrorResource.ArgumentOutOfRangeExceptionAnalyserMessage, ex.ParamName, ex.Message) };
        }
        
    }    
}
