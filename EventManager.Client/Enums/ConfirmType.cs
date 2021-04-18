using System;

namespace EventManager.Client.Enums
{
    /// <summary>
    /// Confirm type
    /// </summary>
    public enum ConfirmType
    {
        /// <summary>
        /// Delete
        /// </summary>
        Delete,
        
        /// <summary>
        /// Update
        /// </summary>
        Update,
        
        /// <summary>
        /// Disable
        /// </summary>
        Disable,
        
        /// <summary>
        /// Archive
        /// </summary>
        Archive,
        
        /// <summary>
        /// Publish
        /// </summary>
        Publish,
        
        /// <summary>
        /// Hide
        /// </summary>
        Hide
    }

    /// <summary>
    /// Confirm type converter
    /// </summary>
    public static class ConfirmTypeConverter
    {
        /// <summary>
        /// Get string value
        /// </summary>
        /// <param name="type">Enum value</param>
        /// <returns>Display text</returns>
        public static string GetStringValue(ConfirmType type)
        {
            return type switch
            {
                ConfirmType.Archive => "archive",
                ConfirmType.Delete => "delete",
                ConfirmType.Disable => "disable",
                ConfirmType.Hide => "hide",
                ConfirmType.Publish => "publish",
                ConfirmType.Update => "update",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}