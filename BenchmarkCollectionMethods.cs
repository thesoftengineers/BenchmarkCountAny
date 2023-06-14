using System.Collections.ObjectModel;
using BenchmarkDotNet.Attributes;

namespace BenchmarkCountAny
{
    [MemoryDiagnoser]
    public class BenchmarkCollectionMethods
    {
        // Works the same for ICollection<T>, IList<T>, List<T>
        private Collection<Person> personCollection;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random();
            personCollection = new Collection<Person>();
            for (int i = 0; i < 1_000_000; i++)
            {
                personCollection.Add(new Person { Name = $"Person {i}", Age = random.Next(10, 100) });
            }
        }

        [Benchmark]
        public int CollectionCountMethod()
        {
            return personCollection.Count;
        }

        [Benchmark]
        public bool CollectionCountMethodGTZero()
        {
            return personCollection.Count > 0;
        }

        [Benchmark]
        public bool CollectionAnyMethod()
        {
            return personCollection.Any();
        }
    }
}
