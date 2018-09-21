using ConectCar.Framework.Infrastructure.Log;
using System;
using System.Collections.Generic;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers
{
    /// <summary>
    /// Classe base para os setups de configuração de analisadores de Exceptions.
    /// </summary>
    public abstract class ExceptionAnalyserSetUpBase : Loggable, IExceptionAnalyserSetUp
    {
        #region [Properties]

        /// <summary>
        /// Lista dos analisadores de Exceptions.
        /// </summary>
        private IDictionary<Type, IExceptionAnalyser> _analysers;

        /// <summary>
        /// Lista dos analisadores de Exceptions.
        /// </summary>
        public IDictionary<Type, IExceptionAnalyser> Analysers
        {
            get
            {
                return _analysers;
            }
        }

        #endregion

        #region [Ctor]

        /// <summary>
        /// Inicializa o SetUp
        /// </summary>
        protected ExceptionAnalyserSetUpBase()
        {
            _analysers = new Dictionary<Type, IExceptionAnalyser>();            
            SetUp();
        }

        #endregion

        #region [Methods]


        /// <summary>
        /// Executa a configuração dos analisadores de Exceptions.
        /// </summary>
        public abstract void SetUp();

        /// <summary>
        /// Inclui um analisador de Exception
        /// </summary>
        /// <typeparam name="TException">Tipo da Exception.</typeparam>
        /// <param name="exceptionAnalyser">Analisador de Exception.</param>
        protected void AddExceptionAnalyser<TException>(ExceptionAnalyserBase<TException> exceptionAnalyser)
            where TException: Exception
        {
            var type = typeof(TException);
            if(_analysers.ContainsKey(type))
            {
                var analyser = _analysers[type];
                analyser.Decorate(exceptionAnalyser);
            }
            else
            {
                _analysers.Add(type, exceptionAnalyser);
            }            
        }

        #endregion

    }
}
