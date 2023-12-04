# Written by Ernesto Diaz
# for CIS3213.700S18

# Function to decipher XOR'd hex strings
def decrypt(ciphertext):
    
    # Stores decoded message
    # "error" if failed to decode
    decoded = "error"
    
    # track current highest score
    score = 0
    
    # test all possible keys
    for i in range (0, 256):
        tempscore = 0
        tempstr = ''
        
        # build string with current key
        for l in range(0, len(ciphertext)):
            tempstr += chr(i ^ ciphertext[l])
            
        # score current sting using etaoin shrdlu
        etsh = "etaoinshrdlu"
        for j in range(0, len(etsh)):
            tempscore = tempscore + tempstr.count(etsh[j])

        # store this string if it beat the current score
        if (tempscore >= score):
            score = tempscore
            decoded = tempstr
          
    # return the string with the highest score
    return decoded, score

# read lines from file
f = open ("4.txt", "r")
lines = f.readlines()

# loop through all lines in file
# store the one with the higest score
hscore, message, index = 0, "", 0
for i in range(0, len(lines)):

    # Read hex line, turn to bytes
    encoded = bytearray.fromhex (lines[i].strip())

    # decode line
    tmessage, tscore = decrypt(encoded)
    
    if (tscore  >= hscore):
        hscore = tscore
        message = tmessage
        index = i
        
# output results
print ("The XOR'd line is ", index)
print ("Decrypted text: ", message)
