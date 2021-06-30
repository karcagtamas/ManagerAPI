using EventManager.Client.Enums;
using ManagerAPI.Shared;
using System;
using System.Collections.Generic;

namespace EventManager.Client.Models
{
    /// <summary>
    /// Table header data
    /// </summary>
    /// <typeparam name="TList">List type</typeparam>
    public class TableHeaderData<TList> where TList : IIdentified
    {
        /// <summary>
        /// Property name
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Displayer
        /// </summary>
        public Func<object, string> Displaying { get; set; }

        /// <summary>
        /// Is sortable
        /// </summary>
        public bool IsSortable { get; set; }

        /// <summary>
        /// Is filterable
        /// </summary>
        public bool IsFilterable { get; set; }

        /// <summary>
        /// Footer data
        /// </summary>
        public string FooterData { get; set; }

        /// <summary>
        /// Footer runnable
        /// </summary>
        public Func<List<TList>, string> FooterRunnableData { get; set; }

        /// <summary>
        /// Alignment
        /// </summary>
        public Alignment HeaderAlignment { get; set; }

        /// <summary>
        /// Init table header data
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="alignment">Alignment</param>
        public TableHeaderData(string propertyName, Alignment alignment)
        {
            this.PropertyName = propertyName;
            this.DisplayName = propertyName;
            this.Displaying = x => (string)x;
            this.IsSortable = false;
            this.IsFilterable = true;
            this.HeaderAlignment = alignment;
        }

        /// <summary>
        /// Init table header data
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="isSortable">Is sortable</param>
        /// <param name="alignment">Alignment</param>
        public TableHeaderData(string propertyName, bool isSortable, Alignment alignment)
        {
            this.PropertyName = propertyName;
            this.DisplayName = propertyName;
            this.Displaying = x => (string)x;
            this.IsSortable = isSortable;
            this.IsFilterable = true;
            this.HeaderAlignment = alignment;
        }

        /// <summary>
        /// Init table header data
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="displayName">Display name</param>
        /// <param name="isSortable">Is sortable</param>
        /// <param name="isFilterable">Is filterable</param>
        /// <param name="alignment">Alignment</param>
        public TableHeaderData(string propertyName, string displayName, bool isSortable, bool isFilterable, Alignment alignment)
        {
            this.PropertyName = propertyName;
            this.DisplayName = displayName;
            this.Displaying = x => (string)x;
            this.IsSortable = isSortable;
            this.IsFilterable = isFilterable;
            this.HeaderAlignment = alignment;
        }

        /// <summary>
        /// Init table header data
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="displayName">Display name</param>
        /// <param name="alignment">Alignment</param>
        public TableHeaderData(string propertyName, string displayName, Alignment alignment)
        {
            this.PropertyName = propertyName;
            this.DisplayName = displayName;
            this.Displaying = x => (string)x;
            this.IsSortable = false;
            this.IsFilterable = true;
            this.HeaderAlignment = alignment;
        }

        /// <summary>
        /// Init table header data
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="displayName">Display name</param>
        /// <param name="isSortable">Is sortable</param>
        /// <param name="alignment">Alignment</param>
        public TableHeaderData(string propertyName, string displayName, bool isSortable, Alignment alignment)
        {
            this.PropertyName = propertyName;
            this.DisplayName = displayName;
            this.Displaying = x => (string)x;
            this.IsSortable = isSortable;
            this.IsFilterable = true;
            this.HeaderAlignment = alignment;
        }

        /// <summary>
        /// Init table header data
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="displayName">Display name</param>
        /// <param name="displaying">Displayer</param>
        /// <param name="alignment">Alignment</param>
        public TableHeaderData(string propertyName, string displayName, Func<object, string> displaying, Alignment alignment)
        {
            this.PropertyName = propertyName;
            this.DisplayName = displayName;
            this.Displaying = displaying;
            this.IsSortable = false;
            this.IsFilterable = true;
            this.HeaderAlignment = alignment;
        }

        /// <summary>
        /// Init table header data
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="displayName">Display name</param>
        /// <param name="isSortable">Is sortable</param>
        /// <param name="displaying">Displayer</param>
        /// <param name="alignment">Alignment</param>
        public TableHeaderData(string propertyName, string displayName, bool isSortable, Func<object, string> displaying, Alignment alignment)
        {
            this.PropertyName = propertyName;
            this.DisplayName = displayName;
            this.Displaying = displaying;
            this.IsSortable = isSortable;
            this.IsFilterable = true;
            this.HeaderAlignment = alignment;
        }

        /// <summary>
        /// Init table header data
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="displayName">Display name</param>
        /// <param name="isSortable">Is sortable</param>
        /// <param name="isFilterable">Is filterable</param>
        /// <param name="displaying">Displayer</param>
        /// <param name="alignment">Alignment</param>
        public TableHeaderData(string propertyName, string displayName, bool isSortable, bool isFilterable, Func<object, string> displaying, Alignment alignment)
        {
            this.PropertyName = propertyName;
            this.DisplayName = displayName;
            this.Displaying = displaying;
            this.IsSortable = isSortable;
            this.IsFilterable = isFilterable;
            this.HeaderAlignment = alignment;
        }
    }
}