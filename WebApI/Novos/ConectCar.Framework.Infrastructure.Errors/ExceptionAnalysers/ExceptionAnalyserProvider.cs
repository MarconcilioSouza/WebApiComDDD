using System;
using System.Collections.Concurrent;


namespace ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers
{
    /// <summary>
    /// Provedor de analisadores de Exceptions.
    /// </summary>
    /// <remarks>
    /// Responsável por fornecer analisadores de exception de acordo com o tipo.
    /// </remarks>
    public static class ExceptionAnalyserProvider
    {
        #region [Properties]

        /// <summary>
        /// Contém a lista de analisadores de exceptions.
        /// </summary>
        private static ConcurrentDictionary<Type, IExceptionAnalyser> _analysers = new ConcurrentDictionary<Type, IExceptionAnalyser>();

        /// <summary>
        /// Analisador de Exception padrão.
        /// </summary>
        private static IExceptionAnalyser fallbackAnalyser = new ExceptionAnalyser();
        
        #endregion


        #region [Methods]        

        /// <summary>
        /// Executa um analisador de exception com base no tipo da exception.
        /// </summary>  
        /// <remarks>
        /// Caso o analisador de exception específico não seja capaz de tratar a Exception, delega para o fallback genérico.
        /// </remarks>
        /// <param name="ex">Exception a ser analisada.</param>
        /// <param name="exceptionType">Tipo da exception a ser analisada.</param>
        /// <returns>Mensagens de erro.</returns>
        public static string[] ExecuteAnalyser(Exception ex, Type exceptionType)            
        {
            if (_analysers.ContainsKey(exceptionType))
            {
                var analyser = _analysers[exceptionType];
                var ret = analyser.GetErrorMessages(ex);
                if (ret != null)
                    return ret;
            }
            
            return fallbackAnalyser.GetErrorMessages(ex);                                        
        }


        /// <summary>
        /// Efetua a configuração dos analisadores de Exceptions.
        /// </summary>
        /// <typeparam name="TException">Tipo da Exception.</typeparam>
        /// <param name="analyser">Analisador da Exception.</param>
        public static void SetUp<TException>(ExceptionAnalyserBase<TException> analyser)
            where TException: Exception
        {
            var type = typeof(TException);
            AddExceptionAnalyser(type, analyser);
        }

        /// <summary>
        /// Efetua a configuração dos analisadores de Exceptions através de SetUp.
        /// </summary>
        /// <param name="setUp">SetUp de analisadores de Exception.</param>
        public static void SetUp(IExceptionAnalyserSetUp setUp)
        {
            foreach (var item in setUp.Analysers)
            {
                AddExceptionAnalyser(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Inclui um exception analyser na coleção ou atualiza caso exista.
        /// </summary>
        /// <remarks>
        /// Caso já exista um analisador, decora com um mais específico. 
        /// </remarks>
        /// <param name="type">Tipo da exception.</param>
        /// <param name="analyser">Analisador de Exception.</param>
        private static void AddExceptionAnalyser(Type type, IExceptionAnalyser analyser)
        {
            if (_analysers.ContainsKey(type))
            {
                var actualAnalyser = _analysers[type];
                actualAnalyser.Decorate(analyser);                
            }                
            else
                _analysers.TryAdd(type, analyser);
        }

        #endregion

    }
}
