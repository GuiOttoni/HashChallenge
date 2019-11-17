"""
Routes and views for the flask application.
"""

from datetime import datetime
from flask import render_template
from flask import jsonify
from ServiceTwoClient import app

import grpc
import serviceTwo_pb2
import serviceTwo_pb2_grpc


@app.route('/products')
def get_products():
  #return all products
  with grpc.insecure_channel('localhost:50051') as channel:
        stub = serviceTwo_pb2_grpc.ServiceTwoStub(channel)
        response = stub.Teste(serviceTwo_pb2.HelloRequest(name='you'))
  return jsonify(response.message)

@app.route('/products/<int:post_id>')
def show_post(post_id):
  #return product by iod
  return jsonify(id = post_id)