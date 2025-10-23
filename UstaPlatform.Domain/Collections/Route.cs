using System;
using System.Collections;
using System.Collections.Generic;

namespace UstaPlatform.Domain.Collections
{
    // IEnumerable arayüzünü uygular
    public class Route : IEnumerable<(int X, int Y)>
    {
        private readonly List<(int X, int Y)> _stops = new();

        // Koleksiyon başlatıcı ( { (1,2), (3,4) } ) desteği için bu metot şarttır
        public void Add(int X, int Y)
        {
            _stops.Add((X, Y));
        }

        public IEnumerator<(int X, int Y)> GetEnumerator() => _stops.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}