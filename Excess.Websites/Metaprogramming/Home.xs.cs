﻿#line 1 "C:\dev\Excess\Excess.Websites\metaprogramming\Home.xs"
using System;
using System.Collections.Generic;
using System.Linq;
using Middleware;
using System.Threading;
using System.Threading.Tasks;
using Excess.Concurrent.Runtime;

#line 4
namespace metaprogramming
#line 5
{
    [Service(id: "9abac447-8bfb-4ee1-b27a-6b40bc15cbc2")]
    [Concurrent(id = "fea753ec-3743-4baf-a550-fe7798e43fec")]
#line 6
    public class Home : ConcurrentObject
#line 7
    {
#line 8
        ITranspiler _transpiler;
        [Concurrent]
#line 10
        //constructor(ITranspiler transpiler)
        //{
        //	_transpiler = transpiler;
        //}   
        public string Transpile(string text)
        {
            return Transpile(text, default (CancellationToken)).Result;
        }

        private IEnumerable<Expression> __concurrentTranspile(string text, CancellationToken __cancellation, Action<object> __success, Action<Exception> __failure)
#line 11
        {
            {
                __dispatch("Transpile");
                if (__success != null)
#line 12
                    __success(_transpiler.Process(text));
                yield break;
            }
#line 13
        }

#line 10
        public Task<string> Transpile(string text, CancellationToken cancellation)
        {
            var completion = new TaskCompletionSource<string>();
            Action<object> __success = (__res) => completion.SetResult((string)__res);
            Action<Exception> __failure = (__ex) => completion.SetException(__ex);
            var __cancellation = cancellation;
            __enter(() => __advance(__concurrentTranspile(text, __cancellation, __success, __failure).GetEnumerator()), __failure);
            return completion.Task;
        }

        public void Transpile(string text, CancellationToken cancellation, Action<object> success, Action<Exception> failure)
        {
            var __success = success;
            var __failure = failure;
            var __cancellation = cancellation;
            __enter(() => __advance(__concurrentTranspile(text, __cancellation, __success, __failure).GetEnumerator()), failure);
        }

        public readonly Guid __ID = Guid.NewGuid();
#line 14
    }
#line 15
}