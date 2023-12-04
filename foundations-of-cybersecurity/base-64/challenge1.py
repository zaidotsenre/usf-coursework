# Written by Ernesto Diaz
# for CIS3213.700S18

import codecs

# Get hex from the user and store as raw bytes
prompt = "Enter hex -->"
number = codecs.decode(input (prompt), 'hex')

# Encode raw bytes to base64
number = codecs.encode(number, 'base64')

# Print base64 number as a string
print ("\nBase 64: ", number.decode ())