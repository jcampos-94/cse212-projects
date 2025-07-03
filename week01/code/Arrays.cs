public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array to store the results. It should have 'length' number of elements.
        var results = new double[length];
        // Step 2: Loop from (i = 1) up to 'length' to calculate each multiple.
        for (int i = 1; i <= length; i++)
        {
            // Step 3: Multiply the current number (i) by the input 'number' to get the multiple.
            double multiple = i * number;
            // Step 4: Store the result in the array at the correct position (i - 1).
            results[i - 1] = multiple;
        }
        // Step 5: Return the array with all the calculated multiples.
        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Get the last 'amount' items and store them in a temporary list.
        int totalData = data.Count;
        List<int> removedItems = data.GetRange(totalData - amount, amount);
        // Step 2: Remove those items from the end of the original list.
        data.RemoveRange(totalData - amount, amount);
        // Step 3: Insert the stored items at the beginning of the original list (in the same order).
        data.InsertRange(0, removedItems);
    }
}
