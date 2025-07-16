using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with 4 diferent priorities: First, Second, Third and Last.
    // Expected Result: First, Second, Third, last.
    // Defect(s) Found: It took the highest number as priority, creating the list backwards. Fixed by fixing the "dequeue" function. Also, it didn't actually "removed" the item on dequeue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Last", 45);
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Third", 3);
        priorityQueue.Enqueue("Second", 2);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();
        var third = priorityQueue.Dequeue();
        var last = priorityQueue.Dequeue();


        Assert.AreEqual("First", first);
        Assert.AreEqual("Second", second);
        Assert.AreEqual("Third", third);
        Assert.AreEqual("Last", last);

        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Enqueue every person (3) with the same priority.
    // Expected Result: The dequeue should be in the same order as they were enqueued.
    // Defect(s) Found: After fixing the "Dequeue" funciton, it worked.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Tim", 4);
        priorityQueue.Enqueue("Bruce", 4);
        priorityQueue.Enqueue("Joe", 4);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();
        var third = priorityQueue.Dequeue();

        Assert.AreEqual("Tim", first);
        Assert.AreEqual("Bruce", second);
        Assert.AreEqual("Joe", third);

        // Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}