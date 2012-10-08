#! /usr/bin/env bash

###################################################
##
## dbouvier Feb 2007
##
## compare the content of two directories
## 
###################################################

# ----------------------------------------------------------------------------
## Activate debug mode
##
if [ "x${DBODEBUG}" != "x" ] ; then 
    set -xv ;
else
    set +xv ;
fi

# ----------------------------------------------------------------------------
#  Ecran d'aide
# ----------------------------------------------------------------------------
Usage() 
{
    echo "+----------------------------------------------------------------------------------+"
    echo "|                       compare.sh : compare tweo directories                      |"
    echo "|                                                                                  |"
    echo "| Option                Commentaire                                    Defaut      |"
    echo "|==================================================================================|"
    echo "|  -H    He;p : Print this screen and exit                               Off       |"
    echo "|  -E    Ext  : Look only for files having a certain extension           Off       |"
    echo "|  -D    Diff : Compare existing files and look for missing ones         Off       |"
    echo "|  -R1   Rep1 : Look for files only present in R1                        Off       |"
    echo "|  -R2   Rep2 : Look for files only present in R2                        Off       |"
    echo "|  -A    All  : D + R1 + R2                                              On        |"
    echo "|  -F    File : Generates diff files (potentialy dumps lots of files)    Off       |"
    echo "+----------------------------------------------------------------------------------+"
    return 0
}

# ----------------------------------------------------------------------------
#  Test des arguments
# ----------------------------------------------------------------------------
TestArg() {
while [ $# -ne 0 ]
do
 OPTION=$1

 case $OPTION in

  -h|-H)        
		Usage
                exit 0;;

  -ROOT)
		shift
		_ROOT=$1
		shift;;
  -E|EXT)
		shift
		_EXT_LST=$1
		shift;;

  -MOT)
		shift
		_MOT_LST=$1
		shift;;

  *)            echo "[ERROR] Pos: Mauvais parametre: '$OPTION'"
                Usage
                exit 1;;
 esac 
done
}

# ----------------------------------------------------------------------------
# Dir to be compared
# We extract absolute path to account deep levels of relative paths.
export _DIR1=$(cd $1 && pwd)
export _DIR2=$(cd $2 && pwd)

# Content of each dir
export _TMP_FILE="/tmp/diff.txt"
export _TMP_FILE1="/tmp/dir1.txt"
export _TMP_FILE2="/tmp/dir2.txt"

if [ "x${_EXT_LST}" = "x" ] ; then
	find $_DIR1 > $_TMP_FILE1
	find $_DIR2 > $_TMP_FILE2
else
	find $_DIR1 -name "*.${_EXT_LST}" > $_TMP_FILE1
	find $_DIR2 -name "*.${_EXT_LST}" > $_TMP_FILE2
fi

_sep="--------------------------------------------------------------------"
# ----------------------------------------------------------------------------
# Log
# ----------------------------------------------------------------------------
export _RAPPORT="./Diff.log"
echo ${_sep} > $_RAPPORT
echo "Compare $_DIR1 and $_DIR2" >> $_RAPPORT
echo ${_sep} >> $_RAPPORT
echo "" >> $_RAPPORT


# ----------------------------------------------------------------------------
# Check for files present in Dir1 but not in Dir2
# ----------------------------------------------------------------------------
echo "Files present ONLY in $_DIR1" >> $_RAPPORT
echo ${_sep} >> $_RAPPORT
for i in `cat $_TMP_FILE1`
do

  if [ -f $i ] ; then
      file=${i#$_DIR1/}
      filePath=`echo $i | sed -e 's|/|/|g'`

      # file is missing in Dir2
      if [ ! -f $_DIR2/$file ] ; then
	  echo "$filePath">> $_RAPPORT
      fi  
  fi
done
echo "" >> $_RAPPORT
echo "" >> $_RAPPORT

# ----------------------------------------------------------------------------
# Check for files present in Dir2 but not in Dir1
# ----------------------------------------------------------------------------
echo "Files present ONLY in $_DIR2" >> $_RAPPORT
echo ${_sep} >> $_RAPPORT
for i in `cat $_TMP_FILE2`
do

  if [ -f $i ] ; then
      file=${i#$_DIR2/}
      filePath=`echo $i | sed -e 's|/|/|g'`

      # file is missing in Dir1
      if [ ! -f $_DIR1/$file ] ; then
	  echo "$filePath">> $_RAPPORT
      fi  
  fi
done
echo "" >> $_RAPPORT
echo "" >> $_RAPPORT

# ----------------------------------------------------------------------------
# For each file in Dir 1 make a diff with the same file in Dir 2
# If the later does not exist, log it is missing
# ----------------------------------------------------------------------------
echo "Files different between $_DIR1 and $_DIR2" >> $_RAPPORT
echo ${_sep} >> $_RAPPORT
for i in `cat $_TMP_FILE1`
do

  if [ -f $i ] ; then
      file=${i#$_DIR1/}
      filePath=`echo $i | sed -e 's|/|/|g'`

      # file is present in both dirs, make a diff
      if [ -f $_DIR2/$file ] ; then
	  dif=`diff $_DIR1/$file $_DIR2/$file > ${_TMP_FILE}`

    # No need to perform sed if _TMP_FILE is zero length.
    if [ -s ${_TMP_FILE} ]; then
	      filePath=`echo $i | sed -e 's|/|/|g'`
	      #echo $i 
	      echo "$_DIR1/$file" >> $_RAPPORT
	      cp -p ${_TMP_FILE} ./diff.$filePath.txt
	  fi
      fi
  fi
done

###############################################################
printRep()
{
    cat $_RAPPORT
}




###############################################################
export _D1="N"

printRep
