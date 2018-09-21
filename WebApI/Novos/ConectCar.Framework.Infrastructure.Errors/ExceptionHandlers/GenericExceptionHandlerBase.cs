using ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers;
using System;
using System.Data.SqlClient;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionHandlers
{
    /// <summary>
    /// Classe base para a criação de tratadores de erro de forma tipada.
    /// </summary>
    /// <typeparam name="T">Tipo de retorno do tratamento.</typeparam>
    public abstract class GenericExceptionHandlerBase<T> : 
        ExceptionHandlerBase<T>
    {

        /// <summary>
        /// Aplica a extração de mensagens de erro de maneira global, fornecendo mensagens padrão
        /// para cada tipo de erro.
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>Conjunto de mensagens de erro associada.</returns>
        protected override string[] ExceptionAnalyser(Exception ex)
        {
            var type = ex.GetType();           
            return ExceptionAnalyserProvider.ExecuteAnalyser(ex, type);
            
        }        
    }
}
