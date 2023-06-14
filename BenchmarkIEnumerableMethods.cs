using BenchmarkDotNet.Attributes;

namespace BenchmarkCountAny
{
    [MemoryDiagnoser]
    public class BenchmarkIEnumerableMethods
    {
        private IEnumerable<Person> personEnumerable;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var personList = new List<Person>();
            var random = new Random();
            for (int i = 0; i < 1_000_000; i++)
            {
                personList.Add(new Person { Name = $"Person {i}", Age = random.Next(10, 100) });
            }
            personEnumerable = personList.AsEnumerable();
        }

        [Benchmark]
        public int EnumerableCountMethod()
        {
            return personEnumerable.Count();
        }

        [Benchmark]
        public bool EnumerableCountMethodGTZero()
        {
            return personEnumerable.Count() > 0;
        }

        [Benchmark]
        public bool EnumerableCountConvertingToList()
        {
            return personEnumerable.ToList().Count > 0;
        }

        [Benchmark]
        public bool EnumerableAnyMethod()
        {
            return personEnumerable.Any();
        }
    }
}
