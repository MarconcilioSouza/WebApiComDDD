using ConectCar.Framework.Infrastructure.Errors.Resources;
using System;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers
{
    /// <summary>
    /// Analisador padrão de ArgumentNullException.
    /// </summary>
    public class ArgumentNullExceptionAnalyser : ExceptionAnalyserBase<ArgumentNullException>
    {
        /// <summary>
        /// Analisa ArgumentNullException.
        /// </summary>
        /// <param name="ex">ArgumentNullException.</param>
        /// <returns>Mensagens de erro.</returns>
        protected override string[] GetErrorMessagesFromException(ArgumentNullException ex)
        {     
            
            return new[] { String.Format(ErrorResource.ArgumentNullExceptionAnalyserMessage, ex.ParamName, ex.Message) };
        }
        
    }    
}
