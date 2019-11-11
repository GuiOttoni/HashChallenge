// Copyright 2015 gRPC authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using ServiceOneLib.Database;
using ServiceOneLib.Database.Interface;
using ServiceOneLib.IMPL;
using ServiceOneLib.IMPL.Interface;
using ServiceOneServer.IMPL;
using Sone;

namespace GreeterServer
{
    class Program
    {
        const int Port = 50051;
        private static readonly AutoResetEvent waitHandle = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ISqlDataContext, SqlDataContext>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IUserService, UserService>()
                .BuildServiceProvider();

            Server server = default;

                Task.Run(() =>
                {
                    server = new Server
                    {
                        //TODO: não consigo fazer automatico a injeção?
                        Services = { ServiceOne.BindService(new ServiceOneImpl(serviceProvider.GetService<IProductService>(), 
                        serviceProvider.GetService<IUserService>())) },
                        Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                    };
                    server.Start();

                    Console.WriteLine("Greeter server listening on port " + Port);
                    Console.WriteLine("Press ctrl+c to stop the server...");


                });

            // Handle Control+C or Control+Break
            Console.CancelKeyPress += (o, e) =>
            {
                Console.WriteLine("Exit");
                server.ShutdownAsync().Wait();
                // Allow the manin thread to continue and exit...
                waitHandle.Set();
            };

            waitHandle.WaitOne();
            Environment.Exit(0);
        }
    }
}
