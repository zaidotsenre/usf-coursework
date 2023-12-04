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
    for i in range (0, 128):
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
        if (tempscore > score):
            score = tempscore
            decoded = tempstr
          
    # return the string with the highest score
    return decoded

# Read hex strin from user and store as int
encoded = bytearray.fromhex (input ("Enter hex string -->"))

# Output decoded message
print ("Decrypted message: ", decrypt(encoded))
