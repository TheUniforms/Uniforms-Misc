#!/bin/bash

# build.sh -a   build all
# build.sh -n   build NuGet
# build.sh -c   build component
# build.sh -h   print help

BUILD_TOOL='/Applications/Xamarin Studio.app/Contents/MacOS/mdtool'
NUGET_TOOL=`which nuget`
PROJECT_BASE='Uniforms.Misc'
OUTPUT_DIR='lib'

build_nuget=false
build_all=false
build_component=false
need_help=false

#################
# Parse options #
#################

if [ -z "$1" ] ; then
   need_help=true
fi

# OPTIND=1 # Reset in case getopts has been used previously in the shell.

while getopts "h?anc" opt; do
    case "$opt" in
    h|\?)
        need_help=true
        ;;
    a)  build_all=true
        build_nuget=true
        build_component=true
        ;;
    c)  build_nuget=true
        build_component=true
        ;;
    n)  build_nuget=true
        ;;
    esac
done

shift $((OPTIND-1))

[ "$1" = "--" ] && shift

#############
# Show help #
#############

if [ "$need_help" = true ] ; then
    echo "build.sh -a   build all"
    echo "build.sh -n   build NuGet only"
    echo "build.sh -h   print help"
    exit 0
fi

##################
# Build solution #
##################

if [ "$build_all" = true ] ; then
    "$BUILD_TOOL" build -c:"Release"
fi

#############################
# Build NuGet and component #
#############################

if [ "$build_nuget" = true ] ; then
    mkdir -p $OUTPUT_DIR

    rm -v $OUTPUT_DIR/*.dll* $OUTPUT_DIR/*.nupkg

    cp -v $PROJECT_BASE.Droid/bin/Release/*.dll* $OUTPUT_DIR 2> /dev/null
    cp -v $PROJECT_BASE.iOS/bin/Release/*.dll* $OUTPUT_DIR 2> /dev/null
    cp -v $PROJECT_BASE/bin/Release/*.dll* $OUTPUT_DIR 2> /dev/null

    "$NUGET_TOOL" pack -OutputDirectory $OUTPUT_DIR

    echo "Use nuget tool to publish the package:"
    echo
    echo "    nuget push $OUTPUT_DIR/$PROJECT_BASE.*.nupkg"
    echo
fi
