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
using Sone;

namespace ServiceOneClient
{
    class Program
    {
        private static readonly AutoResetEvent waitHandle = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            Channel channel = default;
            Task.Run(() =>
            {
                Console.WriteLine("---------Connecting---------");
                channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

                var client = new ServiceOne.ServiceOneClient(channel);
                String id = Console.ReadLine();

                var reply = client.ProductDiscount(new ProductRequest { IdProduto = id });

                Console.WriteLine($"Greeting: {reply.IdProduto}, {reply.Title} ");
      
                Console.WriteLine("Press ctrl+c to exit...");

                // Handle Control+C or Control+Break
                Console.CancelKeyPress += (o, e) =>
                {
                    Console.WriteLine("Exit");
                    channel.ShutdownAsync().Wait();
                    // Allow the manin thread to continue and exit...
                    waitHandle.Set();
                };
            });

            // Wait
            waitHandle.WaitOne();

            Environment.Exit(0);
        }
    }
}
