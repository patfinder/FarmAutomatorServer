
# Introduction

# Database Notes

# Data Structures

## Cattle
Lưu thông tin loại gia súc

## Task
Lưu loại công việc

## Feed
Lưu thông tin loại thuốc/thức ăn

# API Testing


curl docs: https://gist.github.com/subfuzion/08c5d85437d5d4f00e58

curl -d "userName=User%201&password=password" -X POST http://localhost:28205/auth/login
curl -c cookies.txt -d "userName=User%201&password=password" -X POST http://localhost:84/auth/login

http://localhost:84/auth/login?userName=User%201&password=password


curl -d "userName=User%201&password=password" -X POST http://localhost:84/auth/CheckLogin

curl -d "userName=User%201&password=password" -X GET http://localhost:84/auth/CheckAnonymous

## Data Controller

curl -b cookies.txt -X GET http://localhost:84/data/ActionData

