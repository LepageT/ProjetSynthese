using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Application
{
    public class MayBe<T> : IEnumerable<T>
    {

        // Selon le constrcuteur appelée, _value peut contenir aucun élément ou 1 seul élément
        private readonly IEnumerable<T> _values;

        public MayBe()
        {
            _values = new T[0];
        }

        public MayBe(T value)
        {
            _values = new[] { value };
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
