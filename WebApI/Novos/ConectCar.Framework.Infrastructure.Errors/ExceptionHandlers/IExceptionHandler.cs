using System;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionHandlers
{
    /// <summary>
    /// Interface padrão para os tratadores de erro.
    /// </summary>
    /// <typeparam name="T">Tipo de retorno no tratamento de erro.</typeparam>
    public interface IExceptionHandler<T>
    {
        /// <summary>
        /// Analisa um exception e retorna um valor generico.
        /// </summary>
        /// <param name="ex">Exception a ser analisada.</param>
        /// <returns>Retorno generico.</returns>
        T HandleException(Exception ex);

        /// <summary>
        /// Analisa um exception e retorna um valor generico, injetando uma função de análise.
        /// </summary>
        /// <param name="ex">Exception a ser analisada.</param>
        /// <param name="exceptionAnalyser">Função de análise da exception.</param>
        /// <returns>Retorno generico.</returns>
        T HandleException(Exception ex, Func<Exception, string[]> exceptionAnalyser);

    }
}
