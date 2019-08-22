using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TodoList.WebApi.Infrastructure
{
    public class ReadSideDatabase
    {
        private readonly IDictionary<Type, object> _tables = new Dictionary<Type, object>();

        public List<T> Table<T>()
        {
            lock (_tables) {
                if (_tables.ContainsKey(typeof(T)) == false) {
                    _tables.Add(typeof(T), new List<T>());
                }

                return (List<T>) _tables[typeof(T)];
            }
        }
    }
}