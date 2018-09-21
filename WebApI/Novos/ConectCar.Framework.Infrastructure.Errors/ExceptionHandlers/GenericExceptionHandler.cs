using System;

namespace ConectCar.Framework.Infrastructure.Errors.ExceptionHandlers
{

    /// <summary>
    /// Classe responsável por retornar uma string com as mensagens de erro analisadas.
    /// </summary>
    public class GenericExceptionHandler : GenericExceptionHandlerBase<string>
    {
        /// <summary>
        /// Efetua o mapeamento das mensagens de erro para uma string consolidada.
        /// </summary>
        /// <param name="errorMessages">Mensagens de erro.</param>
        /// <returns>Mensagem de erro consolidada.</returns>
        protected override string MapFromMessageError(string[] errorMessages)
        {
            return String.Join(", ", errorMessages);
        }

    }
}
