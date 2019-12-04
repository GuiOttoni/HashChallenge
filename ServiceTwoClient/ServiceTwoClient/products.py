"""
Routes and views for the flask application.
"""

from datetime import datetime
from flask import render_template
from flask import jsonify
from flask import request
from ServiceTwoClient import app
from google.protobuf.json_format import MessageToJson
from google.protobuf.json_format import MessageToDict

import grpc
import serviceTwo_pb2
import serviceTwo_pb2_grpc


@app.route('/products')
def get_products():
  userid = request.headers.get('X-USER-ID')
  #return all products
  with grpc.insecure_channel('servicetwoserver:50056') as channel:
        stub = serviceTwo_pb2_grpc.ServiceTwoStub(channel)
        response = stub.GetProducts(serviceTwo_pb2.ProductsRequest(userId = userid))
        response = MessageToDict(response, preserving_proto_field_name = True)
  return jsonify(response)

@app.route('/products/<int:post_id>')
def show_post(post_id):
  #return product by iod
  userid = request.headers.get('X-USER-ID')
  return jsonify(id = post_id, user = userid)