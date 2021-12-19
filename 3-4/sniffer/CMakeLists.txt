cmake_minimum_required(VERSION 3.20)
project(network-telecom-3-4-sniffer)

set(CMAKE_CXX_STANDARD 20)

add_executable(network-telecom-3-4-sniffer sniffer.cpp Socket.cpp Console.cpp)
target_include_directories(network-telecom-3-4-sniffer PRIVATE ./)