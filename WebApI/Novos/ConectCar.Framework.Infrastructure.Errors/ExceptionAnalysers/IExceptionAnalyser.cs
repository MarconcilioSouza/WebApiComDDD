using System;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers
{
    /// <summary>
    /// Responsável por definir analisadores de Exceptions.
    /// </summary>
    /// <remarks>
    /// Analisadores de exceptions são responsáveis por analisar Exceptions
    /// e retornar resultados com base nas análises.
    /// </remarks>
    public interface IExceptionAnalyser
    {
        /// <summary>
        /// Analisa uma Exception e retorna um conjunto de mensagens de erro tratadas.
        /// </summary>
        /// <param name="ex">Exception a ser analisada</param>
        /// <returns>Mensagens de erro associadas.</returns>
        string[] GetErrorMessages(Exception ex);

        /// <summary>
        /// Decora um analisador de exception.
        /// </summary>
        /// <remarks>
        /// O principal objetivo será colocar camadas adicionais de validação onde as mais específicas
        /// são executadas primeiro.
        /// </remarks>
        /// <param name="analyser">Analisador de exception.</param>
        void Decorate(IExceptionAnalyser analyser);
    }
    
}
