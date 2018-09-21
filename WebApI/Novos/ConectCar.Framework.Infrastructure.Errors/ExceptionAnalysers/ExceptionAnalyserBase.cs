using ConectCar.Framework.Infrastructure.Log;
using System;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers
{
    /// <summary>
    /// Classe base para todos os analisadores de erro.
    /// </summary>
    /// <typeparam name="TException">Tipo da exception a ser analisada.</typeparam>
    public abstract class ExceptionAnalyserBase<TException> : Loggable, IExceptionAnalyser
        where TException: Exception
    {
        #region [Properties]

        /// <summary>
        /// Analisador de Exception interno.
        /// </summary>
        protected IExceptionAnalyser InternalAnalyser;

        #endregion

        #region [Methods]

        /// <summary>
        /// Analisa uma Exception e retorna um conjunto de mensagens de erro tratadas.
        /// </summary>
        /// <remarks>
        /// Utiliza analisador mais interno caso o mesmo seja capaz de lidar com a exception,
        /// caso contrário utiliza o mais geral até chegar ao primeiro item da cadeia de exceptions.
        /// </remarks>
        /// <param name="ex">Exception a ser analisada</param>
        /// <returns>Mensagens de erro associadas.</returns>
        public string[] GetErrorMessages(Exception ex)
        {
            
            if (InternalAnalyser != null)
            {
                var internalReturn = InternalAnalyser.GetErrorMessages(ex);
                if(internalReturn == null)
                    return GetErrorMessagesFromException(ex as TException);

                return internalReturn;
            }
                
            return GetErrorMessagesFromException(ex as TException);
        }

        /// <summary>
        /// Retorna um conjunto de mensagens de erros com base em um tipo específico de Exception.
        /// </summary>
        /// <param name="ex">Tipo específico de exception.</param>
        /// <returns>Mensagens de erro associadas.</returns>
        protected abstract string[] GetErrorMessagesFromException(TException ex);

        /// <summary>
        /// Decora o analisador de Exceptions.
        /// </summary>
        /// <param name="analyser">Analisador de Exception.</param>
        public void Decorate(IExceptionAnalyser analyser)
        {
            if (InternalAnalyser == null)
                InternalAnalyser = analyser;
            else
                InternalAnalyser.Decorate(analyser);
        }


        #endregion


    }
}
