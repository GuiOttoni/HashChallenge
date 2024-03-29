# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
import grpc

import serviceTwo_pb2 as serviceTwo__pb2


class ServiceTwoStub(object):
  # missing associated documentation comment in .proto file
  pass

  def __init__(self, channel):
    """Constructor.

    Args:
      channel: A grpc.Channel.
    """
    self.GetProducts = channel.unary_unary(
        '/STwo.ServiceTwo/GetProducts',
        request_serializer=serviceTwo__pb2.ProductsRequest.SerializeToString,
        response_deserializer=serviceTwo__pb2.ProductsResponse.FromString,
        )


class ServiceTwoServicer(object):
  # missing associated documentation comment in .proto file
  pass

  def GetProducts(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')


def add_ServiceTwoServicer_to_server(servicer, server):
  rpc_method_handlers = {
      'GetProducts': grpc.unary_unary_rpc_method_handler(
          servicer.GetProducts,
          request_deserializer=serviceTwo__pb2.ProductsRequest.FromString,
          response_serializer=serviceTwo__pb2.ProductsResponse.SerializeToString,
      ),
  }
  generic_handler = grpc.method_handlers_generic_handler(
      'STwo.ServiceTwo', rpc_method_handlers)
  server.add_generic_rpc_handlers((generic_handler,))
