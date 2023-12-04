myCars <- mtcars
head(mtcars)
head(myCars)



#Step 1
i <- which.max(myCars$hp)

# 1) What is the highest hp? (The highest hp is 335)
print(paste("The highest hp is: ",  myCars$hp[i]))

# 2) Which car has the highest hp?
print(paste(rownames(myCars)[i], " has the highest hp."))



#Step 2
i <- which.max(myCars$mpg)

# 3) What is the highest mpg?
print(paste("The highest mpg is: ", myCars$mpg[i]))

# 4) Which car has the highest mpg? (Toyota Corolla has the highest mpg.)
print(paste(rownames(myCars)[i]," has the highest mpg."))

# 5) Create a sorted dataframe, based on mpg
# sort the dataframe by mpg, in descending order, and store the sorted dataframe in 'myCars_sorted' 
myCars_sorted <- myCars[order(myCars$mpg, decreasing = TRUE),]



#Step 3
# 6) One method to pick an efficient car: divide the mpg value by hp, and pick the car with highest result
# add a new column 'efficiency' in the dataframe to store the division result
myCars$efficiency <- myCars$mpg / myCars$hp
print(paste("The highest efficiency is: ", max(myCars$efficiency)))

# 7) Which car has the best combination of mpg and hp? 
# get the index of maximum efficiency first, and then get its row name
row.names(myCars)[which.max(myCars$efficiency)]



#Step 4

# scale 'mpg' by subtracting its column mean and then dividing the column standard deviation
#scale mpg first:
scale(myCars$mpg)

# scale 'hp' (scale is subtracting its column mean and then dividing its column’s standard deviation. But you just use scale function like this:)
scale(myCars$hp)

# You just created two new variable using mpg and hp using scale function. Add the two scaled data and save the result as a new column 'combination' in the dataframe. Populate XXXX below;
myCars$combination <-scale(myCars$mpg) + scale(myCars$hp)

# Get the index of maximum combination first, and then get its row name. HINT: use which.max function AND row.names function
row.names(myCars)[which.max(myCars$combination)]
