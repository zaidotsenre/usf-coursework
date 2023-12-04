# Write a code that generates normal distribution of 20 observations with a 
# Mean of 50 and standard deviation of 25, and present the result as a histogram
hist(rnorm(20, 50, 25))

# Create a histogram of a Pareto distribution with 51 random numbers 
# (shape is 10, and scale is 50).  
library(actuar)
hist(rpareto(51, 10, 50))