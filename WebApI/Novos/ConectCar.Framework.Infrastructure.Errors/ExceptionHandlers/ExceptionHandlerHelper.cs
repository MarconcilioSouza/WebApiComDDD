using System;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionHandlers
{
    /// <summary>
    /// Classe helper responsável por fornecer métodos de apoio ao tratamento de erro.
    /// </summary>
    public static class ExceptionHandlerHelper
    {

        #region [Properties]

 
        #endregion

        #region [Methods]        

        /// <summary>
        /// Método responsável por obter mensagens de erro com base em uma exception.
        /// </summary>
        /// <param name="exception">Exception que deverá ser analisada.</param>
        /// <param name="exceptionAnalyser">Analisador de exceptions para obtenção das mensagens de erro.</param>
        /// <returns>Mensagens de erro obtidas.</returns>
        public static string[] GetErrorMessages(Exception exception,Func<Exception,String[]> exceptionAnalyser)
        {
            var innerException = ExtractInnerException(exception);
            return exceptionAnalyser(innerException);
        }

        /// <summary>
        /// Método recursivo para extrair a exception mais interna para análise do erro e tratamento adequado.
        /// </summary>
        /// <param name="exception">Exceção a ser analisada.</param>
        /// <returns>Retorna a exceção mais interna.</returns>
        private static Exception ExtractInnerException(Exception exception)
        {
            if (exception.InnerException == null)
                return exception;
            return ExtractInnerException(exception.InnerException);
        }

        #endregion

    }
}
