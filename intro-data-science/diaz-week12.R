library(RCurl)
## Loading required package: bitops
library(RJSONIO)
library(sqldf)
library(tidyverse)

fileURL <- "https://opendata.maryland.gov/resource/rqid-652u.json"
#fileURL <- "http://opendata.maryland.gov/resource/rqid-652u.json"

######### 1. investigate the url above.
######### 2. covert the JSON format dataset into R objects
mydata <- fromJSON(getURL(fileURL))
# look into the data summary
summary(mydata)

######### 3. what is the data type of "mydata" after reading the URL using the appropriate function.  
class(mydata)

######## 4. Print the number of rows below.
numRows <- NROW(mydata) 
numRows




# Step 2: Clean the data

unpack <- function(x, l) {
  x <- unlist(x)
  unname(x)
  length(x) <- l
  return(x)
}

#If you investigate mydata, you will find the length of each element is 
# different. We must make it consistent.
mydata2 <- mydata |> map(\(x) unpack(x,7)) |> unlist()
mydata2 <- matrix(mydata2, ncol = 7, byrow = TRUE)

#create a dataframe from it.
df1 <- data.frame(mydata2, stringsAsFactors = FALSE)


#change the name of each variables.with meaningful names 
nameList <- names(mydata[[1]])
nameList <- nameList[-5]
nameList <- append(nameList, names(mydata[[1]]$geoco), after = 4)
names(df1) <- nameList


#convert characters to the proper data formats (numeric or date format)
df1$date <- as.Date(df1$date)
df1$latitude <- as.numeric(df1$latitude)
df1$longitude <- as.numeric(df1$longitude)
df1$`:@computed_region_r4de_cuuv` <- as.numeric(df1$`:@computed_region_r4de_cuuv`)


#create day of week variable
df1$day_of_week <- weekdays(df1$date)


#The Maryland Open Data Portal documentation is not correct. 
#So, you have to print out all the unique values included in the accident_type 
# column and their frequency.    
############## Clean the data 
#4.1 Print out all the values and their frequencies here..
table(df1$accident_type)

#4.2 Merge the values so that the final values include only three categories: 
#######Property Damage (pd, PD, Property Damage Crash), 
# Personal Injury (PI and Injury Crash), and Fatal Crash (F)
iDmg <- which((df1$accident_type == "PD") | 
                (df1$accident_type == "pd") |
                (df1$accident_type == "Property Damage Crash"))
iInj <- which((df1$accident_type == "PI") | 
                (df1$accident_type == "Injury Crash") |
                (df1$accident_type == "IS"))
iFat <- which((df1$accident_type == "F"))

df1$accident_type[iDmg] <- "Property Damage"
df1$accident_type[iInj] <-"Personal Injury"
df1$accident_type[iFat] <-"Fatal Crash"


# Step 3: Understand the data using SQL (via SQLDF)
############## 5. how many accidents happen on Sunday?
# Use sql to count how many accidents on "Sunday"
sun_acc <- sqldf("select count(*) from df1 where day_of_week = 'Sunday'")
# Print the result
print(sun_acc)


############## 6. how many accidents had injuries? 
#Read the documentation from the Maryland Open Data portal.
#Use sql to count how many obersavations meet the criterion that accident 
# type is Injury Crash
inj_acc <- sqldf("select count(*) from df1 
                 where accident_type = 'Personal Injury'")
# Print the result
print(inj_acc)


# list the injuries by day
# count the number of injuries for each day of the week
list_inj <- sqldf("select day_of_week, count(*) from df1 
                  where accident_type = 'Personal Injury' group by day_of_week")

# Print the result
print(list_inj)

# Step 4: Understand the data using tapply
###########7.how many accidents happen on SUNDAY?
# tapply(Summary Variable, Group Variable, Function):
# apply the length function on the "Sunday" subset of the column day_of_week
sundays <- subset(df1, day_of_week == "Sunday")
length(sundays$accident_type)

# how many accidents had injuries
# apply the length function
injuries <- subset(df1, accident_type == "Personal Injury")
length(injuries$accident_type)

# list the injuries by day
# apply the length function on subset of the column accident_type 
# broken down by the value in Wday_of_week 
# and accident_type == "Injury Crash"
inj_by_day <- tapply(injuries$accident_type, injuries$day_of_week,  length)
inj_by_day

###########8: What is the percentage of injury for all accidents?
length(injuries$accident_type) / length(df1$accident_type) * 100

########## 9. Which day of a week do you observe the most injury?
inj_by_day[which.max(inj_by_day)]
