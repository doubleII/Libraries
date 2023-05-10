using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace GlobalInstance
{
    public class SingleGlobalInstance : IDisposable
    {
        public bool _hasHandle = false;
        private Mutex _mutex;

        private void InitMutex()
        {
            Assembly newAss = Assembly.GetExecutingAssembly();

            string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
            string mutexId = $"Global\\{{{appGuid}}}";
            _mutex = new Mutex(false, mutexId);

            MutexAccessRule allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.FullControl, AccessControlType.Allow);
            MutexSecurity securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowEveryoneRule);
            // get user rights
            if (_mutex.WaitOne(TimeSpan.Zero, true))
            {
                Console.WriteLine("Current access rules:");
                foreach (MutexAccessRule accessRule in securitySettings.GetAccessRules(true, true, typeof(NTAccount)))
                {
                    Console.WriteLine($"User: {accessRule.IdentityReference}");
                    Console.WriteLine($"Type: {accessRule.AccessControlType}");
                    Console.WriteLine($"Rights: {accessRule.MutexRights}");
                }
            }
			
			            else
            {

                Trace.TraceInformation("Found anthoter instance!");
                Process[] tbPro = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);

                foreach (Process p in tbPro)
                {

                    if (p.Id != Process.GetCurrentProcess().Id)
                    {

                        Trace.TraceInformation(" -- REMOVED");
                        p.Kill();
                        break;
                    }
                }
            }

            _mutex.SetAccessControl(securitySettings);
        }

        public SingleGlobalInstance(int timeOut)
        {
            InitMutex();

            try
            {
                if (timeOut < 0)
                    _hasHandle = _mutex.WaitOne(Timeout.Infinite, false);
                else
                    _hasHandle = _mutex.WaitOne(timeOut, false);

                if (_hasHandle == false)
                    throw new TimeoutException("Timeout waiting for exclusive access on SingleInstance");
            }
            catch (AbandonedMutexException)
            {
                _hasHandle = true;
            }
        }

        public void Dispose()
        {
            if (_mutex != null)
            {
                if (_hasHandle)
                    _mutex.ReleaseMutex();
                _mutex.Close();
            }
        }
    }
}
