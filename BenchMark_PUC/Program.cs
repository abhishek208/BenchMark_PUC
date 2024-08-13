// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


var summary = BenchmarkRunner.Run<MyBenchmark>();
Console.WriteLine("Starting Execution");


SomeClass x = new SomeClass();

// here we are using the sender to get the value and assigning to the receiver we can use multiple receiver if their is  single reciever than "=" can be used when we are usning multiple receiver to multicast then we have to use "+=".
x.sender += receiver1;
x.sender += receiver2;
x.sender += receiver3;
 // using Thread to create a therad that executes the huge task.
Thread v = new Thread(new ThreadStart(x.HugeTask));
v.Start();








 static void receiver1(int i)
{
    Console.WriteLine( $"receiver1-{i}");
}
static void receiver2(int i)
{
    Console.WriteLine($"receiver2-{i}");
}
static void receiver3(int i)
{
    Console.WriteLine($"receiver3-{i}");
}

public class SomeClass
{
    /// <summary>
    /// Delegate is a pointer  to a function or a callback used to comunnicate between threads.
    /// step 1 =>  we are creating a delegate usong delegate keyword  "Sender".
    /// step 2 =>  then creating and instance of the delegate .
    /// and then inside the forloop we are sending the value of i so each time the loops executed it broadcasts the value of i to the reciever's.
    /// </summary>
    /// <param name="i"></param>
    public delegate void Sender(int i);
    /// <summary>
    /// Event is used to encapsulate the Mass transit as without event the sender can be modified as null of the object can be manupilated .But after Using Event it doesnot allow null value  or sender can't be destroyed.
    /// </summary>
    public event Sender sender = null;

    public void HugeTask()
    {

        for (int i = 0; i <= 10000; i++)
        {
            Thread.Sleep(2000);
            sender(i); // broadcasting valueof i to the receiver's
        }
    }


}
public class MyBenchmark
{
    //used for doing benchmark testing
    [Benchmark]
    public void CalculatePrimes()
    {
        // Example of a CPU-bound task: calculating prime numbers
        int count = 0;
        for (int i = 2; i < 10000; i++)
        {
            if (IsPrime(i))
            {
                count++;
            }
        }
    }

    private bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}



