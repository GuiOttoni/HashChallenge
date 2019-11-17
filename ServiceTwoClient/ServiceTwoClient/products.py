"""
Routes and views for the flask application.
"""

from datetime import datetime
from flask import render_template
from flask import jsonify
from ServiceTwoClient import app
from google.protobuf.json_format import MessageToJson
from google.protobuf.json_format import MessageToDict

import grpc
import serviceTwo_pb2
import serviceTwo_pb2_grpc


@app.route('/products')
def get_products():
  #return all products
  with grpc.insecure_channel('localhost:50051') as channel:
        stub = serviceTwo_pb2_grpc.ServiceTwoStub(channel)
        response = stub.GetProducts(serviceTwo_pb2.ProductsRequest())
        response = MessageToDict(response, preserving_proto_field_name = True)
  return jsonify(list = response)

@app.route('/products/<int:post_id>')
def show_post(post_id):
  #return product by iod
  return jsonify(id = post_id)