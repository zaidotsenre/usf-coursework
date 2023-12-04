# 1.Create a Vector
observations <- c(800.64, 217.53, 74.58, 498.6, 723.11, 69.43, 40.15, 58.61, 
                  364.63, 44.31, 216.41, 157.92, 1044.4, 82.3, 90.21, 59.09, 
                  361.38, 37.32, 311.34, 90.84, 580.64, 274.31, 215.06, 202.99)

# 2.Calculate standard error of the mean
sampleSize <- 24
sampleMeans <- replicate(10000, 
                      mean(sample(observations, sampleSize, replace = TRUE)), 
                      simplify =  TRUE)
stdError <- sd(sampleMeans)
stdError

# 3. use the standard error to calculate the 2.5% and 97.5% distribution 
# cut points.
cutPt250 <- mean(observations) - (2 * stdError)
cutPt975 <- mean(observations) + (2 * stdError)

cutPt250
cutPt975