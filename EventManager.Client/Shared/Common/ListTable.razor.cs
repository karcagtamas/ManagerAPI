﻿using EventManager.Client.Models;
using ManagerAPI.Shared;
using ManagerAPI.Shared.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Client.Shared.Common
{
    /// <summary>
    /// List Table
    /// </summary>
    /// <typeparam name="TList">Type of list rows</typeparam>
    public partial class ListTable<TList> where TList : IIdentified
    {
        /// <summary>
        /// Header row settings
        /// </summary>
        [Parameter]
        public List<TableHeaderData<TList>> Header { get; set; }

        /// <summary>
        /// Body data
        /// </summary>
        [Parameter] public List<TList> Body { get; set; }

        /// <summary>
        /// Body row click event
        /// </summary>
        [Parameter] public EventCallback<TList> OnRowClick { get; set; }

        /// <summary>
        /// Preselected elements
        /// </summary>
        [Parameter] public List<int> SelectedIndexes { get; set; } = new List<int>();

        /// <summary>
        /// Selection is enabled on the table
        /// </summary>
        [Parameter] public bool IsSelectionEnabled { get; set; } = false;

        /// <summary>
        /// Footer is available
        /// </summary>
        [Parameter] public bool FooterDisplay { get; set; } = true;

        /// <summary>
        /// Show filters
        /// </summary>
        [Parameter] public bool ShowFilter { get; set; } = false;
        private TableHeaderData<TList> OrderBy { get; set; }
        private List<TList> DisplayList { get; set; } = new List<TList>();
        private OrderDirection Direction { get; set; } = OrderDirection.None;
        private string FilterValue { get; set; } = "";

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            this.DoFilteringAndOrdering();
        }

        private object GetProperty(TList entity, string property)
        {
            var type = typeof(TList);
            var prop = type.GetProperty(property);
            return prop != null ? prop.GetValue(entity) : "";
        }

        private void RowClick(TList entity)
        {
            this.OnRowClick.InvokeAsync(entity);
        }

        private void Filter(string val)
        {
            this.FilterValue = val;
            this.DoFilteringAndOrdering();
        }

        private void HeaderClick(TableHeaderData<TList> data)
        {
            if (data.IsSortable)
            {
                if (this.OrderBy == null || this.OrderBy.PropertyName != data.PropertyName)
                {
                    this.OrderBy = data;
                    this.Direction = OrderDirection.Ascend;
                }
                else
                {
                    if (this.OrderBy.PropertyName == data.PropertyName)
                    {
                        switch (this.Direction)
                        {
                            case OrderDirection.Ascend:
                                this.Direction = OrderDirection.Descend;
                                break;

                            case OrderDirection.Descend:
                                this.Direction = OrderDirection.None;
                                this.OrderBy = null;
                                break;
                        }
                    }
                }

                Console.WriteLine(OrderDirectionService.GetValue(this.Direction));
                this.DoFilteringAndOrdering();
            }
        }

        private void DoFilteringAndOrdering()
        {
            var query = this.Body.AsQueryable();

            if (!string.IsNullOrEmpty(this.FilterValue))
            {
                query = query.Where(x => this.IsFiltered(x));
            }

            if (this.OrderBy != null)
            {
                query = this.Direction switch
                {
                    OrderDirection.Ascend => query.OrderBy(x => this.GetProperty(x, this.OrderBy.PropertyName)),
                    OrderDirection.Descend => query.OrderByDescending(x => this.GetProperty(x, this.OrderBy.PropertyName)),
                    _ => query
                };
            }

            this.DisplayList = query.ToList();
            this.StateHasChanged();
        }

        private bool IsFiltered(TList val)
        {
            bool res = false;

            foreach (var head in this.Header)
            {
                if (head.IsFilterable && !res)
                {
                    string propVal = head.Displaying(this.GetProperty(val, head.PropertyName));
                    res = propVal.Contains(this.FilterValue, StringComparison.OrdinalIgnoreCase);
                }
            }

            return res;
        }
    }
}