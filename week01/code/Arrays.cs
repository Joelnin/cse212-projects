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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Function Characteristics Summary:
        // > MultiplesOf(n,m)
        // >> n: Base (number: double)
        // >> m: # multiples (length: integer) (m > 0)
        // >> Result: List of k values (k: double).

        // Implications for the function:

        // > First Ideas:
        // >> Create a list for the k values. Convert the list to an array.
        // >> Each k has to be a multiple of n. Thus k % n == 0.
        // >> The operation of adding to the list must stop after the value m*k is added or at List[i] with i = k - 1.
        // >> It has to calculate n % i with i > 0 (includes any natural number), then when n % i == 0, add the value to the list of k values.

        // > Second Ideas:
        // >> Create the array directly and this array must have length as the capacity.
        // >> Multiply m times n, so it can make a loop m times, for each multiple between the length. Add the k value of each iteration.

        // > Action plan:
        // >> Create an array with a capacity of length.
        // >> Create a loop that:
        // >>> Multiplies the "number" for an integer greater than 0, knowing that m = index + 1 (m = i + 1).
        // >>> Add this value (a double) to the array created. End of loop.
        // >> Return the array.

        double[] multiplesOfArray = new double[length]; // Creating the array for the multiples for the list of values.

        for (int i = 0; i < length; i++) // This loop with use the integer as a multiplier, going from m = 1 to m = length (knowing that i = m - 1). 
        {
            // double multiple[i] = number * (i + 1);

            multiplesOfArray[i] = number * (i + 1); // Multiply each value of m; m = i + 1). Add the value to the list of multiples.

        }

        return multiplesOfArray; // Return the array of multiples.
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Function Characteristics Summary:
        // > RotateListRight (List of d, n)
        // >> d: data (numbers in an specific order: List-int) 
        // >> n: Amount (number: double)
        // >> Result: List of d values (d: int).

        // Implications for the function:

        // > First Ideas:
        // >> Create 2 list, and then merge both in order.
        // >>> First list: List of "a" values.
        // >>> Second list: List of "b" values.
        // >>> Third list: Merge values.

        // > Second Ideas:
        // >> Copy after the amount.
        // >> Erase before de amount.
        // >> Add the values to the data list from the copied list.

        // > Action plan:
        // >> Create a list with the numbers after the amount (inclusive).
        // >> Creatre a list with the number before the amount (non-inclusive).
        // >> Create a list with both list.

        List<int> firstSectionList = new List<int>(data.GetRange(0, data.Count - amount));

        // List<int> secondSectionList = new List<int>(data.GetRange(0, amount));

        data.RemoveRange(0, data.Count - amount);

        foreach (int number in firstSectionList)
        {
            data.Add(number);
        }
    }
}
