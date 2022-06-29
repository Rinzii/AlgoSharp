using Algorithms;

namespace AlgoSharp.UnitTests;

public class MergeSortTests
{
    [Fact]
    public void MergeSort_Sort_Testing_List_Actually_Sorts_Elements()
    {
        List<int> unsortedList = new List<int>() {6, 2, 7, 4, 9, 8, 5, 3, 1};
        List<int> sortedList = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
        List<int>? mergeSortedList = MergeSort.Sort(unsortedList) as List<int>;
        var parallelMergeSortedList = MergeSort.ParallelSort(unsortedList);
        
        Assert.NotEmpty(new[] {parallelMergeSortedList});

        
    }
}