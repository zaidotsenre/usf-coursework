#The AND(&) operator compares two things
#if the two things are TRUE, the result of AND is TRUE
#if one (or both) of the things are FALSE, then AND results in FALSE
#for example the statement below returns TRUE 
#because 2 is greater than 1 AND 3 is greater than 2
2 > 1 & 3 > 2
#on the other hand, 2 is not greater than false, so AND results in FALSE
2 > 4 & 3 > 2
#needless to say, when both things are FALSE, the result is FALSE:
2 > 4 & 3 > 5



#The OR(|) operator works similarly to the AND operator
#but, OR only results in FALSE only when both of the things we compare are FALSE
#for example, the statement below results in TRUE because 3 is greater than 2:
2 > 4 | 3 > 2
#likewise, if both things are TRUE, OR results in TRUE:
2 > 1 | 3 > 2
#when neither thing is TRUE, the result is FALSE
2 > 4 | 3 > 5



#The NOT(!) operator gives us the opposite of something
#for example, the opposite of TRUE is FALSE:
!TRUE
#and the opposite of FALSE is TRUE
!FALSE


# show the use of an ‘if’ statement - that 1&1 is true
if(1 & 1) "TRUE" else "ERROR"



# Part 2
height <- c(59,60,61,58,67,72,70)
weight <- c(150,140,180,220,160,140,130)
a <- 150



#Step 1: Calculating means

#Compute, using R, the average height (called mean in R).
mean(height)
#Compute, using R, the average weight (called mean in R).
mean(weight)
#Calculate the length of the vector “height” and “weight.”
length(height)
length(weight)
#Calculate the sum of the heights.
sum(height)
sum(weight)
#Compute the average of both height and weight, 
#by dividing the sum (of the height or the width, as appropriate), 
#by the length of the vector. How does this compare to the “mean” function?
sum(height) / length(height)
sum(weight) / length(weight)



#Step 2: Using max/min functions

#Compute the max height, store the result in “maxH.”
maxH <- max(height)
#Compute the min weight, store the results in “minW.”
minW <- min(weight)



#Step 3: Vector math

#Create a new vector, which is the weight + 5 (every person gained 5 pounds).
inc_weight <- weight + 5

#Compute the weight/height (weight divided by height) for each person, using the new weight just created.
inc_weight/height




#Step 4: Using conditional if statements

#Write the R code to test if max height is greater than 60 (output “yes” or “no”).
if(maxH > 60) "yes" else "no"
#Write the R code to test if min weight is greater than the variable “a” (output “yes” or “no”).
if(minW > a) "yes" else "no"
