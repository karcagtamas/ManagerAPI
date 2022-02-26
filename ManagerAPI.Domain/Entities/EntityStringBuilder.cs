using System.Collections.Generic;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Entity string builder
    /// </summary>
    public static class EntityStringBuilder
    {
        /// <summary>
        /// Build string
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="properties">Props</param>
        /// <typeparam name="T">Entitz type</typeparam>
        /// <returns>Built string</returns>
        public static string BuildString<T>(T entity, params string[] properties)
        {
            if (entity is null)
            {
                return "";
            }
            var type = entity.GetType();
            var values = new List<string>();
            foreach (string prop in properties)
            {
                var property = type.GetProperty(prop);

                if (property != null)
                {
                    values.Add(property.GetValue(entity)?.ToString() ?? string.Empty);
                }
            }

            return string.Join(" - ", values);
        }
    }
}