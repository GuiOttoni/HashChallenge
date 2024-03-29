# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: serviceTwo.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='serviceTwo.proto',
  package='STwo',
  syntax='proto3',
  serialized_options=_b('\n\016io.grpc.a.stwoB\004stwoP\001\242\002\004SWTO'),
  serialized_pb=_b('\n\x10serviceTwo.proto\x12\x04STwo\"!\n\x0fProductsRequest\x12\x0e\n\x06userId\x18\x01 \x01(\t\"7\n\x10ProductsResponse\x12#\n\x0clistProducts\x18\x01 \x03(\x0b\x32\r.STwo.Product\"s\n\x07Product\x12\n\n\x02Id\x18\x01 \x01(\t\x12\x16\n\x0eprice_in_cents\x18\x02 \x01(\x05\x12\r\n\x05title\x18\x03 \x01(\t\x12\x13\n\x0b\x64\x65scription\x18\x04 \x01(\t\x12 \n\x08\x64iscount\x18\x05 \x01(\x0b\x32\x0e.STwo.Discount\"/\n\x08\x44iscount\x12\x0b\n\x03pct\x18\x01 \x01(\x02\x12\x16\n\x0evalue_in_cents\x18\x02 \x01(\x05\x32L\n\nServiceTwo\x12>\n\x0bGetProducts\x12\x15.STwo.ProductsRequest\x1a\x16.STwo.ProductsResponse\"\x00\x42\x1f\n\x0eio.grpc.a.stwoB\x04stwoP\x01\xa2\x02\x04SWTOb\x06proto3')
)




_PRODUCTSREQUEST = _descriptor.Descriptor(
  name='ProductsRequest',
  full_name='STwo.ProductsRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='userId', full_name='STwo.ProductsRequest.userId', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=26,
  serialized_end=59,
)


_PRODUCTSRESPONSE = _descriptor.Descriptor(
  name='ProductsResponse',
  full_name='STwo.ProductsResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='listProducts', full_name='STwo.ProductsResponse.listProducts', index=0,
      number=1, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=61,
  serialized_end=116,
)


_PRODUCT = _descriptor.Descriptor(
  name='Product',
  full_name='STwo.Product',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='Id', full_name='STwo.Product.Id', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='price_in_cents', full_name='STwo.Product.price_in_cents', index=1,
      number=2, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='title', full_name='STwo.Product.title', index=2,
      number=3, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='description', full_name='STwo.Product.description', index=3,
      number=4, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='discount', full_name='STwo.Product.discount', index=4,
      number=5, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=118,
  serialized_end=233,
)


_DISCOUNT = _descriptor.Descriptor(
  name='Discount',
  full_name='STwo.Discount',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='pct', full_name='STwo.Discount.pct', index=0,
      number=1, type=2, cpp_type=6, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='value_in_cents', full_name='STwo.Discount.value_in_cents', index=1,
      number=2, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=235,
  serialized_end=282,
)

_PRODUCTSRESPONSE.fields_by_name['listProducts'].message_type = _PRODUCT
_PRODUCT.fields_by_name['discount'].message_type = _DISCOUNT
DESCRIPTOR.message_types_by_name['ProductsRequest'] = _PRODUCTSREQUEST
DESCRIPTOR.message_types_by_name['ProductsResponse'] = _PRODUCTSRESPONSE
DESCRIPTOR.message_types_by_name['Product'] = _PRODUCT
DESCRIPTOR.message_types_by_name['Discount'] = _DISCOUNT
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

ProductsRequest = _reflection.GeneratedProtocolMessageType('ProductsRequest', (_message.Message,), {
  'DESCRIPTOR' : _PRODUCTSREQUEST,
  '__module__' : 'serviceTwo_pb2'
  # @@protoc_insertion_point(class_scope:STwo.ProductsRequest)
  })
_sym_db.RegisterMessage(ProductsRequest)

ProductsResponse = _reflection.GeneratedProtocolMessageType('ProductsResponse', (_message.Message,), {
  'DESCRIPTOR' : _PRODUCTSRESPONSE,
  '__module__' : 'serviceTwo_pb2'
  # @@protoc_insertion_point(class_scope:STwo.ProductsResponse)
  })
_sym_db.RegisterMessage(ProductsResponse)

Product = _reflection.GeneratedProtocolMessageType('Product', (_message.Message,), {
  'DESCRIPTOR' : _PRODUCT,
  '__module__' : 'serviceTwo_pb2'
  # @@protoc_insertion_point(class_scope:STwo.Product)
  })
_sym_db.RegisterMessage(Product)

Discount = _reflection.GeneratedProtocolMessageType('Discount', (_message.Message,), {
  'DESCRIPTOR' : _DISCOUNT,
  '__module__' : 'serviceTwo_pb2'
  # @@protoc_insertion_point(class_scope:STwo.Discount)
  })
_sym_db.RegisterMessage(Discount)


DESCRIPTOR._options = None

_SERVICETWO = _descriptor.ServiceDescriptor(
  name='ServiceTwo',
  full_name='STwo.ServiceTwo',
  file=DESCRIPTOR,
  index=0,
  serialized_options=None,
  serialized_start=284,
  serialized_end=360,
  methods=[
  _descriptor.MethodDescriptor(
    name='GetProducts',
    full_name='STwo.ServiceTwo.GetProducts',
    index=0,
    containing_service=None,
    input_type=_PRODUCTSREQUEST,
    output_type=_PRODUCTSRESPONSE,
    serialized_options=None,
  ),
])
_sym_db.RegisterServiceDescriptor(_SERVICETWO)

DESCRIPTOR.services_by_name['ServiceTwo'] = _SERVICETWO

# @@protoc_insertion_point(module_scope)
