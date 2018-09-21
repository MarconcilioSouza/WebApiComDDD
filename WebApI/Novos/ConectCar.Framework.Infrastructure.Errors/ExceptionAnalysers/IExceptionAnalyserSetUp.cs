using System;
using System.Collections.Generic;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers
{
    /// <summary>
    /// Interface padrão para o setup de analisadores de Exceptions.
    /// </summary>
    public interface IExceptionAnalyserSetUp
    {
        /// <summary>
        /// Lista de analisadores de Exceptions que deverão ser utilizados.
        /// </summary>
        IDictionary<Type, IExceptionAnalyser> Analysers { get; }

        /// <summary>
        /// Executa a configuração dos analisadores de Exceptions.
        /// </summary>
        void SetUp();

    }
}
