using System;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace MutexExample
{
    class Program
    {
        private static Mutex mutex;
        private static int sharedResource;

        static void Main(string[] args)
        {
            // Create a MutexSecurity object to specify the access rights for the mutex
            MutexSecurity mutexSecurity = new MutexSecurity();

            // give access to a mutex to all users
            mutexSecurity.SetAccessRule(
             new MutexAccessRule(
                 new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                 MutexRights.FullControl,
                 AccessControlType.Allow));

            // Create the mutex with the specified security
            mutex = new Mutex(false, "MyMutex", out bool createdNew, mutexSecurity);

            // Start a new process to run the same code
            Process.Start("ConsoleApp1.exe");

            // Wait for the other process to start
            Thread.Sleep(5000);

            // Update the shared resource
            for (int i = 0; i < 10; i++)
            {
                sharedResource++;

                // Print the final value of the shared resource
                Console.WriteLine(sharedResource);
            }

            // Wait for the other process to finish
            Thread.Sleep(5000);         
        }
    }
}