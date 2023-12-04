setwd("C:/Users/lonihagen/Desktop/Intro.Data.Science") 

urlToRead <- "https://www2.census.gov/programs-surveys/popest/tables/2010-2011/state/totals/nst-est2011-01.csv"

testFrame <- read.csv(url(urlToRead))

#1 Display the first 6 rows of data, then display the structure of testFrame.
head(testFrame)

str(testFrame)

#2 Remove rows 1 to 8. Display the first six rows. Display a summary of columns 6 to 10.
testFrame <-testFrame[-1:-8,]
head(testFrame)

summary(testFrame[,6:10])

#3 Rebuild testFrame keeping only columns 1 to 5
testFrame <- testFrame[,1:5]

#4 Remove rows 52 to 58. Display the first 6 rows.
testFrame <-testFrame[-52:-58,]
head(testFrame)

#5 Create a column called stateName and assign the values of the first column to it. Display the first 6 rows.
testFrame$stateName <-testFrame[,1]
head(testFrame)

#6 Display the names of the columns in testFrame.
colnames(testFrame)

#7 Remove the first column from testFrame. Display the first 6 rows.
testFrame <-testFrame[,-1]
head(testFrame)

#8 Display the names of the columns. 
#  Assign column names to a variable called cnames. Display cnames.
#  Create a variable cnmaes2 and assign new column names to it. 
#  Replace testFrame column names with the values in cnames2
#  Display the first 6 rows.
colnames(testFrame)
cnames<-colnames(testFrame)
cnames

cnames2 <-c("Census", "Base", "Census2010", "Census2011","StateName")
colnames(testFrame) <-cnames2
head(testFrame)

#9 Remove the dot from the beginning of every State Name
#  Display the first 6 rows
testFrame$StateName <-gsub("\\.", '',testFrame$StateName)
head(testFrame)

#10 Remove commas from the values in the selected columns and convert the values to numeric types
#   Display testFrame
#   Reset row names so the count starts from 1
#   Display testFrame again
testFrame$Census <-as.numeric(gsub(",","",testFrame$Census))
testFrame$Base <-as.numeric(gsub(",","",testFrame$Base))
testFrame$Census2010 <-as.numeric(gsub(",","",testFrame$Census2010))
testFrame$Census2011 <-as.numeric(gsub(",","",testFrame$Census2011))

testFrame

#rownames
rownames(testFrame)<-NULL
testFrame

#move the last column to first
library(dplyr)
new_testFrame <-testFrame %>% select(StateName, everything())
