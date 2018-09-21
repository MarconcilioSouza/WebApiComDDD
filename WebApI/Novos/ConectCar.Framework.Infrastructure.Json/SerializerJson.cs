using System.IO;
using System.Text;
using Jil;

namespace ConectCar.Framework.Infrastructure.Json
{
    /// <summary>
    /// Classe responsável por serializar e deserializar dados em Json.
    /// </summary>
    public static class SerializerJson
    {
        #region [Methods]

        /// <summary>
        /// Deserializa um Json para um tipo T.
        /// </summary>
        /// <typeparam name="T">Tipo de dados a ser deserializado.</typeparam>
        /// <param name="json">Json a ser deserializado.</param>
        /// <returns>Tipo de dados.</returns>
        public static T Deserialize<T>(string json)
        {
            var entityObject = JSON.Deserialize<T>(json, Options.IncludeInherited);
            return entityObject;
        }

        /// <summary>
        /// Serializa um tipo T em Json.
        /// </summary>
        /// <typeparam name="T">Tipo de dados a ser serializado.</typeparam>
        /// <param name="entity">Entidade a ser serializada.</param>
        /// <returns>Representação em Json da entidade.</returns>
        public static string Serialize<T>(T entity)
        {
            var stringBuilder = new StringBuilder();
            using (var stringOutput = new StringWriter(stringBuilder))
            {
                JSON.Serialize(entity, stringOutput, Options.IncludeInherited);
            }
            var textSerialized = stringBuilder.ToString();

            return textSerialized;
        }

        #endregion
    }
}
