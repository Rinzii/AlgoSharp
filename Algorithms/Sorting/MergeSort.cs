namespace Algorithms;

public static class MergeSort
{
    /// <summary>
    /// Sort a list of integers using the Merge Sort algorithm. 
    /// </summary>
    /// <param name="unsortedList"></param>
    /// <returns></returns>
    public static List<int> Sort(IList<int> unsortedList)
    {
        // Base case for algorithm
        if (unsortedList.Count <= 1)
            return unsortedList;
        
        var left = new List<int>();
        var right = new List<int>();

        // Divide and conquer 
        for (var i = 0; i < unsortedList.Count; i++)
        {
            if (i < (unsortedList.Count/2))
            {
                left.Add(unsortedList[i]);
            }
            else
            {
                right.Add(unsortedList[i]);
            }
        }

        left = Sort(left);
        right = Sort(right);

        return Merge(left, right);
    }

    private static IEnumerable<int> Merge(List<int> left, List<int> right)
    {

        var combined = new List<int>();
        var leftIndex = 0;
        var rightIndex = 0;

        // Keep looping till we have no more elements remaining
        while (left.Any() || right.Any())
        {
            if (left.Any() && right.Any())
            {
                // Compare our two lists
                if (left.First() <= right.First())  
                {
                    combined.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    combined.Add(right[rightIndex]);
                    rightIndex++;
                }
            }
            else if (left.Any()) // If we only have a left element
            {
                combined.Add(left[leftIndex]);
                leftIndex++;
            }
            else if (right.Any()) // if we only have a right element
            {
                combined.Add(right[rightIndex]);
                rightIndex++;
            }
        }
        return combined;
    }
    
    public static async Task<IEnumerable<int>> ParallelSort(IList<int> unsortedList)
    {
        // Base case for algorithm
        if (unsortedList.Count <= 1)
            return unsortedList;
        
        var left = new List<int>();
        var right = new List<int>();

        // Divide and conquer 
        for (var i = 0; i < unsortedList.Count; i++)
        {
            if (i < (unsortedList.Count/2))
            {
                left.Add(unsortedList[i]);
            }
            else
            {
                right.Add(unsortedList[i]);
            }
        }

        left = await ParallelSort(left) as List<int>;;
        right = await ParallelSort(right) as List<int>;;

        return await ParallelMerge(left, right);
    }

    private static Task<List<int>> ParallelMerge(ICollection<int> left, ICollection<int> right)
    {

        var combined = new List<int>();

        // Keep looping till we have no more elements remaining
        while (left.Any() || right.Any())
        {
            if (left.Any() && right.Any())
            {
                // Compare our two lists
                if (left.First() <= right.First())  
                {
                    combined.Add(left.First());
                    left.Remove(left.First());      
                }
                else
                {
                    combined.Add(right.First());
                    right.Remove(right.First());
                }
            }
            else if (left.Any()) // If we only have a left element
            {
                combined.Add(left.First());
                left.Remove(left.First());
            }
            else if (right.Any()) // if we only have a right element
            {
                combined.Add(right.First());
                right.Remove(right.First());
            }
        }
        return Task.FromResult(combined);
    }
}
