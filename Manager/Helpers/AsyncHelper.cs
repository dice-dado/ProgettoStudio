using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Helpers
{
    public static class AsyncHelper
    {
        public static void CallAsync<T>(Func<T> work, Action<T> callback, Action<Exception> excCallback)
        {
            var operation = AsyncOperationManager.CreateOperation(null);
            ThreadPool.QueueUserWorkItem((x) =>
            {
                try
                {
                    var result = work();   

                    operation.PostOperationCompleted((y) =>
                    {
                        callback(result);
                    }, null);
                }
                catch (Exception ex)
                {
                    operation.PostOperationCompleted((y) =>
                    {
                        excCallback(ex);
                    }, null);
                }
            });
        }


    }
}
