#!/bin/bash

clear
if [[ "app" == "$1" ]]
    then
        echo start programm in Debug folder "$1"
        path=`pwd`
        $path/bin/Debug/net8.0/app_1 
    else
        echo "Buid app_1"
        dotnet run app
fi