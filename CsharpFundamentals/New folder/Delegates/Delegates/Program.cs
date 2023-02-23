using static Delegates.ChildClass;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegates in C#\n");

            ParentClass addObject = new ParentClass();

            // Create a delegate obj
            MyDelegateType customDelegate;

            // add reference method to delegate - create new obj from MyDelegateTpe class, and add method Add to it.    
            customDelegate = new MyDelegateType(addObject.Add);

            // Invoke method using delegate obj
            int sum = customDelegate.Invoke(50, 50);
            Console.WriteLine(sum);

        }
    }
}