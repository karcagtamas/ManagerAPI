using System;
using System.Collections.Generic;
using EventManager.Client.Models.Interfaces;

namespace EventManager.Client.Http
{
    /// <summary>
    /// HTTP path parameters
    /// </summary>
    public class HttpPathParameters : IListState
    {

        private List<object> _pathParams;

        /// <summary>
        /// HTTP path parameters
        /// </summary>
        public HttpPathParameters()
        {
            this._pathParams = new List<object>();
        }

        /// <summary>
        /// Add value to a specified index into a row (insert).
        /// If the index is equal with -1, it will add to end of the row.
        /// If the index is invalid (index out of range), it will throw errors.
        /// </summary>
        /// <param name="value">Value for adding</param>
        /// <param name="index">Destination index</param>
        /// <typeparam name="T">Type of the value</typeparam>
        public void Add<T>(T value, int index)
        {
            // Add to end of the list
            if (index == -1)
            {
                this._pathParams.Add(value);
                return;
            }

            // Negative index
            if (index < -1)
            {
                throw new ArgumentException("Index cannot be negative");
            }

            // Out of range
            if (index > this._pathParams.Count)
            {
                throw new ArgumentException("Index cannot be bigger than the list");
            }

            this._pathParams.Insert(index, value);
        }

        /// <summary>
        /// Get length of the row.
        /// </summary>
        /// <returns>Length number</returns>
        public int Count()
        {
            return this._pathParams.Count;
        }

        /// <summary>
        /// Get value by index number.
        /// If the index is invalid (index out of range), it will throw errors.
        /// </summary>
        /// <param name="index"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>(int index)
        {
            // Negative
            if (index < 0)
            {
                throw new ArgumentException("Index cannot be negative");
            }

            // Out of range
            if (index >= this._pathParams.Count)
            {
                throw new ArgumentException("Index cannot be larger than the list size");
            }

            return (T)this._pathParams[index];
        }

        /// <summary>
        /// Add value to a specified index into a row (insert).
        /// If the index is equal with -1, it will add to end of the row.
        /// If the index is invalid (index out of range), it will not throw errors, but it will not execute the adding.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <typeparam name="T"></typeparam>
        public void TryAdd<T>(T value, int index)
        {
            // Add element end of the row
            if (index == -1)
            {
                this._pathParams.Add(value);
                return;
            }

            // Negative
            if (index < -1)
            {
                return;
            }

            // Out of range
            if (index > this._pathParams.Count)
            {
                return;
            }

            this._pathParams.Insert(index, value);
        }

        /// <summary>
        /// Get value by index number.
        /// If the index is invalid (index out of range), it will not throw errors, but it will give back default value.
        /// </summary>
        /// <param name="index"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T TryGet<T>(int index)
        {
            // Negative
            if (index < 0)
            {
                return default;
            }

            // Out of range
            if (index >= this._pathParams.Count)
            {
                return default;
            }

            return (T)this._pathParams[index];
        }

        /// <summary>
        /// List to string.
        /// </summary>
        /// <returns>String in path format</returns>
        override public string ToString()
        {
            string val = "";

            foreach (var param in this._pathParams)
            {
                val += $"/{param.ToString()}";
            }

            return val;
        }
    }
}