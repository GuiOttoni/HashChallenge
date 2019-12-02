# Copyright 2015 gRPC authors.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
"""The Python implementation of the GRPC helloworld.Greeter server."""

from concurrent import futures
import logging
import requests
import sys

import grpc
import pyodbc 

import serviceTwo_pb2
import serviceTwo_pb2_grpc

import sone_pb2
import sone_pb2_grpc

from google.protobuf.json_format import MessageToJson
from google.protobuf.json_format import MessageToDict


class ServiceTwo(serviceTwo_pb2_grpc.ServiceTwoServicer):

    def GetProducts(self, request, context):

        server = 'tcp:10.0.75.1' 
        database = 'Hash' 
        username = 'SA' 
        password = 'teste@123' 
        cnxn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER='+server+';DATABASE='+database+';UID='+username+';PWD='+ password)
        
        cursor = cnxn.cursor()

        # SQL Server format
        cursor.execute("exec [dbo].[Get_Products]")

        list = []

        for row in cursor:
            product = serviceTwo_pb2.Product()
            product.Id = row.Id
            product.price_in_cents = row.PriceInCents
            product.title = row.Title
            product.description = row.Description  
            product.discount.pct = 0
            product.discount.value_in_cents = 0

            try:
                with grpc.insecure_channel('172.18.0.1:5001') as channel:
                    stub = sone_pb2_grpc.ServiceOneStub(channel)
                    prequest = sone_pb2.ProductRequest()
                    prequest.ProductId = product.Id
                    prequest.UserId = request.userId
                    response = stub.ProductDiscount(prequest)
                    #response = MessageToDict(response, preserving_proto_field_name = True)
                    product.discount.pct = response.discount.pct
                    product.discount.value_in_cents = response.discount.value_in_cents
            except grpc.RpcError as e:
                print('ServiceOne failed with {0}: {1}'.format(e.code(), e.details()))
                print(e)
            except:
                print("Unexpected error:", sys.exc_info()[0])

            list.append(product)

        return serviceTwo_pb2.ProductsResponse(listProducts = list)


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    serviceTwo_pb2_grpc.add_ServiceTwoServicer_to_server(ServiceTwo(), server)
    server.add_insecure_port('[::]:50056')
    server.start()
    print("Start server")
    server.wait_for_termination()
    print("Server running...")


if __name__ == '__main__':
    logging.basicConfig()
    serve()
