
#Midterm exam

#Question 2
printVecInfo <- function(x){
  cat("mean:", mean(x), "\n")
  cat("median:", median(x), "\n")
  cat("min:", min(x), "max:", max(x), "\n")
  cat("sd:", sd(x), "\n")
}

printVecInfo(c(1,2,3,4,5,6,7,8,9,10,50))



#Question 3
myFamilyName <- c("John", "Cate", "Troy", "Sonia")
myFamilyAge <- c(23, 12, 45, 43)
myFamily <- data.frame(myFamilyName, myFamilyAge)

myFamily


#Question 4
row.names(myCars_sorted)[which.max(myCars_sorted$mpg)]

#Question 5
jeff <-34
pat <-35
ages <-c(jeff, pat)
ages

jeff <-jeff - 5
jeff

ages[1]

#Question 6
?as.numeric
as.numeric(factor("4,779,736"))
?gsub

#Question 7
head(mtcars)

#Question 10
# create a numeric vector 'Pets'
Pets <- c(1,1,1,0,0)
# create a numeric vector 'Order'
Order <- c(3,1,2,3,3)
# create a numeric vector 'Siblings'
Siblings <- c(0,3,5,0,0)
# create a numeric vector 'IDs'
IDs <- c(1,2,3,4,5)
# comebine those four numeric vectors together into a dataframe called 'myFriends'
myFriends <- data.frame(IDs,Pets,Order,Siblings)
myFriends

myFriends$names <- c("jeff", "jen", "joe", "sunny", "jane")
myFriends

#Question 12
tail(myCars_sorted)

#Question 15
# create a numeric vector 'Pets'
Pets <- c(1,1,1,0,0)
# create a numeric vector 'Order'
Order <- c(3,1,2,3,3)
# create a numeric vector 'Siblings'
Siblings <- c(0,3,5,0,0)
# create a numeric vector 'IDs'
IDs <- c(1,2,3,4,5)
# comebine those four numeric vectors together into a dataframe called 'myFriends'
myFriends <- data.frame(IDs,Pets,Order,Siblings)
myFriends
myFriends[4, 2]

#Question 16
# The vector pioneers has already been created for you
pioneers <- c("GAUSS:1777", "BAYES:1702", "PASCAL:1623", "PEARSON:1857")
# Split names from birth year
split_math <- strsplit(pioneers, split = ":")
str(split_math)
