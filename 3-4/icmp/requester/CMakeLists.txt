cmake_minimum_required(VERSION 3.20)
project(network-telecom-3-4)

set(CMAKE_CXX_STANDARD 20)

add_executable(network-telecom-3-4-requester icmp_requester.cpp)
target_include_directories(network-telecom-3-4-requester PRIVATE ./)