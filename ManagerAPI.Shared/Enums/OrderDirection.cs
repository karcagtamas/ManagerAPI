using System;

namespace ManagerAPI.Shared.Enums
{
    /// <summary>
    /// Order Direction
    /// </summary>
    public enum OrderDirection
    {
        /// <summary>
        /// ASC
        /// </summary>
        Ascend = 1,

        /// <summary>
        /// DESC
        /// </summary>
        Descend = 2,

        /// <summary>
        /// None
        /// </summary>
        None = 3
    }

    /// <summary>
    /// Order Direction Convert Service
    /// </summary>
    public static class OrderDirectionService
    {
        /// <summary>
        /// Get value of direction
        /// </summary>
        /// <param name="direction">Direction</param>
        /// <returns>String value</returns>
        public static string GetValue(OrderDirection direction)
        {
            switch (direction)
            {
                case OrderDirection.Ascend: return "asc";
                case OrderDirection.Descend: return "desc";
                case OrderDirection.None: return "none";
                default: throw new ArgumentException("Direction does not exist");
            }
        }

        /// <summary>
        /// Convert string value to Key
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Order Direction key</returns>
        public static OrderDirection ValueToKey(string value)
        {
            switch (value)
            {
                case "asc": return OrderDirection.Ascend;
                case "desc": return OrderDirection.Descend;
                case "none": return OrderDirection.None;
                default: throw new ArgumentException("Value does not exist");
            }
        }
    }
}