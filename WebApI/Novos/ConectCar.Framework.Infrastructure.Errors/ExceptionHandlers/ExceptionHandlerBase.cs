using ConectCar.Framework.Infrastructure.Log;
using Microsoft.Extensions.Logging;
using System;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionHandlers
{
    /// <summary>
    /// Classe base para os tratadores de erro.
    /// </summary>
    /// <typeparam name="T">Tipo de retorno do erro.</typeparam>
    public abstract class ExceptionHandlerBase<T>: Loggable, IExceptionHandler<T>
    {
        /// <summary>
        /// Responsável por analisar o erro e promover um retorno tipado.
        /// </summary>
        /// <param name="ex">Exception a ser analisada.</param>
        /// <returns>Tipo de dados do retorno.</returns>
        public T HandleException(Exception ex)
        {
            Log.Error(ex, ex.Message);
            return HandleException(ex, ExceptionAnalyser);
        }

        /// <summary>
        /// Responsável por analisar uma exception e retornar um valor generico, injetando uma função de análise.
        /// </summary>
        /// <param name="ex">Exception a ser analisada.</param>
        /// <param name="exceptionAnalyser">Função de análise da exception.</param>
        /// <returns>Retorno generico.</returns>
        public T HandleException(Exception ex, Func<Exception, string[]> exceptionAnalyser)
        {
            if (exceptionAnalyser == null)
                return HandleException(ex);

            Log.Error(ex, ex.Message);
            return MapFromMessageError(ExceptionHandlerHelper.GetErrorMessages(ex, exceptionAnalyser));
            
        }

        /// <summary>
        /// Mapeamento entre as mensagens de erro e o tipo de retorno.
        /// </summary>
        /// <param name="errorMessages">Mensagens de erro.</param>
        /// <returns>Tipo de retorno.</returns>
        protected abstract T MapFromMessageError(string[] errorMessages);

        /// <summary>
        /// Método responsável por analisar o erro e retornar um conjunto de mensagens.
        /// </summary>
        /// <param name="ex">Exception a ser analisada.</param>
        /// <returns></returns>
        protected abstract string[] ExceptionAnalyser(Exception ex);

        
    }
}
