# 1. Install and activate (“library()”) the sqldf package in RStudio. 
library(sqldf)

# 2. Review online documentation for sqldf so that you are familiar with the 
# basic concepts and usage of the package and its commands.
# https://github.com/ggrothendieck/sqldf

# 3. (a) Make sure the built-in “airquality” dataset is available for use in 
# subsequent commands (hint: print head(airquality)). 
head(airquality)

# (b) assign airquality to an object “air” 
air <- airquality

# (c) what is the data type of air? You must use a simple command to reveal the data type.
class(air)

# 4. (a) Using sqldf(), run an SQL select command that calculates the average 
# level of ozone across all records. Assign the resulting value into a variable 
# (average_ozone)
average_ozone <- sqldf("select avg(ozone) from air")

# (b) print it out in the console.
average_ozone

# 5. Again using sqldf(), run another SQL command that selects all of the 
# records from air quality where the value of ozone is higher than the average. 
sqldf("select * from air where ozone > (select avg(ozone) from air)")

# 6. (a) Refine step 5 to write the result table into a new R 
# data object called “newAQ.” 
newAQ <- sqldf("select * from air where ozone > (select avg(ozone) from air)")

# (b) Then run a command to reveal what type of object newAQ is, 
class(newAQ)

# (c) another command to show what its dimensions are
dim(newAQ)

# (d) a head() command to show the first few rows.
head(newAQ)


# 7. Steps above was done using a SQL way. 
# Now, repeat steps 4, 5 and 6 in an R way, using R commands including 
# str, mean, head, dim, which, and tapply, which is a more “R” like way to do 
# the analysis ("a" through "g" below)).

# Repeat step 4: calculates the average level of ozone across all records.

#(a) Exclude Missing Values from calculating "Ozone" mean and assign the result 
# to "average_ozone": Hint:use na.rm
average_ozone <- mean(air$Ozone, na.rm = TRUE)

# (b) print the result (average_ozone)
average_ozone


# Repeat step 5

# (c) select rows with bigger values than the average ozone value
air[which(air$Ozone > average_ozone),]


# (d) Repeat step 6
# only keep the rows in which the Ozone values are higher than the average, 
# and write the result table into a new R data object called "newAQ2"
newAQ2 <- air[which(air$Ozone > average_ozone),]
rownames(newAQ2) <- NULL

# (e) reveal what type of object newAQ2 is
class(newAQ2)

# (f) reveal the number of rows, then reveal the number of columns
dim(newAQ2)

# (g) show the first few rows of "newAQ2"
head(newAQ2)