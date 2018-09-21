using ConectCar.Framework.Infrastructure.Errors.Resources;
using System;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers
{
    /// <summary>
    /// Analisador genérico de Exceptions.
    /// </summary>
    /// <remarks>
    /// Analisador que será utilizado sempre caso não exista nenhum outro configurado.
    /// </remarks>
    public class ExceptionAnalyser : ExceptionAnalyserBase<Exception>
    {
        /// <summary>
        /// Analise exceções genéricas.
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>Mensagens de erro.</returns>
        protected override string[] GetErrorMessagesFromException(Exception ex)
        {            
            return new[] { ErrorResource.ExceptionAnalyserMessage };
        }
        
    }
}
