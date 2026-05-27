using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StackGestaoDeHospital.View.Utils
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection,IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static void Replace<T>(this ObservableCollection<T> collection,IEnumerable<T> items)
        {
            collection.Clear();
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}
