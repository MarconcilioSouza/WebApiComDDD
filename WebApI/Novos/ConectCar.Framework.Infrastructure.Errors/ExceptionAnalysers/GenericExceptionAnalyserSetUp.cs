namespace ConectCar.Framework.Infrastructure.Errors.ExceptionAnalysers
{
    /// <summary>
    /// Classe de inicialização dos analisadores para Exceptions genéricas.
    /// </summary>
    /// <remarks>
    /// Inclui analisadores para as seguintes Exceptions:
    /// Exception, ArgumentExceptioon 
    /// </remarks>
    public class GenericExceptionAnalyserSetUp : ExceptionAnalyserSetUpBase
    {
        public override void SetUp()
        {            
            AddExceptionAnalyser(new ArgumentExceptionAnalyser());
            AddExceptionAnalyser(new ArgumentNullExceptionAnalyser());
            AddExceptionAnalyser(new ArgumentOutOfRangeExceptionAnalyser());
        }
    }
}
