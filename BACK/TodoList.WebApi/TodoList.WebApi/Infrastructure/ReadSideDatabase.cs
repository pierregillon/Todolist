using System;
using System.Collections.Generic;

namespace TodoList.WebApi.Infrastructure {
    public class ReadSideDatabase
    {
        private readonly Dictionary<Type, object> _tables = new Dictionary<Type, object>();

        public IList<T> Table<T>()
        {
            if (_tables.ContainsKey(typeof(T)) == false) {
                _tables.Add(typeof(T), new List<T>());
            }

            return (List<T>) _tables[typeof(T)];
        }
    }
}