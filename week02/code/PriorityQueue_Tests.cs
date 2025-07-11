using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items: "A" with priority 1, "B" with priority 5, and "C" with priority 5.
    // Then call Dequeue() three times.
    // Expected Result: B, C, A
    // Defect(s) Found:
    // - Dequeue() wasn't removing the item from the queue.
    // - The loop inside Dequeue() skipped index 0.
    // - The loop did not iterate through the entire list.
    // - The condition to find the highest priority would replace the current index
    //   even when priorities were equal, breaking FIFO order.
    public void TestPriorityQueue_RespectsPriorityAndFIFO()
    {
        string[] expectedResult = ["B", "C", "A"];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], item);
        }
    }

    [TestMethod]
    // Scenario: Try to get the next priority item from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
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
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }
}