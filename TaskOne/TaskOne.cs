using System;

namespace InterviewTasks
{
    class TaskOne
    {
        public struct MyStruct
        {
            public int Id;
            public int Value;

            public override string ToString() => $"(id: {Id}, value: {Value})";
            public bool IsEmpty() => Id == 0 && Value == 0;
        }

        static void Main(string[] args)
        {
            var arrayOfPairs = new MyStruct[] {
                new MyStruct() {Id = 1, Value = 3},
                new MyStruct() {Id = 2, Value = 7},
                new MyStruct() {Id = 3, Value = 4},
                new MyStruct() {Id = 4, Value = 3},
                new MyStruct() {Id = 5, Value = 1}
            };
            var nextPair = GetNextValidPair(arrayOfPairs);

            if (nextPair.IsEmpty())
            {
                Console.WriteLine("The array does not meet the conditions of this task!");
            }
            else
            {
                Console.WriteLine("The result: " + nextPair.ToString());
            }
        }

        static MyStruct GetNextValidPair(MyStruct[] pairs)
        {
            if (pairs == null || pairs.Length == 0)
            {
                return new MyStruct();
            }
            // Check if array has values that appear at least twice
            var indexOfFirstDuplicateValue = -1;
            for (int i = 0; i < pairs.Length - 1; i++)
            {
                var duplicateFound = false;
                for (int j = i + 1; j < pairs.Length; j++)
                {
                    if (pairs[i].Value == pairs[j].Value)
                    {
                        indexOfFirstDuplicateValue = j;
                        duplicateFound = true;
                        break;
                    }
                }
                if (duplicateFound) break;
            }

            // if not, return empty
            if (indexOfFirstDuplicateValue == -1)
            {
                return new MyStruct();
            }

            var newPair = new MyStruct();

            var maxId = pairs[0].Id;
            for (var i = 1; i < pairs.Length; i++)
            {
                maxId = Math.Max(pairs[i].Id, maxId);
            }
            newPair.Id = maxId + 1;

            // start from first value that appears at least twice and find one larger number that isn't present in the list
            var newPairValue = pairs[indexOfFirstDuplicateValue].Value + 1;
            for (int i = newPairValue; ; i++)
            {
                var valueExists = false;
                for (int j = 0; j < pairs.Length; j++)
                {
                    if (newPairValue == pairs[j].Value)
                    {
                        valueExists = true;
                    }
                }
                if (!valueExists)
                {
                    newPair.Value = newPairValue;
                    return newPair;
                }
                else
                {
                    newPairValue++;
                }
            }
        }
    }
}