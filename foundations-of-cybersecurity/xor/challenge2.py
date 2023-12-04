# Written by Ernesto Diaz
# for CIS3213.700S18

# Decodes two hex buffers and performs XOR
def fixed_XOR(buf1, buf2):
    
    # Return XOR
    return buf1 ^ buf2

# Get buffers from the user
print ("Enter two equal-length hex buffers to perform XOR.")
val1 = int (input ("   hex #1 -->"), 16)
val2 = int (input ("   hex #2 -->"), 16)

# Take XOR
xored = fixed_XOR (val1, val2)

# Print the result
print ("\nOutput: ", hex  (xored))


