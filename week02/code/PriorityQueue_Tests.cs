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
    // Scenario: Enqueue 2 items with the same priority (2), and a third with another one.
    // Expected Result: The dequeue should be in the same order as they were enqueued for tim and Joe, bruce must be last. Ex: Tim, Joe, Bruce.
    // Defect(s) Found: After fixing the "Dequeue" funciton, it worked.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Tim", 2);
        priorityQueue.Enqueue("Bruce", 4);
        priorityQueue.Enqueue("Joe", 2);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();
        var third = priorityQueue.Dequeue();

        Assert.AreEqual("Tim", first);
        Assert.AreEqual("Joe", second);
        Assert.AreEqual("Bruce", third);

        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Queue is empty.
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: None.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
        
        // Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}