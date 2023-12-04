********************************************
*                                          *
*	CIS3213.700                        *
*	Spring 2018                        *
*	Group Project : RSA Implementation *
*	Team 27 Members:                   *
*		- Rebekah Pho              *
*		- Spencer Missbach         *
*		- Ernesto Diaz             *
*	                                   *
********************************************

*********************
**** Description ****
*********************
- This project is divided into two sections: RSA and Factor. 
- RSA contains four programs: CreateKey, Encrypt, and Decrypt which must be run in sequence, as they each use output from the previous program. 
- Factor contains only one program.
- These programs were developed and tested with UNIX-like systems in mind. Specifically the code provided here ran successfully on Mac OS and 

*********************
****     GMP     ****
********************* 
- All the programs in this project use the GNU Multi-precision library to handle big integers.
- GMP must be installed and linked at compilation time.
- Can be installed using apt
	- apt-get install libgmp-dev

*********************
****   GMP-ECM   ****
*********************
- The Factor program uses ECM, an extension of the GMP library that implements the Elliptic Curve method for factoring.
- ECM is provided in the factor_source folder, but must be installed prior to compiling.
- Installation instructions for ECM are provided inside the ecm-7.0.4 folder.(Basically, running a makefile)
- Can be installed using apt
	- apt-get install libecm-dev

*********************
****  Compiling  ****
*********************
- CreateKey: g++ -std=c++11 CreateKey.cpp -o CreateKey -lgmp -lgmpxx
- Encrypt:   g++ -std=c++11 Encrypt.cpp -o Encrypt -lgmp -lgmpxx
- Decrypt:   g++ -std=c++11 Decrypt.cpp -o Decrypt -lgmp -lgmpxx
- Factor:    g++ -std=c++11 Factor.cpp -o Factor -lecm -lgmp -lgmpxx